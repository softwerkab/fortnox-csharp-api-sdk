using System;
using System.IdentityModel.Tokens.Jwt;
using Fortnox.SDK.Authorization;

namespace Fortnox.SDK.Utility;

public static class Utils
{
    internal static string GetStringValue(object value, Type type)
    {
        if (value == null) return null;

        type = Nullable.GetUnderlyingType(type) ?? type; //unwrap nullable type

        if (type == typeof(string))
            return value.ToString();
        if (type.IsEnum)
            return ((Enum)value).GetStringValue();
        if (type == typeof(DateTime))
        {
            if (((DateTime)value).Date == (DateTime)value) //Date without hours/minutes/seconds..
                return ((DateTime)value).ToString(ApiConstants.DateFormat);

            return ((DateTime)value).ToString(ApiConstants.DateAndTimeFormat);
        }

        return value.ToString().ToLower();
    }

    public static JwtSecurityToken DecodeJwt(string jwtToken)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);

            return jsonToken as JwtSecurityToken;
        }
        catch(Exception ex)
        {
            throw new ArgumentException($"Failed to parse the token.", ex);
        }
    }
}