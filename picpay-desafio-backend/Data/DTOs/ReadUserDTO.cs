using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Data.DTOs
{
    public class ReadUserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
    }
}