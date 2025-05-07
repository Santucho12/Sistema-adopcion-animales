
using System;
using System.Windows.Forms;
using logic.presenter;
using data.models;

namespace view
{
    public partial class formMascota : Form
    {
        private MascotaPresenter mascotaPresenter;

        public formMascota()
        {
            InitializeComponent();         // constructor único
            mascotaPresenter = new MascotaPresenter();
            this.Load += formMascota_Load;
        }

        private void formMascota_Load(object sender, EventArgs e)
        {
            CargarMascotas();
        }

        private void CargarMascotas()
        {
            try
            {
                var mascotas = mascotaPresenter.ListarMascotas();
                dataGridView1.DataSource = mascotas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mascotas: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
