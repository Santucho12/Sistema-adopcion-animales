using System;
using System.Windows.Forms;
using view; // esto importa la clase MascotaForm

namespace view
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMascota() );
        }
    }
}
