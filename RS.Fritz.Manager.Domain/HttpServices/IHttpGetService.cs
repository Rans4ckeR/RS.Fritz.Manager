namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Threading.Tasks;

    public interface IHttpGetService
    {
        Task<string> GetHttpResponse(Uri uri);
    }
}