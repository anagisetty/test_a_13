using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using test_a_13;

public class LambdaController : ApiController
{
    // GET api/lambda
    public IHttpActionResult Get()
    {
        var result = Enumerable.Range(1, 10)
            .Select(x => Math.Pow(x, 2))
            .ToList();

        return Ok(result);
    }

    // POST api/lambda
    public async Task<IHttpActionResult> Post([FromBody]int[] array)
    {
        if (array == null)
            return BadRequest();

        var result = await Task.Run(() => array
            .Select(x => Math.Pow(x, 2))
            .ToList());

        return Ok(result);
    }
}