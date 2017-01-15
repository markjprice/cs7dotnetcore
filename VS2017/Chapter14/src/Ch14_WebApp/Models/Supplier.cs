using System.ComponentModel.DataAnnotations;

namespace Packt.CS7
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Supplier's Company Name")]
        public string CompanyName { get; set; }
    }
}
