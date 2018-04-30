using SpokdTechnicalTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SpokdTechnicalTest.Controllers
{
    [EnableCors(origins: "http://localhost:54378", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetNumber"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetPrimeNumbers(int id)
        {
            var primeNumberViewModel = new PrimeNumberViewModel();

            var primeNumbers = Enumerable.Range(1, Convert.ToInt32(Math.Floor(Math.Sqrt(id))))
                .Aggregate(Enumerable.Range(1, id).ToList(),
                    (result, index) =>
                    {
                        result.RemoveAll(i => i > result[index] && i % result[index] == 0);
                        return result;
                    }
            );

            primeNumberViewModel.TargetNumber = id;
            primeNumberViewModel.PrimeNumbers = primeNumbers;

            return Ok(primeNumberViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult AltGetPrimeNumbers(int id)
        {
            var primeNumberViewModel = new PrimeNumberViewModel();

            var primeNumbers = Enumerable.Range(1, (int)Math.Floor(2.52 * Math.Sqrt(id) / Math.Log(id))).Aggregate(
                 Enumerable.Range(1, id).ToList(),
                 (result, index) =>
                 {
                     var bp = result[index]; var sqr = bp * bp;
                     result.RemoveAll(i => i >= sqr && i % bp == 0);
                     return result;
                 }
             );

            primeNumberViewModel.TargetNumber = id;
            primeNumberViewModel.PrimeNumbers = primeNumbers;

            return Ok(primeNumberViewModel);
        }

    }
}
