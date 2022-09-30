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


    public partial class Discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Discount()
        {
            this.Bills = new HashSet<Bill>();
        }

        [Required]
        [DisplayName("Code")]
        public string Dis_Code { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Dis_Description { get; set; }
        [Required]
        [DisplayName("Date Start")]
        public Nullable<System.DateTime> Date_Start { get; set; }
        [Required]
        [DisplayName("Date End")]
        public Nullable<System.DateTime> Date_End { get; set; }
        [Required]
        [DisplayName("Value")]
        public Nullable<int> Discount_Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
