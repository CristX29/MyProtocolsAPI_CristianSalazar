using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProtocolsAPI_CristianSalazar.Attributes
{
    //esta clase ayuda a limitar la forma en que se puede consumir un recurso de controlador(end point)
    //Basicamente vamos a crear una decoracion personalizada que inyecta cierta funcionalidad ya sea a todo un controlador
    // o a un end point particular.



    [AttributeUsage(validOn: AttributeTargets.All)]

    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {

        //especificamos cual es el clave:valor dentro de appsettings que queremos usar como apikey
        private readonly string _apiKey = "Progra6ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //aca validamos que en el body (en tipo json) de request vaya a la info de la ApiKey
            //si no va la info presentamos un mensaje de error indicando que falta ApiKey y que no
            //se puede consumir recurso.

            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401, Content = "Llamada no contiene informacion de seguridad"

                };
                return;
                //si no hay info de seguridad sale la funcion y muestra este mensaje
            }

            //Si viene info de seguridad falta validar que sea la correcta
            //para esto lo primero es extraer el valor de Progra6ApiKey dentro de appsettings.json
            //para poder comparar contra lo que viene en el request
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApiKeyValue = appSettings.GetValue<string>(_apiKey);

            //queda comparar que las apikey sean iguales
            if (!ApiKeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey Invalida..."
                };
                return;
            }

            await next();


        }




    }
}
