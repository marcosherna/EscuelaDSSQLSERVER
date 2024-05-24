using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Rector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Rector.Aulas
{
    public partial class GestionAulas : Form
    {
        private Aula aulaSeleccionada = null;
        public GestionAulas()
        {
            InitializeComponent();
            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.dtgOpciones.SelectionChanged += LtbOpciones_SelectedValueChanged;
             
        }
          
        private void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    aulaSeleccionada = (Aula)this.dtgOpciones.CurrentRow.DataBoundItem; 
                    if (aulaSeleccionada != null)
                    {
                        MostraraulaSeleccionada();
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.txbNombre.Enabled = true;
                this.txbPiso.Enabled = true;
                this.txbNumeroAula.Enabled = true;

                if (this.rbEliminar.Checked)
                {
                    this.txbNombre.Enabled = false; 
                    this.txbPiso.Enabled = false;
                    this.txbNumeroAula.Enabled = false;
                }

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<Aula>)this.dtgOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        aulaSeleccionada = (Aula)this.dtgOpciones.CurrentRow.DataBoundItem;
                        MostraraulaSeleccionada();

                    }
                }

                if (this.rbNuevo.Checked) 
                {
                    this.Reset();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostraraulaSeleccionada()
        { 
            this.txbNombre.Text = aulaSeleccionada.Edificio;
            this.txbPiso.Text = aulaSeleccionada.Piso;
            this.txbNumeroAula.Text = aulaSeleccionada.Numero; 
        }

        private async void BtnOperaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbNuevo.Checked) await Guardar();
                if (this.rbModificar.Checked) await Mdificar();
                if (this.rbEliminar.Checked) await Eliminar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Eliminar()
        {
            if (aulaSeleccionada == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await aulaSeleccionada.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Reset();
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (aulaSeleccionada == null) throw new Exception("Debe seleccionar un país");
            aulaSeleccionada.Edificio = this.txbNombre.Text;
            aulaSeleccionada.Piso = this.txbPiso.Text;
            aulaSeleccionada.Numero = this.txbNumeroAula.Text;

            aulaSeleccionada.Validate();
            bool result = await aulaSeleccionada.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Reset();
            await Cargar();
        }

        private async Task Guardar()
        {
            Aula aula = new Aula();
            aula.Edificio = this.txbNombre.Text;
            aula.Piso = this.txbPiso.Text;
            aula.Numero = this.txbNumeroAula.Text;

            aula.Validate();

            bool result = await aula.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Reset();
            await Cargar();
        }

        private void Reset()
        {
            this.txbNombre.Text = string.Empty;
            this.txbNumeroAula.Text = string.Empty;
            this.txbPiso.Text = string.Empty;
            this.aulaSeleccionada = null;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            { 
                await Cargar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }
         
        private async Task Cargar()
        {
            List<Aula> aulas = await Aula.GetAsync();
            this.dtgOpciones.DataSource = aulas;
        }
    }
}
