﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListofPeople.Models
{
    public class Person
    {
        public Person(object p, string name, string phone, string city)
        {
            Id = Id;
            Name = name;
            Phone = phone;
            City = city;
        }

        public Person(string name, string phone, string city)
        {
            Name = name;
            Phone = phone;
            City = city;
        }

        public int Id { get; set; }
        public  string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public bool Remove { get; set; }
    }
}
