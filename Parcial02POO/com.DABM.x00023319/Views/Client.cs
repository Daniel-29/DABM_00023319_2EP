using System;
using System.Windows.Forms;

namespace com.DABM.x00023319
{
    public partial class Client : UserControl
    {
        private UserControl current = null;
        private int    idUser;
        private bool tipo;
        public Client(int id ,  bool type)
        {
            InitializeComponent();
            this.idUser = id;
            this.tipo = type;
        }
        public void changeUserControl(UserControl obj){
            tableLayoutPanel1.Controls.Remove(current);
            current = obj;
            current.Dock = DockStyle.Fill;
            tableLayoutPanel2.Controls.Add(current, 0, 1);
            tableLayoutPanel2.SetColumnSpan(current, 1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            changeUserControl(new ListOrdenesU(idUser));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeUserControl(new Direcciones(idUser));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            changeUserControl(new OrdenesUsuario(idUser));
        }
    }
}