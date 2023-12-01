using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Threading.Tasks;

namespace BookStoreBusiness.Business
{
    public class UserBusiness : IUserBusiness
    {
        public readonly IUserRepository userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        nlogOperation nlog = new nlogOperation();
        public Task<int> UserRegistration(UserRegister obj)
        {
            try
            {
                var result = this.userRepository.UserRegistration(obj);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public string UserLogin(string email, string password)
        {
            try
            {
                var result = this.userRepository.UserLogin(email, password);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                var result = this.userRepository.ForgetPassword(email);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public UserRegister ResetPassword(string email, string newpassword, string confirmpassword)
        {
            try
            {
                var result = this.userRepository.ResetPassword(email, newpassword, confirmpassword);
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
