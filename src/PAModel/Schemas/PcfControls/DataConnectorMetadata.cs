using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Microsoft.PowerPlatform.Formulas.Tools.Schemas.PcfControl
{
    public struct DataConnectorMetadata
    {
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; }
    }
}
