// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;


namespace Microsoft.PowerPlatform.Formulas.Tools
{
    // Helpers for creating chceksums. 
    public interface IHashMaker : IDisposable
    {
        void AppendStartObj();
        void AppendPropName(string name);
        void AppendEndObj();
        void AppendStartArray();
        void AppendEndArray();

        void AppendData(string value);
        void AppendData(double value);
        void AppendData(bool value);
        void AppendNull();

        // Called after all Appends(). 
        byte[] GetFinalValue();
    }

    // Create a checksum using an incremental hash.    
    class Sha256HashMaker : IHashMaker, IDisposable
    {
        private readonly IncrementalHash _hash;

        private static readonly byte[] _startObj = new byte[] { (byte)'{' };
        private static readonly byte[] _endObj = new byte[] { (byte)'}' };
        private static readonly byte[] _startArray = new byte[] { (byte)'[' };
        private static readonly byte[] _endArray = new byte[] { (byte)']' };
        private static readonly byte[] _null = new byte[] { 254 };
        private static readonly byte[] _true = new byte[] { 1 };
        private static readonly byte[] _false = new byte[] { 0 };

        private static readonly byte[] _marker = new byte[] { 255 };

        public Sha256HashMaker()
        {
            _hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
        }

        private void AppendMarker()
        {
            _hash.AppendData(_marker);
        }

        public void AppendData(double value)
        {
            var bytes = BitConverter.GetBytes(value);
            _hash.AppendData(bytes);
            AppendMarker();
        }

        public void AppendData(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            _hash.AppendData(bytes);
            AppendMarker();
        }

        public void AppendData(bool value)
        {
            var bytes = value ? _true : _false;
            _hash.AppendData(bytes);
            AppendMarker();
        }

        public void AppendPropName(string name)
        {
            this.AppendData(name);
            AppendMarker();
        }

        public void AppendStartObj()
        {
            _hash.AppendData(_startObj);
        }

        public void AppendEndObj()
        {
            _hash.AppendData(_endObj);
        }

        public void AppendStartArray()
        {
            _hash.AppendData(_startArray);
        }

        public void AppendEndArray()
        {
            _hash.AppendData(_endArray);
        }

        public void AppendNull()
        {
            _hash.AppendData(_null);
            AppendMarker();
        }

        public void Dispose()
        {
            _hash.Dispose();
        }

        public byte[] GetFinalValue()
        {
            var key = _hash.GetHashAndReset();
            return key;
        }
    }


    // A debug version of the checksum maker that captures the full raw normalized input.
    // If a checksum doesn't match, re-run it with this algorithm and you can see and diff the raw inputs. 
    class DebugTextHashMaker : IHashMaker
    {
        private readonly Utf8JsonWriter _writer;
        private readonly MemoryStream _buffer = new MemoryStream();
        private bool _wroteProperty;

        public DebugTextHashMaker()
        {
            JsonWriterOptions opts = new JsonWriterOptions
            {
                Indented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            _writer = new Utf8JsonWriter(_buffer, opts);
        }

        public void AppendData(string value)
        {
            _writer.WriteStringValue(value);
            _wroteProperty = false;
        }

        public void AppendData(double value)
        {
            _writer.WriteNumberValue(value);
            _wroteProperty = false;
        }

        public void AppendData(bool value)
        {
            _writer.WriteBooleanValue(value);
            _wroteProperty = false;
        }

        public void AppendEndArray()
        {
            _writer.WriteEndArray();
        }

        public void AppendEndObj()
        {
            if (_wroteProperty)
            {
                _writer.WriteNullValue();
            }
            _writer.WriteEndObject();
            _wroteProperty = false;
        }

        public void AppendNull()
        {
            _writer.WriteNullValue();
            _wroteProperty = false;
        }

        public void AppendPropName(string name)
        {
            if (_wroteProperty)
            {
                _writer.WriteNullValue();
            }
            _writer.WritePropertyName(name);
            _wroteProperty = true;
        }

        public void AppendStartArray()
        {
            _writer.WriteStartArray();
            _wroteProperty = false;
        }

        public void AppendStartObj()
        {
            _writer.WriteStartObject();
            _wroteProperty = false;
        }

        public void Dispose()
        {
            _writer.Dispose();
            _buffer.Dispose();
        }

        public byte[] GetFinalValue()
        {
            _writer.Flush();

            _buffer.Position = 0;
            var bytes = this._buffer.ToArray();
            return bytes;
        }
    }
}
