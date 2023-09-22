using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Data.DTOs
{
    public class CreateUserDTO
    {

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
        public double Balance { get; set; }
    }
}
