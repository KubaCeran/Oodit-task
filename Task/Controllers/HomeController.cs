﻿using Microsoft.AspNetCore.Mvc;
using System.Text;
using Task.Helpers;
using Task.Models;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            InputModel model = new InputModel();
            return View(model);
        }
        
       [HttpPost]
        public ActionResult Submit(InputModel model)
        {

            if(String.IsNullOrEmpty(model.Input))
            {
                ViewBag.Output = "[]";
                return View("Index");
            }

            var splitList = model.Input.modifyInput();

            if (!splitList.isCorrect())
            {
                ViewBag.Output = "Error";
                return View("Index");
            }

            var final = splitList.Counter();

            ViewBag.Output = $"[{final}]";

            return View("Index");
        }
    }
}