    /// <summary>
    /// This content class contains all authentication methods (User Basic, Token, Signature)
    /// </summary>
using System;
using webapi.Models;
using Microsoft.AspNetCore.Mvc;
namespace webapi.Services;

public class AutenticationMiddleware
{
    readonly RequestDelegate next;

    private readonly ILogger<AutenticationMiddleware> _logger;

    public AutenticationMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {

        if (context.Request.Headers.Any(p => p.Key == "Authorization"))
        {
            string[] auth = context.Request.Headers["Authorization"].ToString().Split(' ');
            if (auth.Length > 1 && isAuthBasic(auth[1]))
            {
                await next(context);
            }
            else
            {
                MessageException ex = new MessageException("User Unauthorized", "User not found", "0");
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(ex);
            }

        }
        else
        {
            MessageException ex = new MessageException("User Forbidden", "Your account to be unlocked", "0");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(ex);
        }


    }

    public bool isAuthBasic(string basicAuth)
    {
        var builder = WebApplication.CreateBuilder();
        var base64EncodedBytes = System.Convert.FromBase64String(basicAuth);
        string userDecode = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        string userConfig = builder.Configuration["AuthBasic:User"];
        string passConfig = builder.Configuration["AuthBasic:Password"];

        if (userConfig == userDecode.Split(':')[0] && passConfig == userDecode.Split(':')[1])
            return true;

        return false;
    }
}


public static class AutenticationMiddlewareExtension
{
    public static IApplicationBuilder UseAutenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AutenticationMiddleware>();
    }
}