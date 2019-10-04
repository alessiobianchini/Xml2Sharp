using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Xml2Sharp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
