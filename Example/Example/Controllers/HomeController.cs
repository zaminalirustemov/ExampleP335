﻿using Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}