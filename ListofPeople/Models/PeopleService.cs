using ListofPeople.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListofPeople.Models
{
    public class PeopleService : IPeopleservice
    {
        private PeopleDbContext _context;
        public PeopleService(PeopleDbContext context)
        {
            _context = context;
        }

        //-----------------------
        public Person Create(string name, string phone, string city)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(phone))
            {
                return null;
            }
            Person person = new Person(name, phone, city);
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }


        public Person FindByID(int id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            Person person = _context.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return true;
        }

        public List<Person> GetPeople()
        {
            return _context.Persons.ToList();
        }

        public bool Update(Person person)
        {
            Person original = _context.Persons.FirstOrDefault(p => p.Id == person.Id);

            if (original == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(person.Name)
                || string.IsNullOrWhiteSpace(person.City)
                || string.IsNullOrWhiteSpace(person.Phone))
            {
                return false;
            }

            original.Name = person.Name;
            original.City = person.City;
            original.Phone = person.Phone;

            _context.SaveChanges();

            return true;
        }
    }

    public interface IPeopleService
    {
    }
}


