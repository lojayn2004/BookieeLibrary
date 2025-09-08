using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Books.Student
{
    public class BorrowBookDto
    {
        [Required]
        public string BookIsbn { get; set; } = string.Empty;

        [Required]
        public string StudentUniverstyId { get; set; } = string.Empty; 

    }
}
