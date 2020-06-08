using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

            if (memberInfo.HasAttribute<EnumMemberAttribute>())
                return memberInfo.GetAttribute<EnumMemberAttribute>().Value;
            else
                return enumObj.ToString();
        }

        public static async Task<byte[]> ToBytes(this Stream stream)
        {
            using var memory = new MemoryStream();
            await stream.CopyToAsync(memory);
            memory.Position = 0;

            var bytes = new byte[(int)memory.Length];
            await memory.ReadAsync(bytes, 0, bytes.Length);

            return bytes;
        }

        public static async Task<string> ToText(this Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }

        public static async Task<FileInfo> ToFile(this Stream stream, string path)
        {
            using var file = File.Create(path);
            await stream.CopyToAsync(file);

            return new FileInfo(path);
        }

        public static async Task WriteText(this Stream stream, string value)
        {
            using var streamWriter = new StreamWriter(stream);
            await streamWriter.WriteAsync(value);
        }

        public static async Task WriteBytes(this Stream stream, byte[] data)
        {
            await stream.WriteAsync(data, 0,data.Length);
        }

        public static async Task<byte[]> ToBytes(this FileInfo fileInfo)
        {
            var path = fileInfo.FullName;

            using var file = File.OpenRead(path);
            return await file.ToBytes();
        }

        public static async Task<FileInfo> ToFile(this byte[] data, string path)
        {
            using var file = File.Create(path);
            await file.WriteAsync(data, 0, data.Length);

            return new FileInfo(path);
        }
    }
}