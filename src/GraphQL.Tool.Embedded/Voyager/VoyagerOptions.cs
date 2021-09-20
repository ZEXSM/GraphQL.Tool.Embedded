using System.Collections.Generic;
using System.Net.Mime;

namespace GraphQL.Tool.Embedded.Voyager
{
    public class VoyagerOptions : ToolOptions
    {
        public VoyagerOptions()
        {
            Headers = new Dictionary<string, object>
            {
                ["Accept"] = MediaTypeNames.Application.Json,
                ["Content-Type"] = MediaTypeNames.Application.Json,
            };
        }
    }
}
