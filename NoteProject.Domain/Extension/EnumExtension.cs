using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace NoteProject.Domain.Extenstion;

    public static class EnumExtension

    {
    public static string GetDisplayName(this System.Enum enumValue)
    {
        return enumValue.GetType()
          .GetMember(name: enumValue.ToString())
          .First()
          .GetCustomAttribute<DisplayAttribute>()
      ?.GetName() ?? "Неопределеный";
    }
}