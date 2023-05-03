using Fruityvice.Model.RequestModel;
using Fruityvice.Model.ResponseModel;

namespace Fruityvice.Service
{
    public interface IFruityVoiceService
    {
        Task<List<FruityResponseModel>> GetFruityDetailList();
        Task<List<FruityResponseModel>> GetFruityDetailsByFamily(FruitySearchRequestModel fruitySearchRequestModel);
    }
}