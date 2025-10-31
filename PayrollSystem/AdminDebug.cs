using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class AdminDebug : Form
    {
        public AdminDebug()
        {
            GenerateTextBoxesForClass(typeof(Department));
            InitializeComponent();          
        }

        private void GenerateTextBoxesForClass(Type targetClass)
        {
            int top = 20; // starting y position

            foreach (PropertyInfo prop in targetClass.GetProperties())
            {
                // Create a label
                Label lbl = new Label();
                lbl.Text = prop.Name + ":";
                lbl.Left = 20;
                lbl.Top = top;
                lbl.AutoSize = true;
                this.Controls.Add(lbl);

                // Create a textbox
                TextBox txt = new TextBox();
                txt.Name = "txt" + prop.Name;
                txt.Left = 20;
                txt.Top = top + 20; // 20px below the label
                txt.Width = 200;
                this.Controls.Add(txt);

                // Increase the vertical offset for the next input
                top += 60;
            }
        }
    }

    // Example class


}
