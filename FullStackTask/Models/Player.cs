using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FullStackTask.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name shouldn't exceed 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name shouldn't exceed 50 characters")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateOfBirth(ErrorMessage ="Player must be 18 years old at least")]
        public DateTime DateOfBirth { get; set; }

        public string Image { get; set; }

        public int Fk_nationalityId { get; set; }

        [ForeignKey(nameof(Fk_nationalityId))]
        public virtual Country Nationality { get; set; }

        public int Fk_teamId { get; set; }

        [ForeignKey(nameof(Fk_teamId))]
        public virtual Team Team { get; set; }
    }
}