using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoBookAPI.Model.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please Enter the Book Property")]
        public string Book { get; set; }
        public string Description { get; set; }
    }
}
