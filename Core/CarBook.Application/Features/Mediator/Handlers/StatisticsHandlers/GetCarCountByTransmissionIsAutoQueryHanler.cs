using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByTransmissionIsAutoQueryHanler : IRequestHandler<GetCarCountByTransmissionIsAutoQuery, GetCarCountBtTransmissionIsAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByTransmissionIsAutoQueryHanler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountBtTransmissionIsAutoQueryResult> Handle(GetCarCountByTransmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTransmissionIsAuto();
            return new GetCarCountBtTransmissionIsAutoQueryResult
            {
                CarCountByTransmissionIsAuto = value,
            };
        }
    }
}
