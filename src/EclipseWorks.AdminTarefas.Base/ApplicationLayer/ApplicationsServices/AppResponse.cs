using Flunt.Notifications;

namespace EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;

public sealed class AppResponse<TAppResponse>
{
    public AppResponse(TAppResponse data)
    {
        Success = true;
        Data = data;
        Notifications = null;
    }

    public AppResponse(IReadOnlyCollection<Notification> notifications)
    {
        Success = false;
        Notifications = notifications;
    }

    public AppResponse(Notification notifications)
    {
        Success = false;
        Notifications = [notifications];
    }

    public bool Success { get; set; }
    public TAppResponse Data { get; set; }
    public IReadOnlyCollection<Notification> Notifications { get; set; }
}

