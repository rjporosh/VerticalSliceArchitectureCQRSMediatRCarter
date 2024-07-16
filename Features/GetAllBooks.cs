using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitectureCQRSMediatRCarter.Contracts;
using VerticalSliceArchitectureCQRSMediatRCarter.Database;
using VerticalSliceArchitectureCQRSMediatRCarter.Entities;

namespace VerticalSliceArchitectureCQRSMediatRCarter.Features
{
    //public static class GetAllBooks
    //{
    //    public sealed class Query : IRequest<List<Book>>
    //    {
    //    }
    //    internal sealed class QueryHandler : IRequestHandler<Query, List<Book>>
    //    {
    //        private readonly ApplicationDbContext _dbContext;
    //        public QueryHandler(ApplicationDbContext dbContext)
    //        {
    //            _dbContext = dbContext;
    //        }
    //        public async Task<List<Book>> Handle(Query request, CancellationToken cancellationToken)
    //            => await _dbContext.Books.ToListAsync(cancellationToken: cancellationToken);
    //    }
    //}
    //public class GetAllBooksEndpoint : ICarterModule
    //{
    //    public void AddRoutes(IEndpointRouteBuilder app)
    //    {
    //        app.MapGet("api/books", async (ISender sender) =>
    //        {
    //            var books = await sender.Send(new GetAllBooks.Query());
    //            return Results.Ok(books);
    //        });
    //    }
    //}


    public static class GetAllBooks
    {
        public sealed class Query : IRequest<List<Book>>
        {
        }
        internal sealed class QueryHandler : IRequestHandler<Query, List<Book>>
        {
            private readonly ApplicationDbContext _dbContext;
            public QueryHandler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<List<Book>> Handle(Query request, CancellationToken cancellationToken)
                => await _dbContext.Books.ToListAsync(cancellationToken: cancellationToken);
        }
        public static void AddEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/books", async (ISender sender) =>
            {
                var books = await sender.Send(new GetAllBooks.Query());
                return Results.Ok(books);
            });
        }
    }
}
