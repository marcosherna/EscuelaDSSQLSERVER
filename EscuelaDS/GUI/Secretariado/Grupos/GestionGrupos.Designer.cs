namespace EscuelaDS.GUI.Secretariado.Grupos
{
    partial class GestionGrupos
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAulas = new System.Windows.Forms.ComboBox();
            this.txbAnio = new System.Windows.Forms.TextBox();
            this.txbSeccion = new System.Windows.Forms.TextBox();
            this.cmbProfesores = new System.Windows.Forms.ComboBox();
            this.cmbTurnos = new System.Windows.Forms.ComboBox();
            this.txbGrado = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(543, 450);
            this.panel1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgOpciones);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(15, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(513, 235);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado";
            // 
            // dtgOpciones
            // 
            this.dtgOpciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgOpciones.Location = new System.Drawing.Point(10, 23);
            this.dtgOpciones.Name = "dtgOpciones";
            this.dtgOpciones.Size = new System.Drawing.Size(493, 202);
            this.dtgOpciones.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOperaciones);
            this.groupBox2.Controls.Add(this.rbEliminar);
            this.groupBox2.Controls.Add(this.rbModificar);
            this.groupBox2.Controls.Add(this.rbNuevo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(15, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operaciones";
            // 
            // btnOperaciones
            // 
            this.btnOperaciones.Location = new System.Drawing.Point(312, 19);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(123, 23);
            this.btnOperaciones.TabIndex = 3;
            this.btnOperaciones.Text = "Ejecutar";
            this.btnOperaciones.UseVisualStyleBackColor = true;
            // 
            // rbEliminar
            // 
            this.rbEliminar.AutoSize = true;
            this.rbEliminar.Location = new System.Drawing.Point(211, 22);
            this.rbEliminar.Name = "rbEliminar";
            this.rbEliminar.Size = new System.Drawing.Size(61, 17);
            this.rbEliminar.TabIndex = 2;
            this.rbEliminar.Text = "Eliminar";
            this.rbEliminar.UseVisualStyleBackColor = true;
            // 
            // rbModificar
            // 
            this.rbModificar.AutoSize = true;
            this.rbModificar.Location = new System.Drawing.Point(137, 22);
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
            this.rbNuevo.Location = new System.Drawing.Point(74, 22);
            this.rbNuevo.Name = "rbNuevo";
            this.rbNuevo.Size = new System.Drawing.Size(57, 17);
            this.rbNuevo.TabIndex = 0;
            this.rbNuevo.TabStop = true;
            this.rbNuevo.Text = "Nuevo";
            this.rbNuevo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbAulas);
            this.groupBox1.Controls.Add(this.txbAnio);
            this.groupBox1.Controls.Add(this.txbSeccion);
            this.groupBox1.Controls.Add(this.cmbProfesores);
            this.groupBox1.Controls.Add(this.cmbTurnos);
            this.groupBox1.Controls.Add(this.txbGrado);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Año";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Seccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Grado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Aula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Profesor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Turno";
            // 
            // cmbAulas
            // 
            this.cmbAulas.FormattingEnabled = true;
            this.cmbAulas.Location = new System.Drawing.Point(30, 86);
            this.cmbAulas.Name = "cmbAulas";
            this.cmbAulas.Size = new System.Drawing.Size(149, 21);
            this.cmbAulas.TabIndex = 6;
            // 
            // txbAnio
            // 
            this.txbAnio.Location = new System.Drawing.Point(381, 86);
            this.txbAnio.Name = "txbAnio";
            this.txbAnio.Size = new System.Drawing.Size(110, 20);
            this.txbAnio.TabIndex = 5;
            // 
            // txbSeccion
            // 
            this.txbSeccion.Location = new System.Drawing.Point(279, 86);
            this.txbSeccion.Name = "txbSeccion";
            this.txbSeccion.Size = new System.Drawing.Size(96, 20);
            this.txbSeccion.TabIndex = 4;
            // 
            // cmbProfesores
            // 
            this.cmbProfesores.FormattingEnabled = true;
            this.cmbProfesores.Location = new System.Drawing.Point(141, 42);
            this.cmbProfesores.Name = "cmbProfesores";
            this.cmbProfesores.Size = new System.Drawing.Size(350, 21);
            this.cmbProfesores.TabIndex = 3;
            // 
            // cmbTurnos
            // 
            this.cmbTurnos.FormattingEnabled = true;
            this.cmbTurnos.Location = new System.Drawing.Point(27, 42);
            this.cmbTurnos.Name = "cmbTurnos";
            this.cmbTurnos.Size = new System.Drawing.Size(108, 21);
            this.cmbTurnos.TabIndex = 1;
            // 
            // txbGrado
            // 
            this.txbGrado.Location = new System.Drawing.Point(185, 86);
            this.txbGrado.Name = "txbGrado";
            this.txbGrado.Size = new System.Drawing.Size(88, 20);
            this.txbGrado.TabIndex = 0;
            // 
            // GestionGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 450);
            this.Controls.Add(this.panel1);
            this.Name = "GestionGrupos";
            this.Text = "Gestion Grupos";
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
        private System.Windows.Forms.ComboBox cmbProfesores;
        private System.Windows.Forms.ComboBox cmbTurnos;
        private System.Windows.Forms.TextBox txbGrado;
        private System.Windows.Forms.TextBox txbSeccion;
        private System.Windows.Forms.TextBox txbAnio;
        private System.Windows.Forms.ComboBox cmbAulas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}