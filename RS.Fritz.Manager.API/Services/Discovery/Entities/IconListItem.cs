#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

public readonly record struct IconListItem(string Mimetype, int Width, int Height, int Depth, string Url);