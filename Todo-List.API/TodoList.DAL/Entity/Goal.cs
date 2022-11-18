using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.DAL.Entity
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        public string Aim { get; set; }
        public bool IsDone { get; set; }
    }
}
