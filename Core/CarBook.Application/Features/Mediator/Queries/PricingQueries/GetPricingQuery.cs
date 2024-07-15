﻿using CarBook.Application.Features.Mediator.Results.PricingResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery:IRequest<List<GetPricingQueryResult>>
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
    }
}
