using System;
using System.Linq;
using System.Reflection;

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
    }
}