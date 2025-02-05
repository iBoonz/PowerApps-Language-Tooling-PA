// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.PowerPlatform.Formulas.Tools.MergeTool.Deltas
{
    public class AddDataSource : IDelta
    {
        public string Name;
        public List<DataSourceEntry> Contents;

        public void Apply(CanvasDocument document)
        {
            if (document._dataSources.ContainsKey(Name))
                return;

            document._dataSources.Add(Name, Contents);
        }
    }
    public class RemoveDataSource : IDelta
    {
        public string Name;

        public void Apply(CanvasDocument document)
        {
            if (!document._dataSources.ContainsKey(Name))
                return;

            document._dataSources.Remove(Name);
        }
    }
}
