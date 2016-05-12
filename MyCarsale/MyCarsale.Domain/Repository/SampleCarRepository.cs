using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.Models;
using System.Web;
using System.Web.Script.Serialization;
using System.Runtime.Caching;

namespace MyCarsale.Domain.Repository
{
    public partial class SampleCarRepository : ICarRepository
    {

        private List<Car> CarList;
        MemoryCache memoryCache = MemoryCache.Default;

        public SampleCarRepository()
        {

           

            CarList = new List<Car> {
            new Car
            {
                ID = 1,
                CarSepcificInfo = new CarInfo
                {
                    CarMake = getMakes().Where(x => x.id == 1).FirstOrDefault(),
                    CarModel = getModels().Where(x => x.id == 1).FirstOrDefault(),
                    CarBadge = getBadges().Where(x => x.id == 1).FirstOrDefault(),
                    CarSeries = getSerieses().Where(x => x.id == 1).FirstOrDefault(),
                    CarPrice = 35000,
                    ManufactureYear = 2013,
                    intKilometer = 40000,
                    KilometerRange = getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
                    CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
                },
                CarDetailInfor = null
            },
            new Car
            {
                ID = 2,
                CarSepcificInfo = new CarInfo
                {
                    CarMake = getMakes().Where(x => x.id == 2).FirstOrDefault(),
                    CarModel = getModels().Where(x => x.id == 4).FirstOrDefault(),
                    CarBadge = getBadges().Where(x => x.id == 4).FirstOrDefault(),
                    CarSeries = getSerieses().Where(x => x.id == 4).FirstOrDefault(),
                    CarPrice = 15000,
                    ManufactureYear = 2009,
                    intKilometer = 50000,
                    KilometerRange = getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
                    CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
                },
                CarDetailInfor = null
            },
             new Car
            {
                ID = 3,
                CarSepcificInfo = new CarInfo
                {
                    CarMake = getMakes().Where(x => x.id == 3).FirstOrDefault(),
                    CarModel = getModels().Where(x => x.id == 7).FirstOrDefault(),
                    CarBadge = getBadges().Where(x => x.id == 7).FirstOrDefault(),
                    CarSeries = getSerieses().Where(x => x.id == 7).FirstOrDefault(),
                    CarPrice = 50000,
                    ManufactureYear = 2015,
                    intKilometer = 30000,
                    KilometerRange = getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
                    CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
                },
                CarDetailInfor = null
            }


        };

            //CarCollection carcollection = new CarCollection();
            //carcollection.cars.AddRange(CarList);

            //AddToCacheCarCollection(carcollection);
        }

        CarSearchInfo ICarRepository.CarSearch
        {
            get
            {
                return CarInfo();
            }
        }



