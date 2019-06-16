using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Interface;

namespace UI.Models
{
    [Table("Manager")]
    public class MManager : IHuman
    {

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Parol { get; set; }

        public override string ToString() => "Manager Email: " + Email + "\n";
    }
}