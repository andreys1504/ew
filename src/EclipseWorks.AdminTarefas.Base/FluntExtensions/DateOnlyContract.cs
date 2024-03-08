using Flunt.Validations;

namespace EclipseWorks.AdminTarefas.Base.FluntExtensions;

public static class DateOnlyContract
{
    public static Contract<T> IsDateOnlyValid<T>(
        this Contract<T> contract,
        DateOnly val,
        string key,
        string message)
    {
        contract.AreNotEquals(val, DateOnly.MinValue, key, message);
        contract.AreNotEquals(val, DateOnly.MaxValue, key, message);

        return contract;
    }
}
