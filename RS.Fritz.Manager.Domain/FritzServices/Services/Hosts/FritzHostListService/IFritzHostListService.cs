namespace RS.Fritz.Manager.Domain
{
    using System.Threading.Tasks;

    public interface IFritzHostListService
    {
        Task<string> GetHttpResponseAsync();
    }
}