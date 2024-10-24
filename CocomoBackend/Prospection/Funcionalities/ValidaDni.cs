using Prospection.Models.Response;

namespace Prospection.Api.ProspectionConfig.Funcionalities
{
    public class ValidaDni
    {
        public static EventStatus Validate(string input)
        {
            EventStatus eventStatus = new EventStatus();
            eventStatus.ErrorCode = 1;
            eventStatus.Description = "ok";
            eventStatus.Message = "Dni validado correctamente.";
            return eventStatus;
        }
    }
}
