using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RAA_Session_07_Challenge
{
    public partial class frmToDo : Form
    {
        string todoFilePath = "";

        public frmToDo(string filePath)
        {
            InitializeComponent();

            lblFileName.Text = Path.GetFileName(filePath);

            string curPath = Path.GetDirectoryName(filePath);
            string curFileName = Path.GetFileNameWithoutExtension(filePath) + "_ToDo.txt";

            todoFilePath = curPath + @"\" + curFileName;
        }
    }
}
