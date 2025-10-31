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
        private int globalTop = 20;     // vertical placement inside parent
        private int globalLeft = 20;    // horizontal offset for columns
        private int columnWidth = 325;  // width of each child group box + spacing
        private GroupBox parentGroupBox;

        // Track maximum extents of child boxes
        private int maxRight = 0;
        private int maxBottom = 0;

        public AdminDebug()
        {
            InitializeComponent();
            this.Width = 1080;
            this.Height = 1080;

            // Create parent group box
            parentGroupBox = new GroupBox();
            parentGroupBox.Text = "create";
            parentGroupBox.Left = 20;
            parentGroupBox.Top = 20;
            //parentGroupBox.AutoScroll = true;
            this.Controls.Add(parentGroupBox);

            // Generate child group boxes inside parent
            GenerateTextBoxesForClass(typeof(Department));
            GenerateTextBoxesForClass(typeof(Employee));
            GenerateTextBoxesForClass(typeof(Admin));

            // Resize parent to fit content (with some padding)
            parentGroupBox.Width = Math.Max(maxRight + 20, 300);
            parentGroupBox.Height = Math.Max(maxBottom + 20, 300);
        }

        private void GenerateTextBoxesForClass(Type targetClass)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = targetClass.Name;
            groupBox.Left = globalLeft;
            groupBox.Top = globalTop;
            groupBox.Width = 300;

            int innerTop = 20;

            foreach (PropertyInfo prop in targetClass.GetProperties())
            {
                Label lbl = new Label();
                lbl.Text = prop.Name + ":";
                lbl.Left = 15;
                lbl.Top = innerTop;
                lbl.AutoSize = true;
                groupBox.Controls.Add(lbl);

                TextBox txt = new TextBox();
                txt.Name = "txt" + prop.Name;
                txt.Left = 15;
                txt.Top = innerTop + 20;
                txt.Width = 250;
                groupBox.Controls.Add(txt);

                innerTop += 50;
            }

            groupBox.Height = innerTop + 10;

            // Check if adding next group would exceed parent height
            int nextBottom = globalTop + groupBox.Height + 20;
            if (nextBottom > this.ClientSize.Height - 40) // leave margin inside form
            {
                // Move to new column
                globalLeft += columnWidth;
                globalTop = 20;
                groupBox.Left = globalLeft;
                groupBox.Top = globalTop;
            }

            // Add to parent
            parentGroupBox.Controls.Add(groupBox);

            // Update max extents
            maxRight = Math.Max(maxRight, groupBox.Left + groupBox.Width);
            maxBottom = Math.Max(maxBottom, groupBox.Top + groupBox.Height);

            // Move down for next group
            globalTop += groupBox.Height + 20;
        }
    }
}
