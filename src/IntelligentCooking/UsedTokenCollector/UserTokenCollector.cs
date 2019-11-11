using System;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace UsedTokenCollector
{
    public class UserTokenCollector
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;

        public UserTokenCollector(IIntelligentCookingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FunctionName("UserTokenCollector")]
        public async Task Run([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {
            var expiredTokens = await _unitOfWork.RefreshTokens.GetExpiredTokensAsync();
            _unitOfWork.RefreshTokens.RemoveRange(expiredTokens);

            await _unitOfWork.CommitAsync();

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
