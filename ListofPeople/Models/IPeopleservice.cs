using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListofPeople.Models
{
public interface IPeopleservice
    {
        Person Create(String name, string phone, string city);
        Person FindByID(int id);
        List<Person> GetPeople();
        bool Update(Person person);
        bool Delete(int id);


    }
}
