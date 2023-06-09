﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBookApp.Models;
using PhoneBookApp.Repositories.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;

        private readonly ICountryService countryService;

        private readonly IWebHostEnvironment _webHostEnvironment;

        

        public ContactController(IContactService contactService, ICountryService countryService, IWebHostEnvironment webHostEnvironment)//added iwebhost
        {
            this.contactService = contactService;
            this.countryService = countryService;
            _webHostEnvironment = webHostEnvironment;
        }


        // GET: /<controller>/
        public IActionResult Add()
        {
            var model = new Contact();
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Contact model, IFormFile? file)
        {
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString(), Selected = a.Id == model.CountryId }).ToList();
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string contactPath = Path.Combine(wwwRootPath, @"images/profilepic");

                using (var fileStream = new FileStream(Path.Combine(contactPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                model.ImageUrl = @"/images/profilepic/" + fileName;
            }

            var result = contactService.Add(model);
            if (result)
            {
                TempData["msg"] = "Contact Added!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to add! Error has occured.";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var model = contactService.FindById(id);
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString(), Selected = a.Id == model.CountryId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Contact model, IFormFile? file)
        {
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString(), Selected = a.Id == model.CountryId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string contactPath = Path.Combine(wwwRootPath, @"images/profilepic");

                using (var fileStream = new FileStream(Path.Combine(contactPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                model.ImageUrl = @"/images/profilepic/" + fileName;
            }


            var result = contactService.Update(model);
            if (result)
            {
                TempData["msg"] = "Contact Updated!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to update! Error has occured.";
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            var result = contactService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var result = contactService.GetAll().OrderBy(data => data.FirstName).ToList();
            return View(result);
        }


        public IActionResult GetBySearch(string searchQuery)
        {
            var result = contactService.GetAll().Where(x => x.FirstName.ToLower().Contains(searchQuery.ToLower()));
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var model = contactService.FindById(id);
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString(), Selected = a.Id == model.CountryId }).ToList();
            return View(model);
        }
    }
}

