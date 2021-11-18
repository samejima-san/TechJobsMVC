﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        private const string V = "/search";
        // GET: /<controller>/
        [HttpGet]
        [Route(V)]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        [HttpPost]
        [Route(V)]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            ViewBag.columns = ListController.ColumnChoices;

            if (searchType.ToLower().Equals("all") || searchTerm == null)
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.jobs = jobs;

            return View();
        }
    }
}
