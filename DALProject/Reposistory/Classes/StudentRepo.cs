using DAL.Context;
using DAL.Models;
using DAL.Reposistory.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Reposistory.Classes
{
    /* Developer:Buddhika
     * Date:2025.05.29
     * Descrption:CRUD Operations for Student Perosnal Data
     */
    public class StudentRepo:IStudentRepo
    {
        private readonly SofttOneSmsnewContext softoneDbContext;
        private int retunVal;
        #region DependancyInjection
        public StudentRepo(SofttOneSmsnewContext _softoneDbContext)  //Dependancy injection
        {
            softoneDbContext = _softoneDbContext;
        }
        #endregion
        #region GetData
        public async Task<List<TblStudentPersonal>> GetStudentsAsync()  //Get all Student data
        {
            //try
            //{
                var result = await this.softoneDbContext.TblStudentPersonals.FromSqlRaw(@"exec Get_Student_Data").ToListAsync();
                if (result == null|| result.Count==0)
                {
                    throw new Exception("No data found");
                }
                return result;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in get data: " + ex.Message);
            //}
        }
        public  async Task<List<TblStudentPersonal>> GetStudentByIdAsync(Guid id) //Get Student data by key
        {
            //try
            //{

                var param = new SqlParameter("@uid", id);
                var result = await this.softoneDbContext.TblStudentPersonals.FromSqlRaw(@"exec Get_Student_Data_by_Key @uid", param).ToListAsync();
  
                if (result == null)
                {
                    throw new Exception("No data found");
                }
                return result;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in get data: " + ex.Message);
            //}
        }
     
        public async Task<List<TblStudentPersonal>> GetStudentByTextAsync(string text) //Get Student data by searchtext
        {
            //try
            //{

                var param = new SqlParameter("@search", text);
                var result = await this.softoneDbContext.TblStudentPersonals.FromSqlRaw(@"exec Get_Student_Data_by_Search @search", param).ToListAsync();

                if (result == null)
                {
                    throw new Exception("No data found");
                }
                return result;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in get data: " + ex.Message);
            //}
        }
        #endregion

        #region UpdateData
        public async Task<int> SaveStudentAsync(TblStudentPersonal students)  //Save student data
        {
            using (var transaction = this.softoneDbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
            {
                try
                {

                    var paramList = new List<SqlParameter>()
                    {
                       new SqlParameter("@Uid", students.Uid==Guid.Empty?Guid.NewGuid():students.Uid),
                       new SqlParameter("@First_Name", students.FirstName),
                       new SqlParameter("@Last_Name", students.LastName),
                       new SqlParameter("@Mobile", students.Mobile),
                       new SqlParameter("@Email",students.Email),
                       new SqlParameter("@NIC", students.Nic),
                       new SqlParameter("@Dob", students.Dob),
                       new SqlParameter("@Address", students.Address),
                       new SqlParameter("@Profile_Image", students.Profile_Image ?? Array.Empty<byte>())
                    };


                    var result = await Task.Run(() => this.softoneDbContext.Database
                                           .ExecuteSqlRawAsync(@"exec Save_Student_Personal_Data @uid,@First_Name,@Last_Name,@Mobile,@Email,@NIC,@Dob,@Address,@Profile_Image", paramList.ToArray()));
                    if (result == 0)
                        transaction.Rollback();  //When no updates Rollback Transation
                    else
                        transaction.Commit();   //When success Commit Transation

                    retunVal = 1;
                    return retunVal;

                }
                catch (Exception ex)
                {
                    transaction.Rollback(); //When error Rollback Transation
                    throw new Exception("Error in Save : " +ex.Message);
                }


            }
        }


        #endregion

        #region Delete Data
        public async Task<int> DeleteStudentAsync(Guid id)   //Delete selected student
        {
            //try
            //{
                var param = new SqlParameter("@Uid", id);
                var result = await Task.Run(() => this.softoneDbContext.Database
                             .ExecuteSqlRawAsync(@"exec Delete_Student_Data @uid", param));
                 return result;
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception("Error in Delete : " + ex.Message);
            //}
        }
        #endregion
    }
}
