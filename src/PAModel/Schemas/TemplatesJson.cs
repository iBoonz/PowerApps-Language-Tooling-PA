// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.PowerPlatform.Formulas.Tools.Schemas;

namespace Microsoft.AppMagic.Authoring.Persistence
{
    public class TemplatesJson
    {
        public class TemplateJson
        {
            /// <summary>
            /// Template Name, matches ControlInfoJson.Template.Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Template Version, matches ControlInfoJson.Template.version
            /// </summary>
            public string Version { get; set; }

            /// <summary>
            /// Stringified XML control template, from _oam.xml files in PowerApps Codebase
            /// </summary>
            public string Template { get; set; }
        }

        public TemplateJson[] UsedTemplates { get; set; }
        public TemplateMetadataJson[] ComponentTemplates { get; set; }
        public PcfTemplateJson[] PcfTemplates { get; set; }
    }
}
