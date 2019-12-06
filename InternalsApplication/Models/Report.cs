namespace InternalsApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Report_ID { get; set; }

        public int? Total { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Percentage { get; set; }

        [StringLength(255)]
        public string USN { get; set; }

        [StringLength(255)]
        public string Teacher_ID { get; set; }

        public int? Dept_No { get; set; }

        [StringLength(255)]
        public string Subject_Code { get; set; }

        public int? Script_ID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Script Script { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
