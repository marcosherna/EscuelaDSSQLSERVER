using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Rector;
using EscuelaDS.CLS.Secretaria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Secretariado.Grupos
{
    public partial class GestionGrupos : Form
    {
        private Grupo grupoSeleccionado = null;  
        public GestionGrupos()
        {
            InitializeComponent();
            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.dtgOpciones.SelectionChanged += LtbOpciones_SelectedValueChanged; 
        } 

        private async void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var item = (GrupoDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                    grupoSeleccionado = await Grupo.GetAsync(item.Id);

                    if (grupoSeleccionado != null)
                    {
                        MostrarGrupoSeleccionado();
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbTurnos.Enabled = true;
                this.cmbProfesores.Enabled = true;
                this.cmbAulas.Enabled = true;
                this.txbSeccion.Enabled = true;
                this.txbGrado.Enabled = true;
                this.txbAnio.Enabled = true;

                if (this.rbEliminar.Checked)
                {
                    this.cmbTurnos.Enabled = true;
                    this.cmbProfesores.Enabled = true;
                    this.cmbAulas.Enabled = true;
                    this.txbSeccion.Enabled = true;
                    this.txbGrado.Enabled = true;
                    this.txbAnio.Enabled = true;
                }

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<GrupoDto>)this.dtgOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        var item = (GrupoDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                        grupoSeleccionado = await Grupo.GetAsync(item.Id);

                        MostrarGrupoSeleccionado();

                    }
                }

                if (this.rbNuevo.Checked)
                {
                    this.txbSeccion.Text = string.Empty;
                    this.txbGrado.Text = string.Empty;
                    this.txbAnio.Text = string.Empty;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarGrupoSeleccionado()
        {
            this.cmbAulas.SelectedValue = grupoSeleccionado.IdAula;
            this.cmbProfesores.SelectedValue = grupoSeleccionado.IdDocente;
            this.cmbTurnos.SelectedValue = grupoSeleccionado.IdTurno;

            this.txbSeccion.Text = grupoSeleccionado.Seccion;
            this.txbGrado.Text = grupoSeleccionado.Grado;
            this.txbAnio.Text = grupoSeleccionado.Anio.ToString();
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
            if (grupoSeleccionado == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await grupoSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbSeccion.Text = string.Empty;
                this.txbGrado.Text = string.Empty;
                this.txbAnio.Text = string.Empty;
                this.grupoSeleccionado = null;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (grupoSeleccionado == null) throw new Exception("Debe seleccionar un país");

            grupoSeleccionado.IdTurno = Convert.ToInt32(this.cmbTurnos.SelectedValue);
            grupoSeleccionado.IdDocente = Convert.ToInt32(this.cmbProfesores.SelectedValue);
            grupoSeleccionado.IdAula = Convert.ToInt32(this.cmbAulas.SelectedValue);

            grupoSeleccionado.Grado = this.txbGrado.Text;
            grupoSeleccionado.Seccion = this.txbSeccion.Text;
            grupoSeleccionado.Anio = Convert.ToInt32(this.txbAnio.Text);

            grupoSeleccionado.Validate();
            bool result = await grupoSeleccionado.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbSeccion.Text = string.Empty;
            this.txbGrado.Text = string.Empty;
            this.txbAnio.Text = string.Empty;
            this.grupoSeleccionado = null;
            await Cargar();
        }

        private async Task Guardar()
        {
            Grupo grupo = new Grupo();

            grupo.IdTurno = Convert.ToInt32(this.cmbTurnos.SelectedValue);
            grupo.IdDocente = Convert.ToInt32(this.cmbProfesores.SelectedValue);
            grupo.IdAula = Convert.ToInt32(this.cmbAulas.SelectedValue); 
            grupo.Grado = this.txbGrado.Text;
            grupo.Seccion = this.txbSeccion.Text;
            grupo.Anio = Convert.ToInt32(this.txbAnio.Text);
            grupo.Validate();

            bool result = await grupo.SaveAsync();

            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbSeccion.Text = string.Empty;
            this.txbGrado.Text = string.Empty;
            this.txbAnio.Text = string.Empty;
            await Cargar();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarTurnos();
                await CargarProfesores();
                await CargarAulas();
                await Cargar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarAulas()
        {
            var aulas = await Aula.GetAsync();
            aulas = aulas.Select(aula => new Aula {
                Id = aula.Id,
                Edificio = aula.Edificio + " No. " + aula.Numero,
             }).ToList();
            this.cmbAulas.DataSource = aulas;
            this.cmbAulas.DisplayMember = "Edificio";
            this.cmbAulas.ValueMember = "Id";
        }

        private async Task CargarProfesores()
        {
            var profesores = await Docente.GetAsync();
            this.cmbProfesores.DataSource = profesores;
            this.cmbProfesores.DisplayMember = "Nombre";
            this.cmbProfesores.ValueMember = "Id";

        }

        private async Task CargarTurnos()
        {
            List<Turno> paises = await Turno.GetAsync();
            this.cmbTurnos.DataSource = paises;
            this.cmbTurnos.DisplayMember = "Nombre";
            this.cmbTurnos.ValueMember = "Id";
        }

        private async Task Cargar()
        {
            List<GrupoDto> grupos = await Grupo.GetAsync();
            this.dtgOpciones.DataSource = grupos;
        }
    }
}
