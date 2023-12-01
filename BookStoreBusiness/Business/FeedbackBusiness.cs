using BookStoreBusiness.IBusiness;
using BookStoreCommon;
using BookStoreRepository.IRepository;
using NlogImplemantation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreBusiness.Business
{
    public class FeedbackBusiness : IFeedbackBusiness
    {
        nlogOperation nlog = new nlogOperation();
        public readonly IFeedbackRepository feedbackRepository;
        public FeedbackBusiness(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }
       
        public Task<int> AddFeedback(Feedbacks feedback, int userId)
        {
            try
            {
                var result = this.feedbackRepository.AddFeedback(feedback, userId);
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogWarn(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Feedbacks> GetAllFeedback(int UserId)
        {
            try
            {
                var result = this.feedbackRepository.GetAllFeedback(UserId);
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
