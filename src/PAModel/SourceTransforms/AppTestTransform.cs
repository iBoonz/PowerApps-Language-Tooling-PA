// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.PowerPlatform.Formulas.Tools.EditorState;
using Microsoft.PowerPlatform.Formulas.Tools.IR;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.PowerPlatform.Formulas.Tools.SourceTransforms
{
    public class AppTestTransform : IControlTemplateTransform
    {
        private class TestStepsMetadataJson
        {
            public string Description { get; set; }
            public string Rule { get; set; }
            public string ScreenId { get; set; } = null;
        }

        private static readonly IEnumerable<string> _targets = new List<string>() { "TestCase" };
        public IEnumerable<string> TargetTemplates => _targets;

        private const string _metadataPropName = "TestStepsMetadata";
        private string _testStepTemplateName;

        // Key is UniqueId, Value is ScreenName
        private IList<KeyValuePair<string, string>> _screenIdToScreenName;
        private ErrorContainer _errors;

        // To hold entropy passed in by constructor
        private Entropy _entropy;

        public static bool IsTestSuite(string templateName)
        {
            return templateName == "TestSuite";
        }

        public AppTestTransform(CanvasDocument app, ErrorContainer errors, TemplateStore templateStore, EditorStateStore stateStore, Entropy entropy)
        {
            _testStepTemplateName = "TestStep";

            int i = 1;
            while (templateStore.TryGetTemplate(_testStepTemplateName, out _))
                _testStepTemplateName = "TestStep" + i;

            _screenIdToScreenName = app._screens
                .Select(screen => new KeyValuePair<string, string>(app._idRestorer.GetControlId(screen.Key).ToString(), screen.Key)).ToList();

            _entropy = entropy;
            _errors = errors;
        }

        public void AfterRead(BlockNode control)
        {
            var properties = control.Properties.ToDictionary(prop => prop.Identifier);
            if (!properties.TryGetValue(_metadataPropName, out var metadataProperty))
            {
                // If no metadata props, TestStepsMetadata nonexistent
                _entropy.DoesTestStepsMetadataExist = false;

                // If the test studio is opened, but no tests are created, it's possible for a test case to exist without any
                // steps or teststepmetadata. In that case, write only the base properties.
                if (properties.Count == 2)
                    return;

                _errors.ValidationError($"Unable to find TestStepsMetadata property for TestCase {control.Name.Identifier}");
                throw new DocumentException();
            }
            else{
                _entropy.DoesTestStepsMetadataExist = true;
            }
            properties.Remove(_metadataPropName);
            var metadataJsonString = Utilities.UnEscapePAString(metadataProperty.Expression.Expression);
            var testStepsMetadata = JsonSerializer.Deserialize<List<TestStepsMetadataJson>>(metadataJsonString);
            var newChildren = new List<BlockNode>();

            foreach (var testStep in testStepsMetadata)
            {
                if (!properties.TryGetValue(testStep.Rule, out var testStepProp))
                {
                    _errors.ValidationError($"Unable to find corresponding property for test step {testStep.Rule} in {control.Name.Identifier}");
                    throw new DocumentException();
                }

                var childProperties = new List<PropertyNode>()
                    {
                        new PropertyNode()
                        {
                            Identifier = "Description",
                            Expression = new ExpressionNode()
                            {
                                Expression = Utilities.EscapePAString(testStep.Description)
                            }
                        },
                        new PropertyNode()
                        {
                            Identifier = "Value",
                            Expression = testStepProp.Expression
                        }
                    };

                if (testStep.ScreenId != null)
                {
                    if (!_screenIdToScreenName.ToDictionary(kvp => kvp.Key, kvp => kvp.Value).TryGetValue(testStep.ScreenId, out var screenName))
                    {
                        _errors.ValidationWarning($"ScreenId referenced by TestStep {testStep.Rule} in {control.Name.Identifier} could not be found");
                        var testStepRuleKey = $"{control.Name.Identifier}.{testStep.Rule}";

                        // checking if this key already exist, not an ideal situation
                        // Fallback logic just to make sure collisions are avoided.
                        if (_entropy.RuleScreenIdWithoutScreen.ContainsKey(testStepRuleKey))
                        {
                            _errors.GenericError($"RuleScreenIdWithoutScreen has a duplicate key {testStepRuleKey}");
                        }

                        _entropy.RuleScreenIdWithoutScreen.Add(testStepRuleKey, testStep.ScreenId);
                    }

                    childProperties.Add(new PropertyNode()
                    {
                        Identifier = "Screen",
                        Expression = new ExpressionNode()
                        {
                            Expression = screenName ?? null
                        }
                    });
                }

                var testStepControl = new BlockNode()
                {
                    Name = new TypedNameNode()
                    {
                        Identifier = testStep.Rule,
                        Kind = new TypeNode() { TypeName = _testStepTemplateName }
                    },
                    Properties = childProperties
                };

                properties.Remove(testStep.Rule);
                newChildren.Add(testStepControl);
            }
            control.Properties = properties.Values.ToList();
            control.Children = newChildren;
        }

        public void BeforeWrite(BlockNode control)
        {
            var testStepsMetadata = new List<TestStepsMetadataJson>();
            bool doesTestStepsMetadataExist = _entropy.DoesTestStepsMetadataExist ?? true;

            foreach (var child in control.Children)
            {
                var propName = child.Name.Identifier;
                
                if (child.Name.Kind.TypeName != _testStepTemplateName)
                {
                    _errors.ValidationError($"Only controls of type {_testStepTemplateName} are valid children of a TestCase");
                    throw new DocumentException();
                }

                if (child.Properties.Count > 3)
                {
                    _errors.ValidationWarning($"Test Step {propName} has unexpected properties");
                }

                var descriptionProp = child.Properties.FirstOrDefault(prop => prop.Identifier == "Description");
                
                if (descriptionProp == null)
                {
                    _errors.ValidationError($"Test Step {propName} is missing a Description property");
                    throw new DocumentException();
                }
                
                var valueProp = child.Properties.FirstOrDefault(prop => prop.Identifier == "Value");
                
                if (valueProp == null)
                {
                    _errors.ValidationError($"Test Step {propName} is missing a Value property");
                    throw new DocumentException();
                }
                
                var screenProp = child.Properties.FirstOrDefault(prop => prop.Identifier == "Screen");

                string screenId = null;
                
                // Lookup screenID by Name
                if (screenProp != null)
                {
                    foreach (var prop in _screenIdToScreenName)
                    {
                        if (prop.Value != null && prop.Value == screenProp.Expression.Expression)
                        {
                            screenId = prop.Key;
                        }
                    }

                    // in roundtrip scenario screenId could be null
                    if (screenId == null)
                    {
                        _errors.ValidationWarning($"Test Step {propName} references screen {screenProp.Expression.Expression} that is not present in the app");
                        var testStepRuleKey = $"{control.Name.Identifier}.{propName}";
                        if (_entropy.RuleScreenIdWithoutScreen.TryGetValue(testStepRuleKey, out var screenIdReference))
                        {
                            screenId = screenIdReference;
                            _entropy.RuleScreenIdWithoutScreen.Remove(testStepRuleKey);
                        }
                    }
                }                

                if (doesTestStepsMetadataExist)
                {

                    testStepsMetadata.Add(new TestStepsMetadataJson()
                    {
                        Description = Utilities.UnEscapePAString(descriptionProp.Expression.Expression),
                        Rule = propName,
                        ScreenId = screenId
                    });

                    control.Properties.Add(new PropertyNode()
                    {
                        Expression = valueProp.Expression,
                        Identifier = propName
                    });

                }
            }
            
            if (doesTestStepsMetadataExist)
            {
                var testStepMetadataStr = JsonSerializer.Serialize<List<TestStepsMetadataJson>>(testStepsMetadata, new JsonSerializerOptions() {Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
                control.Properties.Add(new PropertyNode()
                {
                    Expression = new ExpressionNode() { Expression = Utilities.EscapePAString(testStepMetadataStr) },
                    Identifier = _metadataPropName
                });
            }
                control.Children = new List<BlockNode>();
        }
    }
}
