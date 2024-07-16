using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitectureCQRSMediatRCarter.Contracts;
using VerticalSliceArchitectureCQRSMediatRCarter.Database;
using VerticalSliceArchitectureCQRSMediatRCarter.Entities;
using static VerticalSliceArchitectureCQRSMediatRCarter.Features.CreateBook;

namespace VerticalSliceArchitectureCQRSMediatRCarter.Features
{
    //public static class CreateBook
    //{
    //    public sealed class CreateBookCommand : IRequest<long>
    //    {
    //        public string Name { get; set; } = string.Empty;
    //        public string Description { get; set; } = string.Empty;
    //    }
    //    internal sealed class Handler : IRequestHandler<CreateBookCommand, long>
    //    {
    //        private readonly ApplicationDbContext _dbContext;
    //        public Handler(ApplicationDbContext dbContext)
    //        {
    //            _dbContext = dbContext;
    //        }
    //        public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    //        {
    //            var book = new Book
    //            {
    //                Name = request.Name,
    //                Description = request.Description
    //            };
    //            await _dbContext.AddAsync(book, cancellationToken);
    //            await _dbContext.SaveChangesAsync(cancellationToken);
    //            return book.Id;
    //        }
    //    }
    //}
    //public class CreateBookEndpoint : ICarterModule
    //{
    //    public void AddRoutes(IEndpointRouteBuilder app)
    //    {
    //        app.MapPost("api/books", async (CreateBookCommand request, ISender sender) =>
    //        {
    //            var bookId = await sender.Send(request);
    //            return Results.Ok(bookId);
    //        });
    //    }
    //}

    public static class CreateBook
    {
        public sealed class CreateBookCommand : IRequest<long>
        {
            public CreateBookCommand(string name, string description)
            {
                Name = name;
                Description = description;
            }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
        }
        internal sealed class Handler : IRequestHandler<CreateBookCommand, long>
        {
            private readonly ApplicationDbContext _dbContext;
            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                var book = new Book
                {
                    Name = request.Name,
                    Description = request.Description
                };
                await _dbContext.AddAsync(book, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Id;
            }
        }
        public static void AddEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/books", async (CreateBookRequest request, ISender sender) =>
            {
                // var bookId = await sender.Send(request);
                var bookId = await sender.Send(new CreateBookCommand(
                request.Name,
                request.Description));
                return Results.Ok(bookId);
            });
        }
    }
}
