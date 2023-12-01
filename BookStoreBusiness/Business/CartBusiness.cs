using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreBusiness.Business
{
    public class CartBusiness : ICartBusiness
    {
        public readonly ICartRepository cartRepository;
        public CartBusiness(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        nlogOperation nlog = new nlogOperation();
        public Task<int> AddCart(Carts cart, int userId)
        {
            try
            {
                var result = this.cartRepository.AddCart(cart, userId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteCart(int UserId, int BookId)
        {
            try
            {
                var result = this.cartRepository.DeleteCart(UserId, BookId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Carts> GetAllCart(int UserId)
        {
            try
            {
                var result = this.cartRepository.GetAllCart(UserId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateCart(Carts obj, int userId)
        {
            try
            {
                var result = this.cartRepository.UpdateCart(obj, userId);
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
