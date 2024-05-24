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

namespace EscuelaDS.GUI.Rector.Materias
{
    public partial class GestionMaterias : Form
    {
        private Materia materiaSeleccionada = null;
        public GestionMaterias()
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
                    materiaSeleccionada = (Materia)this.llstOpciones.SelectedItem;
                    if (materiaSeleccionada != null)
                    {
                        MostrarMateriaSeleccionado();
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
                if (this.rbEliminar.Checked)
                {
                    this.txbNombre.Enabled = false;
                }

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<Materia>)this.llstOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        materiaSeleccionada = (Materia)this.llstOpciones.SelectedItem;
                        MostrarMateriaSeleccionado();

                    }
                }

                if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMateriaSeleccionado()
        {
            this.txbNombre.Text = materiaSeleccionada.Nombre;
        }

        private async void BtnOperaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbNuevo.Checked) await Guardar();
                if (this.rbModificar.Checked) await Modificar();
                if (this.rbEliminar.Checked) await Eliminar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Eliminar()
        {
            if (materiaSeleccionada == null) throw new Exception("Debe seleccionar una materia");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await materiaSeleccionada.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                this.materiaSeleccionada = null;
                await Cargar();
            }

        }

        private async Task Modificar()
        {
            if (materiaSeleccionada == null) throw new Exception("Debe seleccionar una Materia");
            materiaSeleccionada.Nombre = this.txbNombre.Text;

            materiaSeleccionada.Validate();
            bool result = await materiaSeleccionada.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            this.materiaSeleccionada = null;
            await Cargar();
        }

        private async Task Guardar()
        {
            Materia Materia = new Materia();
            Materia.Nombre = this.txbNombre.Text;

            Materia.Validate();

            bool result = await Materia.SaveAsync();
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
            List<Materia> Materias = await Materia.GetAsync();
            this.llstOpciones.DataSource = Materias;
            this.llstOpciones.ValueMember = "Id";
            this.llstOpciones.DisplayMember = "Nombre";
        }
    }
}
