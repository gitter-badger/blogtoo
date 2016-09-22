using System.Web.Mvc;

namespace BlogToo.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error(string httpStatusCode)
        {
            // Remove the Server HTTP Response Header from being sent
            HttpContext.Response.Headers.Remove("Server");

            // check for a valid st
            int statusCode;
            if (!int.TryParse(httpStatusCode, out statusCode))
            {
                statusCode = 400;
            }

            ViewBag.StatusCode = statusCode;
            ViewBag.StatusMessage = GetStatusMessageFromCode(statusCode);
            ViewBag.Title = string.Format("Error {0} - {1}", ViewBag.StatusCode, ViewBag.StatusMessage);

            Response.StatusCode = statusCode;
            return View("Error");
        }

        private string GetStatusMessageFromCode(int httpStatusCode)
        {
            switch (httpStatusCode)
            {
                // 2xx Success Codes
                case 200:
                    return "OK";
                case 204:
                    return "No Content";
                // 3xx Redirection Codes
                case 301: // Permanent Redirect
                    return "Moved Permanently";
                case 302: // Temporary Redirect
                    return "Found";
                // 4xx Client Error Codes
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unauthorized";
                case 403:
                    return "Forbidden";
                case 404:
                    return "Not Found";
                case 405:
                    return "Method Not Allowed";
                case 406:
                    return "Not Acceptable";
                case 410:
                    return "Gone";
                case 418: // https://tools.ietf.org/html/rfc2324
                    return "I'm a teapot";
                case 429:
                    return "too Many Requests";
                case 451: // https://tools.ietf.org/html/rfc7725
                    return "Unavailable For Legal Reasons";
                // 5xx Server Error Codes
                case 500:
                    return "Internal Server Error";
                case 501:
                    return "Not Implemented";
                case 503:
                    return "Service Unavailable";
                default:
                    return "Unknown Error";
            }
        }
    }
}