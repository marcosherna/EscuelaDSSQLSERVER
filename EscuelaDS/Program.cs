using EscuelaDS.GUI.Catalogos;
using EscuelaDS.GUI.Catalogos.Departamento;
using EscuelaDS.GUI.Catalogos.Distritos;
using EscuelaDS.GUI.Catalogos.Municipios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashBoard());
        }
    }
}
