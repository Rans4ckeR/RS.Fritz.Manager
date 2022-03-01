namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Threading.Tasks;

    public interface IFritzHttpOperationHandler
    {
        Task<string> GetHostsGetHostListAsync(Uri uri);
    }
}