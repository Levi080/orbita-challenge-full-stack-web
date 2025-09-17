
using System.ComponentModel.DataAnnotations;

namespace AmaisEducacao.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email field is required")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The email field is required")]
        [StringLength(50, ErrorMessage = "O RA deve ter no máximo 50 caracteres.")]
        public string RA { get; set; }

        [Required(ErrorMessage = "The CPF field is required")]
        [StringLength(14, ErrorMessage = "O CPF deve ter no máximo 14 caracteres.")]
        public string CPF { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeletionDate { get; set; }
    }
}
