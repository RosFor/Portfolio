using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int releaseYear { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public string notes { get; set; }
    }
}
