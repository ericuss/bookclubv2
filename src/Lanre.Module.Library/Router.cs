using Lanre.Module.Library.Application.Books;

using Microsoft.AspNetCore.Builder;

namespace Lanre.Module.Library;

public static class Router
{
    public static void RegisterBookRoutes(this WebApplication app)
    { 
        //const string route = "/api/v{version:apiVersion}/books";
        const string route = "/api/books";

        app.MapGet(route, GetAllBookEndpoint.Handle).RequireAuthorization();
        app.MapGet(route + "/{id}", GetByIdBookEndpoint.Handle).RequireAuthorization();
        app.MapPost(route, CreateBookEndpoint.Handle).RequireAuthorization();
        app.MapPut(route + "/{id}", UpdateBookEndpoint.Handle).RequireAuthorization();
        app.MapDelete(route + "/{id}", DeleteBookEndpoint.Handle).RequireAuthorization();
    }
}