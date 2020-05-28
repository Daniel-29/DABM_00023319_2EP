using System;
using System.Windows.Forms;

namespace com.DABM.x00023319
 {
     public partial class Main : Form
     {
         private int id;
         private string user;
         private bool type;
         private UserControl current = null;
         public Main(int id , string user, bool type)
         {
             InitializeComponent();
             this.id = id;
             this.user = user;
             this.type = type;
             if (type)
             {
               changeUserControl(new Admin(id,type));
             }
             else
             { changeUserControl(new Client(id,type));
             }
                 
             lbUser.Text = user;
         }
         public void changeUserControl(UserControl obj){
             tlpPrincipal.Controls.Remove(current);
             current = obj;
             current.Dock = DockStyle.Fill;
             tlpPrincipal.Controls.Add(current, 0, 1);
             tlpPrincipal.SetColumnSpan(current, 4);
         }

         private void btnCerrar_Click(object sender, EventArgs e)
         {
             Login lg = new Login();
             lg.Show();
             this.Hide();
             Dispose();
         }

         private void button1_Click(object sender, EventArgs e)
         {
             UpdatePassword menu = new UpdatePassword(id,user,"opcional",type);
             menu.Show();
             this.Hide();
         }
     }
 }