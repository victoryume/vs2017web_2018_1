using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.UI.Web.MVC.Common
{
    public static class SecurityHelpers
    {
        public static List<Claim> CreateClaimsUsuario(Usuario usuario)
        {
            var claims = new List<Claim>();
            //Creando pedazos de información PARA QUE SE GUARDE EN LA COOKIE DE SEGURIDAD
            claims.Add(new Claim(ClaimTypes.Name, $"{usuario.Nombres} {usuario.Apellidos}"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Login));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim("UsuarioID", usuario.UsuarioID.ToString()));

            //Creando claims de roles para ser utilizado en conjunto con el atributo Authorize de MVC
            string[] roles = null;
            roles = usuario.Roles.Split(';');
            foreach (string rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaimsByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = identity.Claims.Where(item=>item.Type==type).ToList();
                        
            return claims;
        }
        
        public static string GetUserFullName()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;

            return claimValue;
        }

        public static int GetUsuarioID()
        {
            var claimValue = GetClaimsByType("UsuarioID").FirstOrDefault()!= null? Convert.ToInt32(GetClaimsByType ("UsuarioID").FirstOrDefault().Value):0;
            return claimValue;
        }

        public static string GetEmail()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Email).FirstOrDefault().Value;
            return claimValue;
        }

        public static bool Islogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool IsAdmin()
        {
            return HttpContext.Current.User.IsInRole("Admin");
        }
    }
}