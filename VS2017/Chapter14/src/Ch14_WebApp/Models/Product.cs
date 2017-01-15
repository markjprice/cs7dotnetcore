using System.ComponentModel.DataAnnotations;

namespace Packt.CS7
{
    public class Product
    {
        [Display(Name = "ID")]
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Units In Stock")]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
