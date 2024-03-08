namespace EclipseWorks.AdminTarefas.Base.Helpers;

public static partial class Helpers
{
    public static DateTime UtcToBrasilia(this DateTime value)
    {
        return value.AddHours(-3);
    }

    public static string DateToYYYYMMDD(this DateTime value)
    {
        return value.ToString("yyyy-MM-dd");
    }
}
