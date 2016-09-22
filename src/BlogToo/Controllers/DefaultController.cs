using System.Web.Mvc;

namespace BlogToo.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult DynamicRenderer(string permalink)
        {
            // Remove the Server HTTP Response Header from being sent
            HttpContext.Response.Headers.Remove("Server");

            ViewBag.Title = permalink;
            ViewBag.Content = string.Format("<h1>{0}</h1>", permalink);

            return View("Default");
        }
    }
}