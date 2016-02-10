using System.Web.Mvc;

namespace SocialAnalytics.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                // Tratar o erro de alguma forma
                // 1 - Gravar no EventViewer
                // 2 - Gravar no banco
                // 3 - Enviar um email
                // 4 - Fazer tudo isso e mais alguma coisa.

                // Muitos recursos disponíveis para montar um LOG completo
                // filterContext.Controller.ControllerContext.HttpContext;
                // filterContext.Exception;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
