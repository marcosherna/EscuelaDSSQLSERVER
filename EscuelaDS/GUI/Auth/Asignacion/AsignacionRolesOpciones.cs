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

namespace EscuelaDS.GUI.Auth.Asignacion
{
    public partial class AsignacionRolesOpciones : Form
    {
        public AsignacionRolesOpciones()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarRoles();
                await CargarOpciones();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarOpciones()
        { 
            var opciones = await Opcion.GetAsync();
            lstOpciones.DataSource = opciones;
            lstOpciones.DisplayMember = "Nombre";
            lstOpciones.ValueMember = "Id";
        }

        private async Task CargarRoles()
        { 
            var roles = await Rol.GetWithOpcionesAsync();

            roles.ForEach(rol => { 
                var nodeRol = new TreeNode(rol.Nombre) { Tag = rol.Id };
                this.tvRoles.Nodes.Add(nodeRol);
                
                rol.Opcions.ForEach(opcion => {
                    var nodeOpciones = new TreeNode(opcion.Nombre) { Tag = opcion.Id };
                    nodeRol.Nodes.Add(nodeOpciones);
                });
            }); 
            this.tvRoles.ExpandAll();
        }

        private async void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                var  nodoRols = tvRoles.SelectedNode;

                if (nodoRols == null) throw new Exception("Debe seleccionar un rol");
                if (!(lstOpciones.SelectedItem is Opcion nodoOpcion)) throw new Exception("Debe seleccionar una opcion");

                var rol = new Rol { Id =  Convert.ToInt32(nodoRols.Tag), Nombre = nodoRols.Text };

                await rol.OpcionEstaAsignada(nodoOpcion);

                bool result = await rol.AsignarOpcionAsync(nodoOpcion);

                if(!result) throw new Exception("No se pudo asignar la opcion al rol");
                this.tvRoles.Nodes.Clear();
                await CargarRoles();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var nodoRols = tvRoles.SelectedNode.Parent; 
                var nodOpcion = tvRoles.SelectedNode; 

                if (nodoRols == null) throw new Exception("Debe seleccionar una opcion para ejecutar la accion");
                if (nodOpcion == null) throw new Exception("Debe seleccionar una opcion para ejecutar la accion");

                if (!(nodOpcion.Tag is int idOpcion)) throw new Exception("No se pudo obtener el id de la opcion");
                if (!(nodoRols.Tag is int idRol)) throw new Exception("No se pudo obtener el id del rol");

                var rol = new Rol { Id = idRol, Nombre = nodoRols.Text };
                var opcion = new Opcion { Id = idOpcion, Nombre = nodOpcion.Text };

                bool result = await rol.EliminarOpcionAsignada(opcion);
                if (!result) throw new Exception("No se pudo eliminar la opcion del rol");
                this.tvRoles.Nodes.Clear();
                await CargarRoles();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
