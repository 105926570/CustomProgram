using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class AdminDebug : Form
    {
        private int globalTop = 20;
        private int globalLeft = 20;
        private int columnWidth = 325;
        private int pageWidth; // max width for one page
        private GroupBox parentGroupBox;

        private List<List<GroupBox>> pages = new List<List<GroupBox>>(); // pages of group boxes
        private int currentPage = 0;

        public AdminDebug()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 600;
            pageWidth = this.ClientSize.Width - 40; // leave some margin

            // Create parent group box
            parentGroupBox = new GroupBox();
            parentGroupBox.Text = "create";
            parentGroupBox.Left = 20;
            parentGroupBox.Top = 20;
            parentGroupBox.Width = pageWidth;
            parentGroupBox.Height = this.ClientSize.Height - 80;
            //parentGroupBox.AutoScroll = true;
            this.Controls.Add(parentGroupBox);

            // Generate child group boxes
            GenerateTextBoxesForClass(typeof(Department));
            GenerateTextBoxesForClass(typeof(Employee));
            GenerateTextBoxesForClass(typeof(Admin));

            // Add button to navigate pages
            Button nextPageBtn = new Button();
            nextPageBtn.Text = "Next Page";
            nextPageBtn.Left = 20;
            nextPageBtn.Top = this.ClientSize.Height - 50;
            nextPageBtn.Click += NextPageBtn_Click;
            this.Controls.Add(nextPageBtn);

            ShowPage(0); // show first page
        }

        private void GenerateTextBoxesForClass(Type targetClass)
        {
            // Create a child group box
            GroupBox groupBox = new GroupBox();
            groupBox.Text = targetClass.Name;
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

            // Place group box on the current page, or start a new page
            if (pages.Count == 0 || (globalLeft + groupBox.Width > pageWidth))
            {
                // start a new page
                pages.Add(new List<GroupBox>());
                globalLeft = 20;
                globalTop = 20;
            }

            groupBox.Left = globalLeft;
            groupBox.Top = globalTop;

            parentGroupBox.Controls.Add(groupBox);
            pages[pages.Count - 1].Add(groupBox);

            // Update positions for next group box
            globalLeft += groupBox.Width + 20;
        }

        private void ShowPage(int pageIndex)
        {
            // Hide all group boxes first
            foreach (var page in pages)
            {
                foreach (var gb in page)
                {
                    gb.Visible = false;
                }
            }

            // Show only the requested page
            if (pages.Count > 0)
            {
                foreach (var gb in pages[pageIndex])
                {
                    gb.Visible = true;
                }
            }

            currentPage = pageIndex;
        }

        private void NextPageBtn_Click(object sender, EventArgs e)
        {
            if (pages.Count == 0) return;

            int nextPage = (currentPage + 1) % pages.Count;
            ShowPage(nextPage);
        }
    }
}
