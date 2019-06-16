using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Interface;

namespace Entity.Entitys
{
    [Table("Admin")]
    public class Admin : IHuman
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Parol { get; set; }

        public Admin() { }

        public Admin(string email,string password)
        {
            this.Email = email;
            this.Parol = password;
        }

        public override string ToString() => "Admin Email: " + Email + "\n";
    }
}
