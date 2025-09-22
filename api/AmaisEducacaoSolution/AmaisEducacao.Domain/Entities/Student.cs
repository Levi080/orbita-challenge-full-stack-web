
using System.ComponentModel.DataAnnotations;

namespace AmaisEducacao.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required")]
        [StringLength(100, ErrorMessage = "The name must be a maximum of 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email field is required")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The email field is required")]
        [StringLength(50, ErrorMessage = "The RA must have a maximum of 50 characters.")]
        public string RA { get; set; }

        [Required(ErrorMessage = "The CPF field is required")]
        [StringLength(14, ErrorMessage = "The CPF must have a maximum of 14 characters.")]
        public string CPF { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
