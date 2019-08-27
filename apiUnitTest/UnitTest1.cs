using System;
using System.Net.Http;
using System.Web.Http.Results;
using API_DAL.DBContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webAPI.Controllers;
using webAPI.Models;

namespace apiUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QuoteGetByIDSuccess()
        {
            var qc = new QuoteController();
            //qc.Request = new HttpRequestMessage();
            //qc.Configuration = new System.Web.Http.HttpConfiguration();


            var q = qc.Get(1);
            var qResult = q as OkNegotiatedContentResult<tblQuote>;
            Assert.IsNotNull(qResult);
            Assert.IsNotNull(qResult.Content);
            Assert.AreEqual("ABC Painting & Renovators", qResult.Content.Company);
        }
    }
}
