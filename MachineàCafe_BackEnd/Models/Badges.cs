using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineàCafe_BackEnd.Models
{
    public class Badges
    {
        public int Id { get; set; }
        public string Name_Boisson { get; set; }
        public int sucre { get; set; }
        public bool Mug { get; set; }
        public bool Badge { get; set; }
    }
}