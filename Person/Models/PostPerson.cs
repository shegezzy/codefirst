using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Models
{
    public class PostPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string stateOfOrigin { get; set; }
        [Required]
        [StringLength(11)]
        public string phoneNumber { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}
