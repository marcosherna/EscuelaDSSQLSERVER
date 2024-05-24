using EscuelaDS.CLS.Administracion;
using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Secretaria;
using EscuelaDS.GUI.Secretariado.Encargados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Secretariado.Estudiantes
{
    public partial class EdicioEstudiantes : Form
    {
        private Estudiante estudianteSeleccionado = null;
        private Direccion direccionestudianteSeleccionado = null;
        private Encargado encargado = null;
        public EdicioEstudiantes(Estudiante estudianteSeleccionado = null)
        {
            InitializeComponent();
            this.estudianteSeleccionado = estudianteSeleccionado;
        }


        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                CargarGeneros();
                await CargarDistritos();

                await CargarestudianteSeleccionado();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarestudianteSeleccionado()
        {
            try
            {
                if (estudianteSeleccionado != null)
                {
                    this.txbNie.Enabled = false;
                    direccionestudianteSeleccionado = await estudianteSeleccionado.GetDireccionAsync();
                    if (direccionestudianteSeleccionado == null) throw new Exception("En estos momentos es imposible recuperar la informacion del empleado, intentalo mas tarde");
                    this.txbCodigoPostal.Text = direccionestudianteSeleccionado.CodigoPostal;
                    this.txbLiena1.Text = direccionestudianteSeleccionado.Linea;
                    this.txbLinea2.Text = direccionestudianteSeleccionado.Linea2;
                    this.cmbDistritos.SelectedValue = direccionestudianteSeleccionado.IdDistrito;

                    this.txbNombres.Text = estudianteSeleccionado.Nombres;
                    this.txbApellido.Text = estudianteSeleccionado.Apellidos;
                    this.txbNie.Text = estudianteSeleccionado.NIE.ToString();
                    this.txbTelefono.Text = estudianteSeleccionado.Telefono; 

                    this.cmbGenero.SelectedValue = estudianteSeleccionado.Genero;
                    this.dtpFechaNacimiento.Value = estudianteSeleccionado.FechaNac;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async Task CargarDistritos()
        {
            var distritos = await Distrito.GetAsync();

            distritos = distritos.Select(distrito => new DistritoDto
            {
                Id = distrito.Id,
                Nombre = distrito.Pais + ", " + distrito.Departamenbto + ", " + distrito.Municipio + ", " + distrito.Nombre
            }).ToList();

            this.cmbDistritos.DataSource = distritos;
            this.cmbDistritos.ValueMember = "Id";
            this.cmbDistritos.DisplayMember = "Nombre";
        }

        private void CargarGeneros()
        {
            List<Genero> cargos = Genero.Get();
            this.cmbGenero.DataSource = cargos;
            this.cmbGenero.ValueMember = "Id";
            this.cmbGenero.DisplayMember = "Nombre";
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estudianteSeleccionado == null)
                {
                    await Guardar();
                }

                if (estudianteSeleccionado != null)
                {
                    await Modificar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Modificar()
        {
            direccionestudianteSeleccionado.CodigoPostal = this.txbCodigoPostal.Text;
            direccionestudianteSeleccionado.Linea = this.txbLiena1.Text;
            direccionestudianteSeleccionado.Linea2 = this.txbLinea2.Text;
            direccionestudianteSeleccionado.IdDistrito = Convert.ToInt32(this.cmbDistritos.SelectedValue);
            direccionestudianteSeleccionado.Validate();

            bool isUpdateDireccion = await direccionestudianteSeleccionado.UpdateAsync();
            if (!isUpdateDireccion) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            estudianteSeleccionado.Nombres = this.txbNombres.Text;
            estudianteSeleccionado.Apellidos = this.txbApellido.Text; 
            estudianteSeleccionado.Telefono = this.txbTelefono.Text; 
            estudianteSeleccionado.FechaNac = this.dtpFechaNacimiento.Value;
            estudianteSeleccionado.Genero = this.cmbGenero.SelectedValue.ToString();

            estudianteSeleccionado.Validate();

            bool result = await estudianteSeleccionado.UpdateAsync();
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registor se guardo exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.direccionestudianteSeleccionado = null;
            this.estudianteSeleccionado = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async Task Guardar()
        {
            Direccion direccion = new Direccion
            {
                CodigoPostal = this.txbCodigoPostal.Text,
                Linea = this.txbLiena1.Text,
                Linea2 = this.txbLinea2.Text,
                IdDistrito = Convert.ToInt32(this.cmbDistritos.SelectedValue)
            };

            direccion.Validate();

            Direccion _direccion = await direccion.SaveAndReturnAsync();
            if (_direccion.Id <= 0) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            Estudiante estudiante = new Estudiante
            {
                NIE = Convert.ToInt32(this.txbNie.Text),
                Nombres = this.txbNombres.Text,
                Apellidos = this.txbApellido.Text,
                Telefono = this.txbTelefono.Text,
                FechaNac = this.dtpFechaNacimiento.Value,
                Genero = this.cmbGenero.SelectedValue.ToString(),
                IdDireccion = _direccion.Id,
                IdEncargado = encargado.Id
            };

            estudiante.Validate();
            bool result = await estudiante.SaveAsync();
            
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registor se guardo exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private async void btnEncargado_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = DialogResult.Cancel;

                if (estudianteSeleccionado == null)
                {

                    EdicionEncargados edicionEncargados = new EdicionEncargados();
                    result = edicionEncargados.ShowDialog();
                }

                if (estudianteSeleccionado != null)
                {
                    Encargado encargado = await estudianteSeleccionado.GetEncargadoAsync();
                    if (encargado == null) throw new Exception("No se puede recuperar el regsitro, porfavor intentelo  mas tarde");
                    EdicionEncargados edicionEncargados = new EdicionEncargados(encargado);
                    result = edicionEncargados.ShowDialog();
                }

                if (result == DialogResult.OK)
                {
                    encargado = EdicionEncargados.encargadoGuardado;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
