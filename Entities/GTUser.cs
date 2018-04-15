using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Entities
{
    public class GTUser
    {
        public GTUser()
        {
            BirthDate = SqlDateTime.MinValue.Value;
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool Admin { get; set; }
    }
}
