namespace Gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblInfo = new Label();
            lblInfo2 = new Label();
            lblInfo3 = new Label();
            cbbYear = new ComboBox();
            cbbCounty = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtAE = new TextBox();
            bttClear = new Button();
            bttSave = new Button();
            gb1 = new GroupBox();
            txtCDC = new TextBox();
            txtTotal = new TextBox();
            txtDX = new TextBox();
            txtPopulation = new TextBox();
            groupBox1 = new GroupBox();
            lblGb2_14 = new Label();
            lblGb2_13 = new Label();
            lblGb2_12 = new Label();
            lblGb2_11 = new Label();
            lblGb2_4 = new Label();
            lblGb2_3 = new Label();
            lblGb2_1 = new Label();
            lblGb2_2 = new Label();
            dgvCounties = new DataGridView();
            errPro = new ErrorProvider(components);
            gb1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCounties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errPro).BeginInit();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(9, 41);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(28, 15);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Any";
            // 
            // lblInfo2
            // 
            lblInfo2.AutoSize = true;
            lblInfo2.Location = new Point(113, 41);
            lblInfo2.Name = "lblInfo2";
            lblInfo2.Size = new Size(53, 15);
            lblInfo2.TabIndex = 3;
            lblInfo2.Text = "Comarca";
            // 
            // lblInfo3
            // 
            lblInfo3.AutoSize = true;
            lblInfo3.Location = new Point(278, 41);
            lblInfo3.Name = "lblInfo3";
            lblInfo3.Size = new Size(53, 15);
            lblInfo3.TabIndex = 4;
            lblInfo3.Text = "Població";
            // 
            // cbbYear
            // 
            cbbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbYear.FormattingEnabled = true;
            cbbYear.ItemHeight = 15;
            cbbYear.Location = new Point(9, 73);
            cbbYear.Name = "cbbYear";
            cbbYear.Size = new Size(66, 23);
            cbbYear.TabIndex = 0;
            // 
            // cbbCounty
            // 
            cbbCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCounty.FormattingEnabled = true;
            cbbCounty.Location = new Point(113, 73);
            cbbCounty.Name = "cbbCounty";
            cbbCounty.Size = new Size(125, 23);
            cbbCounty.TabIndex = 2;
            cbbCounty.SelectedValueChanged += cbbCounty_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 124);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 8;
            label1.Text = "Domèstic xarxa";
            // 
            // label2
            // 
            label2.Location = new Point(149, 124);
            label2.Name = "label2";
            label2.Size = new Size(125, 52);
            label2.TabIndex = 10;
            label2.Text = "Activitats econòmiques i fonts pròpies";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 143);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 11;
            label3.Text = "Total";
            // 
            // label4
            // 
            label4.Location = new Point(326, 168);
            label4.Name = "label4";
            label4.Size = new Size(111, 38);
            label4.TabIndex = 13;
            label4.Text = "Consum domèstic per càpita";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAE
            // 
            txtAE.Location = new Point(149, 183);
            txtAE.Name = "txtAE";
            txtAE.Size = new Size(125, 23);
            txtAE.TabIndex = 5;
            // 
            // bttClear
            // 
            bttClear.AllowDrop = true;
            bttClear.Location = new Point(363, 315);
            bttClear.Name = "bttClear";
            bttClear.Size = new Size(75, 23);
            bttClear.TabIndex = 8;
            bttClear.Text = "Netejar";
            bttClear.UseVisualStyleBackColor = true;
            bttClear.Click += bttClear_Click;
            // 
            // bttSave
            // 
            bttSave.Location = new Point(494, 315);
            bttSave.Name = "bttSave";
            bttSave.Size = new Size(75, 23);
            bttSave.TabIndex = 9;
            bttSave.Text = "Guardar";
            bttSave.UseVisualStyleBackColor = true;
            bttSave.Click += bttSave_Click;
            // 
            // gb1
            // 
            gb1.Controls.Add(txtCDC);
            gb1.Controls.Add(txtTotal);
            gb1.Controls.Add(txtDX);
            gb1.Controls.Add(txtPopulation);
            gb1.Controls.Add(label2);
            gb1.Controls.Add(lblInfo);
            gb1.Controls.Add(lblInfo2);
            gb1.Controls.Add(lblInfo3);
            gb1.Controls.Add(txtAE);
            gb1.Controls.Add(cbbYear);
            gb1.Controls.Add(cbbCounty);
            gb1.Controls.Add(label4);
            gb1.Controls.Add(label1);
            gb1.Controls.Add(label3);
            gb1.Location = new Point(12, 55);
            gb1.Name = "gb1";
            gb1.Size = new Size(557, 243);
            gb1.TabIndex = 20;
            gb1.TabStop = false;
            gb1.Text = "Gestió de dades demografiques de regions";
            // 
            // txtCDC
            // 
            txtCDC.Location = new Point(431, 177);
            txtCDC.Name = "txtCDC";
            txtCDC.Size = new Size(86, 23);
            txtCDC.TabIndex = 7;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(431, 140);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(86, 23);
            txtTotal.TabIndex = 6;
            // 
            // txtDX
            // 
            txtDX.Location = new Point(9, 183);
            txtDX.Name = "txtDX";
            txtDX.Size = new Size(125, 23);
            txtDX.TabIndex = 4;
            // 
            // txtPopulation
            // 
            txtPopulation.Location = new Point(278, 73);
            txtPopulation.Name = "txtPopulation";
            txtPopulation.Size = new Size(125, 23);
            txtPopulation.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblGb2_14);
            groupBox1.Controls.Add(lblGb2_13);
            groupBox1.Controls.Add(lblGb2_12);
            groupBox1.Controls.Add(lblGb2_11);
            groupBox1.Controls.Add(lblGb2_4);
            groupBox1.Controls.Add(lblGb2_3);
            groupBox1.Controls.Add(lblGb2_1);
            groupBox1.Controls.Add(lblGb2_2);
            groupBox1.Location = new Point(588, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 198);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estadístiques";
            // 
            // lblGb2_14
            // 
            lblGb2_14.AutoSize = true;
            lblGb2_14.ForeColor = Color.Blue;
            lblGb2_14.Location = new Point(235, 153);
            lblGb2_14.Name = "lblGb2_14";
            lblGb2_14.Size = new Size(29, 15);
            lblGb2_14.TabIndex = 25;
            lblGb2_14.Text = "N/A";
            // 
            // lblGb2_13
            // 
            lblGb2_13.AutoSize = true;
            lblGb2_13.ForeColor = Color.Blue;
            lblGb2_13.Location = new Point(235, 116);
            lblGb2_13.Name = "lblGb2_13";
            lblGb2_13.Size = new Size(29, 15);
            lblGb2_13.TabIndex = 24;
            lblGb2_13.Text = "N/A";
            // 
            // lblGb2_12
            // 
            lblGb2_12.AutoSize = true;
            lblGb2_12.ForeColor = Color.Blue;
            lblGb2_12.Location = new Point(235, 73);
            lblGb2_12.Name = "lblGb2_12";
            lblGb2_12.Size = new Size(29, 15);
            lblGb2_12.TabIndex = 23;
            lblGb2_12.Text = "N/A";
            // 
            // lblGb2_11
            // 
            lblGb2_11.AutoSize = true;
            lblGb2_11.ForeColor = Color.Blue;
            lblGb2_11.Location = new Point(235, 33);
            lblGb2_11.Name = "lblGb2_11";
            lblGb2_11.Size = new Size(29, 15);
            lblGb2_11.TabIndex = 22;
            lblGb2_11.Text = "N/A";
            // 
            // lblGb2_4
            // 
            lblGb2_4.AutoSize = true;
            lblGb2_4.Location = new Point(6, 153);
            lblGb2_4.Name = "lblGb2_4";
            lblGb2_4.Size = new Size(208, 15);
            lblGb2_4.TabIndex = 21;
            lblGb2_4.Text = "Consum domèstic per càpita més baix:";
            // 
            // lblGb2_3
            // 
            lblGb2_3.AutoSize = true;
            lblGb2_3.Location = new Point(6, 113);
            lblGb2_3.Name = "lblGb2_3";
            lblGb2_3.Size = new Size(199, 15);
            lblGb2_3.TabIndex = 20;
            lblGb2_3.Text = "Consum domèstic per càpita més alt:";
            // 
            // lblGb2_1
            // 
            lblGb2_1.AutoSize = true;
            lblGb2_1.Location = new Point(6, 33);
            lblGb2_1.Name = "lblGb2_1";
            lblGb2_1.Size = new Size(123, 15);
            lblGb2_1.TabIndex = 18;
            lblGb2_1.Text = "Població> 20000 hab.:";
            // 
            // lblGb2_2
            // 
            lblGb2_2.AutoSize = true;
            lblGb2_2.Location = new Point(6, 73);
            lblGb2_2.Name = "lblGb2_2";
            lblGb2_2.Size = new Size(133, 15);
            lblGb2_2.TabIndex = 19;
            lblGb2_2.Text = "Consum domèstic mitjà:";
            // 
            // dgvCounties
            // 
            dgvCounties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCounties.Location = new Point(12, 349);
            dgvCounties.Name = "dgvCounties";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCounties.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCounties.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvCounties.Size = new Size(860, 253);
            dgvCounties.TabIndex = 26;
            dgvCounties.CellClick += dgvCounties_CellClick;
            // 
            // errPro
            // 
            errPro.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 643);
            Controls.Add(dgvCounties);
            Controls.Add(groupBox1);
            Controls.Add(gb1);
            Controls.Add(bttSave);
            Controls.Add(bttClear);
            Text = "Form1";
            Load += Form1_Load;
            gb1.ResumeLayout(false);
            gb1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCounties).EndInit();
            ((System.ComponentModel.ISupportInitialize)errPro).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblInfo;
        private Label lblInfo2;
        private Label lblInfo3;
        private ComboBox cbbYear;
        private ComboBox cbbCounty;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private TextBox txtAE;
        private Button bttClear;
        private Button bttSave;
        private GroupBox gb1;
        private GroupBox groupBox1;
        private Label lblGb2_4;
        private Label lblGb2_3;
        private Label lblGb2_1;
        private Label lblGb2_2;
        private Label lblGb2_14;
        private Label lblGb2_13;
        private Label lblGb2_12;
        private Label lblGb2_11;
        private DataGridView dgvCounties;
        private TextBox txtCDC;
        private TextBox txtTotal;
        private TextBox txtDX;
        private TextBox txtPopulation;
        private ErrorProvider errPro;
    }
}
