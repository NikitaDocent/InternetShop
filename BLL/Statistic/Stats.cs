using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Statistic
{
    [Table("Stats")]
    public class Stats
    {
        [Key]
        public int Id { get; set; }
        public int CountOfUsers = 0;
        public int CountOfBuys = 0;
    }
}
