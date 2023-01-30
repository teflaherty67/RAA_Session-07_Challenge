using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAA_Session_07_Challenge
{
    internal class ToDoData
    {
        public int PositionNumber { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public string Display { get; set; }

        public ToDoData(int positionNumber, string text, string status)
        {
            PositionNumber = positionNumber;
            Text = text;
            Status = status;

            UpdateDisplayString();
        }

        private void UpdateDisplayString()
        {
            Display = PositionNumber + " : " + Text + " : " + Status;
        }
    }
}
