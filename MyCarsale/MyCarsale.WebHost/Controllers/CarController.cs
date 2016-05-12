using System.Web.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Models;
using MyCarsale.WebHost.DTO;
using MyCarsale.WebHost.Service;
using System.Linq;

namespace MyCarsale.WebHost.Controllers
{
    public class CarController : ApiController
    {

        private IUnitOfWork unit;
        private ConvertToDTO convertToDto;



        /// <summary>
        /// Constructor : IOC injection
        /// </summary>
        public CarController(IUnitOfWork unit)
        {
            this.unit = unit;
            convertToDto = new ConvertToDTO();
        }



        /// <summary>
        /// submit request to add the carinformation to database
        /// </summary>
        /// <param name="enquiryRequestDto"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]CarDto carRequestDto, [FromBody]CarCollectionDto carCollectionDto )
        {
            var carRequest = carRequestDto.To<Car>();

            var carCollection = carCollectionDto.To<CarCollection>();

            // var car = convertToDto.GetEnquiryeDto(enquiryRequestDto);
            var carCollectionResponse = unit.Car.SaveCarDetails(carRequest, carCollection);

            var response = carCollectionResponse.To<CarCollectionDto>();

            return Ok(response);
        }



        /// <summary>
        /// Delete car request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carCollectionDto"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id, [FromBody]CarCollectionDto carCollectionDto)
        {

            var carCollection = carCollectionDto.To<CarCollection>();

            var carCollectionResponse = unit.Car.DeleteCarDetails(id, carCollection);

            var response = carCollectionResponse.To<CarCollectionDto>();

            return Ok();
        }




        public IHttpActionResult Get(CarInfoDto CarInfo)
        {
            var CInfo = CarInfo.To<CarInfo>();
            var carcollection = unit.Car.CarSearchResult(CInfo);
            
            var response = carcollection.To<CarCollection>();

            return Ok(response);


        }




    }
}
