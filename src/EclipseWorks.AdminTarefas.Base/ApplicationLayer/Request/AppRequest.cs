using Flunt.Notifications;

namespace EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

public abstract class AppRequest : Notifiable<Notification>
{
    public required Guid? IdUsuario { get; init; }

    protected void ValidateBase(bool idUsuarioRequired = true)
    {
        if (idUsuarioRequired && IdUsuario.HasValue == false)
            throw new ArgumentException("IdUsuario não informado");

        if (IdUsuario.HasValue && IdUsuario.Value == Guid.Empty)
            throw new ArgumentException("IdUsuario inválido");
    }

    public abstract bool Validate();
}
