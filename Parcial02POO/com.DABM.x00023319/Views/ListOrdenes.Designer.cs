using System.ComponentModel;

namespace com.DABM.x00023319
{
    partial class ListOrdenes
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDatos1 = new System.Windows.Forms.DataGridView();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvDatos1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.dgvDatos1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbMensaje, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(950, 560);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // dgvDatos1
            // 
            this.dgvDatos1.AllowUserToAddRows = false;
            this.dgvDatos1.AllowUserToDeleteRows = false;
            this.dgvDatos1.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos1.Location = new System.Drawing.Point(3, 87);
            this.dgvDatos1.MultiSelect = false;
            this.dgvDatos1.Name = "dgvDatos1";
            this.dgvDatos1.ReadOnly = true;
            this.dgvDatos1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos1.Size = new System.Drawing.Size(944, 470);
            this.dgvDatos1.TabIndex = 7;
            // 
            // lbMensaje
            // 
            this.lbMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMensaje.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lbMensaje.ForeColor = System.Drawing.Color.BlueViolet;
            this.lbMensaje.Location = new System.Drawing.Point(3, 0);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(944, 84);
            this.lbMensaje.TabIndex = 6;
            this.lbMensaje.Text = "Ordenes realizadas\r\n\r\n";
            // 
            // ListOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "ListOrdenes";
            this.Size = new System.Drawing.Size(950, 560);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvDatos1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.DataGridView dgvDatos1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}