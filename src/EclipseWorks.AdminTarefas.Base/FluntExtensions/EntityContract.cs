using Flunt.Validations;

namespace EclipseWorks.AdminTarefas.Base.FluntExtensions;

public static class EntityContract
{
    public static Contract<T> IsGuid<T>(
        this Contract<T> contract,
        Guid val,
        string key,
        string message)
    {
        if (val == Guid.Empty)
            contract.AddNotification(key, message);


        return contract;
    }
}
