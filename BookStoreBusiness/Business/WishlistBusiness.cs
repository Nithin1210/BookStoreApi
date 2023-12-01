using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreBusiness.Business
{
    public class WishlistBusiness : IWishlistBusiness
    {
        public readonly IWishlistRepository wishlistRepository;
        public WishlistBusiness(IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        nlogOperation nlog = new nlogOperation();
        public Task<int> AddWishlist(Wishlist wishlist, int userId)
        {
            try
            {
                var result = this.wishlistRepository.AddWishlist(wishlist, userId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteWishlist(int UserId, int BookId)
        {
            try
            {
                var result = this.wishlistRepository.DeleteWishlist(UserId, BookId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Wishlist> GetAllWishList(int UserId)
        {
            try
            {
                var result = this.wishlistRepository.GetAllWishList(UserId);
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
