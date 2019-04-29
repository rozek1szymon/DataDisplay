using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task1PackagesSender.Data;
using Task1PackagesSender.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Task1PackagesSender.Interfaces;
using Task1PackagesSender.FluentValidation;
using FluentValidation.AspNetCore;

namespace Task1PackagesSender.Controllers
{
    
    public class HomeController : Controller
    {

        /// <summary>
        /// We declare our Special Database access 
        /// </summary>
       

        private readonly IDataConverterService _dataService;
        private readonly IMainComponent _personService;

        public HomeController(IDataConverterService dataService)
        {
            _dataService = dataService;
            EmployeesData CompanyEmployees = _dataService.BuildData();
            _personService = new MainComponent(CompanyEmployees);
        }

      

        [HttpPost]
        public IActionResult Login(DataWrapper dataWrapper)
        {



        var MainComponent = _personService.Run(dataWrapper.currentUser.Login,dataWrapper.formData);
      
            ViewData["Acceptant"] = dataWrapper.formData.AcceptingPerson;
            ViewData["SubstituteAcceptant"] = dataWrapper.formData.SubstituteAcceptingPerson;
            ViewBag.b = Category.Categories.Select(x => x).ToArray();
            ViewData["Login"] = dataWrapper.currentUser.Login;
            if(MainComponent != null)
            {
                ViewData["Error"] = MainComponent;
            }




            return View(dataWrapper);
        }






         
        //[HttpPost]
        //public IActionResult Login(DataWrapper dataWrapper)
        //{

        //    int? manager = dataWrapper.currentUser.ORG_ManagerID;

        //    Employees GetManager;

        //    List<AcceptingPerson> CheckThatMangerCanAcceptTheAsk;

        //    AcceptingPerson SubstituteWithLowerOpportunity = null;

        //    FormDataValidation validation = new FormDataValidation();

        //    var result = validation.Validate(dataWrapper.formData);
        //    if (result.IsValid && manager != null)
        //    {

        //        do
        //        {

        //            GetManager = _personService.GetManager(manager);

        //            CheckThatMangerCanAcceptTheAsk = _personService.CheckThatMangerCanAcceptTheAsk(GetManager, dataWrapper.formData);

        //            manager = GetManager.ORG_ManagerID;
        //        } while (CheckThatMangerCanAcceptTheAsk.Count == 0);

        //        if (CheckThatMangerCanAcceptTheAsk.Count > 0)
        //        {
        //            var min = CheckThatMangerCanAcceptTheAsk.Where(x => x.SubstituteLimit > dataWrapper.formData.TotalValue).Min(entry => entry.SubstituteLimit);
        //            SubstituteWithLowerOpportunity = CheckThatMangerCanAcceptTheAsk.FirstOrDefault(x => x.SubstituteLimit == min);
        //            ViewData["Acceptant"] = $"You should ask {CheckThatMangerCanAcceptTheAsk[0].Login} for your permission";
        //            dataWrapper.formData.AcceptingPerson = CheckThatMangerCanAcceptTheAsk[0].Login;
        //        }



        //        if (CheckThatMangerCanAcceptTheAsk.Count > 0 && SubstituteWithLowerOpportunity != null && SubstituteWithLowerOpportunity.SubstituteLogin != null)
        //        {
        //            ViewData["SubstituteAcceptant"] = $"If you can't find your main Acceptant, go to { SubstituteWithLowerOpportunity.SubstituteLogin}";
        //            dataWrapper.formData.AcceptingPerson = SubstituteWithLowerOpportunity.SubstituteLogin;
        //        }

        //        else
        //        {
        //            ViewData["SubstituteAcceptant"] = "There are no any Substitute acceptant";
        //        }
        //    }
        //    else if (manager == null)
        //    {
        //        ViewData["Acceptant"] = $"Actually you are a CEO, so you can do everything";
        //    }
        //    else
        //    {
        //        if (dataWrapper.formData.TotalValue <= 0)
        //        {
        //            ViewData["SubstituteAcceptant"] = "You have to write value greather than 0";
        //        }
        //        else
        //        {
        //            ViewData["SubstituteAcceptant"] = "Your value cannot be greather than 1000000";
        //        }

        //        result.AddToModelState(ModelState, null);
        //    }

        //    ViewBag.b = Category.Categories.Select(x => x).ToArray();
        //    ViewData["Login"] = dataWrapper.currentUser.Login;

        //    return View(dataWrapper);
        //}

        [HttpGet]
        public ActionResult Index() => View();

        [HttpPost]
        public ActionResult Index(DataWrapper person)
        {
            if (person.currentUser.Login==null)
            {
               ViewData["Login"] = "You have to write your Login";
            }
            else
            {
          
            var result = _personService.FindUser(person.currentUser.Login);
            if (result == true)
            {
            person.currentUser = _personService.GetEmployee(person.currentUser.Login);
            ViewData["Login"]  = person.currentUser.Login;
            ViewBag.b = Category.Categories.Select(x => x).ToArray();
              return View("Login",person);
            }
                ViewData["Login"] = "There is no User like this";
            }
            
            return View();
                                
        }

    }
}
