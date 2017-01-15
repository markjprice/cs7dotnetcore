using System.Collections.Generic;

namespace Packt.CS7
{
    public class HomeIndexViewModel
    {
        public int VisitorCount;
        public ICollection<Product> Products { get; set; }
    }
}
