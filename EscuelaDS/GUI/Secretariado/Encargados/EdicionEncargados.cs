using EscuelaDS.CLS.Administracion;
using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
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

namespace EscuelaDS.GUI.Secretariado.Encargados
{
    public partial class EdicionEncargados : Form
    {
        private Encargado encargadoSeleccionado = null;
        private Direccion direccionencargadoSeleccionado = null;

        public static Encargado encargadoGuardado = null;
        public EdicionEncargados(Encargado encargadoSeleccionado = null)
        {
            InitializeComponent();
            this.encargadoSeleccionado = encargadoSeleccionado;
        }


        protected override async void OnLoad(EventArgs e)
        {
            try
            { 
                await CargarDistritos();

                await CargarencargadoSeleccionado();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarencargadoSeleccionado()
        {
            if (encargadoSeleccionado != null)
            {
                direccionencargadoSeleccionado = await encargadoSeleccionado.GetDireccionAsync();
                if (direccionencargadoSeleccionado == null) throw new Exception("En estos momentos es imposible recuperar la informacion del empleado, intentalo mas tarde");
                this.txbCodigoPostal.Text = direccionencargadoSeleccionado.CodigoPostal;
                this.txbLiena1.Text = direccionencargadoSeleccionado.Linea;
                this.txbLinea2.Text = direccionencargadoSeleccionado.Linea2;
                this.cmbDistritos.SelectedValue = direccionencargadoSeleccionado.IdDistrito;

                this.txbNombres.Text = encargadoSeleccionado.Nombres;
                this.txbApellido.Text = encargadoSeleccionado.Apellidos;
                this.txbDui.Text = encargadoSeleccionado.DUI; 
                this.txbTelefono.Text = encargadoSeleccionado.Telefono; 
            }
        }

        private async Task CargarDistritos()
        {
            try
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
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (encargadoSeleccionado == null)
                {
                    await Guardar();
                }

                if (encargadoSeleccionado != null)
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
            direccionencargadoSeleccionado.CodigoPostal = this.txbCodigoPostal.Text;
            direccionencargadoSeleccionado.Linea = this.txbLiena1.Text;
            direccionencargadoSeleccionado.Linea2 = this.txbLinea2.Text;
            direccionencargadoSeleccionado.IdDistrito = Convert.ToInt32(this.cmbDistritos.SelectedValue);
            direccionencargadoSeleccionado.Validate();

            bool isUpdateDireccion = await direccionencargadoSeleccionado.UpdateAsync();
            if (!isUpdateDireccion) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            encargadoSeleccionado.Nombres = this.txbNombres.Text;
            encargadoSeleccionado.Apellidos = this.txbApellido.Text;
            encargadoSeleccionado.DUI = this.txbDui.Text; 
            encargadoSeleccionado.Telefono = this.txbTelefono.Text; 

            encargadoSeleccionado.Validate();

            bool result = await encargadoSeleccionado.UpdateAsync();
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registor se guardo exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.direccionencargadoSeleccionado = null;
            this.encargadoSeleccionado = null;
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

            Encargado encargado = new Encargado
            {
                Nombres = this.txbNombres.Text,
                Apellidos = this.txbApellido.Text,
                DUI = this.txbDui.Text, 
                Telefono = this.txbTelefono.Text, 
                IdDireccion = _direccion.Id,
            };

            encargado.Validate();

            var _encargado = await encargado.SaveAndReturnAsync();
            if (_encargado.Id < 0) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            encargadoGuardado = _encargado;
            MessageBox.Show("El registor se guardo exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}