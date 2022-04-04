using System.Threading.Tasks;

namespace Transas.Examples.Ioc
{
    public interface IDbRepository
    {
        void Save(string text);
    }

    public class DbRepository : IDbRepository
    {
        public void Save(string text)
        {
            // save text to database
        }
    }
}
