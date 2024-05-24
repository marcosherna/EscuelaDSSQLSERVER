using EscuelaDS.CLS.Administracion;
using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace EscuelaDS.GUI.Admnistracion.Empleados
{
    public partial class EdicionEmpleado : Form
    {
        private List<DistritoDto> distritos = new List<DistritoDto>();
        private Empleado empleadoSeleccionado = null;
        private Direccion direccionEmpleadoSeleccionado = null;
        public EdicionEmpleado(Empleado empleadoSeleccionado = null)
        {
            InitializeComponent();
            this.empleadoSeleccionado = empleadoSeleccionado;
        }
         

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarCargos();
                await CargarDistritos();

                await CargarEmpleadoSeleccionado();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarEmpleadoSeleccionado()
        {
            if (empleadoSeleccionado != null)
            {
                direccionEmpleadoSeleccionado = await empleadoSeleccionado.GetDireccionAsync();
                if (direccionEmpleadoSeleccionado == null) throw new Exception("En estos momentos es imposible recuperar la informacion del empleado, intentalo mas tarde");
                this.txbCodigoPostal.Text = direccionEmpleadoSeleccionado.CodigoPostal;
                this.txbLiena1.Text = direccionEmpleadoSeleccionado.Linea;
                this.txbLinea2.Text = direccionEmpleadoSeleccionado.Linea2;
                this.cmbDistritos.SelectedValue = direccionEmpleadoSeleccionado.IdDistrito;

                this.txbNombres.Text = empleadoSeleccionado.Nombres;
                this.txbApellido.Text = empleadoSeleccionado.Apellidos;
                this.txbDui.Text = empleadoSeleccionado.DUI;
                this.txbISSS.Text = empleadoSeleccionado.ISSS;
                this.txbCorreo.Text = empleadoSeleccionado.Correo;
                this.txbTelefono.Text = empleadoSeleccionado.Telefono;
                this.cmbCargos.SelectedValue = empleadoSeleccionado.IdCargo;
                this.dtpFechaNacimiento.Value = empleadoSeleccionado.FechaNac;  
            }
        }

        private async Task CargarDistritos()
        {
            var distritos = await Distrito.GetAsync();

            this.distritos = distritos.Select(distrito => new DistritoDto {
                Id = distrito.Id,
                Nombre = distrito.Pais + ", " + distrito.Departamenbto + ", " + distrito.Municipio + ", " + distrito.Nombre
            }).ToList();

            this.cmbDistritos.DataSource = this.distritos;
            this.cmbDistritos.ValueMember = "Id";
            this.cmbDistritos.DisplayMember = "Nombre";
        }

        private async Task CargarCargos()
        {
            List<Cargo> cargos = await Cargo.GetAsync();
            this.cmbCargos.DataSource = cargos;
            this.cmbCargos.ValueMember = "Id";
            this.cmbCargos.DisplayMember = "Nombre";
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(empleadoSeleccionado == null)
                {
                    await Guardar();
                }

                if(empleadoSeleccionado != null)
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
            direccionEmpleadoSeleccionado.CodigoPostal = this.txbCodigoPostal.Text;
            direccionEmpleadoSeleccionado.Linea = this.txbLiena1.Text;
            direccionEmpleadoSeleccionado.Linea2 = this.txbLinea2.Text;
            direccionEmpleadoSeleccionado.IdDistrito = Convert.ToInt32(this.cmbDistritos.SelectedValue);
            direccionEmpleadoSeleccionado.Validate();

            bool isUpdateDireccion = await direccionEmpleadoSeleccionado.UpdateAsync();
            if (!isUpdateDireccion) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            empleadoSeleccionado.Nombres = this.txbNombres.Text;
            empleadoSeleccionado.Apellidos = this.txbApellido.Text;
            empleadoSeleccionado.DUI = this.txbDui.Text;
            empleadoSeleccionado.ISSS = this.txbISSS.Text;
            empleadoSeleccionado.Correo = this.txbCorreo.Text;
            empleadoSeleccionado.Telefono = this.txbTelefono.Text;
            empleadoSeleccionado.IdCargo = Convert.ToInt32(this.cmbCargos.SelectedValue);
            empleadoSeleccionado.FechaNac = this.dtpFechaNacimiento.Value;
            empleadoSeleccionado.Validate();

            bool result = await empleadoSeleccionado.UpdateAsync();
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registor se guardo exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.direccionEmpleadoSeleccionado = null;
            this.empleadoSeleccionado = null;
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

            Empleado empleado = new Empleado
            {
                Nombres = this.txbNombres.Text,
                Apellidos = this.txbApellido.Text,
                DUI = this.txbDui.Text,
                ISSS = this.txbISSS.Text,
                Correo = this.txbCorreo.Text,
                Telefono = this.txbTelefono.Text,
                IdCargo = Convert.ToInt32(this.cmbCargos.SelectedValue),
                FechaNac = this.dtpFechaNacimiento.Value,
                IdDireccion = _direccion.Id,
            };
            empleado.Validate();
            bool result = await empleado.SaveAsync();
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registor se guardo exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
