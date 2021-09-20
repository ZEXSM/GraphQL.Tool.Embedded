using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using System;
using System.Threading.Tasks;

namespace GraphQL.Tool.Embedded
{
    internal class StaticFileMiddleware
    {
        private readonly IFileProvider _fileProvider;

        public StaticFileMiddleware(ToolPage toolPage) =>
            _fileProvider = new EmbeddedFileProvider(typeof(StaticFileMiddleware).Assembly, toolPage.GetBaseNamespaceAssets());

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var fileName = httpContext.GetRouteValue("path").ToString();

            var fileInfo = _fileProvider.GetFileInfo(fileName);

            if (!fileInfo.Exists)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                httpContext.Response.Headers.Add("Cache-Control", "public,max-age=300");

                using var fileStream = fileInfo.CreateReadStream();

                await fileStream.CopyToAsync(httpContext.Response.Body);
            }
        }
    }
}
