using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResults>
    {
        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
