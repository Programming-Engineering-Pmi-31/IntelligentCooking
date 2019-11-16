using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;

namespace InelligentCooking.BLL.Services
{
    public class LikeService: ILikeService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikeService(IIntelligentCookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddLikesForDishAsync(AddLikeDto addLikeDto, int userId)
        {
            var like = _mapper.Map<Like>(addLikeDto);
            like.UserId = userId;
            _unitOfWork.Likes.Add(like);

            await _unitOfWork.CommitAsync();
        }
    }
}
