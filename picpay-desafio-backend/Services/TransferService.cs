using AutoMapper;
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Data;
using picpay_desafio_backend.Data.DTOs;
using picpay_desafio_backend.Models;
using System.Reflection.Metadata;

namespace picpay_desafio_backend.Services
{
    public class TransferService
    {
        private readonly IMapper _mapper;
        private readonly InMemoryContext _context;

        public TransferService(IMapper mapper, InMemoryContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(CreateTransferDTO createTransferDTO)
        {
            ValidatePayer(createTransferDTO.Payer, createTransferDTO.AmountCur);

            ValidatePayee(createTransferDTO.Payee);
 
            DoTransfer(createTransferDTO);

        }

        public IList<ReadTransferDTO> GetAll()
        {
            return _mapper.ProjectTo<ReadTransferDTO>(_context.Transfer.Select(_ => _)).ToList();
        }

        private void DoTransfer(CreateTransferDTO createTransferDTO)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                Transfer transfer = _mapper.Map<Transfer>(createTransferDTO);
                _context.Transfer.Add(transfer);
                _context.SaveChanges();

                // Payer
                var payer = _context.User.FirstOrDefault(_ => _.Id == createTransferDTO.Payer);
                payer.Balance -= createTransferDTO.AmountCur;
                _context.SaveChanges();

                // Payee
                var payee = _context.User.FirstOrDefault(_ => _.Id == createTransferDTO.Payee);
                payee.Balance += createTransferDTO.AmountCur;
                _context.SaveChanges();

                //throw new Exception("Exceção jogada depois de fazer tudo, porém antes de commitar!");


                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }

        private void ValidatePayee(long id)
        {
            var user = _context.User.FirstOrDefault(_ => _.Id == id);

            if (user == null)
            {
                throw new ArgumentException("Beneficiário inválido!");
            }
        }

        private void ValidatePayer(long id, double amountCur)
        {
            var user = _context.User.FirstOrDefault(_ => _.Id == id);

            if (user == null)
            {
                throw new ArgumentException("Pagador inválido!");
            }

            if (user.Balance - amountCur < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountCur));
            }
        }
    }
}
