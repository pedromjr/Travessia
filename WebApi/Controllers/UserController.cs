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
        public List<GTUser> GetAll()
        {
            UserBusiness ub = new UserBusiness();
            return ub.GetAllUsers();
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("create")]
        [HttpPost]
        public void Create(GTUser user)
        {
            UserBusiness ub = new UserBusiness();
            ub.CreateUser(user);
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("edit")]
        [HttpPut]
        public void Edit(GTUser user)
        {
            UserBusiness ub = new UserBusiness();
            ub.UpdateUser(user);
        }

        [EnableCors("*", "*", "*")]
        [MVC.Route("delete")]
        [HttpDelete]
        public void Delete(string id)
        {
            UserBusiness ub = new UserBusiness();
            ub.DeleteUser(int.Parse(id));
        }
    }
}
