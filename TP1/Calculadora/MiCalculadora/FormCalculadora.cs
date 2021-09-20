using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.cmbOperador.Text != "" && this.txtNumero1.Text != "" && this.txtNumero2.Text != "")
            {
                double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                string srtResultado = resultado.ToString();
                string operacion = this.txtNumero1.Text + " " + this.cmbOperador.Text + " " + this.txtNumero2.Text + " = " + resultado;

                this.lstOperaciones.Items.Add(operacion);

                this.lblResultado.Text = srtResultado;
            }
            else
            {
                MessageBox.Show("Debe rellenar todos los campos de la operacion", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = " ";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            return Calculadora.Operar(operando1, operando2, operador);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
            }
        }


        private void FormCalculadora_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de querer salir?", "Cerrar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (respuesta == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
