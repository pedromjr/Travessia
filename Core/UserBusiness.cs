using DataCore.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UserBusiness : BusinessClass
    {
        public UserBusiness() { }

        public UserBusiness(GTContext existingContext) : base(existingContext) { }

        public GTUser GetUserById(int id)
        {
            GTUser user = new GTUser();

            user = Context.Users.FirstOrDefault(p => p.Id == id);

            if(user == null)
            {
                Context.Dispose();
                AddError("Não foi possível localizar o usuário.");
            }

            return user;
        }

        public void CreateUser(GTUser user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            GTUser user = Context.Users.FirstOrDefault(p => p.Id == id);

            Context.Users.Remove(user);

            Context.SaveChanges();
        }

        public void UpdateUser(GTUser user)
        {
            GTUser savedUser = Context.Users.FirstOrDefault(p => p.Id == user.Id);

            if(savedUser != null)
            {
                savedUser = user;
                Context.Entry(savedUser).State = EntityState.Modified;

                Context.SaveChanges();
            }
        }

        public List<GTUser> GetAllUsers()
        {
            return Context.Users.ToList();
        }
    }
}
