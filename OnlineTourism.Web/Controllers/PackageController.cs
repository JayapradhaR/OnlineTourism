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
            return RedirectToAction("TempDataChecking");
        }
        public ActionResult TempDataChecking()
        {
            IEnumerable<PackageDetails> packageDetails = package.GetPackageDetails();
            TempData["packages"] = packageDetails;
            return View();
        }
    }
}