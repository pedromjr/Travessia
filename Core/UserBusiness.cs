using DataCore.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UserBusiness : BusinessClass
    {
        public UserBusiness() { }

        public UserBusiness(GTContext existingContext) : base(existingContext) { }

        public bool AuthenticateUser(string login, string password)
        {
            GTUser user = GetUserByLogin(login);

            bool authenticate = false;

            if (user != null)
            {
                using (var sha1 = new SHA1Managed())
                {
                    var hash = Encoding.UTF8.GetBytes(password);
                    var generatedHash = sha1.ComputeHash(hash);
                    var generatedHashString = Convert.ToBase64String(generatedHash);

                    if (user.Password == generatedHashString)
                        authenticate = true;
                    else
                        AddError("A combinação usuário x senha está incorreta");
                }
            }                

            return authenticate;
        }

        public GTUser GetUserByLogin(string login)
        {
            GTUser user = Context.Users.FirstOrDefault(p => p.Login == login);

            if (user != null)
                return user;

            AddError("Usuário não encontrado");

            return null;
        }

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
            using (var sha1 = new SHA1Managed())
            {
                var hash = Encoding.UTF8.GetBytes(user.Password);
                var generatedHash = sha1.ComputeHash(hash);
                var generatedHashString = Convert.ToBase64String(generatedHash);

                user.Password = generatedHashString;
            }

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
            using (var sha1 = new SHA1Managed())
            {
                var hash = Encoding.UTF8.GetBytes(user.Password);
                var generatedHash = sha1.ComputeHash(hash);
                var generatedHashString = Convert.ToBase64String(generatedHash);

                user.Password = generatedHashString;
            }

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
