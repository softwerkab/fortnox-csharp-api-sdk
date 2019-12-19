using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FortnoxAPILibrary
{
	/// <remarks/>
	internal static class Extensions
	{
        public static bool HasAttribute<T>(this MemberInfo property) where T : Attribute
        {
            return property.GetCustomAttributes<T>().Any();
        }

        public static T GetAttribute<T>(this MemberInfo property) where T : Attribute
        {
            return property.GetCustomAttributes<T>().FirstOrDefault();
        }

        public static string GetStringValue(this Enum enumObj)
        {
            var type = enumObj.GetType();
            var memberInfo = type.GetMember(enumObj.ToString()).First();

            if (memberInfo.HasAttribute<StringValueAttribute>())
                return memberInfo.GetAttribute<StringValueAttribute>().RealValue;
            else
                return enumObj.ToString();
        }

        public static byte[] ToBytes(this Stream stream)
        {
            using var memory = new MemoryStream();
            stream.CopyTo(memory);

            return memory.ToArray();
        }

        public static string ToText(this Stream stream)
        {
            return Encoding.UTF8.GetString(stream.ToBytes());
        }

        public static FileInfo ToFile(this Stream stream, string path)
        {
            using var file = File.Create(path);
            stream.CopyTo(file);

            return new FileInfo(path);
        }

        public static void WriteText(this Stream stream, string value)
        {
            using var streamWriter = new StreamWriter(stream);
            streamWriter.Write(value);
        }
    }
}