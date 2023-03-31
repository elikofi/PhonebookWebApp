using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Models;
using PhoneBookApp.Repositories.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService service;

        public CountryController(ICountryService service)
        {
            this.service = service;
        }


        // GET: /<controller>/
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Country model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Country Added Successfully.";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to add. Error has occured on server side.";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var result = service.FindById(id);
            return View(result);
        }

        [HttpPost] // for sending data to the server from the client.
        public IActionResult Update(Country model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated Successfully.";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error occured, couldn't update.";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _ = service.FindById(id);
            service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var result = service.GetAll().OrderBy(result => result.CountryName).ToList();
            return View(result);
        }
    }
}

