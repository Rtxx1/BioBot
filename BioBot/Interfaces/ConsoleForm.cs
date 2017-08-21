using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBot.Interfaces
{
    public partial class ConsoleForm : Form
    {
        public enum TypeOfText
        {
            Erreur,
            Information,
            Not_Implemented
        }

        private delegate void LogDelegate(string Message, Color Color);

        public ConsoleForm()
        {
            InitializeComponent();
        }

        public void WriteLog(string Text, TypeOfText type)
        {
            Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] : " + Text;
            switch (type)
            {
                case TypeOfText.Erreur:
                    Invoke(new LogDelegate(AddMessage), Text, Color.Red);
                    break;

                case TypeOfText.Information:
                    Invoke(new LogDelegate(AddMessage), Text, Color.Green);
                    break;

                case TypeOfText.Not_Implemented:
                    Invoke(new LogDelegate(AddMessage), Text, Color.Blue);
                    break;
            }
        }

        private void AddMessage(string Message, Color Color)
        {
            rtLog.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
            rtLog.SelectionColor = Color;
            rtLog.AppendText(Message + "\r\n");
            rtLog.SelectionStart = rtLog.Text.Length;
            rtLog.DeselectAll();
            rtLog.ScrollToCaret();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            ClearConsole();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            HideConsole();
        }

        public void ClearConsole()
        {
            rtLog.Clear();
        }
        public void HideConsole()
        {
            Visible = false;
        }
        public void ShowConsole()
        {
            Visible = true;
        }
    }
}
