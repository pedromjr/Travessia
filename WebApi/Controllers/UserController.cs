using Core;
using Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using MVC = System.Web.Mvc;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [MVC.Route("all")]
        [HttpGet]
        public GTUser AuthenticateAndGetUser(string login, string password)
        {
            GTUser user = null;
            using (UserBusiness ub = new UserBusiness())
            {
                if (ub.AuthenticateUser(login, password))
                    user = ub.GetUserByLogin(login);
            }

            return user;
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("all")]
        [HttpGet]
        public List<GTUser> GetAll()
        {
            List<GTUser> users = new List<GTUser>();
            using (UserBusiness ub = new UserBusiness())
            {
                users = ub.GetAllUsers();
            }

            return users;
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("create")]
        [HttpPost]
        public void Create(GTUser user)
        {
            using (UserBusiness ub = new UserBusiness())
            {
                ub.CreateUser(user);
            }
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("edit")]
        [HttpPut]
        public void Edit(GTUser user)
        {
            using (UserBusiness ub = new UserBusiness())
            {
                ub.UpdateUser(user);
            }
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("delete")]
        [HttpDelete]
        public void Delete(string id)
        {
            using (UserBusiness ub = new UserBusiness())
            {
                ub.DeleteUser(int.Parse(id));
            }
        }
    }
}
