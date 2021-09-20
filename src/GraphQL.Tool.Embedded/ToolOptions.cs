using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GraphQL.Tool.Embedded
{
    public abstract class ToolOptions
    {
        public PathString GraphQLEndPoint { get; set; } = "/graphql";

        public Dictionary<string, object> Headers { get; set; }
    }
}
