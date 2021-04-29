
namespace GemmyLanguageManageTool
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
            this.languagecbx = new System.Windows.Forms.ComboBox();
            this.importbtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.createbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jsondgv)).BeginInit();
            this.SuspendLayout();
            // 
            // jsondgv
            // 
            this.jsondgv.AllowUserToAddRows = false;
            this.jsondgv.AllowUserToDeleteRows = false;
            this.jsondgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jsondgv.Location = new System.Drawing.Point(12, 105);
            this.jsondgv.Name = "jsondgv";
            this.jsondgv.ReadOnly = true;
            this.jsondgv.RowHeadersVisible = false;
            this.jsondgv.RowTemplate.Height = 25;
            this.jsondgv.Size = new System.Drawing.Size(776, 264);
            this.jsondgv.TabIndex = 0;
            // 
            // languagetypelbl
            // 
            this.languagetypelbl.AutoSize = true;
            this.languagetypelbl.Location = new System.Drawing.Point(12, 27);
            this.languagetypelbl.Name = "languagetypelbl";
            this.languagetypelbl.Size = new System.Drawing.Size(56, 17);
            this.languagetypelbl.TabIndex = 1;
            this.languagetypelbl.Text = "选择语言";
            // 
            // languagecbx
            // 
            this.languagecbx.FormattingEnabled = true;
            this.languagecbx.Location = new System.Drawing.Point(74, 24);
            this.languagecbx.Name = "languagecbx";
            this.languagecbx.Size = new System.Drawing.Size(100, 25);
            this.languagecbx.TabIndex = 2;
            // 
            // importbtn
            // 
            this.importbtn.Location = new System.Drawing.Point(189, 24);
            this.importbtn.Name = "importbtn";
            this.importbtn.Size = new System.Drawing.Size(104, 23);
            this.importbtn.TabIndex = 3;
            this.importbtn.Text = "导入多语言模板";
            this.importbtn.UseVisualStyleBackColor = true;
            this.importbtn.Click += new System.EventHandler(this.importbtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(189, 407);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 4;
            this.updatebtn.Text = "修改";
            this.updatebtn.UseVisualStyleBackColor = true;
            // 
            // createbtn
            // 
            this.createbtn.Location = new System.Drawing.Point(459, 407);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(75, 23);
            this.createbtn.TabIndex = 5;
            this.createbtn.Text = "生成";
            this.createbtn.UseVisualStyleBackColor = true;
            this.createbtn.Click += new System.EventHandler(this.createbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createbtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.importbtn);
            this.Controls.Add(this.languagecbx);
            this.Controls.Add(this.languagetypelbl);
            this.Controls.Add(this.jsondgv);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.jsondgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView jsondgv;
        private System.Windows.Forms.Label languagetypelbl;
        private System.Windows.Forms.ComboBox languagecbx;
        private System.Windows.Forms.Button importbtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button createbtn;
    }
}

