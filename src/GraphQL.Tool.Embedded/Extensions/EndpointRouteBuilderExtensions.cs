using GraphQL.Tool.Embedded;
using GraphQL.Tool.Embedded.Playground;
using GraphQL.Tool.Embedded.Voyager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapGraphQLPlayground(
            this IEndpointRouteBuilder endpoints,
            string requestPath = "/graphql/playground",
            PlaygroundOptions options = default)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            var playgroundPage = new PlaygroundPage(requestPath, options ?? new PlaygroundOptions());

            var staticFileMiddleware = new StaticFileMiddleware(playgroundPage);
            var playgroundMiddleware = new PlaygroundMiddleware(playgroundPage);

            endpoints
                .MapStaticFile(playgroundPage.AssetsPath, staticFileMiddleware.Invoke)
                .MapGet(requestPath, playgroundMiddleware.Invoke);

            return endpoints;
        }

        public static IEndpointRouteBuilder MapGraphQLVoyager(
            this IEndpointRouteBuilder endpoints,
            string requestPath = "/graphql/voyager",
            VoyagerOptions options = default)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            var voyagerPage = new VoyagerPage(requestPath, options ?? new VoyagerOptions());

            var staticFileMiddleware = new StaticFileMiddleware(voyagerPage);
            var voyagerMiddleware = new VoyagerMiddleware(voyagerPage);

            endpoints
                .MapStaticFile(voyagerPage.AssetsPath, staticFileMiddleware.Invoke)
                .MapGet(requestPath, voyagerMiddleware.Invoke);

            return endpoints;
        }

        private static IEndpointRouteBuilder MapStaticFile(this IEndpointRouteBuilder endpoints, string requestPath, RequestDelegate requestDelegate)
        {
            endpoints.MapGet($"{requestPath}/{{*path:file}}", requestDelegate);

            return endpoints;
        }
    }
}
