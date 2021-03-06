﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListofPeople.Models;

namespace ListofPeople.Controllers
{
    public class PeopleController : Controller
    {

        IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Person(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Person", person);
        }

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Details", person);
        }

        [HttpGet]

        public IActionResult Edit(int id,string Name, string Phone, string City)
        {

            Person person = _peopleService.FindById(id);
  
            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Edit", person);
        }
        [HttpPost]
        public IActionResult ConfirmEdit(Person person)
        {
           
            if (person == null)
            {
                return NotFound();
            }
            
            if (_peopleService.Update(person))
            {

                return PartialView("_Person", person);
            }
            else
            {
                return PartialView("_Edit", _peopleService.FindById(person.Id));
            }
        

        }

        [HttpPost]
        public IActionResult Create(string name, string phone, string city)
        {

            if (name == null)
            {
                return BadRequest(new { msg = "You most write name" });
            }
            if (city == null)
            {
                return BadRequest(new { msg = "You most write a City" });
            }
            if (phone == null)
            {
                return BadRequest(new { msg = "You most write yor phonenumber" });
            }
           
            Person person = _peopleService.Create(name, phone, city);

            return PartialView("_Person",person);
            //return RedirectToAction("Filter");

        }
        [HttpPost]
        public IActionResult Confirmcreate(Person person)
        {

            if (person == null)
            {
                return NotFound();
            }

            if (_peopleService.Update(person))
            {

                return PartialView("_Person", person);
            }
            else
            {
                return PartialView("_Person", _peopleService.FindById(person.Id));
            }
        }

            public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            _peopleService.Delete(id);
            return Content("");
            //return RedirectToAction("Filter");
        }

        public IActionResult Filter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return View("Index", _peopleService.GetPeople());
            }

            filter = filter.ToLower();

            return View("Index", _peopleService.GetPeople()
                .Where(p => p.Name.ToLower().Contains(filter) || p.City.ToLower().Contains(filter))
                .ToList());
        }
    }
}