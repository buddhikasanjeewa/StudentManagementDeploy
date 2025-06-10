using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposistory.Interfaces
{
    // Inteface for repository 
    public  interface IStudentRepo
    {
        Task<List<TblStudentPersonal>> GetStudentsAsync();
        Task<List<TblStudentPersonal>> GetStudentByIdAsync(Guid id);
        Task<List<TblStudentPersonal>> GetStudentByTextAsync(string text);
        Task<int> SaveStudentAsync(TblStudentPersonal students);
        Task<int> DeleteStudentAsync(Guid id);
    }
}
