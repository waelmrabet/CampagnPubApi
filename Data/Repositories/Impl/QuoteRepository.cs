using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Impl
{
    public class QuoteRepository: Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(MyDataBaseContext ctx): base(ctx) {  }
    }
}
