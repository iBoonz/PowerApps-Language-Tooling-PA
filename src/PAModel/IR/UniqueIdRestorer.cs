// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.PowerPlatform.Formulas.Tools.IR
{
    public class UniqueIdRestorer
    {
        private readonly Dictionary<string, int> _controlUniqueIds;
        private int _nextId;

        public UniqueIdRestorer(Entropy entropy)
        {
            _controlUniqueIds = entropy.ControlUniqueIds;
            _nextId = (_controlUniqueIds.Any() ? Math.Max(2, _controlUniqueIds.Values.Max()) : 2) + 1;
        }

        public int GetControlId(string controlName)
        {
            if (_controlUniqueIds.TryGetValue(controlName, out var id))
                return id;
            if (controlName == "App")
                return 1;
            var nextId = _nextId++;
            _controlUniqueIds.Add(controlName, nextId);
            return nextId;
        }
    }
}
