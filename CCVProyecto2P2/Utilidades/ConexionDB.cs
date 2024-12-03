using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Utilidades
{
    public static class ConexionDB
    {
        public static string DevolverRuta(string nombreBaseDatos)
        {
            string rutaBD = string.Empty;
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                rutaBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBD = Path.Combine(rutaBD, nombreBaseDatos);
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                rutaBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBD = Path.Combine(rutaBD, "..", "Library", nombreBaseDatos);

            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI || Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                rutaBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBD = Path.Combine(rutaBD, nombreBaseDatos);
            }


            return rutaBD;
        }
    }
}
