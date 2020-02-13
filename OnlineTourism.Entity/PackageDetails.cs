
namespace OnlineTourism.Entity
{
    public class PackageDetails
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int PackagePrice { get; set; }
        public PackageDetails(int packageId,string packageName,int packagePrice)
        {
            PackageId = packageId;
            PackageName = packageName;
            PackagePrice = packagePrice;
        }
    }
}
