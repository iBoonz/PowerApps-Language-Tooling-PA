// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Xml.Linq;

// Taken from Studio code, mostly unused right now
namespace Microsoft.PowerPlatform.Formulas.Tools.ControlTemplates
{
    public static class ControlMetadataXNames
    {
        public static readonly XNamespace ManifestNS = "http://openajax.org/metadata";
        // TASK:72028 - Revisit the use of appMagic in namespace
        public static readonly XNamespace AppMagicNS = "http://schemas.microsoft.com/appMagic";

        public static readonly XName WidgetTag = ManifestNS + "widget";
        public static readonly XName RequirementsTag = ManifestNS + "requires";
        public static readonly XName RequirementTag = ManifestNS + "require";
        public static readonly XName JavaScriptTag = ManifestNS + "javascript";
        public static readonly XName ContentTag = ManifestNS + "content";
        public static readonly XName EnumsTag = ManifestNS + "enums";
        public static readonly XName EnumTag = ManifestNS + "enum";
        public static readonly XName OptionsTag = ManifestNS + "options";
        public static readonly XName OptionTag = ManifestNS + "option";
        public static readonly XName LabelTag = ManifestNS + "label";
        public static readonly XName EnabledForFeatureGateTag = "enabledForFeatureGate";

        public static readonly XName PropertiesTag = ManifestNS + "properties";
        public static readonly XName PropertyTag = ManifestNS + "property";
        public static readonly XName NameAttribute = "name";
        public static readonly XName TypeAttribute = "type";
        public static readonly XName AppTypeAttribute = "appType";
        public static readonly XName DisplayNameAttribute = "displayName";
        public static readonly XName LocalizedNameAttribute = "localizedName";
        public static readonly XName TemplateAttribute = "template";
        public static readonly XName MetaDataIdAttribute = "metaDataId";
        public static readonly XName ParentMetaDataIdAttribute = "parentMetaDataId";
        public static readonly XName IsPrimaryControlAttribute = "isPrimaryControl";
        public static readonly XName DataSourceLocationAttribute = "dataSourceLocation";
        public static readonly XName VariantAttribute = "variant";
        public static readonly XName ContentTemplateNameAttribute = "contentTemplate";
        public static readonly XName DefaultStyleAttribute = "defaultStyle";
        public static readonly XName RestServiceConnectorIdAttribute = "restServiceConnectorId";
        public static readonly XName ScreenLayoutTypeAttribute = "screenLayoutType";
        public static readonly XName DataTypeAttribute = "datatype";
        public static readonly XName StrictAttribute = "strict";
        public static readonly XName PropertyMappingTypeAttribute = "mappingType";
        public static readonly XName DefaultValueAttribute = "defaultValue";
        public static readonly XName PhoneDefaultValueAttribute = "phoneDefaultValue";
        public static readonly XName WebDefaultValueAttribute = "webDefaultValue";
        public static readonly XName NestedDefaultValueAttribute = "nestedDefaultValue";
        public static readonly XName UnloadedDefaultAttribute = "unloadedDefault";
        public static readonly XName ComputeValueAttribute = "computeValue";
        public static readonly XName HiddenAttribute = "hidden";
        public static readonly XName StyleableAttribute = "styleable";
        public static readonly XName LocationAttribute = "location";
        public static readonly XName IdAttribute = "id";
        public static readonly XName VersionAttribute = "version";
        public static readonly XName ClassAttribute = "jsClass";
        public static readonly XName ValueAttribute = "value";
        public static readonly XName PhoneValueAttribute = "phoneValue";
        public static readonly XName WebValueAttribute = "webValue";
        public static readonly XName AppFromDataValueAttribute = "appFromDataValue";
        public static readonly XName MinimumAttribute = "minimum";
        public static readonly XName MaximumAttribute = "maximum";
        public static readonly XName InputAttribute = "input";
        public static readonly XName OutputAttribute = "output";
        public static readonly XName FilteredAttribute = "filtered";
        public static readonly XName SupportsEntityTypeAttribute = "supportsEntityType";
        public static readonly XName SupportedTypeAttribute = "supportedType";
        public static readonly XName SupportedFormatAttribute = "supportedFormat";
        public static readonly XName ModeAttribute = "mode";
        public static readonly XName CustomizableAttribute = "customizable";
        public static readonly XName IsFallbackForVariantSelectionAttribute = "isFallbackForVariantSelection";
        public static readonly XName IsDefaultRuleAttribute = "isdefaultRule";
        public static readonly XName DelegationCapabilityAttribute = "delegationCapability";
        public static readonly XName LayoutEnabledAttribute = "layoutEnabled";
        public static readonly XName SupportedOrientationAttribute = "supportedOrientation";
        public static readonly XName LayoutGroupIdAttribute = "layoutGroupId";
        public static readonly XName ApiNameAttribute = "apiName";
        public static readonly XName MetaDataIdMapKeyAttribute = "metaDataIdMapKey";
        public static readonly XName RuntimeCostAttribute = "runtimeCost";

