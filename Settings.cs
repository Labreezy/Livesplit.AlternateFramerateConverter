using LiveSplit.UI;
using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class AlternateFramerateSettings : UserControl
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Label adjFramerateLabel;
        private NumericUpDown srcFramerateUpDown;
        private NumericUpDown adjNumericUpDown;
        private Label srcFramerateLabel;
        public double srcFramerate { get; set; }
        public double adjFramerate { get; set; }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.srcFramerateLabel = new System.Windows.Forms.Label();
            this.adjFramerateLabel = new System.Windows.Forms.Label();
            this.srcFramerateUpDown = new System.Windows.Forms.NumericUpDown();
            this.adjNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcFramerateUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.srcFramerateLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.adjFramerateLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.srcFramerateUpDown, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.adjNumericUpDown, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 89);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // srcFramerateLabel
            // 
            this.srcFramerateLabel.AutoSize = true;
            this.srcFramerateLabel.Location = new System.Drawing.Point(3, 0);
            this.srcFramerateLabel.Name = "srcFramerateLabel";
            this.srcFramerateLabel.Size = new System.Drawing.Size(91, 13);
            this.srcFramerateLabel.TabIndex = 0;
            this.srcFramerateLabel.Text = "Source Framerate";
            // 
            // adjFramerateLabel
            // 
            this.adjFramerateLabel.AutoSize = true;
            this.adjFramerateLabel.Location = new System.Drawing.Point(129, 0);
            this.adjFramerateLabel.Name = "adjFramerateLabel";
            this.adjFramerateLabel.Size = new System.Drawing.Size(98, 13);
            this.adjFramerateLabel.TabIndex = 1;
            this.adjFramerateLabel.Text = "Adjusted Framerate";
            // 
            // srcFramerateUpDown
            // 
            this.srcFramerateUpDown.DecimalPlaces = 3;
            this.srcFramerateUpDown.Location = new System.Drawing.Point(3, 47);
            this.srcFramerateUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.srcFramerateUpDown.Name = "srcFramerateUpDown";
            this.srcFramerateUpDown.Size = new System.Drawing.Size(120, 20);
            this.srcFramerateUpDown.TabIndex = 2;
            this.srcFramerateUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // adjNumericUpDown
            // 
            this.adjNumericUpDown.DecimalPlaces = 3;
            this.adjNumericUpDown.Location = new System.Drawing.Point(129, 47);
            this.adjNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.adjNumericUpDown.Name = "adjNumericUpDown";
            this.adjNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.adjNumericUpDown.TabIndex = 3;
            this.adjNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Settings
            // 
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(259, 96);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcFramerateUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public AlternateFramerateSettings()
        {
            srcFramerate = 1.0;
            adjFramerate = 1.0;
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            srcFramerateUpDown.DataBindings.Clear();
            srcFramerateUpDown.DataBindings.Add("Value", this, "srcFramerate", false, DataSourceUpdateMode.OnPropertyChanged);
            adjNumericUpDown.DataBindings.Clear();
            adjNumericUpDown.DataBindings.Add("Value", this, "adjFramerate", false, DataSourceUpdateMode.OnPropertyChanged);

            
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            srcFramerate = SettingsHelper.ParseDouble(element["srcFramerate"], 1.0);
            adjFramerate = SettingsHelper.ParseDouble(element["adjFramerate"], 1.0);
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "SourceFramerate", srcFramerate) ^
                SettingsHelper.CreateSetting(document, parent, "AdjFramerate", adjFramerate);
        }
    }

}
