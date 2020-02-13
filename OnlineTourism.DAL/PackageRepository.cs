
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
    }
}
