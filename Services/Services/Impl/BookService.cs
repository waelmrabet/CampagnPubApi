using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfwork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        
    }
}
