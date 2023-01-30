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
        BindingList<ToDoData> todoDataList = new BindingList<ToDoData>();
         
        public frmToDo(string filePath)
        {
            InitializeComponent();

            lblFileName.Text = Path.GetFileName(filePath);

            string curPath = Path.GetDirectoryName(filePath);
            string curFileName = Path.GetFileNameWithoutExtension(filePath) + "_ToDo.txt";

            todoFilePath = curPath + @"\" + curFileName;

            ReadToDoFile();
        }

        private void ReadToDoFile()
        {
            if(File.Exists(todoFilePath))
            {
                int counter = 0;
                string[] strings = File.ReadAllLines(todoFilePath);

                foreach( string line in strings )
                {
                    string[] todoData = ToDoData.ParseDsiplayString(line);

                    ToDoData curToDo = new ToDoData(counter +1, todoData[0], todoData[1]);
                }
            }
        }
    }
}
