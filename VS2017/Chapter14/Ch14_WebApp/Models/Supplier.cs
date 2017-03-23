using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.CS7
{
    [Table("Suppliers")]
    public class Supplier
    {
        public int SupplierID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Supplier's Company Name")]
        public string CompanyName { get; set; }
    }
}
