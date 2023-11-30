using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVYmodaONLINE.Models.EF
{
    [Table("tb_ProductCategory")]
    public class Productcategory : CommonAbstract
    {
        public Productcategory()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string alias { get; set; }
        public string Description { get; set; }
        [StringLength(250)]
        public string icon { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}