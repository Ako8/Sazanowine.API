using Sazanowine.Domain.Exceptions;
using System.Net;

namespace Sazanowine.API.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next.Invoke(context);
		}
		catch (NotFoundException notFound)
		{
			context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			await context.Response.WriteAsync(notFound.Message);
		}
		catch (ForbidException)
		{
			context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
			await context.Response.WriteAsync("Access forbidden");
		}
        catch (Exception ex)
		{
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			await context.Response.WriteAsync($"Error: {ex.Message}");
		}
	}
} 
