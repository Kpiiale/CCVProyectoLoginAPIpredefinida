using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCVProyecto2P2.Models;

namespace CCVProyecto2P2.Services
{
    internal interface ILoginRepository
    {
        Task<InfoUsuario> Login(string usuario, string contrasenia);
    }
}