        // Extensions to OpenAjax metadata
        public static readonly XName AutoBindTag = AppMagicNS + "autoBind";
        public static readonly XName NestedWidgets = AppMagicNS + "nestedWidgets";
        public static readonly XName DataControlWidgetTag = AppMagicNS + "dataControlWidget";
        public static readonly XName CategoryTag = AppMagicNS + "category";
        public static readonly XName DisplayNameTag = AppMagicNS + "displayName";
        public static readonly XName TooltipTag = AppMagicNS + "tooltip";
        public static readonly XName PropertyHelperUITag = AppMagicNS + "helperUI";
        public static readonly XName PassThroughTag = AppMagicNS + "passThroughReference";
        public static readonly XName NestedAwareTag = AppMagicNS + "nestedAware";
        public static readonly XName ReferencesNestedControlsTag = AppMagicNS + "referencesNestedControls";
        public static readonly XName ThisItemInputTag = AppMagicNS + "thisItemInput";
        public static readonly XName IncludePropertiesTag = AppMagicNS + "includeProperties";
        public static readonly XName IncludePropertyTag = AppMagicNS + "includeProperty";
        public static readonly XName CapabilitiesTag = AppMagicNS + "capabilities";
        public static readonly XName SampleDataSourceTag = AppMagicNS + "sampleDataSource";
        public static readonly XName ControlVariantsTag = AppMagicNS + "controlVariants";
        public static readonly XName ControlVariantTag = AppMagicNS + "controlVariant";
        public static readonly XName ContentTemplatesTag = AppMagicNS + "contentTemplates";
        public static readonly XName ContentTemplateTag = AppMagicNS + "contentTemplate";
        public static readonly XName ControlsTag = AppMagicNS + "controls";
        public static readonly XName ControlTag = AppMagicNS + "control";
        public static readonly XName DataSourcesTag = AppMagicNS + "datasources";
        public static readonly XName DataSourceTag = AppMagicNS + "datasource";
        public static readonly XName CompositionTag = AppMagicNS + "composition";
        public static readonly XName OverridePropertiesTag = AppMagicNS + "overrideProperties";
        public static readonly XName OverridePropertyTag = AppMagicNS + "overrideProperty";
        public static readonly XName RulesTag = AppMagicNS + "rules";
        public static readonly XName NestedWidgetRulesTag = AppMagicNS + "nestedWidgetRules";
        public static readonly XName NestedWidgetTemplateTag = AppMagicNS + "nestedWidgetTemplate";
        public static readonly XName RuleTag = AppMagicNS + "rule";
        public static readonly XName LayoutRulesTag = AppMagicNS + "layoutRules";
        public static readonly XName LayoutTag = AppMagicNS + "layout";
        public static readonly XName NameMapTag = AppMagicNS + "nameMap";
        public static readonly XName EntryTag = AppMagicNS + "entry";
        public static readonly XName DependenciesTag = AppMagicNS + "propertyDependencies";
        public static readonly XName DependencyTag = AppMagicNS + "propertyDependency";
        public static readonly XName LayoutBindingsTag = AppMagicNS + "layoutBindings";
        public static readonly XName AppMagicPropertyTag = AppMagicNS + "property";
        public static readonly XName ColumnNameReferenceTag = AppMagicNS + "columnNameReference";
        public static readonly XName DataSourceReferenceTag = AppMagicNS + "dataSourceReference";
        public static readonly XName DataSourcePropertyTag = AppMagicNS + "dataSourceProperty";
        public static readonly XName IncludeThisItemFormulaPropertyTag = AppMagicNS + "includeThisItemFormula";

