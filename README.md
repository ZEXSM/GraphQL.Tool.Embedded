# GraphQL.Tool.Embedded
Library of GraphQL tools such as GraphQL Playground and GraphQL Voyager.

[![Build Status](https://travis-ci.com/ZEXSM/GraphQL.Tool.Embedded.svg?branch=main)](https://travis-ci.com/ZEXSM/GraphQL.Tool.Embedded)
[![Nuget Status](https://img.shields.io/nuget/dt/GraphQL.Tool.Embedded.svg)](https://www.nuget.org/packages/GraphQL.Tool.Embedded)

## Usage

Default use

```csharp
app.UseEndpoints(endpoints =>
{
    ...
    endpoints.MapGraphQLPlayground();
    endpoints.MapGraphQLVoyager();
});
```

Using with settings

```csharp
app.UseEndpoints(endpoints =>
{
    ...
    // https://github.com/graphql/graphql-playground#settings
    var playgroundOptions = PlaygroundOptions
    {
        ...
    }

    // https://github.com/APIs-guru/graphql-voyager#properties
    var voyagerOptions = VoyagerOptions
    {
        ...
    }

    endpoints.MapGraphQLPlayground("/ui/playground", playgroundOptions);
    endpoints.MapGraphQLVoyager("/ui/voyager", VoyagerOptions);
});
```