﻿namespace EscuelaDS.GUI.Catalogos.Distritos
{
    partial class GestionDistritos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgOpciones = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOperaciones = new System.Windows.Forms.Button();
            this.rbEliminar = new System.Windows.Forms.RadioButton();
            this.rbModificar = new System.Windows.Forms.RadioButton();
            this.rbNuevo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.cmbPaises = new System.Windows.Forms.ComboBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.cmbMunicipios = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOpciones)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(456, 475);
            this.panel1.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgOpciones);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(15, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(426, 296);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado";
            // 
            // dtgOpciones
            // 
            this.dtgOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgOpciones.Location = new System.Drawing.Point(10, 23);
            this.dtgOpciones.Name = "dtgOpciones";
            this.dtgOpciones.Size = new System.Drawing.Size(406, 263);
            this.dtgOpciones.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOperaciones);
            this.groupBox2.Controls.Add(this.rbEliminar);
            this.groupBox2.Controls.Add(this.rbModificar);
            this.groupBox2.Controls.Add(this.rbNuevo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(15, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operaciones";
            // 
            // btnOperaciones
            // 
            this.btnOperaciones.Location = new System.Drawing.Point(250, 16);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(123, 23);
            this.btnOperaciones.TabIndex = 3;
            this.btnOperaciones.Text = "Ejecutar";
            this.btnOperaciones.UseVisualStyleBackColor = true;
            // 
            // rbEliminar
            // 
            this.rbEliminar.AutoSize = true;
            this.rbEliminar.Location = new System.Drawing.Point(183, 19);
            this.rbEliminar.Name = "rbEliminar";
            this.rbEliminar.Size = new System.Drawing.Size(61, 17);
            this.rbEliminar.TabIndex = 2;
            this.rbEliminar.Text = "Eliminar";
            this.rbEliminar.UseVisualStyleBackColor = true;
            // 
            // rbModificar
            // 
            this.rbModificar.AutoSize = true;
            this.rbModificar.Location = new System.Drawing.Point(109, 19);
            this.rbModificar.Name = "rbModificar";
            this.rbModificar.Size = new System.Drawing.Size(68, 17);
            this.rbModificar.TabIndex = 1;
            this.rbModificar.Text = "Modificar";
            this.rbModificar.UseVisualStyleBackColor = true;
            // 
            // rbNuevo
            // 
            this.rbNuevo.AutoSize = true;
            this.rbNuevo.Checked = true;
            this.rbNuevo.Location = new System.Drawing.Point(46, 19);
            this.rbNuevo.Name = "rbNuevo";
            this.rbNuevo.Size = new System.Drawing.Size(57, 17);
            this.rbNuevo.TabIndex = 0;
            this.rbNuevo.TabStop = true;
            this.rbNuevo.Text = "Nuevo";
            this.rbNuevo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMunicipios);
            this.groupBox1.Controls.Add(this.cmbDepartamentos);
            this.groupBox1.Controls.Add(this.cmbPaises);
            this.groupBox1.Controls.Add(this.txbNombre);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario";
            // 
            // cmbDepartamentos
            // 
            this.cmbDepartamentos.FormattingEnabled = true;
            this.cmbDepartamentos.Location = new System.Drawing.Point(143, 19);
            this.cmbDepartamentos.Name = "cmbDepartamentos";
            this.cmbDepartamentos.Size = new System.Drawing.Size(266, 21);
            this.cmbDepartamentos.TabIndex = 2;
            // 
            // cmbPaises
            // 
            this.cmbPaises.FormattingEnabled = true;
            this.cmbPaises.Location = new System.Drawing.Point(15, 19);
            this.cmbPaises.Name = "cmbPaises";
            this.cmbPaises.Size = new System.Drawing.Size(122, 21);
            this.cmbPaises.TabIndex = 1;
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(198, 51);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(211, 20);
            this.txbNombre.TabIndex = 0;
            // 
            // cmbMunicipios
            // 
            this.cmbMunicipios.FormattingEnabled = true;
            this.cmbMunicipios.Location = new System.Drawing.Point(15, 51);
            this.cmbMunicipios.Name = "cmbMunicipios";
            this.cmbMunicipios.Size = new System.Drawing.Size(177, 21);
            this.cmbMunicipios.TabIndex = 3;
            // 
            // GestionDistritos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 475);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GestionDistritos";
            this.Text = "GestionDistritos";
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOpciones)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgOpciones;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOperaciones;
        private System.Windows.Forms.RadioButton rbEliminar;
        private System.Windows.Forms.RadioButton rbModificar;
        private System.Windows.Forms.RadioButton rbNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMunicipios;
        private System.Windows.Forms.ComboBox cmbDepartamentos;
        private System.Windows.Forms.ComboBox cmbPaises;
        private System.Windows.Forms.TextBox txbNombre;
    }
}