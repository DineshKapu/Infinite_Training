using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10.Models;
namespace CC10.Controllers
{
    [RoutePrefix("api/Country")]

    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "US", Capital = "Washington" },

        };
        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> GetAllCountries()
        {
            return countries;
        }
        [HttpGet]
        [Route("Bymsg")]
        public HttpResponseMessage GetCountriesWithMessage()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countries);
            return response;
        }
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetCountryById(int pId)
        {
            Country country = countries.SingleOrDefault(c => c.ID == pId);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country.CountryName);
        }
        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostCountry([FromBody] Country country)
        {
            countries.Add(country);
            return countries;
        }

        [HttpPost]
        [Route("countrypost")]
        public IEnumerable<Country> PostCountryByParams([FromUri] int Id, string name, string capital)
        {
            Country country = new Country
            {
                ID = Id,
                CountryName = name,
                Capital = capital
            };
            countries.Add(country);
            return countries;
        }
        [HttpPut]
        [Route("countryput")]
        public IHttpActionResult PutCountry(int pid, [FromBody] Country updatedCountry)
        {
            if (updatedCountry == null)
                return BadRequest("Updated country data is missing.");

            var country = countries.FirstOrDefault(c => c.ID == pid);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;

            return Ok(countries);
        }

        [HttpDelete]
        [Route("delcountry")]
        public IEnumerable<Country> DeleteCountry(int pid)
        {
            Country countryToRemove = countries.SingleOrDefault(c => c.ID == pid);
            if (countryToRemove != null)
            {
                countries.Remove(countryToRemove);
            }
            return countries;
        }

    }
}
