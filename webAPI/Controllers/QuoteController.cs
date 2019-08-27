using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using webAPI.Models;
using API_DAL.DBContext;
using webAPI.ExceptionHandle;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace webAPI.Controllers
{
    [Authorize]
    public class QuoteController : ApiController
    {
        // GET: Quote

        private ElvisAPIEntities dbcontext = new ElvisAPIEntities();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbcontext.Dispose();
            }
            base.Dispose(disposing);
        }
        public IHttpActionResult Get()
        {

            IList<Quote> quotes = null;

            using (/*ElvisAPIEntities dbcontext = new ElvisAPIEntities()*/dbcontext)
            {
                quotes = dbcontext.Set<tblQuote>().Select(x => new Quote
                {
                    ID = x.ID,
                    QuoteNum = x.QuoteNum,
                    Company = x.Company,
                    Price = x.Price,
                    ExpireDate = x.ExpireDate,
                    Description = x.Description
                }).ToList();
            }
            if (quotes.Count == 0)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("There is no quote in the database!")
                };
                throw new HttpResponseException(message);
                //return this.NotFound("There is no quote in the database!");
            }
            return Ok(quotes);
        }

        public IHttpActionResult Get(int id)
        {
            Quote outputQuote = new Quote();
            //ElvisAPIEntities dbcontext = new ElvisAPIEntities();
            //tblQuote searchQuote = dbcontext.Set<tblQuote>().Find(id);
            List<tblQuote> searchQuotes = dbcontext.GetQuoteByID(id).ToList();
            if(searchQuotes.Count == 0)
            {
                int count = dbcontext.Set<tblQuote>().Count();
                if(id > dbcontext.Set<tblQuote>().ToList()[count-1].ID)
                {
                    var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Given ID is out of index!")
                    };
                    throw new HttpResponseException(message);
                    //return this.NotFound("Given ID is out of index!");
                }
                else
                {
                    var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("No such quote with ID: " + id)
                    };
                    throw new HttpResponseException(message);
                    //return this.NotFound("No such quote with ID: " + id);
                }
            }
            else
            {
                outputQuote.ID = searchQuotes.First().ID;
                outputQuote.QuoteNum = searchQuotes.First().QuoteNum;
                outputQuote.Company = searchQuotes.First().Company;
                outputQuote.Price = searchQuotes.First().Price;
                outputQuote.ExpireDate = searchQuotes.First().ExpireDate;
                outputQuote.Description = searchQuotes.First().Description;
            }
            return Ok(outputQuote); 
        }

        public IHttpActionResult Post([FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            //ElvisAPIEntities dbcontext = new ElvisAPIEntities();
            dbcontext.tblQuotes.Add(new tblQuote()
            {
                ID = quote.ID,
                QuoteNum = quote.QuoteNum,
                Company = quote.Company,
                Price = quote.Price,
                ExpireDate = quote.ExpireDate,
                Description = quote.Description
            });
            Debugger.NotifyOfCrossThreadDependency();
            dbcontext.SaveChanges();
            //return Ok();
            return CreatedAtRoute("DefaultApi", new { id = quote.ID }, quote);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid quote!");
            //ElvisAPIEntities dbcontext = new ElvisAPIEntities();
            var existQuote = dbcontext.tblQuotes.Where(q => q.ID == quote.ID).FirstOrDefault<tblQuote>();
            if (existQuote != null)
            {
                existQuote.QuoteNum = quote.QuoteNum;
                existQuote.Company = quote.Company;
                existQuote.Price = quote.Price;
                existQuote.ExpireDate = quote.ExpireDate;
                existQuote.Description = quote.Description;
                dbcontext.SaveChanges();
            }
            else
            {
                return this.NotFound("Not a valid quote!");
            }
            return Ok();  
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid quote ID!");
            //ElvisAPIEntities dbcontext = new ElvisAPIEntities();
            var quote = dbcontext.Set<tblQuote>().Find(id);
            dbcontext.Entry(quote).State = System.Data.Entity.EntityState.Deleted;
            dbcontext.SaveChanges();
            return Ok();
        }

    }
}