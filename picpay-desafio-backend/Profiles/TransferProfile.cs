using AutoMapper;
using picpay_desafio_backend.Data.DTOs;
using picpay_desafio_backend.Models;

namespace picpay_desafio_backend.Profiles
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {
            CreateMap<CreateTransferDTO, Transfer>();
            CreateMap<Transfer, ReadTransferDTO>();
        }
    }
}
