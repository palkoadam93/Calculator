using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double value;
        string soperator;
        bool check;
        public Form1()
        {
            InitializeComponent();
        }

        //PNumber eseménykezelő: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, .
        //ezek a gombok ugyanezt a PNumber eljárást hívják megnyomáskor!
        private void PNumber(object sender, EventArgs e)
        {
            //ha műveleti jel megnyomása UTÁN nyomunk számot!
            if ((soperator=="+")||(soperator=="-")||(soperator=="*")||(soperator=="/"))
            {
                if (check)
                    //ha meg van nyomva műveleti jel
                {
                    check = false; //már nem nyomhatunk műveleti jelet
                    txtResult.Text = "0";
                }
            }
            Button b = sender as Button;
                //eltároljuk a gombot a "b" változóban
            if (txtResult.Text == "0") txtResult.Text = b.Text;
                //ha a szövegmezőben 0 van, értéke a b.Text
            else txtResult.Text += b.Text;
                //különben hozzáfűzi a b.Text értékét
        }

        //POperator eseménykezelő: +, -, *, /
        //mindegyik műveleti jel ezt az eljárást hívja
        private void POperator(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                    //eltároljuk a gombot a "b" változóban
                value = double.Parse(txtResult.Text);
                //value = Convert.ToDouble(txtResult.Text);
                    //eltároljuk a szövegmező értékét valós számként
                soperator = b.Text;
                    //eltároljuk a műveleti jelet sztringként
                txtResult.Text += b.Text;
                    //hozzáírjuk a műveleti jelet!
                check = true;
                    //igaz, hogy meg van nyomva egy műveleti jel!
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //VISSZAVONÁS ESEMÉNYKEZELŐ
        private void button5_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        //TÖRLÉS ESEMÉNYKEZELŐ
        private void button10_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            value = 0; //a szövegmező értékének tárolását is törli!
        }

        //KIÉRTÉKELÉS ESEMÉNYKEZELŐ
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                switch (soperator)
                {
                    case "+":
                        txtResult.Text = (value + double.Parse(txtResult.Text)).ToString();
                        //a szövegmező előző értékéhez hozzáadja a jelenlegi értékét!
                        break;
                    case "-":
                        txtResult.Text = (value - double.Parse(txtResult.Text)).ToString();
                        //a szövegmező előző értékéből kivonja a jelenlegi értékét!
                        break;
                    case "*":
                        txtResult.Text = (value * double.Parse(txtResult.Text)).ToString();
                        //a szövegmező előző értékét megszorozza a jelenlegi értékével!
                        break;
                    case "/":
                        txtResult.Text = (value / double.Parse(txtResult.Text)).ToString();
                        //a szövegmező előző értékét elosztja a jelenlegi értékével!
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
