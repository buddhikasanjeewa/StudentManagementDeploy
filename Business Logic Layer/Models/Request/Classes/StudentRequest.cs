using Business_Logic_Layer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models.Request.Interfaces
{
    /*Developer:Buddhika
     * Data:2026.05.29
     * Description:Encapulate Student Request
     */
    //Impement student request interface
    public  class StudentRequest:IStudentRequest
    {
      
        public Guid Uid { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Nic { get; set; } = null!;

        public DateOnly? Dob { get; set; }

        public string? Address { get; set; }
       public string? Profile_Image { get; set; }

        // Add logging functionality to log student details
        public void LogStudentDetails()
        {
            Logger.Instance.Log($"Student Details:  Name={FirstName} {LastName}, Email={Email}, Mobile={Mobile},Address={Address},Nic={Nic},Dateofbirth={Dob}");
        }
    }
}
