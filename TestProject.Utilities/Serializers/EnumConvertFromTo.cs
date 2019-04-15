
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TestProject.Common.Core.Classes.Utilities.Serializers
{
    /// <summary>
    /// Set of types you may Serialize/Deserialize
    /// by these serializers.
    /// </summary>
    public enum ConvertFromTo
    {
        Binary,
        JSON,
        XML
    }
}
