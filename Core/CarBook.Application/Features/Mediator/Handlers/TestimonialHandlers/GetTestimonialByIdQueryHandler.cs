using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResults>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResults> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResults
            {
                Comment=values.Comment,
                Title=values.Title,
                Name=values.Name,
                ImageURL=values.ImageURL,
                TestimonialID = values.TestimonialID
            };
        }
    }
}
