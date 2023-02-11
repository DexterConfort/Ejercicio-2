using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicación2
{
    public partial class Ejercicio2 : Form
    {
        public Ejercicio2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (Nota1TextBox.Text == "")
            {
                PosibleErrorProvider.SetError(Nota1TextBox, "Campo vacío");
                return;
            }
            PosibleErrorProvider.Clear();
            if (Nota2TextBox.Text == "")
            {
                PosibleErrorProvider.SetError(Nota2TextBox, "Campo vacío");
                return;
            }
            PosibleErrorProvider.Clear();
            if (Nota3TextBox.Text == "")
            {
                PosibleErrorProvider.SetError(Nota3TextBox, "Campo vacío");
                return;
            }
            if (Nota4TextBox.Text == "")
            {
                PosibleErrorProvider.SetError(Nota4TextBox, "Campo vacío");
                return;
            }
            PosibleErrorProvider.Clear();

            decimal nota1 = Convert.ToDecimal(Nota1TextBox.Text);
            decimal nota2 = Convert.ToDecimal(Nota2TextBox.Text);
            decimal nota3 = Convert.ToDecimal(Nota3TextBox.Text);
            decimal nota4 = Convert.ToDecimal(Nota4TextBox.Text);

            decimal promedio = await PromedioAsync(nota1, nota2, nota3, nota4);

            PromedioTextBox.Text = Convert.ToString(promedio);
        }

        private async Task<decimal> PromedioAsync(decimal nota1, decimal nota2, decimal nota3, decimal nota4)
        {
            decimal promedio = await Task.Run(() => {
                return (nota1 + nota2 + nota3 + nota4) / 4;
            });
            return promedio;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PosibleErrorProvider.Clear();
            Nota1TextBox.Text = "";
            Nota2TextBox.Text = "";
            Nota3TextBox.Text = "";
            Nota4TextBox.Text = "";
            PromedioTextBox.Text = "";
        }
    }
}
