using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebApplication.Models
{
    public class CarType
    {
        [Key]
        public int CarTypeID { get; set; }
        [Required]
        [StringLength(20)]
        public string TypeName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}