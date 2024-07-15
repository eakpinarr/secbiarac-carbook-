using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandler
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x=> new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Email=x.Email,
                Message = x.Message,
                Subject = x.Subject,
                Name = x.Name,
                SendDate=x.SendDate,
            }).ToList();
        }
    }
}
