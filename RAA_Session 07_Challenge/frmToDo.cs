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
        ToDoData curEdit;
         
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
                    todoDataList.Add(curToDo);
                    counter++;
                }
            }

            ShowData();
        }

        private void ShowData()
        {
            lbxToDo.DataSource = null;
            lbxToDo.DataSource = todoDataList;
            lbxToDo.DisplayMember = "Display";
        }

        private void AddToDoItem(string todoText)
        {
            ToDoData curToDo = new ToDoData(todoDataList.Count +1, todoText, "To Do");
            todoDataList.Add(curToDo);

            WriteToDoFile();
        }

        private void RemoveItem(ToDoData curToDo)
        {
            todoDataList.Remove(curToDo);
            ReOrderToDoItems();

            WriteToDoFile();
        }

        private void ReOrderToDoItems()
        {
            for(int i = 0; i < todoDataList.Count; i++)
            {
                todoDataList[i].PositionNumber = i + 1;
                todoDataList[i].UpdateDisplayString();
            }
            WriteToDoFile();
        }

        private void WriteToDoFile()
        {
            using (StreamWriter writer = File.CreateText(todoFilePath))
            {
                foreach(ToDoData curToDo in lbxToDo.Items)
                {
                    curToDo.UpdateDisplayString();
                    writer.WriteLine(curToDo.Display);
                }
            }

            ShowData();
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            if(curEdit == null)
            {
                AddToDoItem(tbxAddEdit.Text);
            }
            else
            {
                CompleteEditingItem();
            }

            tbxAddEdit.Text = "";
            
        }

        private void CompleteEditingItem()
        {
            foreach(ToDoData todo in todoDataList)
            {
                if(todo == curEdit)
                    todo.Text = tbxAddEdit.Text;
            }

            curEdit = null;
            lblAddEdit.Text = "Add Item";
            btnAddEdit.Text = "Add Item";

            WriteToDoFile();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lbxToDo.SelectedItems != null)
            {
                ToDoData curToDo = lbxToDo.SelectedItem as ToDoData;
                RemoveItem(curToDo);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbxToDo.SelectedItems != null)
            {
                ToDoData curToDo = lbxToDo.SelectedItem as ToDoData;
                StartEditingItem(curToDo);
            }
        }

        private void StartEditingItem(ToDoData curToDo)
        {
            curEdit = curToDo;

            lblAddEdit.Text = "Update Item";
            btnAddEdit.Text = "Update Item";
            tbxAddEdit.Text = curToDo.Text;
        }

        private void lbxToDo_DoubleClick(object sender, EventArgs e)
        {
            if(lbxToDo.SelectedItems != null)
            {
                ToDoData todo = lbxToDo.SelectedItem as ToDoData;
                FinishItem(todo);
            }
        }

        private void FinishItem(ToDoData todo)
        {
            todo.Status = "Complete";
            WriteToDoFile();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbxToDo.SelectedItems != null)
            {
                ToDoData todo = lbxToDo.SelectedItem as ToDoData;
                MoveItemUp(todo);
            }
        }

        private void MoveItemUp(ToDoData todo)
        {
            for (int i = 0; i < todoDataList.Count; i++)
            {
                if (todoDataList[i] == todo)
                {
                    if(i != 0)
                    {
                        todoDataList.RemoveAt(i);
                        todoDataList.Insert(i - 1, todo);
                        ReOrderToDoItems();
                    }                    
                }
            }

            WriteToDoFile();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if(lbxToDo.SelectedItems != null)
            {
                ToDoData todo = lbxToDo.SelectedItem as ToDoData;
                MoveItemDn(todo);
            }
        }

        private void MoveItemDn(ToDoData todo)
        {
            for (int i = 0; i < todoDataList.Count; i++)
            {
                if (todoDataList[i] == todo)
                {
                    if (i <todoDataList.Count -1)
                    {
                        todoDataList.RemoveAt(i);
                        todoDataList.Insert(i + 1, todo);
                        ReOrderToDoItems();
                    }
                }
            }

            WriteToDoFile(); 
        }
    }
}
 