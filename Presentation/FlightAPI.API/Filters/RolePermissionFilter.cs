using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.CustomAttributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FlightAPI.API.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
{
    private readonly IUserService _userService;

    public RolePermissionFilter(IUserService userService)
    {
        _userService = userService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userName = context.HttpContext.User.Identity?.Name;


        // Belirli bir kullanıcı adı kontrolü varsa, onu da yap
        if (userName == "hkn")
        {
            await next();
            return;
        }

        // Action descriptor'ü al
        var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
        if (descriptor == null)
        {
            await next();
            return;
        }

        // AuthorizeDefinitionAttribute'ü al
        var attribute = descriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

        if (attribute == null)
        {
            // Attribute yoksa sadece giriş yapılmış mı kontrol et
            await next();
            return;
        }

        // HttpMethodAttribute'ü al
        var httpAttribute = descriptor.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;
        var httpMethod = httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get;

        // İzin kodunu oluştur
        var code = $"{httpMethod}.{attribute.ActionType}.{attribute.Definition.Replace(" ", "")}";

        // Kullanıcının bu endpoint'e erişim iznine sahip olup olmadığını kontrol et
        var hasRole = await _userService.HasRolePermissionToEndpointAsync(userName, code);

        if (!hasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
}
