using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.Models;

namespace MyCarsale.Domain.Repository
{
    public class SampleEnquiry : IEnquiry
    {

        
        List<Enquiry> enquiry;

        public SampleEnquiry()
        {
            var customer = new Customer
            {
                CustomerName = new PersonalInfo
                {
                    FName = "Andrew",
                    LName = "Force",
                    Email = "andrew@yahoo.com",
                    PhoneInfo = new ContactInfo { Mobile = "0423945876", Phone = "0236845598", WorkPhone = "0252680045", AfterHourContact = "0236845598" },
                }, CustomerAddress = new Address { Address1 = "11", Address2 = "Rose Street", AreaLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() } }
            };

            enquiry = new List<Enquiry>
            { new Enquiry { ID=1, CustomerDetail = customer,
                            CarEnquiryDetail = new List<Car> { new Car { ID=1}, new Car {  ID=2} },
                            Comment = "Hi, I am interested in this model.  Could you please get your saleperson to contact me" } };
        }



        
        public List<Enquiry> GetEnquiryReport(int carID)
        {
            return enquiry.AsQueryable().Where( x=> x.ID == carID).ToList();
        }




        public List<Enquiry> SubmitEnquiry(Enquiry CustomerInquiry)
        {
            enquiry.Add(CustomerInquiry);

            return enquiry.AsQueryable().ToList();

        }



    }


   




    
}
