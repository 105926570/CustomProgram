using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class AdminDebug : Form
    {
        // editable at top
        private string GeneratedFormName = "GeneratedCreateForm";

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

            // window size for layout
            this.Width = 650;
            this.Height = 700;
            pageWidth = this.ClientSize.Width - 40; // leave some margin

            // Create parent group box
            parentGroupBox = new GroupBox
            {
                Text = "create",
                Left = 20,
                Top = 20,
                Width = pageWidth,
                Height = this.ClientSize.Height - 140,
                //AutoScroll = true
            };
            this.Controls.Add(parentGroupBox);

            // Generate child group boxes
            GenerateTextBoxesForClass(typeof(Department));
            GenerateTextBoxesForClass(typeof(Employee));
            GenerateTextBoxesForClass(typeof(Admin));
            GenerateTextBoxesForClass(typeof(EmployeeTaxInfo));

            // Add button to navigate pages
            Button nextPageBtn = new Button
            {
                Text = "Next Page",
                Left = 20,
                Top = this.ClientSize.Height - 100,
                Width = 100
            };
            nextPageBtn.Click += NextPageBtn_Click;
            this.Controls.Add(nextPageBtn);

            // Export button
            Button exportBtn = new Button
            {
                Text = "Export as Form",
                Left = nextPageBtn.Right + 10,
                Top = nextPageBtn.Top,
                Width = 120
            };
            exportBtn.Click += ExportBtn_Click;
            this.Controls.Add(exportBtn);

            ShowPage(0); // show first page
        }

        private void GenerateTextBoxesForClass(Type targetClass)
        {
            // Create a child group box
            GroupBox groupBox = new GroupBox
            {
                Text = targetClass.Name,
                Width = 300
            };

            int innerTop = 20;

            foreach (PropertyInfo prop in targetClass.GetProperties())
            {
                Label lbl = new Label
                {
                    Text = prop.Name + ":",
                    Left = 15,
                    Top = innerTop,
                    AutoSize = true
                };
                groupBox.Controls.Add(lbl);

                TextBox txt = new TextBox
                {
                    Name = "txt" + targetClass.Name + "_" + prop.Name,
                    Left = 15,
                    Top = innerTop + 20,
                    Width = 250
                };
                groupBox.Controls.Add(txt);

                innerTop += 50;
            }

            // Create "Create" button (keeps pattern)
            Button createBtn = new Button
            {
                Text = "Create " + targetClass.Name,
                Left = 15,
                Top = innerTop,
                Width = 250,
                Tag = targetClass
            };
            // createBtn.Click += CreateBtn_Click; // optional hookup
            groupBox.Controls.Add(createBtn);

            innerTop += 40; // space for button
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
            if (pages.Count > 0 && pageIndex >= 0 && pageIndex < pages.Count)
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

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // export when clicking
                ExportFormToFiles(GeneratedFormName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export the current runtime controls into two files:
        /// /Generated/<formName>.Designer.cs and /Generated/<formName>.cs
        /// </summary>
        private void ExportFormToFiles(string formName)
        {
            // choose safer user Documents folder to avoid permission problems
            string baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PayrollSystem", "Generated");
            Directory.CreateDirectory(baseFolder);

            var declarations = new List<string>();
            var initLines = new List<string>();
            var addLines = new List<string>();

            var controlVarNames = new Dictionary<Control, string>();

            // Parent groupbox variable
            string parentVar = "groupBoxCreate";
            declarations.Add($"private System.Windows.Forms.GroupBox {parentVar};");
            initLines.Add($"this.{parentVar} = new System.Windows.Forms.GroupBox();");
            initLines.Add($"this.{parentVar}.Location = new System.Drawing.Point({parentGroupBox.Left}, {parentGroupBox.Top});");
            initLines.Add($"this.{parentVar}.Name = \"{parentVar}\";");
            initLines.Add($"this.{parentVar}.Size = new System.Drawing.Size({parentGroupBox.Width}, {parentGroupBox.Height});");
            initLines.Add($"this.{parentVar}.TabIndex = 0;");
            initLines.Add($"this.{parentVar}.TabStop = false;");
            initLines.Add($"this.{parentVar}.Text = \"{EscapeForCode(parentGroupBox.Text)}\";");
            controlVarNames[parentGroupBox] = parentVar;

            // Find actual child groupboxes inside parentGroupBox (in the order they were added)
            var childGroupBoxes = parentGroupBox.Controls.OfType<GroupBox>().ToList();

            int gbIndex = 0;
            foreach (var gb in childGroupBoxes)
            {
                string gbVar = $"groupBox_{gbIndex}";
                controlVarNames[gb] = gbVar;
                declarations.Add($"private System.Windows.Forms.GroupBox {gbVar};");
                initLines.Add($"this.{gbVar} = new System.Windows.Forms.GroupBox();");
                initLines.Add($"this.{gbVar}.Location = new System.Drawing.Point({gb.Left}, {gb.Top});");
                initLines.Add($"this.{gbVar}.Name = \"{gbVar}\";");
                initLines.Add($"this.{gbVar}.Size = new System.Drawing.Size({gb.Width}, {gb.Height});");
                initLines.Add($"this.{gbVar}.TabIndex = 0;");
                initLines.Add($"this.{gbVar}.TabStop = false;");
                initLines.Add($"this.{gbVar}.Text = \"{EscapeForCode(gb.Text)}\";");

                int ctrlIndex = 0;
                foreach (Control c in gb.Controls)
                {
                    if (c is Label lbl)
                    {
                        string var = $"label_{gbIndex}_{ctrlIndex}";
                        controlVarNames[c] = var;
                        declarations.Add($"private System.Windows.Forms.Label {var};");
                        initLines.Add($"this.{var} = new System.Windows.Forms.Label();");
                        initLines.Add($"this.{var}.AutoSize = {lbl.AutoSize.ToString().ToLower()};");
                        initLines.Add($"this.{var}.Location = new System.Drawing.Point({c.Left}, {c.Top});");
                        initLines.Add($"this.{var}.Name = \"{var}\";");
                        initLines.Add($"this.{var}.Size = new System.Drawing.Size({c.Width}, {c.Height});");
                        initLines.Add($"this.{var}.TabIndex = 0;");
                        initLines.Add($"this.{var}.Text = \"{EscapeForCode(c.Text)}\";");
                        addLines.Add($"this.{gbVar}.Controls.Add(this.{var});");
                    }
                    else if (c is TextBox tb)
                    {
                        string var = $"textBox_{gbIndex}_{ctrlIndex}";
                        controlVarNames[c] = var;
                        declarations.Add($"private System.Windows.Forms.TextBox {var};");
                        initLines.Add($"this.{var} = new System.Windows.Forms.TextBox();");
                        initLines.Add($"this.{var}.Location = new System.Drawing.Point({c.Left}, {c.Top});");
                        initLines.Add($"this.{var}.Name = \"{EscapeForCode(c.Name)}\";");
                        initLines.Add($"this.{var}.Size = new System.Drawing.Size({c.Width}, {c.Height});");
                        initLines.Add($"this.{var}.TabIndex = 0;");
                        if (!string.IsNullOrEmpty(tb.Text))
                            initLines.Add($"this.{var}.Text = \"{EscapeForCode(tb.Text)}\";");
                        addLines.Add($"this.{gbVar}.Controls.Add(this.{var});");
                    }
                    else if (c is Button btn)
                    {
                        string var = $"button_{gbIndex}_{ctrlIndex}";
                        controlVarNames[c] = var;
                        declarations.Add($"private System.Windows.Forms.Button {var};");
                        initLines.Add($"this.{var} = new System.Windows.Forms.Button();");
                        initLines.Add($"this.{var}.Location = new System.Drawing.Point({c.Left}, {c.Top});");
                        initLines.Add($"this.{var}.Name = \"{var}\";");
                        initLines.Add($"this.{var}.Size = new System.Drawing.Size({c.Width}, {c.Height});");
                        initLines.Add($"this.{var}.TabIndex = 0;");
                        initLines.Add($"this.{var}.Text = \"{EscapeForCode(c.Text)}\";");
                        initLines.Add($"this.{var}.UseVisualStyleBackColor = true;");
                        addLines.Add($"this.{gbVar}.Controls.Add(this.{var});");
                    }
                    else
                    {
                        // fallback: generic control
                        string var = $"ctrl_{gbIndex}_{ctrlIndex}";
                        controlVarNames[c] = var;
                        declarations.Add($"private System.Windows.Forms.Control {var};");
                        initLines.Add($"this.{var} = new System.Windows.Forms.Control();");
                        initLines.Add($"this.{var}.Location = new System.Drawing.Point({c.Left}, {c.Top});");
                        initLines.Add($"this.{var}.Name = \"{EscapeForCode(c.Name ?? var)}\";");
                        initLines.Add($"this.{var}.Size = new System.Drawing.Size({c.Width}, {c.Height});");
                        addLines.Add($"this.{gbVar}.Controls.Add(this.{var});");
                    }

                    ctrlIndex++;
                }

                // add this gb to parent
                addLines.Add($"this.{parentVar}.Controls.Add(this.{gbVar});");

                gbIndex++;
            }

            // finally, add parent to form
            addLines.Add($"this.Controls.Add(this.{parentVar});");

            // build designer content
            var designerSb = new StringBuilder();
            designerSb.AppendLine("namespace PayrollSystem");
            designerSb.AppendLine("{");
            designerSb.AppendLine($"    partial class {formName}");
            designerSb.AppendLine("    {");
            designerSb.AppendLine("        /// <summary>");
            designerSb.AppendLine("        /// Required designer variable.");
            designerSb.AppendLine("        /// </summary>");
            designerSb.AppendLine("        private System.ComponentModel.IContainer components = null;");
            designerSb.AppendLine();

            // declarations
            foreach (var decl in declarations) designerSb.AppendLine("        " + decl);
            designerSb.AppendLine();

            // Dispose
            designerSb.AppendLine("        /// <summary>");
            designerSb.AppendLine("        /// Clean up any resources being used.");
            designerSb.AppendLine("        /// </summary>");
            designerSb.AppendLine("        /// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>");
            designerSb.AppendLine("        protected override void Dispose(bool disposing)");
            designerSb.AppendLine("        {");
            designerSb.AppendLine("            if (disposing && (components != null))");
            designerSb.AppendLine("            {");
            designerSb.AppendLine("                components.Dispose();");
            designerSb.AppendLine("            }");
            designerSb.AppendLine("            base.Dispose(disposing);");
            designerSb.AppendLine("        }");
            designerSb.AppendLine();

            // InitializeComponent
            designerSb.AppendLine("        #region Windows Form Designer generated code");
            designerSb.AppendLine();
            designerSb.AppendLine("        /// <summary>");
            designerSb.AppendLine("        /// Required method for Designer support - do not modify");
            designerSb.AppendLine("        /// the contents of this method with the code editor.");
            designerSb.AppendLine("        /// </summary>");
            designerSb.AppendLine("        private void InitializeComponent()");
            designerSb.AppendLine("        {");
            designerSb.AppendLine("            this.components = new System.ComponentModel.Container();");

            // init lines
            foreach (var line in initLines) designerSb.AppendLine("            " + line);

            designerSb.AppendLine();
            designerSb.AppendLine("            this.SuspendLayout();");
            designerSb.AppendLine();

            // add children
            foreach (var line in addLines) designerSb.AppendLine("            " + line);

            // form properties (size ensures all controls fit)
            int clientW = Math.Max(parentGroupBox.Left + parentGroupBox.Width + 40, 400);
            int clientH = Math.Max(parentGroupBox.Top + parentGroupBox.Height + 140, 300);
            designerSb.AppendLine();
            designerSb.AppendLine($"            this.ClientSize = new System.Drawing.Size({clientW}, {clientH});");
            designerSb.AppendLine($"            this.Name = \"{formName}\";");
            designerSb.AppendLine($"            this.Text = \"{EscapeForCode(formName)}\";");
            designerSb.AppendLine("            this.ResumeLayout(false);");
            designerSb.AppendLine("        }");
            designerSb.AppendLine();
            designerSb.AppendLine("        #endregion");
            designerSb.AppendLine("    }");
            designerSb.AppendLine("}");

            // build main .cs
            var csSb = new StringBuilder();
            csSb.AppendLine("using System;");
            csSb.AppendLine("using System.Windows.Forms;");
            csSb.AppendLine();
            csSb.AppendLine("namespace PayrollSystem");
            csSb.AppendLine("{");
            csSb.AppendLine($"    public partial class {formName} : Form");
            csSb.AppendLine("    {");
            csSb.AppendLine($"        public {formName}()");
            csSb.AppendLine("        {");
            csSb.AppendLine("            InitializeComponent();");
            csSb.AppendLine("        }");
            csSb.AppendLine("    }");
            csSb.AppendLine("}");

            // write files
            string designerPath = Path.Combine(baseFolder, formName + ".Designer.cs");
            string csPath = Path.Combine(baseFolder, formName + ".cs");

            File.WriteAllText(designerPath, designerSb.ToString(), Encoding.UTF8);
            File.WriteAllText(csPath, csSb.ToString(), Encoding.UTF8);

            // Inform the user with full paths
            MessageBox.Show($"Export complete.\n\nDesigner: {designerPath}\nCode: {csPath}", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Helper: escape quotes and newlines for inclusion in string literals
        private static string EscapeForCode(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n");
        }
    }
}
