using Prospection.Models.Response;
using Prospection.Services.Handlers;

namespace Prospection.Api.ProspectionConfig.Funcionalities
{
    public class MailList
    {
        public static EventStatus Validate(string input)
        {
            EventStatus eventStatus = new EventStatus();
            eventStatus.ErrorCode = 1;
            eventStatus.Description = "ok";
            eventStatus.Message = SqlHandler.GetJson("select ServiceName Token from ProServices");
            return eventStatus;
        }
    }
}
