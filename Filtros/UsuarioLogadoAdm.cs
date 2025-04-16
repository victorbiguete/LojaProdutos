using LojaProdutos.Enums;
using LojaProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace LojaProdutos.Filtros
{
    [UsuarioLogado]
    [UsuarioLogadoAdm]
    public class UsuarioLogadoAdm: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessao = context.HttpContext.Session.GetString("usuarioSessao");
            UsuarioModel usuarioModel = JsonConvert.DeserializeObject<UsuarioModel>(sessao);

            if (usuarioModel.Cargo == CargoEnum.Cliente)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Login" },
                    {"action", "Login" }
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
