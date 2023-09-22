using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Data.DTOs
{
    public class CreateTransferDTO
    {
        [Required]
        public long Payer { get; set; }

        [Required]
        public long Payee { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public double AmountCur { get; set; }
    }
}
