using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
  public  class Redirector
    {
        public enum PageName
        {
            //errorpage, GroupManagment, 
           FacultiesManager,EditFaculty,AddFaculty,errorpage,EduLevelsManager,EditEduLevel,AddEduLevel,EduFieldsManager,AddEduField,EditEduField,
            EduTendenciesManagment,EditEduTendency,AddEduTendency,DepartmentsManager,AddDepartment,EditDepartment,RolesManagmet,AddRole,EditRole,
            EmailTypesManagment,AddEmailType,EditEmailType,TelTypesManagment,AddTelType,EditTelType,EmailContactsManagment,AddEmailContact,EditEmailContact,
            TelContactsManagment,AddTelContact,EditTelContact,StudentsManagment,AddStudent,EditStudent,EmailManagment,AddEmail,EditEmail,
            TelManagment,EditTel,AddTel,LecturersManagment,AddLecturer,EditLecturer,EmployeesManagment,AddEmployee,EditEmployee,
            PersonsAdminsManagment,AddPersonsAdmin,EditPersonsAdmin,AddWebServiceAccount,WebServiceUpdate,WebServiceManagement,SystemLogin,add,AddVPNs,EditVPNs,VPNsManagment
            
      
        };

        public static void Goto(PageName pageName)
        {
            switch (pageName)
            {
                //======================================================================================

                case PageName.FacultiesManager:
                    { HttpContext.Current.Response.Redirect("~/FacultiesManager"); break; }
                case PageName.EditFaculty:
                    { HttpContext.Current.Response.Redirect("~/EditFaculty"); break; }

                case PageName.AddFaculty:
                    { HttpContext.Current.Response.Redirect("~/AddFaculty"); break; }
                case PageName.errorpage:
                    { HttpContext.Current.Response.Redirect("~/errorpage"); break; }

                case PageName.EduLevelsManager:
                    { HttpContext.Current.Response.Redirect("~/EduLevelsManager"); break; }
                case PageName.EditEduLevel:
                    { HttpContext.Current.Response.Redirect("~/EditEduLevel"); break; }
                case PageName.AddEduLevel:
                    { HttpContext.Current.Response.Redirect("~/AddEduLevel"); break; }

                case PageName.EduFieldsManager:
                    { HttpContext.Current.Response.Redirect("~/EduFieldsManager"); break; }
                case PageName.AddEduField:
                    { HttpContext.Current.Response.Redirect("~/AddEduField"); break; }
                case PageName.EditEduField:
                    { HttpContext.Current.Response.Redirect("~/EditEduField"); break; }


                case PageName.EduTendenciesManagment:
                    { HttpContext.Current.Response.Redirect("~/EduTendenciesManagment"); break; }
                case PageName.AddEduTendency:
                    { HttpContext.Current.Response.Redirect("~/AddEduTendency"); break; }
                case PageName.EditEduTendency:
                    { HttpContext.Current.Response.Redirect("~/EditEduTendency"); break; }



                case PageName.DepartmentsManager:
                    { HttpContext.Current.Response.Redirect("~/DepartmentsManager"); break; }
                case PageName.AddDepartment:
                    { HttpContext.Current.Response.Redirect("~/AddDepartment"); break; }
                case PageName.EditDepartment:
                    { HttpContext.Current.Response.Redirect("~/EditDepartment"); break; }


                case PageName.RolesManagmet:
                    { HttpContext.Current.Response.Redirect("~/RolesManagment"); break; }
                case PageName.AddRole:
                    { HttpContext.Current.Response.Redirect("~/AddRole"); break; }
                case PageName.EditRole:
                    { HttpContext.Current.Response.Redirect("~/EditRole"); break; }


                case PageName.EmailTypesManagment:
                    { HttpContext.Current.Response.Redirect("~/EmailTypesManagment"); break; }
                case PageName.AddEmailType:
                    { HttpContext.Current.Response.Redirect("~/AddEmailType"); break; }
                case PageName.EditEmailType:
                    { HttpContext.Current.Response.Redirect("~/EditEmailType"); break; }


                case PageName.TelTypesManagment:
                    { HttpContext.Current.Response.Redirect("~/TelTypesManagment"); break; }
                case PageName.AddTelType:
                    { HttpContext.Current.Response.Redirect("~/AddTelType"); break; }
                case PageName.EditTelType:
                    { HttpContext.Current.Response.Redirect("~/EditTelType"); break; }

                case PageName.EmailContactsManagment:
                    { HttpContext.Current.Response.Redirect("~/EmailContactsManagment"); break; }
                case PageName.AddEmailContact:
                    { HttpContext.Current.Response.Redirect("~/AddEmailContact"); break; }
                case PageName.EditEmailContact:
                    { HttpContext.Current.Response.Redirect("~/EditEmailContact"); break; }


                case PageName.TelContactsManagment:
                    { HttpContext.Current.Response.Redirect("~/TelContactsManagment"); break; }
                case PageName.AddTelContact:
                    { HttpContext.Current.Response.Redirect("~/AddTelContact"); break; }
                case PageName.EditTelContact:
                    { HttpContext.Current.Response.Redirect("~/EditTelContact"); break; }

                case PageName.StudentsManagment:
                    { HttpContext.Current.Response.Redirect("~/StudentsManagment"); break; }
                case PageName.AddStudent:
                    { HttpContext.Current.Response.Redirect("~/AddStudent"); break; }
                case PageName.EditStudent:
                    { HttpContext.Current.Response.Redirect("~/EditStudent"); break; }

                case PageName.LecturersManagment:
                    { HttpContext.Current.Response.Redirect("~/LecturersManagment"); break; }
                case PageName.AddLecturer:
                    { HttpContext.Current.Response.Redirect("~/AddLecturer"); break; }
                case PageName.EditLecturer:
                    { HttpContext.Current.Response.Redirect("~/EdiLecturer"); break; }

                case PageName.EmployeesManagment:
                    { HttpContext.Current.Response.Redirect("~/EmployeesManagment"); break; }
                case PageName.AddEmployee:
                    { HttpContext.Current.Response.Redirect("~/AddEmployee"); break; }
                case PageName.EditEmployee:
                    { HttpContext.Current.Response.Redirect("~/EditEmployee"); break; }


                case PageName.PersonsAdminsManagment:
                    { HttpContext.Current.Response.Redirect("~/PersonsAdminsManagment"); break; }
                case PageName.AddPersonsAdmin:
                    { HttpContext.Current.Response.Redirect("~/AddPersonsAdmin"); break; }
                case PageName.EditPersonsAdmin:
                    { HttpContext.Current.Response.Redirect("~/EditPersonsAdmin"); break; }



                case PageName.EmailManagment:
                    { HttpContext.Current.Response.Redirect("~/EmailManagment"); break; }
                case PageName.AddEmail:
                    { HttpContext.Current.Response.Redirect("~/AddEmail"); break; }
                case PageName.EditEmail:
                    { HttpContext.Current.Response.Redirect("~/EditEmail"); break; }

                case PageName.TelManagment:
                    { HttpContext.Current.Response.Redirect("~/TelManagment"); break; }
                case PageName.AddTel:
                    { HttpContext.Current.Response.Redirect("~/AddTel"); break; }
                case PageName.EditTel:
                    { HttpContext.Current.Response.Redirect("~/EditTel"); break; }

                case PageName.AddWebServiceAccount:
                    { HttpContext.Current.Response.Redirect("~/AddWebServiceAccount"); break; }
                case PageName.WebServiceUpdate:
                    { HttpContext.Current.Response.Redirect("~/WebServiceUpdate"); break; }
                case PageName.WebServiceManagement:
                    { HttpContext.Current.Response.Redirect("~/WebServiceManagement"); break; }

                case PageName.SystemLogin:
                    { HttpContext.Current.Response.Redirect("~/SystemLogin"); break; }
                case PageName.add:
                    { HttpContext.Current.Response.Redirect("~/employee/add"); break; }


                case PageName.AddVPNs:
                    { HttpContext.Current.Response.Redirect("~/AddVPNs"); break; }
                case PageName.EditVPNs:
                    { HttpContext.Current.Response.Redirect("~/EditVPNs"); break; }
                case PageName.VPNsManagment:
                    { HttpContext.Current.Response.Redirect("~/VPNsManagment"); break; }


            }
        }
    }
}
