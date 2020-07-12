using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Toolbooth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [ForeignKey("Location")]
        [Required]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool InUse { get; set; }

        public Location Location { get; set; }

        public ICollection<History> History { get; set; }

    }
}
