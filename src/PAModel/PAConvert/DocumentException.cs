// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;

namespace Microsoft.PowerPlatform.Formulas.Tools
{
    // public exception to throw on fatal error to stop document load.
    // Caller should have added an error to the error container first.
    // These should be caught internally. 
    public class DocumentException : Exception
    {
    }
}
