using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler
{
    public class GetAboutQureyHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQureyHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAboutQueryResult
            {
                AboutID = x.AboutID,
                Description = x.Description,
                Title = x.Title,
                ImageURL = x.ImageURL
            }).ToList();
    
        }
        
    }
}
