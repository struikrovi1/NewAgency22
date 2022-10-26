using NewAgency.Models;

namespace NewAgency.ViewModels
{
    public class IndexVM
    {

        public Header Header {get; set; }

        public List<Service> Services { get; set; }

        public List<Portfolio> Portfolios { get; set; }
        public List<Team> Teams { get; set; }   
        public List<About> Abouts { get; set; }   
    }
}
