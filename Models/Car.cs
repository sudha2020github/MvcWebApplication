using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcWebApplication.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string OwnerLastName { get; set; }

        [Required]
        public string ImageFile { get; set; }        
        
        /// <summary>
        /// Thiis field might be helpful for future reports 
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Inventory Date")]
        public DateTime RecordCreationDate { get; set; }

        [Required]
        public virtual int CarTypeID { get; set; }
        public virtual string Description{ get; set; }
    }
}