using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscosApp
{
    public partial class frmDiscos : Form
    {
        private List<Disco> listaDisco;
        public frmDiscos()
        {
            InitializeComponent();
        }

        private void frmDiscos_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            listaDisco = negocio.Listar();
            dgvDiscos.DataSource = listaDisco;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            cargarImagen(listaDisco[0].UrlImagenTapa);
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDisco.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxDisco.Load("https://i0.wp.com/lanecdr.org/wp-content/uploads/2019/08/placeholder.png?w=1200&ssl=1");
            }
        }
    }
}
