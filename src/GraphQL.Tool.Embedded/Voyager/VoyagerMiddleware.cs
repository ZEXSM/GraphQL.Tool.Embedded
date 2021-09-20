namespace GraphQL.Tool.Embedded.Voyager
{
    internal class VoyagerMiddleware : ToolMiddleware
    {
        public VoyagerMiddleware(VoyagerPage voyagerPage)
            : base(voyagerPage)
        {
        }
    }
}
