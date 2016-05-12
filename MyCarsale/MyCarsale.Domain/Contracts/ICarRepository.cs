using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Models;

namespace MyCarsale.Domain.Contracts
{
   public interface ICarRepository
    {
        CarCollection CarSearchResult(CarInfo carrequest);

        CarSearchInfo CarSearch { get; }

        CarCollection SaveCarDetails(Car cardet, CarCollection carslistl);

        CarCollection UpdateCarDetails(Car cardet, CarCollection carslistl);

        CarCollection DeleteCarDetails(int id, CarCollection carslist);


    }
}
