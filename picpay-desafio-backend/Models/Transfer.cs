using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Models
{
    public class Transfer
    {
        [Required]
        [Key]
        public long Id { get; set; }

        [Required]
        public long Payer { get; set; }

        [Required]
        public long Payee { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double AmountCur { get; set; }
    }
}
