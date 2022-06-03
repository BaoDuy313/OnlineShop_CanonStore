//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CanonStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Bills = new HashSet<Bill>();
        }

        public int id { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Only letters")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Must be 10 digits ")]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Day Of Birth")]
        public Nullable<System.DateTime> DayOfBirth { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Only letters")]
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        //[RegularExpression("[a-zA-Z0-9]{6}", ErrorMessage = "Must be 6 digits")]
        //[RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).{6,}", ErrorMessage = "Must contain at least 1 number and 1 letter and must be 6 characters")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("DateCreated")]
        public Nullable<System.DateTime> DateCreated { get; set; }
        [DisplayName("Image")]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        [NotMapped]
        [DisplayName("ImageUpload")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}