using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using picpay_desafio_backend.Data;
using picpay_desafio_backend.Data.DTOs;
using picpay_desafio_backend.Models;

namespace picpay_desafio_backend.Service
{
    public class UserService
    {
        private readonly InMemoryContext _context;
        private readonly IMapper _mapper;
        public UserService(InMemoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUser(CreateUserDTO createUserDTO)
        {
            User user = _mapper.Map<User>(createUserDTO);
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public ReadUserDTO GetUser(long id)
        {
            User? user = _context.User.FirstOrDefault(_ => _.Id == id);

            return _mapper.Map<ReadUserDTO>(user);
        }

        public IList<ReadUserDTO> GetAllUser()
        {
            return _mapper.ProjectTo<ReadUserDTO>(_context.User.Select(_ => _)).ToList();
        }
    }
}
