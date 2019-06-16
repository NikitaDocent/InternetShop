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
    [Table("Manager")]
    public class Manager : IHuman
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Parol { get; set; }
        public Manager(string email,string parol)
        {
            this.Email = email;
            this.Parol = parol;
        }

        public Manager() { }

        public override string ToString() => "Manager Email: " + Email + "\n";
    }
}
