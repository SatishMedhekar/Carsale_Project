using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Client.Infrastructure;
using MyCarsale.Client.Models;

namespace MyCarsale.Client
{

     public class MyCarSaleClient
    {
        private readonly HttpClient client;
        private HttpResponseMessage response;


        public MyCarSaleClient()
        {
            client = new HttpClient(new AuthenticationHandler("fanier", "supersecretpassword"));

            client.BaseAddress = new Uri("http://localhost:57047/");

        }


        public CarSearchInfo GetFillSearchCriteria()
        {
            return null;
        }


        public Car GerCarSearchResult()
        {
            return null;
        }


        public void PostEnquiry(Enquiry enquiry)
        {
            
        }


        public Enquiry GetEnquires(int CarID)
        {

            return null;
        }



        public void PostCar(Car carRequest, CarCollection carCollection)

        {
            
        }


        //ToDo : Decide to remove carcollection
        public void DeleteCar(int id, CarCollection carCollectionDto)
        {

        }


        public void PutCar(Car car)
        {

        }


    }
}