        public static readonly XName RequirementsMetadataTag = AppMagicNS + "requirementsMetadata";
        public static readonly XName RequiredConditionsTag = AppMagicNS + "requiredConditions";
        public static readonly XName DisallowedConditionsTag = AppMagicNS + "disallowedConditions";
        public static readonly XName AppPreviewFlagConditionTag = AppMagicNS + "previewFlag";
        public static readonly XName UserFeatureFlagConditionTag = AppMagicNS + "userFlag";
        public static readonly XName FlagConditionNameAttribute = "name";
        public static readonly XName InsertMetadataTag = AppMagicNS + "insertMetadata";
        public static readonly XName InsertMetadataCategoryTag = AppMagicNS + "category";
        public static readonly XName InsertMetadataIsInPreviewAttribute = "isInPreview";
        public static readonly XName InsertMetadataIsPremiumAttribute = "isPremium";
        public static readonly XName InsertCategoryNameAttribute = "name";
        public static readonly XName InsertCategoryPriorityAttribute = "priority";
        public static readonly XName SupportedParentsTag = AppMagicNS + "supportedParents";
        public static readonly XName SupportedChildrenTag = AppMagicNS + "supportedChildren";
        public static readonly XName SupportedControlTag = AppMagicNS + "supportedControl";
        public static readonly XName SupportedControlNameAttribute = "name";
        public static readonly XName DisplayMetadataTag = AppMagicNS + "displayMetadata";
        public static readonly XName DisplayMetadataSectionTag = AppMagicNS + "section";
        public static readonly XName DisplayPropertyGroupTag = AppMagicNS + "propertyGroup";
        public static readonly XName DisplayPropertyGroupNameAttribute = "name";
        public static readonly XName DisplayPropertyTag = AppMagicNS + "property";
        public static readonly XName DisplayPropertyNameAttribute = "name";
        public static readonly XName DisplayPropertyLabelOverrideAttribute = "labelOverride";
        public static readonly XName DisplayPropertyItemsOrderAttribute = "itemsOrder";
        public static readonly XName DisplayPropertyHideInPropertyPanel = "hideInPropertyPanel";
        public static readonly XName DisplayPropertyShowOnlyInPropertyPanel = "showOnlyInPropertyPanel";
        public static readonly XName DisplayPropertyHideInRecordingMode = "hideInRecordingMode";
        public static readonly XName DisplayPropertyShouldAutoBind = "shouldAutoBind";
        public static readonly XName DisplayPropertyHasNamemapsAttribute = "hasNameMaps";
        public static readonly XName DisplayPropertyHasAdvancedNamemapsOnlyAttribute = "hasAdvancedNameMapsOnly";
        public static readonly XName DisplayPropertyDependentPropertiesAttribute = "dependentProperties";
        public static readonly XName DisplayWizardPropertyGroupTag = AppMagicNS + "wizardPropertyGroup";
        public static readonly XName DisplayDataSourceSelectionPropertyTag = AppMagicNS + "dataSourceSelectionCallout";
        public static readonly XName DisplayDataSourceSelectionPropertyDataSourceAttribute = "dataSourcePropertyName";
        public static readonly XName ServerProvidesValue = "serverProvidesValue";
        public static readonly XName WizardStepTag = AppMagicNS + "wizardStep";
        public static readonly XName DisplayServerPropertyTag = AppMagicNS + "serverProperty";
        public static readonly XName ConfigureCdsViewsTag = AppMagicNS + "configureCdsViews";
        public static readonly XName ConfigureCdsViewsPropertyToReplaceAttribute = "propertyToReplace";
        public static readonly XName ServerPropertyType = "type";
        public static readonly XName WizardStepLabelAttribute = "label";
        public static readonly XName WizardStepPanelTitleAttribute = "panelTitle";
        public static readonly XName WizardStepLinkedLocationAttribute = "linkedLocation";
        public static readonly XName ComputedValueTypeAttribute = "computedValueType";
        public static readonly XName DisplayTypeAttribute = "displayType";
        public static readonly XName WizardStepPropertyServerProvidesValue = "serverProvidesValue";
        public static readonly XName WizardStepPropertyDependentSteps = "dependentSteps";
        public static readonly XName ConfigureFieldsPropertyTag = AppMagicNS + "configureFields";
        public static readonly XName ConfigureFieldsDataSourcePropertyNameAttribute = "dataSourcePropertyName";
        public static readonly XName ConfigureFieldsSupportsCollectionAttribute = "supportsCollection";
        public static readonly XName addCustomFieldTypeAttribute = "addCustomFieldType";
        public static readonly XName fieldOrderingTypeAttribute = "fieldOrderingType";
        public static readonly XName ConfigureFieldsIsEditableAttribute = "isEditable";
        public static readonly XName ConfigureFieldsDisplayFormatAttribute = "displayFormat";
        public static readonly XName ConfigureFieldsGenerateFieldSelectionConfigAttribute = "generateFieldSelectionConfig";
        public static readonly XName ConfigureFieldsContentContainersAttribute = "contentContainers";
        public static readonly XName ConfigureFieldsUnsupportedFieldTypesAttribute = "unsupportedFieldTypes";
        public static readonly XName ConfigureFieldsVariantBuilder = "variantBuilder";
        public static readonly XName ConfigurePropertyTag = AppMagicNS + "configureProperty";
        public static readonly XName ConfigurePropertyRuleToSetAttribute = "ruleToSet";
        public static readonly XName PropertyInvariantNameAttribute = "propertyInvariantName";
        public static readonly XName FloatieDisplayTypeAttribute = "floatieDisplayType";
        public static readonly XName ShowInFloatieAttribute = "showInFloatie";

