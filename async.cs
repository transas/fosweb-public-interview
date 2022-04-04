using System.Threading.Tasks;

namespace Transas.Examples.Ioc
{
    public interface IDbRepository
    {
        Task Save(string text);
    }

    public class DbRepository : IDbRepository
    {
        public async Task Save(string text)
        {
            // save text to database
        }
    }
}
