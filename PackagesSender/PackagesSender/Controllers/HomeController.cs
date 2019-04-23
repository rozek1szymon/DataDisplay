using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1PackagesSender.Data;
using Task1PackagesSender.Models;
using X.PagedList;
using Task1PackagesSender.AbstractValidator;
using FluentValidation.AspNetCore;
using System.Collections.Generic;

namespace Task1PackagesSender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Main page, with using this method we are getting list of a Packeges with deliveries inside and if we have more than 10 packages our application adds pages
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? page)
        {

            var products = _context.MainPackages.Include(i => i.Deliveries).ToList();
            var pageNumber = page ?? 1;
            var onePageOfProducts = await products.ToPagedListAsync(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">it shows what we are looking for "open" or "closed"</param>
        /// <param name="page"></param>
        /// <returns></returns>  
        public async Task<IActionResult> Index2(bool? search, int? page)
        {
            var pageNumber = page ?? 1;

            if (search == null)
            {
                var products = _context.MainPackages.Include(i => i.Deliveries).ToList();
                var onePageOfProducts = await products.ToPagedListAsync(pageNumber, 10);
                ViewBag.OnePageOfProducts = onePageOfProducts;
            }
            else
            {
                var products = _context.MainPackages.Where(x => x.IsPackageOpen == search).Include(i => i.Deliveries).ToList();
                var onePageOfProducts = await products.ToPagedListAsync(pageNumber, 10);
                ViewBag.OnePageOfProducts = onePageOfProducts;

            }

            return PartialView("_IndexPartial");
        }

        /// <summary>
        /// It creates Packages with few deliveries, and save it only when everything is valid
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreatePackageWithDeliveries(MainPackage package)
        {
            MainPackageValidation validator = new MainPackageValidation();
          
            bool isEveryPackageValid=true;
           
            if(package.Deliveries.Count>0 && package.Deliveries!=null)
            {
                package.Deliveries = package.Deliveries.Where(x => x.PackageID != -1).ToList();
                

                DeliveryValidation validator1 = new DeliveryValidation();

                foreach (var item in package.Deliveries)
                {
                    var result1 = validator1.Validate(item);
                    if (result1.IsValid == false)
                    {
                        result1.AddToModelState(ModelState, null);
                        isEveryPackageValid = false;
                    }
                }
            }
            var FinalPackage = package;
            var results = validator.Validate(package);
            if (results.IsValid == false)
            {
                results.AddToModelState(ModelState, null);
            }


            if (results.IsValid==true && isEveryPackageValid==true)
            {
                package.DateOfMadeThePackage = DateTime.Now;
                _context.MainPackages.Add(package);               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            return View("Create", FinalPackage);

        }



        /// <summary>
        /// it is creating for us new package
        /// </summary>
        /// <param name="mainPackage"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Create(MainPackage Mpackage)
        {
            
            return View(Mpackage);
        }

/// <summary>
/// We here can create New Package
/// </summary>
/// <param name="mainPackage"></param>
/// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PackageID,NameOfPackage,DateOfMadeThePackage,IsPackageOpen,DateOfCloseThePackage,DestinationCityOfDelivery")] MainPackage mainPackage)
        //{
        //    MainPackageValidation validator = new MainPackageValidation();

        //    var results = validator.Validate(mainPackage);
                      
        //    if(results.IsValid)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            mainPackage.DateOfMadeThePackage = DateTime.Now;
        //            _context.Add(mainPackage);
        //            //sprawdzic czy mozna wziac ID paczki po jej dodaniu na stronie
        //            //wszystko musi byc dobrze lacznei z przesylkami i paczka
 
        //            await _context.SaveChangesAsync();

        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    else
        //    {
        //        results.AddToModelState(ModelState, null);
        //    }

        //    return View(mainPackage);           
        //}
        
        /// <summary>
        /// our page with view of main package and its deliveries
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mainPackagesIndexData1"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id , MainPackagesIndexData mainPackagesIndexData1)
        {
            if (id == null)
            {
                return NotFound();
            } 
            
                 var mainPackage = await _context.MainPackages.FindAsync(id);

                 var products = await _context.Deliveries.Where(x => x.PackageID == id).ToListAsync();

            if (mainPackage == null)
            {
                return NotFound();
            }

                  mainPackagesIndexData1.Deliveries = products;

                  mainPackagesIndexData1.MainPackage = mainPackage;
           
            return View(mainPackagesIndexData1);
        }
      
        /// <summary>
        /// Whilst deleting main packagae we delete every deliviery related to it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var mainPackage = await _context.MainPackages.FindAsync(id);

            var deletedeliveries = _context.Deliveries.Where(del => del.PackageID == id);
            
            foreach (var item in deletedeliveries)
            {
                _context.Deliveries.Remove(item);
            }
            _context.MainPackages.Remove(mainPackage);

            await _context.SaveChangesAsync(); 

            return RedirectToAction("Index");
        }

        private bool MainPackageExists(int id)
        {
            return _context.MainPackages.Any(e => e.PackageID == id);
        }




        /// <summary>
        /// Editing package and all releted to this deliveries 
        /// </summary>
        /// <param name="DeliveryAndPackageWrapper"> wrapper of main package and deliveries</param>
        /// <returns></returns>

        public async Task<IActionResult> EditFewDeliveries(MainPackagesIndexData DeliveryAndPackageWrapper)
        {
            if(DeliveryAndPackageWrapper.MainPackage.IsPackageOpen==false && DeliveryAndPackageWrapper.MainPackage.DateOfCloseThePackage==null)
            {
                DeliveryAndPackageWrapper.MainPackage.DateOfCloseThePackage = DateTime.Now;
            }
            else if(DeliveryAndPackageWrapper.MainPackage.IsPackageOpen == true)
            {
                DeliveryAndPackageWrapper.MainPackage.DateOfCloseThePackage = null;
            }

            WrapperValidation validatorX = new WrapperValidation();

            MainPackageValidation validator1 = new MainPackageValidation();

            var resultX = validator1.Validate(DeliveryAndPackageWrapper.MainPackage);
           // var result1 = validator1.Validate(DeliveryAndPackageWrapper.MainPackage);
       
            bool isEveryPackageValid = true;

            DeliveryValidation validator2 = new DeliveryValidation();

            if(resultX.IsValid)
            {
                _context.Update(DeliveryAndPackageWrapper.MainPackage);
            }
            else
            {
              resultX.AddToModelState(ModelState, null);
            }
            ///sprawdz na liscie ktora jest w main package czy na niej sie zapisuje packageID
            if(DeliveryAndPackageWrapper.Deliveries.Count!=0)
            {

                foreach (var item in DeliveryAndPackageWrapper.Deliveries)
                {
                  
                    try
                    {
                        var results = validator2.Validate(item);
                        if (item.PackageID == 0 && item.DeliveryID != 0)
                        {
                            _context.Deliveries.Remove(item);
                        }
                        else if (item.PackageID != 0)
                        {
                            if (results.IsValid)
                            {
                                
                                if (item.DeliveryID == 0)
                                {
                                    item.DateOfMade = DateTime.Now;
                                    _context.Add(item);
                                }
                                else
                                {
                                    _context.Update(item);
                                    
                                }
                            }
                            else
                            {
                                results.AddToModelState(ModelState, null);
                                isEveryPackageValid = false;
                            }

                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MainPackageExists(item.DeliveryID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            if(isEveryPackageValid==true && resultX.IsValid==true)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { controller = "Home", action = "Edit", Id = DeliveryAndPackageWrapper.MainPackage.PackageID });
            }
            var mainPackagesIndexData1 = DeliveryAndPackageWrapper;
            return RedirectToAction("Edit", new {  Id = DeliveryAndPackageWrapper.MainPackage.PackageID, mainPackagesIndexData1 });
        }

    }

    
}


