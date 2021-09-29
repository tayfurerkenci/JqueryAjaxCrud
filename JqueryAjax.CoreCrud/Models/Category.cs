using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JqueryAjax.CoreCrud.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }


        public int CategoryId { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
