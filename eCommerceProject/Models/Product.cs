using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProject.Models
{
    public class Product
    {
        /// <summary>
        /// A salable product
        /// </summary>

        [Key] // Make Primary Key in DB
        public int ProductID { get; set; }

        /// <summary>
        /// Consumer facing name of product
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Retail price as US currency
        /// </summary>
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        /// <summary>
        /// Category product falls under. Ex. Electronics, furniture, etc.
        /// </summary>
        public string Category { get; set; }
    }
}
