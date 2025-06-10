using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    /*Developer:Buddhika
 * Data:2025.05.29
 * Description:Student Model  
 */

    public class Student
    {
        public Guid Uid { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Nic { get; set; } = null!;

        public DateOnly? Dob { get; set; }

        public string? Address { get; set; }
         public byte[] ProfileImage { get; set; } = Array.Empty<byte>();
    }
}
