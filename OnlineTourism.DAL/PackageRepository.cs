using System.Collections.Generic;
using OnlineTourism.Entity;
namespace OnlineTourism.DAL
{
    public class PackageRepository
    {
        public static List<PackageDetails> package = new List<PackageDetails>();
        static PackageRepository()
        {
            package.Add(new PackageDetails (1,"Kerala",15000));
            package.Add(new PackageDetails(2, "Goa", 15000));
            package.Add(new PackageDetails(3, "Kashmir", 10000));
        }
        public IEnumerable<PackageDetails> GetPackageDetails()
        {
            return package;
        }
        public void AddPackage(PackageDetails packageDetails)
        {
            package.Add(packageDetails);
        }
        public PackageDetails GetPackageById(int packageId)
        {
            return package.Find(id => id.PackageId == packageId);
        }
        public void DeletePackage(int packageId)
        {
            PackageDetails pack = GetPackageById(packageId);
            if (pack != null)
                package.Remove(pack);
        }
        public void UpdatePackage(PackageDetails pack)
        {
            //PackageDetails packages = package.Find(id => id.PackageId == pack.PackageId);
            PackageDetails packages=GetPackageById(pack.PackageId);
            packages.PackageName = pack.PackageName;
            packages.PackagePrice = pack.PackagePrice;
        }
    }
}
