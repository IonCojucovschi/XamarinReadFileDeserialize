using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OefOpentTestFiles.Util
{
    public class DeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            var assembly = Assembly.GetExecutingAssembly().FullName;

            var type = Type.GetType(assemblyName.Contains("Shared") ? $"{typeName}, {assembly}" : $"{typeName}, {assemblyName}");

            return type;
        }
    }
}