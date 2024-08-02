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

        public UserViewModel()
        { 
            MyUserRole = new UserRole(); 
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
    }
}
