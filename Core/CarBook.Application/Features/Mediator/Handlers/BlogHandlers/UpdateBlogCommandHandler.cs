﻿using CarBook.Application.Features.Mediator.Commands.AuthorCommends;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {

        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AuthorID);
            values.CreatedDate=request.CreatedDate;
            values.Title=request.Title;
            values.BlogID=request.BlogID;
            values.AuthorID=request.AuthorID;
            values.CoverImageUrl=request.CoverImageUrl;
            values.CategoryID=request.CategoryID;
            await _repository.UpdateAsync(values);
        }
    }
}
