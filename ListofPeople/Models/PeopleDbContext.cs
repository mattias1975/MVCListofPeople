using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListofPeople.Models
{
    public class PeopleDbContext: DbContext
    {
     public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options) { }
      public DBSet<Person> Persons { get; set; }
        public object People { get; internal set; }
    }
}
