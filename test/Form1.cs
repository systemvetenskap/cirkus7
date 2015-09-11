using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(" HELLO! ", new Font("Arial", 18), 
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDialog pdialog = new PrintDialog();
            pdialog.Document = printDocument1;
            //pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(partOfForm());

            DialogResult result = pdialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
