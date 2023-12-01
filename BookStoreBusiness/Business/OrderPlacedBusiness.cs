using BookStoreBusiness.IBusiness;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Threading.Tasks;

namespace BookStoreBusiness.Business
{
    public class OrderPlacedBusiness : IOrderPlacedBusiness
    {
        public readonly IOrderPlacedRepository orderPlacedRepository;
        public OrderPlacedBusiness(IOrderPlacedRepository orderPlacedRepo)
        {
            this.orderPlacedRepository = orderPlacedRepo;
        }
        nlogOperation nlog = new nlogOperation();
        public Task<int> PlaceOrder(int UserId, int CartId, int CustomerId)
        {
            try
            {
                var result = this.orderPlacedRepository.PlaceOrder(UserId, CartId, CustomerId);
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
