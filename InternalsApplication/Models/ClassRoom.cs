namespace InternalsApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassRoom")]
    public partial class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_No { get; set; }

        public TimeSpan? Duration { get; set; }

        public int? Dept_No { get; set; }

        [StringLength(255)]
        public string Teacher_ID { get; set; }

        [StringLength(255)]
        [ForeignKey("Student")]
        public string USN { get; set; }

        public virtual Department Department { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }
    }
}
