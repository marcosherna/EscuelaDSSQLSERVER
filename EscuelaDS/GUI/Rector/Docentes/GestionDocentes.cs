using EscuelaDS.CLS.Administracion;
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

namespace EscuelaDS.GUI.Rector.Docentes
{
    public partial class GestionDocentes : Form
    {
        private List<DocenteDto> docentes = new List<DocenteDto>(); 
        public GestionDocentes()
        {
            InitializeComponent();
            this.tsbSearch.TextChanged += TsbSearch_TextChanged;
            this.tsbEspecialidad.SelectedIndexChanged += TsbEspecialidad_SelectedIndexChanged;
        }

        private void TsbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var especialidad = this.tsbEspecialidad.SelectedItem;
            var fillter = docentes.Where(docente => 
                docente.Especialidad == especialidad.ToString()).ToList();
            this.dtgDocentes.DataSource = fillter;
        }

        private void TsbSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.tsbSearch.Text != null)
            {
                string query = this.tsbSearch.Text;
                var fillter = docentes.Where(
                    docente => docente.Nombre.ToLower().Contains(query) || 
                    docente.Correo.ToLower().Contains(query)).ToList();

                dtgDocentes.DataSource = fillter;
            }

            if (this.tsbSearch.Text == null)
                dtgDocentes.DataSource = docentes;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await Cargar();
                await CarcgarEspecialidades();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CarcgarEspecialidades()
        {
            var especialidades = await Especialidad.GetAsync();
            especialidades.ForEach(especialidad => {
                tsbEspecialidad.Items.Add(especialidad.Nombre);
            });
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            

            try
            {
                EdicionDocentes edicionDocentes = new EdicionDocentes();
                var result = edicionDocentes.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await Cargar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tsbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDocentes.SelectedRows.Count < 0) throw new Exception("Porfavor Seleciona un registro antes de la accion");
                var dto = (DocenteDto)this.dtgDocentes.CurrentRow.DataBoundItem;
                var docente = await Docente.GetAsync(dto.Id);

                EdicionDocentes edicionDocentes = new EdicionDocentes(docente);
                var result = edicionDocentes.ShowDialog();
                if(result == DialogResult.OK)
                {
                    await Cargar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDocentes.SelectedRows.Count < 0) throw new Exception("Porfavor Seleciona un registro antes de la accion");
                var dto = (DocenteDto)this.dtgDocentes.CurrentRow.DataBoundItem;
                var docente = await Docente.GetAsync(dto.Id);

                if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = await docente.DeleteAsync();
                    if (!result) throw new Exception("El registro no pudo ser eliminado");

                    MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                    await Cargar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Cargar()
        {
            var docentes = await Docente.GetAsync();
            this.dtgDocentes.DataSource = docentes;
            this.docentes = docentes;
        }
    }
}
