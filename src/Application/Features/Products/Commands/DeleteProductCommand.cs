using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly ApplicationDbContext _context;
        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken) ?? throw new Exception("Product not found!");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
