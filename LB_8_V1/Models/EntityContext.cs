using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_8_V1.Models
{
    internal class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DataBaseInittializer()); //засевает базу данных при запуске
        }

        public DbSet<Student> Students { get; set; }
    }
}
