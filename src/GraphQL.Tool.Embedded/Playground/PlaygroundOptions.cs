using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GraphQL.Tool.Embedded.Playground
{
    public class PlaygroundOptions : ToolOptions
    {
        public PathString SubscriptionsEndPoint { get; set; } = "/graphql";

        public Dictionary<string, object> Config { get; set; }

        public Dictionary<string, object> Settings { get; set; } = new()
        {
            ["editor.cursorShape"] = "line",
            ["editor.theme"] = "light",
            ["schema.polling.enable"] = false,
            ["tracing.tracingSupported"] = false,
        };
    }
}
