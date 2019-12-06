namespace InternalsApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Script")]
    public partial class Script
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Script()
        {
            Reports = new HashSet<Report>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Script_ID { get; set; }

        public int? IA1 { get; set; }

        public int? IA2 { get; set; }

        public int? IA3 { get; set; }

        [StringLength(255)]
        public string Teacher_ID { get; set; }

        [StringLength(255)]
        [Display(Name = "Subject")]
        public string Subject_Code { get; set; }

        [StringLength(255)]
        [ForeignKey("Student")]
        public string USN { get; set; }

        
        [ForeignKey("Department")]
        public int? Dept_No { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }

        public virtual Department Department { get; set; }
    }
}
