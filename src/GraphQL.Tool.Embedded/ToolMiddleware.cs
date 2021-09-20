using Microsoft.AspNetCore.Http;
using System;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Tool.Embedded
{
    internal abstract class ToolMiddleware
    {
        private readonly ToolPage _toolPage;

        public ToolMiddleware(ToolPage toolPage) =>
            _toolPage = toolPage ?? throw new ArgumentNullException(nameof(toolPage));

        public virtual async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var page = await _toolPage.RenderAsync();

            httpContext.Response.ContentType = MediaTypeNames.Text.Html;
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            httpContext.Response.Headers.Add("Cache-Control", "public,max-age=300");

            await httpContext.Response.WriteAsync(page, Encoding.UTF8);
        }
    }
}
