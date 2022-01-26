using System;
using System.ComponentModel;

public enum ButtonEnum
{
    F1_Help=1,
    F2_Search,
    F3_Compare,
    F4_Info,
    F5_Copy,
    F6_RenMov,
    F7_MkDir,
    F8_Delete,
    F9_DiskInfo,
    F10_Quit,
}

public enum MenuButton
{
    YES=1,
    NO
}

public enum Fkeys
{
    [Description("You wanna copy this file?")]
    F5,
    [Description("You wanna rename this file?")]
    F6,
    [Description("You wanna create new folder?")]
    F7,
    [Description("You wanna delete this file?")]
    F8
}
public static class EnumHelper
{
    public static string GetDescription<T>(this T enumValue)
        where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            return null;

        var description = enumValue.ToString();
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

        if (fieldInfo != null)
        {
            var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                description = ((DescriptionAttribute)attrs[0]).Description;
            }
        }

        return description;
    }
}