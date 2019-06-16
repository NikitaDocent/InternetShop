using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Interface;

namespace UI.Models
{
    [Table("Admin")]
    public class MAdmin : IHuman
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Parol { get; set; }

        public MAdmin() { }

        public MAdmin(string email, string password)
        {
            this.Email = email;
            this.Parol = password;
        }

        public override string ToString() => "Admin Email: " + Email + "\n";

    }
}