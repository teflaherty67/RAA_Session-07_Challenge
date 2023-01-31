﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public void UpdateDisplayString()
        {
            Display = PositionNumber + " : " + Text + " : " + Status;
        }

        public static string[] ParseDsiplayString(string displayString)
        {
            string[] splitString = displayString.Split(':');
            string text = splitString[1].Trim();
            string status = splitString[2].Trim();

            string[] returnString = new string[2];
            returnString[0] = text;
            returnString[1] = status;

            return returnString;
        }
    }
}
