using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace personweb
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapPageRoute("R1", "ManagmentPage", "~/Managment.aspx");
            routes.MapPageRoute("R2", "FacultiesManager", "~/FacultiesManager.aspx");
            routes.MapPageRoute("R3", "AddFaculty", "~/AddFaculties.aspx");
          
            routes.MapPageRoute("R4", "EditFaculty/{FacultyID}", "~/UpdateFaculties.aspx");
            routes.MapPageRoute("R5", "errorpage", "~/error.aspx");
            routes.MapPageRoute("R6", "EduLevelsManager", "~/EduLevelsManager.aspx");
            routes.MapPageRoute("R7", "EditEduLevel/{LevelID}", "~/EduLevelsUpdate.aspx");
            routes.MapPageRoute("R8", "AddEduLevel", "~/AddEduLevels.aspx");

            routes.MapPageRoute("R9", "EduFieldsManager", "~/EduFieldsManager.aspx");
            routes.MapPageRoute("R10", "EditEduField/{FieldID}", "~/EduFieldsUpdate.aspx");
            routes.MapPageRoute("R11", "AddEduField", "~/AddEduFields.aspx");

            routes.MapPageRoute("R12", "EduTendenciesManagment", "~/EduTendenciesManagment.aspx");
            routes.MapPageRoute("R13", "EditEduTendency/{TendencyID}", "~/EduTendenciesUpdate.aspx");
            routes.MapPageRoute("R14", "AddEduTendency", "~/AddEduTendencies.aspx");

            routes.MapPageRoute("R15", "DepartmentsManager", "~/DepartmentsManager.aspx");
            routes.MapPageRoute("R16", "EditDepartment/{DepartmentID}", "~/DepartmentsUpdate.aspx");
            routes.MapPageRoute("R17", "AddDepartment", "~/AddDepartments.aspx");
            
            routes.MapPageRoute("R18", "RolesManagment", "~/RolesManagment.aspx");
            routes.MapPageRoute("R19", "EditRole/{RoleID}", "~/RolesUpdate.aspx");
            routes.MapPageRoute("R20", "AddRole", "~/AddRoles.aspx");

            routes.MapPageRoute("R21", "EmailTypesManagment", "~/EmailTypesManagment.aspx");
            routes.MapPageRoute("R22", "EditEmailType/{EmailTypeID}", "~/EmailTypesUpdate.aspx");
            routes.MapPageRoute("R23", "AddEmailType", "~/AddEmailTypes.aspx");

            routes.MapPageRoute("R24", "TelTypesManagment", "~/TelTypesManagment.aspx");
            routes.MapPageRoute("R25", "EditTelType/{TelTypeID}", "~/EmailTelUpdate.aspx");
            routes.MapPageRoute("R26", "AddTelType", "~/AddTelTypes.aspx");

            routes.MapPageRoute("R27", "EmailContactsManagment", "~/EmailContactsManagment.aspx");
            routes.MapPageRoute("R28", "EditEmailContact/{ID}", "~/EmailContactsUpdate.aspx");
            routes.MapPageRoute("R29", "AddEmailContact", "~/AddEmailContacts.aspx");

            routes.MapPageRoute("R30", "TelContactsManagment", "~/TelContactsManagment.aspx");
            routes.MapPageRoute("R31", "EditTelContact/{ID}", "~/TelContactsUpdate.aspx");
            routes.MapPageRoute("R32", "AddTelContact", "~/AddTelContacts.aspx");

            routes.MapPageRoute("R33", "StudentsManagment", "~/StudentsManagment.aspx");
            routes.MapPageRoute("R34", "EditStudent/{StudentID}", "~/StudentsUpdate.aspx");
            routes.MapPageRoute("R35", "AddStudent", "~/AddStudents.aspx");

            routes.MapPageRoute("R36", "EmailManagment/{UserTypeID}/{UserID}", "~/EmailManagment.aspx");
            routes.MapPageRoute("R37", "AddEmail/{UserTypeID}/{UserID}", "~/AddEmail.aspx");
            routes.MapPageRoute("R38", "EditEmail/{ID}/{UserTypeID}/{UserID}", "~/EmailUpdate.aspx");

            routes.MapPageRoute("R39", "TelManagment/{UserTypeID}/{UserID}", "~/TelManagment.aspx");
            routes.MapPageRoute("R40", "AddTel/{UserTypeID}/{UserID}", "~/AddTel.aspx");
            routes.MapPageRoute("R41", "EditTel/{ID}/{UserTypeID}/{UserID}", "~/TelUpdate.aspx");

            routes.MapPageRoute("R42", "LecturersManagment", "~/LecturersManagment.aspx");
            routes.MapPageRoute("R43", "EditLecturer/{LecturerID}", "~/LecturersUpdate.aspx");
            routes.MapPageRoute("R44", "AddLecturer", "~/AddLecturers.aspx");

            routes.MapPageRoute("R45", "EmployeesManagment", "~/EmployeesManagment.aspx");
            routes.MapPageRoute("R46", "EditEmployee/{EmployeeID}", "~/EmployeesUpdate.aspx");
            routes.MapPageRoute("R47", "AddEmployee", "~/AddEmployees.aspx");

            routes.MapPageRoute("R48", "PersonsAdminsManagment", "~/PersonsAdminsManagment.aspx");
            routes.MapPageRoute("R49", "EditPersonsAdmin/{AdminID}", "~/PersonsAdminsUpdate.aspx");
            routes.MapPageRoute("R50", "AddPersonsAdmin", "~/AddPersonsAdmins.aspx");

            routes.MapPageRoute("R51", "WebServiceManagement", "~/WebServiceAccountManagment.aspx");
            routes.MapPageRoute("R52", "WebServiceUpdate/{AccountID}", "~/WebServiceAccountUpdate.aspx");
            routes.MapPageRoute("R53", "AddWebServiceAccount", "~/AddWebServiceAccount.aspx");

            routes.MapPageRoute("R54", "SystemLogin", "~/Default.aspx");
            routes.MapPageRoute("R55", "employee/add", "~/employee/add.aspx");

            routes.MapPageRoute("R56", "AddVPNs", "~/AddVPNs.aspx");
            routes.MapPageRoute("R57", "EditVPNs/{VPNID}", "~/VPNsUpdate.aspx");
            routes.MapPageRoute("R58", "VPNsManagment", "~/VPNsManagment.aspx");

        }



        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}