using System.Web.Mvc;

namespace cams.Controllers
{
    /// <summary>
    /// Defines the Home controller. (not used)
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets the default index.
        /// </summary>
        /// <returns>Default page.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}