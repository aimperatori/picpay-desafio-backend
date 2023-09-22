using picpay_desafio_backend.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Models
{
    public class User
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CpfCnpj { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public UserType Type { get; set; }

        public double Balance { get; set; }
    }
}
