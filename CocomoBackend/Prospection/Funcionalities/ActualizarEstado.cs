using Prospection.Models.Response;

namespace Prospection.Api.ProspectionConfig.Funcionalities
{
    public class ActualizarEstado
    {
        public static EventStatus Validate(string input)
        {
            EventStatus eventStatus = new EventStatus();
            eventStatus.ErrorCode = 1;
            eventStatus.Description = "ok";
            eventStatus.Message = "Estado actualizado correctamente.";
            return eventStatus;
        }
    }
}
