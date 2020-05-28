using System.Windows.Forms;
using com.DABM.x00023319.Models;

namespace com.DABM.x00023319
{
    public partial class ListOrdenes : UserControl
    {
        private AppOrdera ordenes = new AppOrdera();
        public ListOrdenes()
        {
            InitializeComponent();
            CargarDatos();
        }
        public void CargarDatos()
        {
            dgvDatos1.DataSource=null;
            dgvDatos1.DataSource = ordenes.ALLselectAppOrdera();
        }
    }
}