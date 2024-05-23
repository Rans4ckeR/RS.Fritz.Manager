namespace RS.Fritz.Manager.API;

internal interface IFritzService : IAsyncDisposable
{
    static abstract string ControlUrl { get; }
}