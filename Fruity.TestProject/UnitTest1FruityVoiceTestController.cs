//using FakeItEasy;
using FakeItEasy;
using Fruityvice.Controllers;
using Fruityvice.Model.RequestModel;
using Fruityvice.Model.ResponseModel;
using Fruityvice.Service;
using System.Runtime.CompilerServices;

namespace Fruity.TestProject
{
    public class UnitTest1FruityVoiceTestController
    {
        //public readonly IFruityVoiceService _fruityVoiceService;

        //public UnitTest1FruityVoiceTestController(IFruityVoiceService fruityVoiceService)
        //{
        //    _fruityVoiceService = fruityVoiceService;
        //}
        [Fact]
        public async Task  GetFruitys_List_Based_On_Family()
        {
            int itemCount = 5;
            FruitySearchRequestModel fruitySearchRequestModel = new FruitySearchRequestModel();
            fruitySearchRequestModel.FruitFamily = "Rosaceae";

            var fackFruity = FakeItEasy.A.CollectionOfDummy<FruityResponseModel>(itemCount).AsEnumerable();

            var service = FakeItEasy.A.Fake<IFruityVoiceService>();
            var fruityVoiceController = new FruityVoiceController(service);
            FakeItEasy.A.CallTo(() => service.GetFruityDetailsByFamily(fruitySearchRequestModel)).Returns(Task.FromResult(fackFruity));
            var fruityList = fruityVoiceController.GetFruityDetailList().Result;


        }
    }
}