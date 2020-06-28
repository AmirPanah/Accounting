using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Common;

namespace personweb
{
    /// <summary>
    /// Summary description for PersonWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PersonWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    
       
        [WebMethod]
        public DataTable GetDepartments(string username,string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    DepartmentsRepository depir = new DepartmentsRepository();
                    return depir.GetAllDepartment();
                }
                else
                {
 return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public Department FindByDepID(string username, string password,int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    DepartmentsRepository depir = new DepartmentsRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

//-------------------------------------------------------------------------------------------

        [WebMethod]
        public DataTable GetEduField(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EduFieldsRepository depir = new EduFieldsRepository();
                    return depir.GetAllEduFields();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public EduField FindByEduFieldID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EduFieldsRepository depir = new EduFieldsRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
//------------------------------------------------------------------------------------------------------

        [WebMethod]
        public DataTable GetEduLevel(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EduLevelsRepository depir = new EduLevelsRepository();
                    return depir.GetAllEduLevels();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public EduLevel FindByEduLevelID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EduLevelsRepository depir = new EduLevelsRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

//------------------------------------------------------------------------------------------------------------
     
        [WebMethod]
        public DataTable GetEmailContact(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EmailContactsRepository depir = new EmailContactsRepository();
                    return depir.GetAllEmailContacts();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public EmailContact FindByEmailContactID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EmailContactsRepository depir = new EmailContactsRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
 //-----------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetEmailtype(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EmailTypesRepository depir = new EmailTypesRepository();
                    return depir.GetAllEmailTypes();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public EmailType FindByEmailTypeID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    EmailTypesRepository depir = new EmailTypesRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
    //---------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetFaculty(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    FacultiesRepositpry depir = new FacultiesRepositpry();
                    return depir.GetAllFaculties();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public Faculty FindByFacultyID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    FacultiesRepositpry depir = new FacultiesRepositpry();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
//---------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetRole(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    RolesRepository depir = new RolesRepository();
                    return depir.GetAllRoles();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public Role FindByRoleID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    RolesRepository depir = new RolesRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
//---------------------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetTelContact(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    TelContactsRepository depir = new TelContactsRepository();
                    return depir.GetAllTelContacts();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public TelContact FindByTelContactID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    TelContactsRepository depir = new TelContactsRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

//----------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetTeltype(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    TelTypesRepository depir = new TelTypesRepository();
                    return depir.GetAllTelType();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public TelType FindTelTypeID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    TelTypesRepository depir = new TelTypesRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
//--------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetVEduTendency(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEduTendenciesRepository depir = new VEduTendenciesRepository();
                    return depir.GetAllTendency();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public VEduTendency FindByEduTendencyID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEduTendenciesRepository depir = new VEduTendenciesRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
  //-----------------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetEmployee(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    
                    VEmployeesRepository depir = new VEmployeesRepository();
                    return depir.GetAllvEmp();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public VEmployee FindByEmployeeID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEmployeesRepository depir = new VEmployeesRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        [WebMethod]
        public VEmployee FindByEmpUsername(string username, string password, string empusername)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEmployeesRepository depir = new VEmployeesRepository();
                    return depir.FindByuserName(empusername);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public VEmployee FindByEmpNationalCode(string username, string password, string empcode)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEmployeesRepository depir = new VEmployeesRepository();
                    return depir.FindBynationalcode(empcode);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
        [WebMethod]
        public void SetEmpPasswordByID(string username, string password, int EmployeeID,string NewPassword)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEmployeesRepository vempir = new VEmployeesRepository();
                    Employee emp = vempir.FindByid2(EmployeeID);
                    emp.Password = NewPassword;
                    vempir.Saveemp(emp);
                }
                else
                {
                    
                }
            }

            else
            {
                
            }
        }

        [WebMethod]
        public void SetEmpStatusByUsername(string username, string password, string Username, bool isactive)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEmployeesRepository vempir = new VEmployeesRepository();
                    Employee emp = vempir.FindByuserName2(Username);
                    if (isactive == true)

                    {
                        emp.Status = "0".ToInt();
                            }
                    else
                    {
                        emp.Status = "1".ToInt();
                    }
                    vempir.Saveemp(emp);
                }
                else
                {

                }
            }

            else
            {

            }
        }
        [WebMethod]
        public void UpdateEmployeeByID(string username, string password,int EmpID, Employee emp)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VEmployeesRepository vempir = new VEmployeesRepository();
                    Employee employee = vempir.FindByid2(EmpID);
                   
                    vempir.Saveemp(emp);
                }
                else
                {

                }
            }

            else
            {

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetLecturer(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VLecturersRepository depir = new VLecturersRepository();
                    return depir.GetAllVLec();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public VLecturer FindByLecturerID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VLecturersRepository depir = new VLecturersRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        [WebMethod]
        public VLecturer FindByLecUsername(string username, string password, string lecusername)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VLecturersRepository depir = new VLecturersRepository();
                    return depir.FindByuserName(lecusername);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }


        [WebMethod]
        public VLecturer FindByLecNationalCode(string username, string password, string lecnationalcode)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VLecturersRepository depir = new VLecturersRepository();
                    return depir.FindBynationalcode(lecnationalcode);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }
        [WebMethod]
        public void SetLecPasswordByID(string username, string password, int lecturerID, string NewPassword)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VLecturersRepository vempir = new VLecturersRepository();
                    Lecturer emp = vempir.FindByid2(lecturerID);
                    emp.Password = NewPassword;
                    vempir.Savestd(emp);
                }
                else
                {

                }
            }

            else
            {

            }
        }

     




        //---------------------------------------------------------------------------------------------------------------------------------
        [WebMethod]
        public DataTable GetStudent(string username, string password)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VStudentsRepository depir = new VStudentsRepository();
                    return depir.GetAllstd();
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public VStudent FindByStudentID(string username, string password, int id)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VStudentsRepository depir = new VStudentsRepository();
                    return depir.FindByid(id);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }



        [WebMethod]
        public VStudent FindByStdUsername(string username, string password, string stdusername)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VStudentsRepository depir = new VStudentsRepository();
                    return depir.FindByuserName(stdusername);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        [WebMethod]
        public VStudent FindByStdNationalCode(string username, string password, string stdcode)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VStudentsRepository depir = new VStudentsRepository();
                    return depir.FindBynationatcode(stdcode);
                }
                else
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        [WebMethod]
        public void SetstdPasswordByID(string username, string password, int studentID, string NewPassword)
        {
            WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
            WebServiceAccount currentuser = webir.FindByUserName(username);

            if (currentuser != null)
            {
                if (currentuser.Password == password)
                {
                    VStudentsRepository vempir = new VStudentsRepository();
                    Student emp = vempir.FindByid2(studentID);
                    emp.Password = NewPassword;
                    vempir.Savestd(emp);
                }
                else
                {

                }
            }

            else
            {

            }
        }









    }
}
