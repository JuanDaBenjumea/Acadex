namespace PryPresentacion1
{
    partial class AgregarAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IdAdmin = new System.Windows.Forms.TextBox();
            this.txt_ApellAdmin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NombAdmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_RcontraAdmin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ContraAdmin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_AgregarBD_Ad = new System.Windows.Forms.Button();
            this.btn_Cancelar_Ad = new System.Windows.Forms.Button();
            this.txt_UsuarioAdmin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 50);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar Administrador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "DI:";
            // 
            // txt_IdAdmin
            // 
            this.txt_IdAdmin.Location = new System.Drawing.Point(178, 85);
            this.txt_IdAdmin.Name = "txt_IdAdmin";
            this.txt_IdAdmin.Size = new System.Drawing.Size(129, 20);
            this.txt_IdAdmin.TabIndex = 2;
            // 
            // txt_ApellAdmin
            // 
            this.txt_ApellAdmin.Location = new System.Drawing.Point(409, 127);
            this.txt_ApellAdmin.Name = "txt_ApellAdmin";
            this.txt_ApellAdmin.Size = new System.Drawing.Size(129, 20);
            this.txt_ApellAdmin.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido:";
            // 
            // txt_NombAdmin
            // 
            this.txt_NombAdmin.Location = new System.Drawing.Point(409, 83);
            this.txt_NombAdmin.Name = "txt_NombAdmin";
            this.txt_NombAdmin.Size = new System.Drawing.Size(129, 20);
            this.txt_NombAdmin.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(324, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre:";
            // 
            // txt_RcontraAdmin
            // 
            this.txt_RcontraAdmin.Location = new System.Drawing.Point(178, 226);
            this.txt_RcontraAdmin.Name = "txt_RcontraAdmin";
            this.txt_RcontraAdmin.PasswordChar = '*';
            this.txt_RcontraAdmin.Size = new System.Drawing.Size(129, 20);
            this.txt_RcontraAdmin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Repetir Contraseña:";
            // 
            // txt_ContraAdmin
            // 
            this.txt_ContraAdmin.Location = new System.Drawing.Point(178, 179);
            this.txt_ContraAdmin.Name = "txt_ContraAdmin";
            this.txt_ContraAdmin.PasswordChar = '*';
            this.txt_ContraAdmin.Size = new System.Drawing.Size(129, 20);
            this.txt_ContraAdmin.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Contraseña:";
            // 
            // btn_AgregarBD_Ad
            // 
            this.btn_AgregarBD_Ad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AgregarBD_Ad.BackgroundImage")));
            this.btn_AgregarBD_Ad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarBD_Ad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AgregarBD_Ad.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarBD_Ad.ForeColor = System.Drawing.Color.White;
            this.btn_AgregarBD_Ad.Location = new System.Drawing.Point(61, 301);
            this.btn_AgregarBD_Ad.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AgregarBD_Ad.Name = "btn_AgregarBD_Ad";
            this.btn_AgregarBD_Ad.Size = new System.Drawing.Size(165, 45);
            this.btn_AgregarBD_Ad.TabIndex = 11;
            this.btn_AgregarBD_Ad.Text = "AGREGAR";
            this.btn_AgregarBD_Ad.UseVisualStyleBackColor = true;
            this.btn_AgregarBD_Ad.Click += new System.EventHandler(this.btn_AgregarBD_Ad_Click);
            // 
            // btn_Cancelar_Ad
            // 
            this.btn_Cancelar_Ad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancelar_Ad.BackgroundImage")));
            this.btn_Cancelar_Ad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar_Ad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar_Ad.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar_Ad.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar_Ad.Location = new System.Drawing.Point(345, 301);
            this.btn_Cancelar_Ad.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Cancelar_Ad.Name = "btn_Cancelar_Ad";
            this.btn_Cancelar_Ad.Size = new System.Drawing.Size(165, 45);
            this.btn_Cancelar_Ad.TabIndex = 12;
            this.btn_Cancelar_Ad.Text = "CANCELAR";
            this.btn_Cancelar_Ad.UseVisualStyleBackColor = true;
            this.btn_Cancelar_Ad.Click += new System.EventHandler(this.btn_Cancelar_Ad_Click);
            // 
            // txt_UsuarioAdmin
            // 
            this.txt_UsuarioAdmin.Location = new System.Drawing.Point(178, 132);
            this.txt_UsuarioAdmin.Name = "txt_UsuarioAdmin";
            this.txt_UsuarioAdmin.Size = new System.Drawing.Size(129, 20);
            this.txt_UsuarioAdmin.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Usuario:";
            // 
            // AgregarAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 369);
            this.Controls.Add(this.txt_UsuarioAdmin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Cancelar_Ad);
            this.Controls.Add(this.btn_AgregarBD_Ad);
            this.Controls.Add(this.txt_ContraAdmin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_RcontraAdmin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_NombAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ApellAdmin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_IdAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AgregarAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Admin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IdAdmin;
        private System.Windows.Forms.TextBox txt_ApellAdmin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NombAdmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_RcontraAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ContraAdmin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_AgregarBD_Ad;
        private System.Windows.Forms.Button btn_Cancelar_Ad;
        private System.Windows.Forms.TextBox txt_UsuarioAdmin;
        private System.Windows.Forms.Label label7;
    }
}