using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListofPeople.Models
{
    public class DbInit
    {
        public static void Init(PeopleDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Persons.Any())
            {
                return;
                    }
            else
            {
                context.Persons.Add(new Person("Mattias", "Rävemåla", "0735-XXXXXX"));
                context.SaveChanges();
             
            }
          
            }
        }
    }
