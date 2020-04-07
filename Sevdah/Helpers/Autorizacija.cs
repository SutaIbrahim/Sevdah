using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Sevdah.Data;
using Sevdah.Models;

namespace Sevdah.Helpers
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool osoba)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { osoba };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool osoba)
        {
            _osoba = osoba;
        }
        private readonly bool _osoba;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            KorisnickiNalog k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Authentication", new { @area = "" });
                return;
            }

            //Preuzimamo DbContext preko app services
            DBContext db = filterContext.HttpContext.RequestServices.GetService<DBContext>();

            if (_osoba && db.KorisnickiNalog.Any(s => s.ID == k.ID))
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.ViewData["error_poruka"] = "Nemate pravo pristupa";
            }

            filterContext.Result = new RedirectToActionResult("Index", "Authentication", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}

