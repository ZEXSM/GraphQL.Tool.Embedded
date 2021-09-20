using System.Collections.Generic;

namespace GraphQL.Tool.Embedded.Voyager
{
    internal class VoyagerPage : ToolPage
    {
        public VoyagerPage(string requestPath, VoyagerOptions options)
            : base(requestPath, options)
        {
        }

        public override string GetBaseNamespaceResourse() =>
            "GraphQL.Tool.Embedded.Voyager.index.html";

        public override string GetBaseNamespaceAssets() =>
            "GraphQL.Tool.Embedded.Voyager.Assets";

        protected override Dictionary<string, string> GetMaps() =>
            base.GetMaps();
    }
}
