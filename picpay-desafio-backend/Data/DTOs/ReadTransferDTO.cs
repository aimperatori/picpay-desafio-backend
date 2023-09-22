using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Data.DTOs
{
    public class ReadTransferDTO
    {
        public long Id { get; set; }
        public long Payer { get; set; }
        public long Payee { get; set; }
        public double AmountCur { get; set; }
    }
}
