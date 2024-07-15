using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommends
{
    public class RemoveAuthorCommand:IRequest
    {
        public RemoveAuthorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
