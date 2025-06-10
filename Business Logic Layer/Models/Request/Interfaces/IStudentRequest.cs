using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models.Request.Interfaces
{
    //Apply fully abstraction student request
    public  interface IStudentRequest
    {
        Guid Uid { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Mobile { get; set; } 

        string Email { get; set; }

        string Nic { get; set; } 

        DateOnly? Dob { get; set; }

        string? Address { get; set; }
        string Profile_Image { get; set; }
        void LogStudentDetails();
    }
}
