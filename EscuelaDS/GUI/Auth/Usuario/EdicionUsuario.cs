using EscuelaDS.CLS.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Auth.Usuario
{
    public partial class EdicionUsuario : Form
    {
        int idEmpleado = 0;
        private CLS.Auth.Usuario usuario = null;
        public EdicionUsuario(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            this.cmbRoles.SelectedValueChanged += CmbRoles_SelectedValueChanged;
        }

        private async void CmbRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoles.SelectedItem != null)
                {
                    var rol = (Rol)cmbRoles.SelectedItem;
                    if (rol != null)
                    { 
                        this.tvOpciones.Nodes.Clear();
                        await AddNodeRol(rol);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AddNodeRol(Rol rol)
        {
            var nodeRol = new TreeNode(rol.Nombre) { Tag = rol.Id };
            this.tvOpciones.Nodes.Add(nodeRol);

            var opciones = await rol.GetOpcionesAsync();

            opciones.ForEach(opcion => {
                var nodeOpciones = new TreeNode(opcion.Nombre) { Tag = opcion.Id };
                nodeRol.Nodes.Add(nodeOpciones);
            });

            this.tvOpciones.ExpandAll();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarRoles();  
                await ComprobarUsuario();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task ComprobarUsuario()
        {
            this.usuario = await CLS.Auth.Usuario.GetByIdEmpleadosync(this.idEmpleado);
            if (this.usuario != null)
            {

                txbUserName.Text = this.usuario.UserName;
                txbPassword.Text = this.usuario.Password;
                cmbRoles.SelectedValue = this.usuario.IdRol;
            }
        }

        private async Task CargarRoles()
        {
            var roles = await Rol.GetAsync();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "Id";
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               if(this.usuario == null)
               {
                    await Guardar();
               }

               if (this.usuario != null)
               {
                    await Actualizar();
               }
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Actualizar()
        { 
            this.usuario.IdRol = Convert.ToInt32(cmbRoles.SelectedValue);
            this.usuario.UserName = txbUserName.Text;
            this.usuario.Password = txbPassword.Text;

            bool result = await this.usuario.UpdateAsync();
            if (!result) throw new Exception("No se pudo actualizar el usuario");
            MessageBox.Show("Usuario actualizado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task Guardar()
        {
            CLS.Auth.Usuario usuario = new CLS.Auth.Usuario
            {
                IdEmpleado = this.idEmpleado,
                IdRol = Convert.ToInt32(cmbRoles.SelectedValue),
                UserName = txbUserName.Text,
                Password = txbPassword.Text
            };

            bool result = await usuario.SaveAsync();
            if (!result) throw new Exception("No se pudo guardar el usuario");
            MessageBox.Show("Usuario guardado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.usuario == null) throw new Exception("No se puede eliminar el usuario");

                if (this.usuario != null)
                {
                    if (MessageBox.Show("¿Realmente desea eliminar el usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool result =await this.usuario.DeleteAsync();
                        if (!result) throw new Exception("No se pudo eliminar el usuario");
                        MessageBox.Show("Usuario eliminado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception exc)
            { 
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
