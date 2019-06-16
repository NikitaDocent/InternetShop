﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Interface;

namespace Entity.Entitys
{
    [Table("Client")]
    public class Client : IHuman
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Parol { get; set; }
        public int Money { get; set; }
        public int Books { get; set; } = 0;
        public Client() { }
        public Client(string email,string parol,int money)
        {
            this.Email = email;
            this.Parol = parol;
            this.Money = money;
        }
        public void AddMoney(int sum) => Money += sum;
        public override string ToString() => "Email: " + Email + "\tMoney: " + Money + "gen\n";
    }
}
