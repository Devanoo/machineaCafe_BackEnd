using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MachineàCafe_BackEnd.Models
{
    public class MachineàCafe_BackEndContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MachineàCafe_BackEndContext() : base("name=MachineàCafe_BackEndContext")
        {
        }

        public System.Data.Entity.DbSet<MachineàCafe_BackEnd.Models.Boissons> Boissons { get; set; }

        public System.Data.Entity.DbSet<MachineàCafe_BackEnd.Models.Badges> Badges { get; set; }
    }
}
