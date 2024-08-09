using P6Travels_APP_KeirynS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6Travels_APP_KeirynS.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }
        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUserRole = new UserRole();
            MyUser = new User();
        }

        //Funcion que carga los datos de los roles de usuario para mostrar en lista
        public async Task<List<UserRole>?> VmGetUserRolesAsync()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();

                roles = await MyUserRole.GetUserRolesAsync();

                if (roles == null) return null;
                return roles;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Funcion para agregar usuario
        public async Task<bool> VmAddUser(string pEmail, string pName, string pPhoneNumber, string pPassword, int pRolID)
        {
         if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser = new()
                {
                    Correo = pEmail,
                    Nombre = pName,
                    Telefono = pPhoneNumber,
                    Contrasennia = pPassword,
                    RolID = pRolID

                };

                bool Ret = await MyUser.AddUserAsync();

                return Ret;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { IsBusy = false; }
            
        }
    }
}
