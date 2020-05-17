using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainAppForm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            // 產生一列表機物件
            PrinterSimulator.Printer printer = new PrinterSimulator.Printer();
            // 列印
            printer.Print(PrintCallback, "Print OK");
        }

        /// <summary>列印完畢後回呼呼端的委派 Function</summary>
        /// <param name="callbackMessage"></param>
        public void PrintCallback(string callbackMessage)
        {
            MessageBox.Show(callbackMessage);
        }
    }
}
