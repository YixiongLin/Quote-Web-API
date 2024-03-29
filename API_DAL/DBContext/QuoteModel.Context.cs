﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_DAL.DBContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ElvisAPIEntities : DbContext
    {
        public ElvisAPIEntities()
            : base("name=ElvisAPIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblQuote> tblQuotes { get; set; }
    
        public virtual ObjectResult<tblQuote> GetQuoteByID(Nullable<int> quoteID)
        {
            var quoteIDParameter = quoteID.HasValue ?
                new ObjectParameter("QuoteID", quoteID) :
                new ObjectParameter("QuoteID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblQuote>("GetQuoteByID", quoteIDParameter);
        }
    
        public virtual ObjectResult<tblQuote> GetQuoteByID(Nullable<int> quoteID, MergeOption mergeOption)
        {
            var quoteIDParameter = quoteID.HasValue ?
                new ObjectParameter("QuoteID", quoteID) :
                new ObjectParameter("QuoteID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblQuote>("GetQuoteByID", mergeOption, quoteIDParameter);
        }
    }
}