        public static readonly XName AuthoringClassAttribute = "authoringjsClass";
        public static readonly XName ConverterAttribute = "converter";
        public static readonly XName ModelValueConstrainerAttribute = "modelValueConstrainer";
        public static readonly XName NullDefaultAttribute = "nullDefault";
        public static readonly XName EditableAttribute = "editable";
        public static readonly XName IsExprAttribute = "isExpr";
        public static readonly XName IsLockableAttribute = "isLockable";
        public static readonly XName IsVersionFlexibleAttribute = "isVersionFlexible";
        public static readonly XName IsAppFromDataExprAttribute = "isAppFromDataExpr";
        public static readonly XName FormatAttribute = "format";
        public static readonly XName DirectionAttribute = "direction";
        public static readonly XName AuthoringOnlyAttribute = "authoringOnly";
        public static readonly XName IncludeOnFeatureGateAttribute = "includeOnFeatureGate";
        public static readonly XName ExcludeOnFeatureGateAttribute = "excludeOnFeatureGate";
        public static readonly XName PlatformAttribute = "platform";
        public static readonly XName NeedsStaticLoading = "needsStaticLoading";
        public static readonly XName HasEditableNameMapAttribute = "hasEditableNameMap";
        public static readonly XName AcceptsCoercedNullValues = "acceptsCoercedNullValues";
        public static readonly XName IsPrimaryInputPropertyAttribute = "isPrimaryInputProperty";
        public static readonly XName IndicatesActiveItemAttribute = "indicatesActiveItem";
        public static readonly XName IsPrimaryOutputPropertyAttribute = "isPrimaryOutputProperty";
        public static readonly XName IsPrimaryDescriptionPropertyAttribute = "isPrimaryDescriptionProperty";
        public static readonly XName IsSecondaryDescriptionPropertyAttribute = "isSecondaryDescriptionProperty";
        public static readonly XName IsPrimaryBehaviorPropertyAttribute = "isPrimaryBehaviorProperty";
        public static readonly XName IsSelectableFieldsPropertyPropertyAttribute = "isSelectableFieldsProperty";
        public static readonly XName IsSelectedFieldPropertyAttribute = "isSelectedFieldProperty";
        public static readonly XName SinkAttribute = "sink";
        public static readonly XName SourceAttribute = "source";
        public static readonly XName IsRecordingReadOnly = "isRecordingReadOnly";
        public static readonly XName PromptUserBeforeChanging = "promptUserBeforeChanging";
        public static readonly XName PromptUserTitle = "promptUserTitle";
        public static readonly XName PromptUserBody = "promptUserBody";
        public static readonly XName PromptUserOkButtonText = "promptUserOkButtonText";
        public static readonly XName PromptUserOnValue = "promptUserOnValue";
        public static readonly XName RequiresWriteableDataSource = "requiresWriteableDataSource";
        public static readonly XName RequiresRefreshableDataSource = "requiresRefreshableDataSource";
        public static readonly XName Conversion = AppMagicNS + "conversion";
        public static readonly XName ConversionAction = AppMagicNS + "conversionAction";
        public static readonly XName ConversionTypeAttribute = "type";
        public static readonly XName ConversionNameAttribute = "name";
        public static readonly XName ConversionFromAttribute = "from";
        public static readonly XName ConversionToAttribute = "to";
        public static readonly XName ConversionNewNameAttribute = "newName";
        public static readonly XName ConversionNewDocVersionAttribute = "newDocVersion";
        public static readonly XName CanBeCompressed = "canBeCompressed";

