using System;
using System.Windows.Forms;

namespace com.DABM.x00023319
{
    public partial class Admin : UserControl
    { 
        private UserControl current = null;
        private int id;
        private bool type;
        public Admin(int id , bool type)
        {
            InitializeComponent();
            this.id = id;
            this.type = type;
        }
        public void changeUserControl(UserControl obj){
            tableLayoutPanel1.Controls.Remove(current);
            current = obj;
            current.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(current, 0, 1);
            tableLayoutPanel2.SetColumnSpan(current, 1);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            changeUserControl(new Users(id));
        }

        private void btnNegocios_Click(object sender, EventArgs e)
        {
            changeUserControl(new Negocios(id));
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            changeUserControl(new Producto());
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            changeUserControl(new ListOrdenes());
        }
    }
}