
namespace _6.GemmyLanguageTool
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
            this.jsondgv = new System.Windows.Forms.DataGridView();
            this.languagetypelbl = new System.Windows.Forms.Label();
            this.cbx_language = new System.Windows.Forms.ComboBox();
            this.importbtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.createbtn = new System.Windows.Forms.Button();
            this.jsonmaindgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.improtmainbtn = new System.Windows.Forms.Button();
            this.updatemainbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.insertbtn = new System.Windows.Forms.Button();
            this.insertlanguagetxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jsondgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonmaindgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // jsondgv
            // 
            this.jsondgv.AllowUserToAddRows = false;
            this.jsondgv.AllowUserToDeleteRows = false;
            this.jsondgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jsondgv.Location = new System.Drawing.Point(19, 92);
            this.jsondgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jsondgv.Name = "jsondgv";
            this.jsondgv.RowHeadersVisible = false;
            this.jsondgv.RowHeadersWidth = 51;
            this.jsondgv.RowTemplate.Height = 25;
            this.jsondgv.Size = new System.Drawing.Size(447, 318);
            this.jsondgv.TabIndex = 0;
            // 
            // languagetypelbl
            // 
            this.languagetypelbl.AutoSize = true;
            this.languagetypelbl.Location = new System.Drawing.Point(17, 45);
            this.languagetypelbl.Name = "languagetypelbl";
            this.languagetypelbl.Size = new System.Drawing.Size(53, 12);
            this.languagetypelbl.TabIndex = 1;
            this.languagetypelbl.Text = "选择语言";
            // 
            // cbx_language
            // 
            this.cbx_language.FormattingEnabled = true;
            this.cbx_language.Location = new System.Drawing.Point(74, 42);
            this.cbx_language.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_language.Name = "cbx_language";
            this.cbx_language.Size = new System.Drawing.Size(86, 20);
            this.cbx_language.TabIndex = 2;
            this.cbx_language.SelectedIndexChanged += new System.EventHandler(this.languagecbx_SelectedIndexChanged);
            // 
            // importbtn
            // 
            this.importbtn.Location = new System.Drawing.Point(172, 42);
            this.importbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.importbtn.Name = "importbtn";
            this.importbtn.Size = new System.Drawing.Size(89, 20);
            this.importbtn.TabIndex = 3;
            this.importbtn.Text = "导入多语言模板";
            this.importbtn.UseVisualStyleBackColor = true;
            this.importbtn.Click += new System.EventHandler(this.importbtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(17, 430);
            this.updatebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(64, 22);
            this.updatebtn.TabIndex = 4;
            this.updatebtn.Text = "修改";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // createbtn
            // 
            this.createbtn.Location = new System.Drawing.Point(400, 430);
            this.createbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(64, 22);
            this.createbtn.TabIndex = 5;
            this.createbtn.Text = "生成";
            this.createbtn.UseVisualStyleBackColor = true;
            this.createbtn.Click += new System.EventHandler(this.createbtn_Click);
            // 
            // jsonmaindgv
            // 
            this.jsonmaindgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jsonmaindgv.Location = new System.Drawing.Point(17, 92);
            this.jsonmaindgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jsonmaindgv.Name = "jsonmaindgv";
            this.jsonmaindgv.RowHeadersVisible = false;
            this.jsonmaindgv.RowHeadersWidth = 51;
            this.jsonmaindgv.RowTemplate.Height = 25;
            this.jsonmaindgv.Size = new System.Drawing.Size(465, 318);
            this.jsonmaindgv.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.improtmainbtn);
            this.groupBox1.Controls.Add(this.updatemainbtn);
            this.groupBox1.Controls.Add(this.jsonmaindgv);
            this.groupBox1.Location = new System.Drawing.Point(549, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(499, 456);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改语言母版";
            // 
            // improtmainbtn
            // 
            this.improtmainbtn.Location = new System.Drawing.Point(17, 42);
            this.improtmainbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.improtmainbtn.Name = "improtmainbtn";
            this.improtmainbtn.Size = new System.Drawing.Size(64, 20);
            this.improtmainbtn.TabIndex = 8;
            this.improtmainbtn.Text = "导入母版";
            this.improtmainbtn.UseVisualStyleBackColor = true;
            this.improtmainbtn.Click += new System.EventHandler(this.improtmainbtn_Click);
            // 
            // updatemainbtn
            // 
            this.updatemainbtn.Location = new System.Drawing.Point(17, 430);
            this.updatemainbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updatemainbtn.Name = "updatemainbtn";
            this.updatemainbtn.Size = new System.Drawing.Size(64, 22);
            this.updatemainbtn.TabIndex = 7;
            this.updatemainbtn.Text = "修改";
            this.updatemainbtn.UseVisualStyleBackColor = true;
            this.updatemainbtn.Click += new System.EventHandler(this.updatemainbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.insertbtn);
            this.groupBox2.Controls.Add(this.insertlanguagetxt);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.createbtn);
            this.groupBox2.Controls.Add(this.jsondgv);
            this.groupBox2.Controls.Add(this.importbtn);
            this.groupBox2.Controls.Add(this.cbx_language);
            this.groupBox2.Controls.Add(this.updatebtn);
            this.groupBox2.Controls.Add(this.languagetypelbl);
            this.groupBox2.Location = new System.Drawing.Point(10, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(485, 456);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改&&新建";
            // 
            // insertbtn
            // 
            this.insertbtn.Location = new System.Drawing.Point(172, 18);
            this.insertbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.Size = new System.Drawing.Size(64, 20);
            this.insertbtn.TabIndex = 8;
            this.insertbtn.Text = "添加语言";
            this.insertbtn.UseVisualStyleBackColor = true;
            this.insertbtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // insertlanguagetxt
            // 
            this.insertlanguagetxt.Location = new System.Drawing.Point(74, 18);
            this.insertlanguagetxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertlanguagetxt.Name = "insertlanguagetxt";
            this.insertlanguagetxt.Size = new System.Drawing.Size(86, 21);
            this.insertlanguagetxt.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "新增语言";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 504);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "GemmyLanguageTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jsondgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonmaindgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView jsondgv;
        private System.Windows.Forms.Label languagetypelbl;
        private System.Windows.Forms.ComboBox cbx_language;
        private System.Windows.Forms.Button importbtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button createbtn;
        private System.Windows.Forms.DataGridView jsonmaindgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button updatemainbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button improtmainbtn;
        private System.Windows.Forms.Button insertbtn;
        private System.Windows.Forms.TextBox insertlanguagetxt;
        private System.Windows.Forms.Label label1;
    }
}

