using Core;
using Entities;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class BaseAnonymousController : Controller
    {
        public GTUser GTUser
        {
            get
            {
                return (GTUser)this.Session["GTUser"];
            }
            set
            {
                this.Session["GTUser"] = value;
            }
        }

        public void SetGTUser(GTUser ltsUser)
        {
            this.Session["GTUser"] = ltsUser;
        }

        public bool CheckForDomainErrors(BusinessClass bc)
        {
            if (bc.HasErrors)
            {
                foreach (BusinessError error in bc.Errors)
                {
                    if (error.ThrownException != null)
                        ModelState.AddModelError((error.Key == null ? "" : error.Key), error.Message + ". Exception: " + error.ThrownException.Message + ". Stack: " + error.ThrownException.StackTrace);
                    else ModelState.AddModelError((error.Key == null ? "" : error.Key), error.Message);
                }
                return true;
            }

            return false;
        }

        protected void ClearSession()
        {
            this.Session.RemoveAll();
        }
    }
}