using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Collections.Generic;

namespace BookStoreBusiness.Business
{
    public class OrderSummaryBusiness : IOrderSummaryBusiness
    {
        public readonly IOrderSummaryRepository orderSummaryRepository;
        public OrderSummaryBusiness(IOrderSummaryRepository orderSummaryRepository)
        {
            this.orderSummaryRepository = orderSummaryRepository;
        }
        nlogOperation nlog = new nlogOperation();
        public IEnumerable<SummaryOrder> GetOrderSummary(int UserId, int OrderId)
        {
            try
            {
                var result = this.orderSummaryRepository.GetOrderSummary(UserId, OrderId);
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
