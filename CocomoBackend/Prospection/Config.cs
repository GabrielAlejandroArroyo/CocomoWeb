using Newtonsoft.Json.Linq;
using Prospection.Api.ProspectionConfig.Funcionalities;
using Prospection.Backend.Lib.Handlers;
using Prospection.Models.Bpm;
using Prospection.Models.DTO;
using Prospection.Models.Response;
using Prospection.Repositories.v1;
using Prospection.Services.Handlers;
using Prospection.Services.Repositories.v1;
using Prospection.Services.Services.v1;
using Prospection.Services.v1;

namespace ProspectionConfig
{
    public class Config
    {
        public static void ConfigureRoutes(WebApplication app)
        {

            List<MagicConfig> flowConfig = MagicService.GetWorkflowByName();

            for (int i = 0; i < flowConfig.Count; i++)
            {
                string method = flowConfig[i].method;
                string query = flowConfig[i].query;
                string condition = flowConfig[i].condicion;

                if (!string.IsNullOrEmpty(method))
                {
                    var route = $"magic/{flowConfig[i].workflowid}/{flowConfig[i].elementNameAttribute}/{flowConfig[i].elementNameAttribute}/";

                    switch (method.ToUpper())
                    {
                        case "GET":
                            app.MapGet(route, () =>
                            {
                                return string.IsNullOrEmpty(condition)
                                    ? SqlHandler.GetJson(query)
                                    : SqlHandler.GetJson($"{query} where {condition}");
                            });
                            break;

                        case "POST":
                            app.MapPost(route, async (HttpContext context) =>
                            {
                                using var reader = new StreamReader(context.Request.Body);
                                string requestBody = await reader.ReadToEndAsync();
                                var jsonObject = JObject.Parse(requestBody);
                                string finalQuery = MagicHandler.RemplazarVariables(query, jsonObject);
                                return SqlHandler.Exec(finalQuery, "ConfigureRoutes.POST");
                            });
                            break;

                        case "PUT":
                            app.MapPut(route, async (HttpContext context) =>
                            {
                                using var reader = new StreamReader(context.Request.Body);
                                string requestBody = await reader.ReadToEndAsync();
                                var jsonObject = JObject.Parse(requestBody);
                                string finalQuery = MagicHandler.RemplazarVariables(query, jsonObject);
                                return SqlHandler.Exec(finalQuery, "ConfigureRoutes.PUT");
                            });
                            break;

                        case "DELETE":
                            app.MapDelete(route, (string condition) =>
                            {
                                return string.IsNullOrEmpty(condition)
                                    ? SqlHandler.Exec(query, "ConfigureRoutes.DELETE")
                                    : SqlHandler.Exec($"{query} where {condition}", "ConfigureRoutes.DELETE");
                            });
                            break;
                    }
                }


            }
        }

        public static void ConfigureInjection(WebApplicationBuilder builder, string connStr)
        {
            ProspectionData.ConnStr = connStr;
            bool enabledMigration = bool.Parse(builder.Configuration["ProspectionSettings:enabledMigracion"]);
            LogHandler.EnabledLog = bool.Parse(builder.Configuration["ProspectionSettings:enabledLog"]);
            LogHandler.OnlyErrors = bool.Parse(builder.Configuration["ProspectionSettings:onlyErrors"]);

            builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if (enabledMigration)
            {
                MigrationService.Migrate();
            }

            builder.Services.AddScoped<CrudRepository, CrudService>();
            builder.Services.AddScoped<FormRepository, FormService>();
            builder.Services.AddScoped<WorkFlowRepository, WorkFlowService>();
            builder.Services.AddScoped<RepoRepository, RepoService>();
        }

        public static async Task<EventStatus> GetEvent(EventDTO evento)
        {
            EventStatus eventStatus = new EventStatus();
            List<EventDTO> list = new List<EventDTO>();
            list.Add(evento);

            for (int i = 0; i < list.Count; i++)
            {
                string[] parameters = new string[100];
                parameters[0] = evento.Valor;
                eventStatus = MapFunction(list[i].Funcion, parameters);
                eventStatus.Target = evento.Target;
            }

            return eventStatus;
        }

        public static EventStatus MapFunction(string function, string[] param)
        {
            EventStatus eventStatus = new EventStatus();
            switch (function)
            {
                case "ValidaDni":
                    eventStatus = ValidaDni.Validate(param[0]);
                    break;
                case "MailList":
                    eventStatus = MailList.Validate(param[0]);
                    break;
                case "ActualizarEstado":
                    eventStatus = ActualizarEstado.Validate(param[0]);
                    break;
                case "InsertForm":
                    eventStatus = ActualizarEstado.Validate(param[0]);
                    break;
                default:
                    eventStatus = ConfigHandler.GetDefault();
                    break;
            }

            return eventStatus;
        }

    }
}
