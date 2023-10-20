using Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class CreateUpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    public class CreateUpdateProductCommandHandler : IRequestHandler<CreateUpdateProductCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateUpdateProductCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateUpdateProductCommand command, CancellationToken cancellationToken)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (command.Id == 0)
            {
                var mappedProduct = _mapper.Map<Product>(command);
                await _context.Products.AddAsync(mappedProduct, cancellationToken);
            }
            else
            {
                var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken: cancellationToken) ?? throw new Exception("Product not found!");
                _mapper.Map(command, dbProduct);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return command.Id;
        }

    }
}
