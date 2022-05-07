using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// !!! УВАГА похідна з наведеного варіанту дає ціле число тому така велика точність вимірювань УВАГА !!!

namespace Lab_4_NM_Var9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_a.Clear();
            textBox_b.Clear();
            textBox_y0.Clear();
            textBox_h.Clear();

            label_x1.Text = "x1";
            label_y1.Text = "y1";

            label_x2.Text = "x2";
            label_y2.Text = "y2";

            label_x3.Text = "x3";
            label_y3.Text = "y3";

            label_x4.Text = "x4";
            label_y4.Text = "y4";

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();

            double a, b, y0, h;
            double y0_h, h_h;

            const int arr_size = 100;

            a = Convert.ToDouble(textBox_a.Text);
            b = Convert.ToDouble(textBox_b.Text);
            y0 = Convert.ToDouble(textBox_y0.Text);
            h = Convert.ToDouble(textBox_h.Text);


            // Метод Ейлера
            {
                y0_h = y0;
                h_h = h;

                double[] arr_x = new double[arr_size + 1];
                double[] arr_y = new double[arr_size + 1];
                double ffunc;

                for (int i = 0; i < arr_size; i++)
                {
                    arr_y[0] = y0_h;
                    arr_x[0] = 0.201938;

                    if (arr_x[i] >= a && arr_x[i] <= b)
                    {
                        chart1.Series[0].Points.AddXY(arr_x[i], arr_y[i]);
                    }

                    ffunc = 5 / 2;

                    arr_x[i + 1] = arr_x[0] + (i + 1) * h_h;

                    arr_y[i + 1] = arr_y[i] + h_h * ffunc;

                }
                label_x1.Text = Convert.ToString(arr_x[arr_size]);
                label_y1.Text = Convert.ToString(arr_y[arr_size]);
            }

            // Метод додаткового півкроку
            {
                y0_h = y0;
                h_h = h;

                double[] arr_x = new double[arr_size + 1];
                double[] arr_y = new double[arr_size + 1];
                double[] arr_yh = new double[arr_size + 1];
                double ffunc;
                double ffunc_h;

                for (int i = 0; i < arr_size; i++)
                {
                    arr_y[0] = y0_h;
                    arr_x[0] = 0.201938;

                    if (arr_x[i] >= a && arr_x[i] <= b)
                    {
                        chart1.Series[1].Points.AddXY(arr_x[i], arr_y[i]);
                    }

                    ffunc = 5 / 2;

                    arr_yh[i + 1] = arr_y[i] + h_h / 2 * ffunc;

                    ffunc_h = 5 / 2;

                    arr_x[i + 1] = arr_x[0] + (i + 1) * h_h;

                    arr_y[i + 1] = arr_y[i] + h_h * ffunc_h;

                }
                label_x2.Text = Convert.ToString(arr_x[arr_size]);
                label_y2.Text = Convert.ToString(arr_y[arr_size]);
            }

            // Метод пробного кроку
            {
                y0_h = y0;
                h_h = h;

                double[] arr_x = new double[arr_size + 1];
                double[] arr_y = new double[arr_size + 1];
                double[] arr_yh = new double[arr_size + 1];
                double ffunc;
                double ffunc_h;

                for (int i = 0; i < arr_size; i++)
                {
                    arr_y[0] = y0_h;
                    arr_x[0] = 0.201938;

                    if (arr_x[i] >= a && arr_x[i] <= b)
                    {
                        chart1.Series[2].Points.AddXY(arr_x[i], arr_y[i]);
                    }

                    ffunc = 5 / 2;

                    arr_yh[i + 1] = arr_y[i] + (h_h * ffunc);

                    ffunc_h = 5 / 2;

                    arr_x[i + 1] = arr_x[0] + (i + 1) * h_h;

                    arr_y[i + 1] = arr_y[i] + (h_h / 2 * (ffunc + ffunc_h));
                }
                label_x3.Text = Convert.ToString(arr_x[arr_size]);
                label_y3.Text = Convert.ToString(arr_y[arr_size]);
            }

            // Метод Рунге-Кутта
            {
                y0_h = y0;
                h_h = h;

                double[] arr_x = new double[arr_size + 1];
                double[] arr_y = new double[arr_size + 1];
                double[] arr_k = new double[4];
                double ffunc;
                double ffunc_h1;
                double ffunc_h2;
                double ffunc_h3;

                double t = 0.166667;

                for (int i = 0; i < arr_size; i++)
                {
                    arr_y[0] = y0_h;
                    arr_x[0] = 0.201938;

                    if (arr_x[i] >= a && arr_x[i] <= b)
                    {
                        chart1.Series[3].Points.AddXY(arr_x[i], arr_y[i]);
                    }

                    ffunc = 5 / 2;

                    arr_k[0] = h_h * ffunc;

                    ffunc_h1 = 5 / 2;

                    arr_k[1] = h_h * ffunc_h1;

                    ffunc_h2 = 5 / 2;

                    arr_k[2] = h_h * ffunc_h2;

                    ffunc_h3 = 5 / 2;

                    arr_k[3] = h_h * ffunc_h3;

                    arr_x[i + 1] = arr_x[0] + (i + 1) * h_h;

                    arr_y[i + 1] = arr_y[i] + ((t) * (arr_k[0] + 2 * arr_k[1] + 2 * arr_k[2] + arr_k[3]));
                }
                label_x4.Text = Convert.ToString(arr_x[arr_size]);
                label_y4.Text = Convert.ToString(arr_y[arr_size]);
            }
        }
    }
}
