namespace EscuelaDS.GUI.Rector.Docentes
{
    partial class ViewReportDocente
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
            this.crvDocentes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvDocentes
            // 
            this.crvDocentes.ActiveViewIndex = -1;
            this.crvDocentes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDocentes.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDocentes.Location = new System.Drawing.Point(0, 0);
            this.crvDocentes.Name = "crvDocentes";
            this.crvDocentes.Size = new System.Drawing.Size(800, 450);
            this.crvDocentes.TabIndex = 0;
            this.crvDocentes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ViewReportDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvDocentes);
            this.Name = "ViewReportDocente";
            this.Text = "ViewReportDocente";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDocentes;
    }
}