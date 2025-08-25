using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CC9_Question_2.Models
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }
    }
}