﻿using System;
using Newtonsoft.Json.Serialization;

namespace Ts.IO.JsonSerialization{

    /// <summary>
    /// Binder for types in this assembly. If serializer settings
    /// enables type name handling, types in this assembly are handled
    /// without namespace and assembly prefix
    /// </summary>
    public class TableauJsonBinder : ISerializationBinder {

        public virtual Type BindToType(string assemblyName, string typeName) {

            var typesAssembly = typeof(Formula).Assembly;
            var typesNamespace = typeof(Formula).Namespace;
            return typesAssembly.GetType($"{typesNamespace}.{typeName}");
        }

        public virtual void BindToName(Type serializedType, out string assemblyName, out string typeName) {

            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}
