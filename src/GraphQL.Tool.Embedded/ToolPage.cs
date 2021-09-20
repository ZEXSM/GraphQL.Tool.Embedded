using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GraphQL.Tool.Embedded
{
    internal abstract class ToolPage
    {
        protected readonly ToolOptions _options;

        public ToolPage(string requestPath, ToolOptions options)
        {
            _options = options;
            AssetsPath = $"{requestPath}/assets";
        }

        public string AssetsPath { get; }

        public async Task<string> RenderAsync()
        {
            using var indexStream = typeof(ToolPage).Assembly.GetManifestResourceStream(GetBaseNamespaceResourse());
            using var streamReader = new StreamReader(indexStream);

            var htmlBuilder = new StringBuilder(await streamReader.ReadToEndAsync());

            foreach (var (key, value) in GetMaps())
            {
                htmlBuilder.Replace(key, value);
            }

            return htmlBuilder.ToString();
        }

        public abstract string GetBaseNamespaceResourse();

        public abstract string GetBaseNamespaceAssets();

        protected virtual Dictionary<string, string> GetMaps() => new()
        {
            [$"%({nameof(AssetsPath)})"] = AssetsPath,
            [$"%({nameof(_options.GraphQLEndPoint)})"] = _options.GraphQLEndPoint,
            [$"%({nameof(_options.Headers)})"] = JsonSerializer.Serialize<object>(_options.Headers),
        };
    }
}
