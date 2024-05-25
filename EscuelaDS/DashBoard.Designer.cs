namespace EscuelaDS
{
    partial class DashBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Grupos");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionPaisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDepartamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionMunicipiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDistritosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionCargosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeAulasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeMateriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeEstudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeGruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tvGrupos = new System.Windows.Forms.TreeView();
            this.cmsGrupos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.matricularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEstudiantesC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.calificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boletaDeCalificaionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.cmsGrupos.SuspendLayout();
            this.cmsEstudiantesC.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogosToolStripMenuItem,
            this.administracionToolStripMenuItem,
            this.rectoriaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // catalogosToolStripMenuItem
            // 
            this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionPaisToolStripMenuItem1,
            this.gestionDepartamentoToolStripMenuItem,
            this.gestionMunicipiosToolStripMenuItem,
            this.gestionDistritosToolStripMenuItem});
            this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
            this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.catalogosToolStripMenuItem.Text = "Catalogos";
            // 
            // gestionPaisToolStripMenuItem1
            // 
            this.gestionPaisToolStripMenuItem1.Name = "gestionPaisToolStripMenuItem1";
            this.gestionPaisToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.gestionPaisToolStripMenuItem1.Text = "Gestion Pais";
            this.gestionPaisToolStripMenuItem1.Click += new System.EventHandler(this.gestionPaisToolStripMenuItem1_Click);
            // 
            // gestionDepartamentoToolStripMenuItem
            // 
            this.gestionDepartamentoToolStripMenuItem.Name = "gestionDepartamentoToolStripMenuItem";
            this.gestionDepartamentoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDepartamentoToolStripMenuItem.Text = "Gestion Departamento";
            this.gestionDepartamentoToolStripMenuItem.Click += new System.EventHandler(this.gestionDepartamentoToolStripMenuItem_Click);
            // 
            // gestionMunicipiosToolStripMenuItem
            // 
            this.gestionMunicipiosToolStripMenuItem.Name = "gestionMunicipiosToolStripMenuItem";
            this.gestionMunicipiosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionMunicipiosToolStripMenuItem.Text = "Gestion Municipios";
            this.gestionMunicipiosToolStripMenuItem.Click += new System.EventHandler(this.gestionMunicipiosToolStripMenuItem_Click);
            // 
            // gestionDistritosToolStripMenuItem
            // 
            this.gestionDistritosToolStripMenuItem.Name = "gestionDistritosToolStripMenuItem";
            this.gestionDistritosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDistritosToolStripMenuItem.Text = "Gestion Distritos";
            this.gestionDistritosToolStripMenuItem.Click += new System.EventHandler(this.gestionDistritosToolStripMenuItem_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionCargosToolStripMenuItem,
            this.gestionEmpleadosToolStripMenuItem,
            this.gestionEspecialidadesToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // gestionCargosToolStripMenuItem
            // 
            this.gestionCargosToolStripMenuItem.Name = "gestionCargosToolStripMenuItem";
            this.gestionCargosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionCargosToolStripMenuItem.Text = "Gestion Cargos";
            this.gestionCargosToolStripMenuItem.Click += new System.EventHandler(this.gestionCargosToolStripMenuItem_Click);
            // 
            // gestionEmpleadosToolStripMenuItem
            // 
            this.gestionEmpleadosToolStripMenuItem.Name = "gestionEmpleadosToolStripMenuItem";
            this.gestionEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionEmpleadosToolStripMenuItem.Text = "Gestion Empleados";
            this.gestionEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.gestionEmpleadosToolStripMenuItem_Click);
            // 
            // gestionEspecialidadesToolStripMenuItem
            // 
            this.gestionEspecialidadesToolStripMenuItem.Name = "gestionEspecialidadesToolStripMenuItem";
            this.gestionEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionEspecialidadesToolStripMenuItem.Text = "Gestion Especialidades";
            this.gestionEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.gestionEspecialidadesToolStripMenuItem_Click);
            // 
            // rectoriaToolStripMenuItem
            // 
            this.rectoriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeAulasToolStripMenuItem,
            this.gestionDeTurnosToolStripMenuItem,
            this.gestionDeMateriasToolStripMenuItem,
            this.gestionDeDocentesToolStripMenuItem,
            this.gestionDeEstudiantesToolStripMenuItem,
            this.gestionDeGruposToolStripMenuItem});
            this.rectoriaToolStripMenuItem.Name = "rectoriaToolStripMenuItem";
            this.rectoriaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.rectoriaToolStripMenuItem.Text = "Rectoria";
            // 
            // gestionDeAulasToolStripMenuItem
            // 
            this.gestionDeAulasToolStripMenuItem.Name = "gestionDeAulasToolStripMenuItem";
            this.gestionDeAulasToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDeAulasToolStripMenuItem.Text = "Gestion de Aulas";
            this.gestionDeAulasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeAulasToolStripMenuItem_Click);
            // 
            // gestionDeTurnosToolStripMenuItem
            // 
            this.gestionDeTurnosToolStripMenuItem.Name = "gestionDeTurnosToolStripMenuItem";
            this.gestionDeTurnosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDeTurnosToolStripMenuItem.Text = "Gestion de Turnos";
            this.gestionDeTurnosToolStripMenuItem.Click += new System.EventHandler(this.gestionDeTurnosToolStripMenuItem_Click);
            // 
            // gestionDeMateriasToolStripMenuItem
            // 
            this.gestionDeMateriasToolStripMenuItem.Name = "gestionDeMateriasToolStripMenuItem";
            this.gestionDeMateriasToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDeMateriasToolStripMenuItem.Text = "Gestion de Materias";
            this.gestionDeMateriasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeMateriasToolStripMenuItem_Click);
            // 
            // gestionDeDocentesToolStripMenuItem
            // 
            this.gestionDeDocentesToolStripMenuItem.Name = "gestionDeDocentesToolStripMenuItem";
            this.gestionDeDocentesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDeDocentesToolStripMenuItem.Text = "Gestion de Docentes";
            this.gestionDeDocentesToolStripMenuItem.Click += new System.EventHandler(this.gestionDeDocentesToolStripMenuItem_Click);
            // 
            // gestionDeEstudiantesToolStripMenuItem
            // 
            this.gestionDeEstudiantesToolStripMenuItem.Name = "gestionDeEstudiantesToolStripMenuItem";
            this.gestionDeEstudiantesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDeEstudiantesToolStripMenuItem.Text = "Gestion de Estudiantes";
            this.gestionDeEstudiantesToolStripMenuItem.Click += new System.EventHandler(this.gestionDeEstudiantesToolStripMenuItem_Click);
            // 
            // gestionDeGruposToolStripMenuItem
            // 
            this.gestionDeGruposToolStripMenuItem.Name = "gestionDeGruposToolStripMenuItem";
            this.gestionDeGruposToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gestionDeGruposToolStripMenuItem.Text = "Gestion de Grupos";
            this.gestionDeGruposToolStripMenuItem.Click += new System.EventHandler(this.gestionDeGruposToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1302, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton1.Text = "Refrescar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvGrupos);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.splitContainer1.Size = new System.Drawing.Size(1302, 401);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.tsbRefrescar,
            this.toolStripSeparator4,
            this.tsNuevo,
            this.toolStripSeparator5});
            this.toolStrip2.Location = new System.Drawing.Point(10, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(290, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "Nuevo";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton3.Text = "Filtrar";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefrescar
            // 
            this.tsbRefrescar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefrescar.Image")));
            this.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefrescar.Name = "tsbRefrescar";
            this.tsbRefrescar.Size = new System.Drawing.Size(59, 22);
            this.tsbRefrescar.Text = "Refrescar";
            this.tsbRefrescar.Click += new System.EventHandler(this.tsbRefrescar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsNuevo
            // 
            this.tsNuevo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevo.Image")));
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(46, 22);
            this.tsNuevo.Text = "Nuevo";
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tvGrupos
            // 
            this.tvGrupos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGrupos.Location = new System.Drawing.Point(10, 25);
            this.tvGrupos.Name = "tvGrupos";
            treeNode2.Name = "Nodo0";
            treeNode2.Text = "Grupos";
            this.tvGrupos.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvGrupos.Size = new System.Drawing.Size(290, 366);
            this.tvGrupos.TabIndex = 1;
            // 
            // cmsGrupos
            // 
            this.cmsGrupos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matricularToolStripMenuItem,
            this.asignarDToolStripMenuItem,
            this.opToolStripMenuItem});
            this.cmsGrupos.Name = "cmsGrupos";
            this.cmsGrupos.Size = new System.Drawing.Size(162, 70);
            // 
            // matricularToolStripMenuItem
            // 
            this.matricularToolStripMenuItem.Name = "matricularToolStripMenuItem";
            this.matricularToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.matricularToolStripMenuItem.Text = "Matricular";
            this.matricularToolStripMenuItem.Click += new System.EventHandler(this.matricularToolStripMenuItem_Click);
            // 
            // asignarDToolStripMenuItem
            // 
            this.asignarDToolStripMenuItem.Name = "asignarDToolStripMenuItem";
            this.asignarDToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.asignarDToolStripMenuItem.Text = "Asignar Docente";
            // 
            // opToolStripMenuItem
            // 
            this.opToolStripMenuItem.Name = "opToolStripMenuItem";
            this.opToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.opToolStripMenuItem.Text = "Elimimar";
            this.opToolStripMenuItem.Click += new System.EventHandler(this.opToolStripMenuItem_Click);
            // 
            // cmsEstudiantesC
            // 
            this.cmsEstudiantesC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calificacionesToolStripMenuItem,
            this.boletaDeCalificaionesToolStripMenuItem,
            this.quitarToolStripMenuItem});
            this.cmsEstudiantesC.Name = "cmsEstudiantesC";
            this.cmsEstudiantesC.Size = new System.Drawing.Size(194, 92);
            // 
            // calificacionesToolStripMenuItem
            // 
            this.calificacionesToolStripMenuItem.Name = "calificacionesToolStripMenuItem";
            this.calificacionesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.calificacionesToolStripMenuItem.Text = "Calificaciones";
            // 
            // boletaDeCalificaionesToolStripMenuItem
            // 
            this.boletaDeCalificaionesToolStripMenuItem.Name = "boletaDeCalificaionesToolStripMenuItem";
            this.boletaDeCalificaionesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.boletaDeCalificaionesToolStripMenuItem.Text = "Boleta de Calificaiones";
            // 
            // quitarToolStripMenuItem
            // 
            this.quitarToolStripMenuItem.Name = "quitarToolStripMenuItem";
            this.quitarToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.quitarToolStripMenuItem.Text = "Quitar";
            this.quitarToolStripMenuItem.Click += new System.EventHandler(this.quitarToolStripMenuItem_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.cmsGrupos.ResumeLayout(false);
            this.cmsEstudiantesC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionPaisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestionDepartamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionMunicipiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDistritosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionCargosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeAulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeMateriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeDocentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeEstudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeGruposToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripButton3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TreeView tvGrupos;
        private System.Windows.Forms.ContextMenuStrip cmsGrupos;
        private System.Windows.Forms.ToolStripMenuItem matricularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsEstudiantesC;
        private System.Windows.Forms.ToolStripMenuItem calificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boletaDeCalificaionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarToolStripMenuItem;
    }
}