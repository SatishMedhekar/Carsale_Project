using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Models;

namespace MyCarsale.Domain.Repository
{
    public static class CityRepository
    {
        private static IQueryable<City> city = new List<City> {
            new City { CityId = 1, Name = "Richmond" , State = new State { StateID=1, Name="NSW" } },
            new City {CityId=2, Name="Blue Mountains",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 3, Name= "Newcastle",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 1, Name = "Richmond",State = new State { StateID=1, Name="NSW" } },
            new City {CityId=2, Name="Gosford",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 3, Name= "Wollongong",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 1, Name = "Maitland",State = new State { StateID=1, Name="NSW" } },
            new City {CityId=2, Name="Albury",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 3, Name= "Wagga Wagga ",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 1, Name = "Tamworth",State = new State { StateID=1, Name="NSW" }},
            new City {CityId=2, Name="Blue Mountains", State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 3, Name= "" },

            new City { CityId = 1, Name = "" },
            new City {CityId=2, Name="" },
            new City { CityId = 3, Name= "" },

            new City { CityId = 1, Name = "" },
            new City {CityId=2, Name="" },
            new City { CityId = 3, Name= "" },

            new City { CityId = 1, Name = "" },
            new City {CityId=2, Name="Blue " },
            new City { CityId = 3, Name= "" },



        }.AsQueryable();


        public static IQueryable<City> getCity()
        {
            return city;
        }


    }

    public static class StateRepository
    {
        private static IQueryable<State> state = new List<State> {
            new State{ StateID= 1, Name = "Any" },
            new State{ StateID= 2, Name = "NSW" },
            new State{StateID=3, Name="ACT" },
            new State { StateID = 4, Name= "VIC" },

        }.AsQueryable();


        public static IQueryable<State> getState()
        {
            return StateRepository.state;
        }
    }
}
