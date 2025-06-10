using Business_Logic_Layer.Models;
using Business_Logic_Layer.Models.Request.Interfaces;
using Business_Logic_Layer.Services.AbstactClasses;
using DAL.Models;
using DAL.Reposistory.Classes;
using DAL.Reposistory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.ConcreteClasses
{
    /*Developer:Buddhika
    * Date:2025-05-29
    * Description:Inherit from Abstract student service
    */
    public class StudentService : AStudentService
    {
        //Apply Encapsulation 
        private readonly IStudentRepo studentRepo;
        private int rtnVal;
        private string studentImageData;
        #region DependancyInjection
        public StudentService(IStudentRepo _studentRepo)  //Apply dependancy injection
        {
            studentRepo = _studentRepo;
        }
        #endregion

        #region GetData
        public override async Task<List<Student>> GetStudents()  //Get all student data
        {
            //try
            //{
                var dbResults = await this.studentRepo.GetStudentsAsync();
                List<Student> students = new List<Student>();
                foreach (var dbResult in dbResults)
                {
                    students.Add(new Student()
                    {
                        Uid = dbResult.Uid,
                        FirstName = dbResult.FirstName,
                        LastName = dbResult.LastName,
                        Mobile = dbResult.Mobile,
                        Email = dbResult.Email,
                        Address = dbResult.Address,
                        Dob = dbResult.Dob,
                        Nic = dbResult.Nic,
                       
                   
                        
                    });
                }
                return students;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in Get Students :" + ex.Message);
            //}
        }
      
        
        public override async Task<List<Student>> GetStudentsbyId(Guid id)  //Filter student data by key
        {
            //try
            //{
                var dbResults = await this.studentRepo.GetStudentByIdAsync(id);
                List<Student> students = new List<Student>();
                foreach (var dbResult in dbResults)
                {
                    students.Add(new Student()
                    {
                        Uid = dbResult.Uid,
                        FirstName = dbResult.FirstName,
                        LastName = dbResult.LastName,
                        Mobile = dbResult.Mobile,
                        Email = dbResult.Email,
                        Address = dbResult.Address,
                        Dob = dbResult.Dob,
                        Nic = dbResult.Nic,
                       
                    });
                }
                return students;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in Get Students by key :" + ex.Message);
            //}
        }

        public override async Task<List<ImageData>> GetStudentsImageById(Guid id)  //Get student image
        {
            //try
            //{
                var dbResults = await this.studentRepo.GetStudentByIdAsync(id);
                var imageList=new List<ImageData>();
                foreach (var dbResult in dbResults)
                {
                    imageList.Add(new ImageData()
                    {
                        ProfileImage = Encoding.UTF8.GetString(dbResult.Profile_Image,0,dbResult.Profile_Image.Length)

                    });
                }
                
                return imageList;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in Get Students by key :" + ex.Message);
            //}

        }
        public override async Task<List<Student>> GetStudentsbyText(string searchText)  //Filter student data by Search Text
        {
            //try
            //{
                var dbResults = await this.studentRepo.GetStudentByTextAsync(searchText);
                List<Student> students = new List<Student>();
                foreach (var dbResult in dbResults)
                {
                    students.Add(new Student()
                    {
                        Uid = dbResult.Uid,
                        FirstName = dbResult.FirstName,
                        LastName = dbResult.LastName,
                        Mobile = dbResult.Mobile,
                        Email = dbResult.Email,
                        Address = dbResult.Address,
                        Dob = dbResult.Dob,
                        Nic = dbResult.Nic,
                       
                    });
                }
                return students;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in Get Students by text :" + ex.Message);
            //}
        }

        #endregion
        #region  UpdateData
        public override async Task<int> SaveStudentData(IStudentRequest stuRequest)  //Save student
        {
            //try
            //{
               byte[] imgData = Encoding.UTF8.GetBytes(stuRequest.Profile_Image);
                var dbStudent = new TblStudentPersonal
                {
                    Uid = stuRequest.Uid,
                    FirstName = stuRequest.FirstName,
                    LastName = stuRequest.LastName,
                    Mobile = stuRequest.Mobile,
                    Email = stuRequest.Email,
                    Address = stuRequest.Address,
                    Dob = stuRequest.Dob,
                    Nic = stuRequest.Nic,
                   Profile_Image  =imgData
                };
                rtnVal = await this.studentRepo.SaveStudentAsync(dbStudent);
                stuRequest.LogStudentDetails();
                return rtnVal;

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in Save :" + ex.Message);
            //}
        }
        #endregion

        #region DeleteData
        public override async Task<int> DeleteStudentData(Guid id)  //Delete Student
        {
            //try
            //{
                rtnVal = await  this.studentRepo.DeleteStudentAsync(id);
                return rtnVal;
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception("Error in delete :" + ex.Message);
            //}
        }

        #endregion

    }
}
