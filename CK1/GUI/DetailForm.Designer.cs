namespace CK1
{
    partial class DetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MSSV = new System.Windows.Forms.TextBox();
            this.cbb_LopSH = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.rd_Nu = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_Nam = new System.Windows.Forms.RadioButton();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.cbb_HP = new System.Windows.Forms.ComboBox();
            this.txt_DiemCK = new System.Windows.Forms.TextBox();
            this.txt_DiemGK = new System.Windows.Forms.TextBox();
            this.txt_DiemTB = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_DiemTK = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSSV";
            // 
            // txt_MSSV
            // 
            this.txt_MSSV.Location = new System.Drawing.Point(123, 37);
            this.txt_MSSV.Name = "txt_MSSV";
            this.txt_MSSV.Size = new System.Drawing.Size(179, 26);
            this.txt_MSSV.TabIndex = 1;
            this.txt_MSSV.TextChanged += new System.EventHandler(this.txt_MSSV_TextChanged);
            // 
            // cbb_LopSH
            // 
            this.cbb_LopSH.FormattingEnabled = true;
            this.cbb_LopSH.Location = new System.Drawing.Point(123, 156);
            this.cbb_LopSH.Name = "cbb_LopSH";
            this.cbb_LopSH.Size = new System.Drawing.Size(179, 28);
            this.cbb_LopSH.TabIndex = 2;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(242, 413);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(142, 48);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // rd_Nu
            // 
            this.rd_Nu.AutoSize = true;
            this.rd_Nu.Location = new System.Drawing.Point(33, 53);
            this.rd_Nu.Name = "rd_Nu";
            this.rd_Nu.Size = new System.Drawing.Size(54, 24);
            this.rd_Nu.TabIndex = 4;
            this.rd_Nu.TabStop = true;
            this.rd_Nu.Text = "Nữ";
            this.rd_Nu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_Nam);
            this.groupBox1.Controls.Add(this.rd_Nu);
            this.groupBox1.Location = new System.Drawing.Point(46, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giới tính";
            // 
            // rd_Nam
            // 
            this.rd_Nam.AutoSize = true;
            this.rd_Nam.Location = new System.Drawing.Point(130, 53);
            this.rd_Nam.Name = "rd_Nam";
            this.rd_Nam.Size = new System.Drawing.Size(67, 24);
            this.rd_Nam.TabIndex = 20;
            this.rd_Nam.TabStop = true;
            this.rd_Nam.Text = "Nam";
            this.rd_Nam.UseVisualStyleBackColor = true;
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(550, 34);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(179, 26);
            this.dateTime.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lớp SH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Học phần";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ngày thi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Điểm BT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Điểm GK";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(459, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Điểm CK";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(123, 98);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(179, 26);
            this.txt_Name.TabIndex = 15;
            // 
            // cbb_HP
            // 
            this.cbb_HP.FormattingEnabled = true;
            this.cbb_HP.Location = new System.Drawing.Point(123, 214);
            this.cbb_HP.Name = "cbb_HP";
            this.cbb_HP.Size = new System.Drawing.Size(179, 28);
            this.cbb_HP.TabIndex = 16;
            // 
            // txt_DiemCK
            // 
            this.txt_DiemCK.Location = new System.Drawing.Point(550, 211);
            this.txt_DiemCK.Name = "txt_DiemCK";
            this.txt_DiemCK.Size = new System.Drawing.Size(179, 26);
            this.txt_DiemCK.TabIndex = 17;
            this.txt_DiemCK.TextChanged += new System.EventHandler(this.txt_DiemCK_TextChanged);
            // 
            // txt_DiemGK
            // 
            this.txt_DiemGK.Location = new System.Drawing.Point(550, 153);
            this.txt_DiemGK.Name = "txt_DiemGK";
            this.txt_DiemGK.Size = new System.Drawing.Size(179, 26);
            this.txt_DiemGK.TabIndex = 18;
            this.txt_DiemGK.TextChanged += new System.EventHandler(this.txt_DiemGK_TextChanged);
            // 
            // txt_DiemTB
            // 
            this.txt_DiemTB.Location = new System.Drawing.Point(550, 101);
            this.txt_DiemTB.Name = "txt_DiemTB";
            this.txt_DiemTB.Size = new System.Drawing.Size(179, 26);
            this.txt_DiemTB.TabIndex = 19;
            this.txt_DiemTB.TextChanged += new System.EventHandler(this.txt_DiemTB_TextChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(439, 413);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 48);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_DiemTK
            // 
            this.txt_DiemTK.Location = new System.Drawing.Point(550, 267);
            this.txt_DiemTK.Name = "txt_DiemTK";
            this.txt_DiemTK.Size = new System.Drawing.Size(179, 26);
            this.txt_DiemTK.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(459, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tổng kết";
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.txt_DiemTK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_DiemTB);
            this.Controls.Add(this.txt_DiemGK);
            this.Controls.Add(this.txt_DiemCK);
            this.Controls.Add(this.cbb_HP);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cbb_LopSH);
            this.Controls.Add(this.txt_MSSV);
            this.Controls.Add(this.label1);
            this.Name = "DetailForm";
            this.Text = "DetailForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MSSV;
        private System.Windows.Forms.ComboBox cbb_LopSH;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.RadioButton rd_Nu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.ComboBox cbb_HP;
        private System.Windows.Forms.TextBox txt_DiemCK;
        private System.Windows.Forms.TextBox txt_DiemGK;
        private System.Windows.Forms.TextBox txt_DiemTB;
        private System.Windows.Forms.RadioButton rd_Nam;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_DiemTK;
        private System.Windows.Forms.Label label9;
    }
}