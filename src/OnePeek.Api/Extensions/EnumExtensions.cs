using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace OnePeek.Api.Extensions
{
  internal static class EnumExtensions
  {
    public static string GetEnumDisplayName(this Enum value)
    {
      TypeInfo typeInfo = value.GetType().GetTypeInfo();
      FieldInfo fieldInfo = typeInfo.GetDeclaredField(value.ToString());

      if (fieldInfo == null)
      {
        return null;
      }

      DisplayAttribute attribute = (DisplayAttribute)fieldInfo.GetCustomAttribute(typeof(DisplayAttribute), false);
      return attribute != null ? attribute.Name : null;
    }
  }
}
