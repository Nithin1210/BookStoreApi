using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreBusiness.Business
{
    public class BookBusiness : IBookBusiness
    {
        public readonly IBookRepository bookRepository;
        public BookBusiness(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        nlogOperation nlog = new nlogOperation();
        public Task<int> AddBook(Books obj)
        {
            try
            {
                var result = this.bookRepository.AddBook(obj);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Books> GetAllBooks()
        {
            try
            {
                var result = this.bookRepository.GetAllBooks();
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateBook(Books obj)
        {
            try
            {
                var result = this.bookRepository.UpdateBook(obj);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteBook(int BookId)
        {
            try
            {
                var result = this.bookRepository.DeleteBook(BookId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        public IEnumerable<Books> GetBookById(int BookId)
        {
            try
            {
                var result = this.bookRepository.GetBookById(BookId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
