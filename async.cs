using System.Threading.Tasks;

namespace Transas.Examples.Api
{
    public MyController : ApiController 
    {
        public async Task<IHttpActionResult> ExampleMethodAsync()
        {
            var res1 = await LoadDataFromDatabase();

            res1++;

            var res2 = await SaveDataToDatabase(res1);

            return Ok(res2);
        }
    }
}
