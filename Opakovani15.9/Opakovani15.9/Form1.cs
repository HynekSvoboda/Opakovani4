using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Opakovani15._9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            StreamReader cteni=null;
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                cteni = new StreamReader("cisla.txt");
                int i = 1;
                long cislo=0;
                double soucet=0;
                while(!cteni.EndOfStream)
                {
                    long cisla= Convert.ToInt64(cteni.ReadLine());
                    if (i == 5)
                    {
                        cislo = cisla;
                    }
                    soucet += cisla;
                    i++;
                }
                long umocneni=0;
                if (n > 0)
                {
                    umocneni = cislo;
                    for (int c = 1; c < n; c++)
                    {
                        checked { umocneni *= cislo; }
                    }
                }
                else if (n == 0) umocneni = 1;
                else
                {
                    umocneni = 1;
                    int p = Convert.ToInt32(n * -1);
                    for (int c = 0; c < p; c++)
                    {
                        checked { umocneni /= cislo; }
                    }
                }
                label4.Text = cislo+ "^"+n +" = "+ umocneni;
                double podil = cislo / n;
                int podil2 = (int)cislo / n;
                label1.Text="Reálný podíl "+cislo+"/"+n+" = "+podil;
                label2.Text="Celočíselný podíl: " + cislo + "/" + n + " = " + podil2;
                label3.Text = "Součet všech čísel ze souboru: " + soucet;
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "N není číslo");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Deleni nulou");
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Přetečení");
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Soubor nenalezen");
            }
            finally
            {
                if(cteni!=null) cteni.Close();
            }

        }
    }
}