        /// <summary>
        /// Fake car repository
        /// </summary>
        /// <param name="carrequest"></param>
        /// <returns></returns>
        public CarCollection CarSearchResult(CarInfo carrequest)
        {
            CarCollection carcollection = new CarCollection();

            List<Car> carlist  =  (from lst in CarList
                                   where ((carrequest.CarMake == null || lst.CarSepcificInfo.CarBadge.id == carrequest.CarBadge.id)

                                           || (carrequest.CarModel == null || lst.CarSepcificInfo.CarModel.id == carrequest.CarModel.id)
                                           || (carrequest.CarBadge == null || lst.CarSepcificInfo.CarBadge.id == carrequest.CarBadge.id)
                                           || (carrequest.CarSeries == null || lst.CarSepcificInfo.CarSeries.id == carrequest.CarSeries.id)
                                           ||  ((carrequest.PriceRange == null || (carrequest.PriceRange.PriceRange.minvalue == 0 && carrequest.PriceRange.PriceRange.maxvalue == 0))
                                                || (lst.CarSepcificInfo.CarPrice >= carrequest.PriceRange.PriceRange.minvalue && lst.CarSepcificInfo.CarPrice <= carrequest.PriceRange.PriceRange.maxvalue))
                                           || ((carrequest.YearRange.YearRange == null || (carrequest.YearRange.YearRange.minvalue == 0 && carrequest.YearRange.YearRange.maxvalue == 0))
                                                || (lst.CarSepcificInfo.ManufactureYear >= carrequest.YearRange.YearRange.minvalue && lst.CarSepcificInfo.ManufactureYear <= carrequest.YearRange.YearRange.maxvalue))
                                           || ((carrequest.YearRange.YearRange == null || (carrequest.YearRange.YearRange.minvalue == 0 && carrequest.YearRange.YearRange.maxvalue == 0))
                                                || (lst.CarSepcificInfo.ManufactureYear >= carrequest.YearRange.YearRange.minvalue && lst.CarSepcificInfo.ManufactureYear <= carrequest.YearRange.YearRange.maxvalue))
                                           || (carrequest.CarLocation.city == null || lst.CarSepcificInfo.CarLocation.city.CityId == carrequest.CarLocation.city.CityId)
                                          )
                       select new Car
                       {
                           ID = lst.ID,
                          CarSepcificInfo = lst.CarSepcificInfo == null ? null : new CarInfo { CarMake = getMakes().Where( x=>x.id == lst.CarSepcificInfo.CarMake.id).FirstOrDefault(),
                                                  CarModel = getModels().Where( x=>x.id == lst.CarSepcificInfo.CarModel.id).FirstOrDefault(),
                                                  CarBadge = getBadges().Where( x=>x.id == lst.CarSepcificInfo.CarBadge.id).FirstOrDefault(),
                                                  CarSeries = getSerieses().Where( x=>x.id == lst.CarSepcificInfo.CarSeries.id).FirstOrDefault(),
                                                  CarPrice = lst.CarSepcificInfo.CarPrice,
                                                  ManufactureYear = lst.CarSepcificInfo.ManufactureYear,
                                                  intKilometer =  lst.CarSepcificInfo.intKilometer,
                                                  CarLocation = lst.CarSepcificInfo.CarLocation
                                                },
                          CarDetailInfor = lst.CarDetailInfor ==null ? null : new CarDetailSepification { CarEngine =  lst.CarDetailInfor.CarEngine ==null ? null : new Engine {
                                                                         EngineTransmission = lst.CarDetailInfor.CarEngine.EngineTransmission.Id != 0 ? getTransmissionList().Where(x=>x.Id == lst.CarDetailInfor.CarEngine.EngineTransmission.Id).FirstOrDefault() : null,
                                                                           EngineFuel = getFuelList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineFuel.Id).FirstOrDefault(),
                                                                           EngineDrive = getDriveList().Where(x => x.id == lst.CarDetailInfor.CarEngine.EngineDrive.id).FirstOrDefault(),
                                                                           EngineClinders = getCylindersList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineClinders.Id).FirstOrDefault(),
                                                                           EngineSize = getSizelist().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineSize.Id).FirstOrDefault(),
                                                                           EnginePower = getPowerlist().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EnginePower.Id).FirstOrDefault(),
                                                                           EngineTowing = getTowinglist().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineTowing.Id).FirstOrDefault(),
                                                                           EngineInduction = getInductionList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineInduction.Id).FirstOrDefault(),
                       },
                                              CarExtra = lst.CarDetailInfor.CarExtra == null ? null : new Extra { ExtraPplate = getPplateList().Where(x=>x.Id== lst.CarDetailInfor.CarExtra.ExtraPplate.Id).FirstOrDefault(),
                                                                     ExtraAncap = getAncapList().Where(x=>x.Id== lst.CarDetailInfor.CarExtra.ExtraAncap.Id).FirstOrDefault(),
                                                                     ExtraGreenRating = getGreenRatingList().Where(x=>x.Id== lst.CarDetailInfor.CarExtra.ExtraGreenRating.Id).FirstOrDefault()
                                                                   },
                                              CarStyle = lst.CarDetailInfor.CarStyle == null ? null : new Style { StyleBody = getBodyList().Where(x=>x.Id== lst.CarDetailInfor.CarStyle.StyleBody.Id).FirstOrDefault(),
                                                                     StyleSeats = getSeatList().Where(x=>x.Id== lst.CarDetailInfor.CarStyle.StyleSeats.Id).FirstOrDefault(),
                                                                     StyleColor = getColorList().Where(x=>x.Id== lst.CarDetailInfor.CarStyle.StyleColor.Id).FirstOrDefault(),
                                                                     StyleDoor = getDoorList().Where(x=>x.Id== lst.CarDetailInfor.CarStyle.StyleDoor.Id).FirstOrDefault(),
                                                                    }
                                              }
                       }).ToList();


            carcollection.cars.AddRange(carlist);


            return carcollection;




        }


        /// <summary>
        /// Delete car from collection object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carslist"></param>
        /// <returns></returns>
        public CarCollection DeleteCarDetails(int id, CarCollection carslist)
        {
            
            CarCollection carcollection = carslist;

            Car cardetail = carcollection.cars.Where(x => x.ID == id).FirstOrDefault();

            carcollection.cars.Remove(cardetail);

            return carcollection;
        }

        /// <summary>
        /// Save car in collection object
        /// </summary>
        /// <param name="cardet"></param>
        /// <param name="carslist"></param>
        /// <returns></returns>
        public CarCollection SaveCarDetails(Car cardet, CarCollection carslist)
        {
            CarCollection carcollection = new CarCollection();

            carcollection = GetCacheCarCollection();

            Car cardetail = cardet;

            carcollection.cars.Add(cardetail);

            AddToCacheCarCollection(carcollection);

            return carcollection;
        }


        /// <summary>
        /// Update the Car in collection object
        /// </summary>
        /// <param name="cardet"></param>
        /// <param name="carslist"></param>
        /// <returns>CarCollection</returns>
        public CarCollection UpdateCarDetails(Car cardet, CarCollection carslist)
        {
            CarCollection carcollection = new CarCollection();

            carcollection = carslist;

            Car cardetail = carcollection.cars.Where(x => x.ID == cardet.ID).FirstOrDefault();

            carcollection.cars.Remove(cardetail);

            carcollection.cars.Add(cardet);

            return carcollection;

        }


        public void AddToCacheCarCollection(CarCollection carcollection)
        {
            
            var javascriptserializer = new JavaScriptSerializer();
            DateTimeOffset absExpiration = DateTimeOffset.UtcNow.AddHours(1);

            string carSerialize = javascriptserializer.Serialize(carcollection);

            memoryCache.Add("carcollection", carSerialize, absExpiration);


        }




        private CarCollection GetCacheCarCollection()
        {
            var javascriptserializer = new JavaScriptSerializer();

            var strCarcol = memoryCache.Get("carcollection");
            CarCollection carcoll = javascriptserializer.Deserialize<CarCollection>(strCarcol.ToString());

            return carcoll;
        }
       
    }
}
