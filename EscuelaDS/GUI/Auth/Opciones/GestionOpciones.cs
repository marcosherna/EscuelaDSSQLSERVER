using EscuelaDS.CLS.Auth;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Auth.Opciones
{
    public partial class GestionOpciones : Form
    {
        private Opcion opcionSeleccionada = null;
        public GestionOpciones()
        {
            InitializeComponent();
            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.llstOpciones.SelectedValueChanged += LtbOpciones_SelectedValueChanged;
        }

        private void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    opcionSeleccionada = (Opcion)this.llstOpciones.SelectedItem;
                    this.txbNombre.Text = opcionSeleccionada.Nombre;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            this.txbNombre.Enabled = true;
            if (this.rbEliminar.Checked) this.txbNombre.Enabled = false;

            if (this.rbEliminar.Checked || this.rbModificar.Checked)
            {
                if (this.llstOpciones.Items.Count > 0)
                {
                    opcionSeleccionada = (Opcion)this.llstOpciones.SelectedItem;
                    this.txbNombre.Text = opcionSeleccionada.Nombre;
                }
            }

            if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
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
            if (opcionSeleccionada == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await opcionSeleccionada.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (opcionSeleccionada == null) throw new Exception("Debe seleccionar un país");
            opcionSeleccionada.Nombre = this.txbNombre.Text;
            opcionSeleccionada.Validate();
            bool result = await opcionSeleccionada.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            await Cargar();
        }

        private async Task Guardar()
        {
            Opcion opcion = new Opcion();
            opcion.Nombre = this.txbNombre.Text;

            opcion.Validate();
            bool result = await opcion.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            await Cargar();
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
            List<Opcion> opciones = await Opcion.GetAsync();
            this.llstOpciones.DataSource = opciones;
            this.llstOpciones.DisplayMember = "Nombre";
            this.llstOpciones.ValueMember = "Id";
        }
    }
}