        // Control capabilities
        public static readonly XName SupportsNestedControlsAttribute = "supportsNestedControls";
        public static readonly XName AllowsNestedControlsWithoutUnlockingAttribute = "allowsNestedControlsWithoutUnlocking";
        public static readonly XName SupportsNestedComponentsAttribute = "supportsNestedComponents";
        public static readonly XName ReplicatesNestedControlsAttribute = "replicatesNestedControls";
        public static readonly XName PassThisItemThroughAttribute = "passThisItemThrough";
        public static readonly XName ContextualViewsEnabledAttribute = "contextualViewsEnabled";
        public static readonly XName AllowsPerCharacterFormattingAttribute = "allowsPerCharacterFormatting";
        public static readonly XName SupportsPagingAttribute = "supportsPaging";
        public static readonly XName IsTypeBoundToPrimaryInput = "isTypeBoundToPrimaryInput";
        public static readonly XName isTypeInferredFromPrimaryInput = "isTypeInferredFromPrimaryInput";
        public static readonly XName AutoBordersAttribute = "autoBorders";
        public static readonly XName AutoFocusedBordersAttribute = "autoFocusedBorders";
        public static readonly XName AutoBorderRadiusAttribute = "autoBorderRadius";
        public static readonly XName AutoFillAttribute = "autoFill";
        public static readonly XName AutoPointerViewStateAttribute = "autoPointerViewState";
        public static readonly XName AutoDisabledViewStateAttribute = "autoDisabledViewState";
        public static readonly XName OutlineIncompatibleAttribute = "outlineIncompatible";
        public static readonly XName IntangibleAttribute = "intangible";
        public static readonly XName AppGlobalAttribute = "appGlobal";
        public static readonly XName ViewContainerAttribute = "viewContainer";
        public static readonly XName AddPropertiesToParentAttribute = "addPropertiesToParent";
        public static readonly XName ScreenActiveAwareAttribute = "screenActiveAware";
        public static readonly XName SharedByMultipleControlsAttribute = "sharedByMultipleControls";
        public static readonly XName DefaultLayoutNameAttribute = "defaultLayoutName";
        public static readonly XName FieldSelectionFieldPropertyInvariantNameAttribute = "fieldSelectionFieldPropertyInvariantName";
        public static readonly XName FieldSelectionDisplayNamePropertyInvariantNameAttribute = "fieldSelectionDisplayNamePropertyInvariantName";
        public static readonly XName AggregatesChildLayouts = "aggregatesChildLayouts";
        public static readonly XName ChildrenShowAllProperties = "childrenShowAllProperties";
        public static readonly XName RequiresCameraAccess = "requiresCameraAccess";
        public static readonly XName RequiresMicrophoneAccess = "requiresMicrophoneAccess";
        public static readonly XName RequiresLocalStateAccess = "requiresLocalStateAccess";
        public static readonly XName RequiresInternetAccess = "requiresInternetAccess";
        public static readonly XName RequiresEnterpriseAuthentication = "requiresEnterpriseAuthentication";
        public static readonly XName RequiresPrivateNetworkAccess = "requiresPrivateNetworkAccess";
        public static readonly XName ReplicationLimitAttribute = "replicationLimit";
        public static readonly XName ManagesNestedControlBoundsAttribute = "managesNestedControlBounds";
        public static readonly XName AggregatesChildUpdatesAttribute = "aggregatesChildUpdates";
        public static readonly XName SubmitsDataAttribute = "submitsData";
        public static readonly XName SupportsAutomationAttribute = "supportsAutomation";
        public static readonly XName PromptUserBeforeChangingProperty = "promptUserBeforeChangingProperty";
        public static readonly XName PromptUserBeforeChangingPropertyValue = "promptUserBeforeChangingPropertyValue";
        public static readonly XName PromptUserBeforeChangingPropertyTitle = "promptUserBeforeChangingPropertyTitle";
        public static readonly XName PromptUserBeforeChangingPropertyBody = "promptUserBeforeChangingPropertyBody";
        public static readonly XName PromptUserBeforeChangingPropertyOkButtonText = "promptUserBeforeChangingPropertyOkButtonText";


        /// <summary>
        /// Whether `SetFocus` function in PowerApps language can be used on the control
        /// </summary>
        /// <remarks>
        /// The SetFocus function requests a control to focus itself.
        /// This capability does not indicate whether a control is tabbable
        /// or focusable through other means.
        /// </remarks>
        /// <see cref="Authoring.Texl:SetFocusFunction"/>
        public static readonly XName SupportsSetFocusAttribute = "supportsSetFocus";

        // AccessibilityCheck names
        public static readonly XName AccessibilityChecksTag = AppMagicNS + "accessibilityChecks";
        public static readonly XName AccessibilityCheckControlIsInteractive = "controlIsInteractive";
        public static readonly XName AccessibilityCheckTag = AppMagicNS + "accessibilityCheck";
        public static readonly XName AccessibilityCheckTypeAttribute = "type";
        public static readonly XName AccessibilityCheckInteractivityAttribute = "interactivity";
        public static readonly XName AccessibilityCheckLogicAttribute = "condition";
        public static readonly XName AccessibilityCheckPropertyAttribute = "property";
    }
}
