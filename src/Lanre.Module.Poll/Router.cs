using Lanre.Module.Poll.Application.VoteList;

using Microsoft.AspNetCore.Builder;

namespace Lanre.Module.Poll;

public static class Router
{
    public static void RegisterPollRoutes(this WebApplication app)
    { 
        //const string route = "/api/v{version:apiVersion}/books";
        const string route = "/api/vote-lists";

        app.MapGet(route, GetAllVoteListEndpoint.Handle).RequireAuthorization();
        app.MapGet(route + "/{id}", GetByIdVoteListEndpoint.Handle).RequireAuthorization();
        app.MapPost(route, CreateVoteListEndpoint.Handle).RequireAuthorization();
        app.MapPost(route + "/{id}", VoteEndpoint.Handle).RequireAuthorization();
    }
}