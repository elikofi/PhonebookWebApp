using System;
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

        private readonly IFileService fileService;

        

        public ContactController(IContactService contactService, ICountryService countryService, IFileService fileService)//added iwebhost
        {
            this.contactService = contactService;
            this.countryService = countryService;
            this.fileService = fileService;
        }


        // GET: /<controller>/
        public IActionResult Add()
        {
            var model = new Contact();
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Contact model)
        {
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString(), Selected = a.Id == model.CountryId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Added here
            if (model.ProfilePicture != null)
            {
                var fileResult = this.fileService.SaveImage(model.ProfilePicture);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "Couldn't save file";
                    return View(model);
                }
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
        public IActionResult Update(Contact model)
        {
            model.CountryList = countryService.GetAll().Select(a => new SelectListItem { Text = a.CountryName, Value = a.Id.ToString(), Selected = a.Id == model.CountryId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // added here

            if (model.ProfilePicture != null)
            {
                var fileResult = this.fileService.SaveImage(model.ProfilePicture);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "Couldn't save file";
                    return View(model);
                }
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
    }
}

