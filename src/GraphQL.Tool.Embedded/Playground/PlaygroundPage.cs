using System.Collections.Generic;
using System.Text.Json;

namespace GraphQL.Tool.Embedded.Playground
{
    internal class PlaygroundPage : ToolPage
    {
        public PlaygroundPage(string requestPath, PlaygroundOptions options)
            : base(requestPath, options)
        {
        }
        public override string GetBaseNamespaceResourse() =>
            "GraphQL.Tool.Embedded.Playground.index.html";

        public override string GetBaseNamespaceAssets() =>
            "GraphQL.Tool.Embedded.Playground.Assets";

        protected override Dictionary<string, string> GetMaps()
        {
            var maps = base.GetMaps();

            var playgroundOptions = (PlaygroundOptions)_options;

            maps.Add($"%({nameof(playgroundOptions.SubscriptionsEndPoint)})", playgroundOptions.SubscriptionsEndPoint);
            maps.Add($"%({nameof(playgroundOptions.Config)})", JsonSerializer.Serialize<object>(playgroundOptions.Config));
            maps.Add($"%({nameof(playgroundOptions.Settings)})", JsonSerializer.Serialize<object>(playgroundOptions.Settings));

            return maps;
        }
    }
}
