using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Interface;

namespace UI.Models
{
    [Table("Product")]
    public class MProduct : IProduct
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public string http { get; set; }
        public string Description { get; set; }
        public MProduct(string Http, string type, string name, string description, int cost, int startCount)
        {
            this.http = Http;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.Count = startCount;
        }
        public MProduct() { }
        public void AddToAssortiment(int count) => Count = Count + count;
        public void AddToAssortiment() => Count++;
    }
}