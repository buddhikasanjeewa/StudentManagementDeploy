using Business_Logic_Layer.Models;
using Business_Logic_Layer.Models.Request.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.AbstactClasses
{
    /*Developer:Buddhika
     * Date:2025-05-29
     * Description: Apply abstraction to student service
     */
    public abstract class AStudentService
    {
        public abstract Task<List<Student>> GetStudents();
        public abstract Task<List<Student>> GetStudentsbyId(Guid id);

        public abstract Task<List<ImageData>> GetStudentsImageById(Guid id);

        public abstract Task<List<Student>> GetStudentsbyText(string text);

        public abstract Task<int> SaveStudentData(IStudentRequest stuRequest);

        public abstract Task<int> DeleteStudentData(Guid id);
    }
}
