using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage ="Foundation date is required")]
        [FoundationDate(ErrorMessage = "Foundation date must be before now")]
        public DateTime FoundationDate { get; set; }

        public string CoachName { get; set; }

        public string LogoImage { get; set; }

        public int Fk_countryId { get; set; }
        
        [ForeignKey(nameof(Fk_countryId))]
        public virtual Country Country { get; set; }

        public virtual List<Player> Players { get; set; }
    }
}