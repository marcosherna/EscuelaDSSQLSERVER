namespace EscuelaDS.GUI.Reportes.View
{
    partial class BoletaCalificacion
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
            this.crvBoletaCalificaciones = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvBoletaCalificaciones
            // 
            this.crvBoletaCalificaciones.ActiveViewIndex = -1;
            this.crvBoletaCalificaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBoletaCalificaciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBoletaCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBoletaCalificaciones.Location = new System.Drawing.Point(0, 0);
            this.crvBoletaCalificaciones.Name = "crvBoletaCalificaciones";
            this.crvBoletaCalificaciones.Size = new System.Drawing.Size(800, 450);
            this.crvBoletaCalificaciones.TabIndex = 0;
            this.crvBoletaCalificaciones.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // BoletaCalificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvBoletaCalificaciones);
            this.Name = "BoletaCalificacion";
            this.Text = "BoletaCalificacion";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBoletaCalificaciones;
    }
}