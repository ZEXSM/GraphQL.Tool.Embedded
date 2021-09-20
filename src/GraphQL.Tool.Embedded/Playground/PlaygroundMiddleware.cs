namespace GraphQL.Tool.Embedded.Playground
{
    internal class PlaygroundMiddleware : ToolMiddleware
    {
        public PlaygroundMiddleware(PlaygroundPage playgroundPage)
            : base(playgroundPage)
        {
        }
    }
}
