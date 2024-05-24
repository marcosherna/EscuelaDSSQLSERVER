﻿using EscuelaDS.CLS.Catalogos;
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

namespace EscuelaDS.GUI.Rector.Turnos
{
    public partial class GestionTurnos : Form
    {
        private Turno turnoSeleccionado = null;
        public GestionTurnos()
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
                    turnoSeleccionado = (Turno)this.llstOpciones.SelectedItem;
                    if (turnoSeleccionado != null)
                    {
                        MostrarturnoSeleccionado();
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
                    var items = (List<Turno>)this.llstOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        turnoSeleccionado = (Turno)this.llstOpciones.SelectedItem;
                        MostrarturnoSeleccionado();

                    }
                }

                if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private  void MostrarturnoSeleccionado()
        { 
            this.txbNombre.Text = turnoSeleccionado.Nombre; 
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
            if (turnoSeleccionado == null) throw new Exception("Debe seleccionar un turno");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await turnoSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                this.turnoSeleccionado = null;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (turnoSeleccionado == null) throw new Exception("Debe seleccionar un Tuno");
            turnoSeleccionado.Nombre = this.txbNombre.Text; 

            turnoSeleccionado.Validate();
            bool result = await turnoSeleccionado.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            this.turnoSeleccionado = null;
            await Cargar();
        }

        private async Task Guardar()
        {
            Turno Turno = new Turno();
            Turno.Nombre = this.txbNombre.Text; 

            Turno.Validate();

            bool result = await Turno.SaveAsync();
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
            List<Turno> Turnos = await Turno.GetAsync();
            this.llstOpciones.DataSource = Turnos;
            this.llstOpciones.ValueMember = "Id";
            this.llstOpciones.DisplayMember = "Nombre";
        }
    }
}
