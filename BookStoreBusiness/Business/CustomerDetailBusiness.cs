using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Collections.Generic;

namespace BookStoreBusiness.Business
{
    public class CustomerDetailBusiness : ICustomerDetailBusiness
    {
        public readonly ICustomerDetailRepository customerDetailRepository;
        public CustomerDetailBusiness(ICustomerDetailRepository customerDetailRepository)
        {
            this.customerDetailRepository = customerDetailRepository;
        }
        nlogOperation nlog = new nlogOperation();
        public CustomerDetails AddAddress(CustomerDetails customerDetails, int userId)
        {
            try
            {
                var result = this.customerDetailRepository.AddAddress(customerDetails, userId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteAddress(int CustomerId, int UserId)
        {
            try
            {
                var result = this.customerDetailRepository.DeleteAddress(CustomerId, UserId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<CustomerDetails> GetAllAddress(int UserId)
        {
            try
            {
                var result = this.customerDetailRepository.GetAllAddress(UserId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateAddress(CustomerDetails obj, int userId)
        {
            try
            {
                var result = this.customerDetailRepository.UpdateAddress(obj, userId);
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
