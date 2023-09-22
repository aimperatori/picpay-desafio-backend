using Microsoft.AspNetCore.Mvc;
using picpay_desafio_backend.Data.DTOs;
using picpay_desafio_backend.Services;

namespace picpay_desafio_backend.Controllers
{
    [ApiController]
    [Route("transaction")]
    public class TransferController : ControllerBase
    {
        private readonly TransferService _tranferService;

        public TransferController(TransferService tranferService)
        {
            _tranferService = tranferService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tranferService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateTransferDTO createTransferDTO)
        {
            _tranferService.Create(createTransferDTO);

            return Ok("Transferencia criada!");
        }


    }
}
