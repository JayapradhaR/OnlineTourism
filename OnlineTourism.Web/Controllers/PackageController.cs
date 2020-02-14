using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTourism.DAL;
using OnlineTourism.Entity;
namespace OnlineTourism.Web.Controllers
{
    public class PackageController : Controller
    {
        // GET: Package
        PackageRepository package;
        public PackageController()
        {
            package = new PackageRepository();
        }
        public ActionResult Index()
        {
            IEnumerable<PackageDetails> packages = package.GetPackageDetails();
            return View(packages);
        }
        public ActionResult DataPassing()
        {
            IEnumerable<PackageDetails> packages = package.GetPackageDetails();
            ViewBag.Package = packages;
            ViewData["packages"] = packages;
            return View();
        }
        public ActionResult TempDataCheck()
        {
            IEnumerable<PackageDetails> packageDetails = package.GetPackageDetails();
            TempData["packages"] = packageDetails;
            return RedirectToAction("TempDataChecking");
        }
        public ActionResult TempDataChecking()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PackageDetails packageDetails)
        {
           // if(ModelState.IsValid)
            //{
                package.AddPackage(packageDetails);
                TempData["Message"] = "Package added";
                return RedirectToAction("Index");
            //}
            //return View(packageDetails);
        }
        public ActionResult Edit(int id)
        {
            PackageDetails pack = package.GetPackageById(id);
            return View(pack);
        }
        public ActionResult Delete(int id)
        {
            package.DeletePackage(id);
            TempData["Message"] = "Package deleted";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(PackageDetails packageDetails)
        {
           // if (ModelState.IsValid)
            //{
                package.UpdatePackage(packageDetails);
                TempData["Message"] = "Package updated";
                return RedirectToAction("Index");
            //}
            //return View("Edit",packageDetails);
        }
    }
}