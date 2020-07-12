using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public User User { get; set; }
        public ICollection<History> History { get; set; }
    }
}
