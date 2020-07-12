using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class History
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Toolbooth")]
        public int ToolboothId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public float Value { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        [NotMapped]
        public Location Location { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public Employee Employee { get; set; }
        public Toolbooth Toolbooth { get; set; }

    }
}
