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
        [ActionName("Create")]
        public ActionResult CreatePackage()
        {
            PackageDetails packageDetails = new PackageDetails();
            UpdateModel(packageDetails);
            package.AddPackage(packageDetails);
            TempData["Message"] = "Package added";
            return RedirectToAction("Index");
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
        public ActionResult Update()
        {
            PackageDetails packageDetails = new PackageDetails();
            TryUpdateModel(packageDetails);
            package.UpdatePackage(packageDetails);
            TempData["Message"] = "Package updated";
            return RedirectToAction("Index");
        }
    }
}