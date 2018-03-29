using System;
using System.Collections.Generic;

namespace Entities
{
    public class GTUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool Admin { get; set; }
    }
}
