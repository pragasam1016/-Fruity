using Fruityvice.Model.RequestModel;
using Fruityvice.Model.ResponseModel;
using FruityVice.DataAccess;

namespace Fruityvice.Service
{
    public class FruityVoiceService : IFruityVoiceService
    {
        private readonly FruityViceDbContext _fruityViceDbContext;

        public FruityVoiceService( FruityViceDbContext fruityViceDbContext)
        {
            _fruityViceDbContext = fruityViceDbContext;
        }

        public async Task<List<FruityResponseModel>> GetFruityDetailList()
        {
            List<FruityResponseModel> fruityResponseModels = (from fruity in _fruityViceDbContext.Fruities.AsQueryable()
                                                              join nutrition in _fruityViceDbContext.Nutritions.AsQueryable()
                                                              on fruity.FruityId equals nutrition.FruityId
                                                              select new FruityResponseModel() { 
                                                              Id= fruity.FruityId,
                                                              Name= fruity.Name,
                                                              Genus = fruity.Genus,
                                                              Family= fruity.Family,
                                                              Order= fruity.Order,
                                                              Nutritions = new List<Model.NutritionModel>()
                                                              {
                                                                  new Model.NutritionModel()
                                                                  {
                                                                      Carbohydrates = nutrition.Carbohydrates,
                                                                      Protein = nutrition.Protein,
                                                                      Fat = nutrition.Fat,
                                                                      Calories= nutrition.Calories,
                                                                      Sugar= nutrition.Sugar,
                                                                  }
                                                              }
                                                              }).ToList();
            return fruityResponseModels;
        }

        public async Task<List<FruityResponseModel>> GetFruityDetailsByFamily(FruitySearchRequestModel fruitySearchRequestModel)
        {
            List<FruityResponseModel> fruityResponseModels = (from fruity in _fruityViceDbContext.Fruities.AsQueryable()
                                                              join nutrition in _fruityViceDbContext.Nutritions.AsQueryable()
                                                              on fruity.FruityId equals nutrition.FruityId
                                                              where fruitySearchRequestModel.FruitFamily.Contains(fruity.Family)

                                                              select new FruityResponseModel()
                                                              {
                                                                  Id = fruity.FruityId,
                                                                  Name = fruity.Name,
                                                                  Genus = fruity.Genus,
                                                                  Family = fruity.Family,
                                                                  Order = fruity.Order,
                                                                  Nutritions = new List<Model.NutritionModel>()
                                                              {
                                                                  new Model.NutritionModel()
                                                                  {
                                                                      Carbohydrates = nutrition.Carbohydrates,
                                                                      Protein = nutrition.Protein,
                                                                      Fat = nutrition.Fat,
                                                                      Calories= nutrition.Calories,
                                                                      Sugar= nutrition.Sugar,
                                                                  }
                                                              }
                                                              }).ToList();
            return fruityResponseModels;
        }
        
    }
}
