// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.AppMagic.Authoring.Persistence
{
    public class PaletteJson
    {
        public string value { get; set; } // A formula
        public string name { get; set; }
        public string type { get; set; } // a PA type, usually "c" for color. 
        public string phoneValue { get; set; }
    }

    public class PropertyStyleJson
    {
        public string property { get; set; }
        public string value { get; set; } // Can use %% encoding. 
        public string phoneValue { get; set; }
    }

    public class StylesJson
    {
        public string name { get; set; }
        public string controlTemplateName { get; set; }
        // public string CStyle { get; set; }
        public PropertyStyleJson[] propertyValuesMap { get; set; }        
    }


    public class CustomThemeJson
    {
        public string name { get; set; }
        public PaletteJson[] palette { get; set; }
        public StylesJson[] styles { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; }
    }

    /// <summary>
    /// Schematic class for Themes.json
    /// </summary>
    public class ThemesJson
    {
        public string CurrentTheme { get; set; }
        public CustomThemeJson[] CustomThemes { get; set; }
    }
}
