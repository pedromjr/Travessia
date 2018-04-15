using System.Configuration;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class UserController : BaseAsyncController
    {
        public static string ApiAddress = ConfigurationManager.AppSettings.Get("ApiAddress");

        public UserController()
        {
            ViewBag.ApiAddress = ApiAddress;
        }

        // GET: User
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            return View();
        }
    }
}