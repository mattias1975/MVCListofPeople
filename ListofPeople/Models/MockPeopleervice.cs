using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListofPeople.Models
{
    public class MockPeopleervice : IPeopleService
    {
        int countid = 0;
        List<Person> People;

        public MockPeopleervice()
        {
            People = new List<Person>();
            this.Create("Mattias", "0735-xxxxxx", "Rävemåla");

        }
        public Person Create(string name, string city, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(phone))
            {
                return null;
            }
            Person person = new Person(countid++, name, city, phone);
            People.Add(person);
            return person;
        }

        public bool Delete(int id)
        {
            return People.Remove(People.FirstOrDefault(p => p.Id == id));
        }

        public Person FindById(int id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        public Person FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeople()
        {
            return People;
        }
        public bool Update(Person person)
        {
            Person Orginal = People.FirstOrDefault(p => p.Id == person.Id);
            if (Orginal == null)
            {
                return false;
            }
            Orginal.Name = person.Name;
            Orginal.Phone = person.Phone;
            Orginal.City = person.City;
            return true;
        }
    }
}





