
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.page_language = new System.Windows.Forms.TabPage();
            this.page_upload = new System.Windows.Forms.TabPage();
            this.lbx_Language = new System.Windows.Forms.ListBox();
            this.lbx_Lock = new System.Windows.Forms.ListBox();
            this.lbx_partType = new System.Windows.Forms.ListBox();
            this.dgv_fileUpload = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtn_addFiles = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_addFolderFiles = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_clearRow = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_clearAll = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_importRow = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_importAll = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.jsondgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonmaindgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.page_language.SuspendLayout();
            this.page_upload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fileUpload)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(545, 5);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 5);
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.page_language);
            this.tabControl1.Controls.Add(this.page_upload);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1094, 501);
            this.tabControl1.TabIndex = 9;
            // 
            // page_language
            // 
            this.page_language.Controls.Add(this.groupBox2);
            this.page_language.Controls.Add(this.groupBox1);
            this.page_language.Location = new System.Drawing.Point(4, 22);
            this.page_language.Name = "page_language";
            this.page_language.Padding = new System.Windows.Forms.Padding(3);
            this.page_language.Size = new System.Drawing.Size(1086, 475);
            this.page_language.TabIndex = 0;
            this.page_language.Text = "语言管理";
            this.page_language.UseVisualStyleBackColor = true;
            // 
            // page_upload
            // 
            this.page_upload.Controls.Add(this.lbx_Language);
            this.page_upload.Controls.Add(this.lbx_Lock);
            this.page_upload.Controls.Add(this.lbx_partType);
            this.page_upload.Controls.Add(this.dgv_fileUpload);
            this.page_upload.Controls.Add(this.toolStrip1);
            this.page_upload.Location = new System.Drawing.Point(4, 22);
            this.page_upload.Name = "page_upload";
            this.page_upload.Padding = new System.Windows.Forms.Padding(3);
            this.page_upload.Size = new System.Drawing.Size(1086, 475);
            this.page_upload.TabIndex = 1;
            this.page_upload.Text = "文件上传";
            this.page_upload.UseVisualStyleBackColor = true;
            // 
            // lbx_Language
            // 
            this.lbx_Language.FormattingEnabled = true;
            this.lbx_Language.ItemHeight = 12;
            this.lbx_Language.Location = new System.Drawing.Point(597, 64);
            this.lbx_Language.Name = "lbx_Language";
            this.lbx_Language.Size = new System.Drawing.Size(120, 88);
            this.lbx_Language.TabIndex = 4;
            this.lbx_Language.Visible = false;
            this.lbx_Language.Click += new System.EventHandler(this.lbx_Language_Click);
            // 
            // lbx_Lock
            // 
            this.lbx_Lock.FormattingEnabled = true;
            this.lbx_Lock.ItemHeight = 12;
            this.lbx_Lock.Location = new System.Drawing.Point(407, 64);
            this.lbx_Lock.Name = "lbx_Lock";
            this.lbx_Lock.Size = new System.Drawing.Size(120, 88);
            this.lbx_Lock.TabIndex = 3;
            this.lbx_Lock.Visible = false;
            this.lbx_Lock.Click += new System.EventHandler(this.lbx_Lock_Click);
            // 
            // lbx_partType
            // 
            this.lbx_partType.FormattingEnabled = true;
            this.lbx_partType.ItemHeight = 12;
            this.lbx_partType.Location = new System.Drawing.Point(65, 64);
            this.lbx_partType.Name = "lbx_partType";
            this.lbx_partType.Size = new System.Drawing.Size(120, 88);
            this.lbx_partType.TabIndex = 2;
            this.lbx_partType.Visible = false;
            this.lbx_partType.Click += new System.EventHandler(this.lbx_partType_Click);
            // 
            // dgv_fileUpload
            // 
            this.dgv_fileUpload.AllowUserToAddRows = false;
            this.dgv_fileUpload.AllowUserToDeleteRows = false;
            this.dgv_fileUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_fileUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fileUpload.Location = new System.Drawing.Point(3, 30);
            this.dgv_fileUpload.Name = "dgv_fileUpload";
            this.dgv_fileUpload.RowHeadersWidth = 24;
            this.dgv_fileUpload.RowTemplate.Height = 23;
            this.dgv_fileUpload.Size = new System.Drawing.Size(1080, 441);
            this.dgv_fileUpload.TabIndex = 1;
            this.dgv_fileUpload.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgv_fileUpload_CellStateChanged);
            this.dgv_fileUpload.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_fileUpload_EditingControlShowing);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtn_addFiles,
            this.toolbtn_addFolderFiles,
            this.toolbtn_clearRow,
            this.toolbtn_clearAll,
            this.toolbtn_importRow,
            this.toolbtn_importAll});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1080, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtn_addFiles
            // 
            this.toolbtn_addFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_addFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_addFiles.Image")));
            this.toolbtn_addFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_addFiles.Name = "toolbtn_addFiles";
            this.toolbtn_addFiles.Size = new System.Drawing.Size(60, 22);
            this.toolbtn_addFiles.Text = "添加文件";
            this.toolbtn_addFiles.Click += new System.EventHandler(this.toolbtn_addFiles_Click);
            // 
            // toolbtn_addFolderFiles
            // 
            this.toolbtn_addFolderFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_addFolderFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_addFolderFiles.Image")));
            this.toolbtn_addFolderFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_addFolderFiles.Name = "toolbtn_addFolderFiles";
            this.toolbtn_addFolderFiles.Size = new System.Drawing.Size(108, 22);
            this.toolbtn_addFolderFiles.Text = "添加文件里的文件";
            this.toolbtn_addFolderFiles.Click += new System.EventHandler(this.toolbtn_addFolderFiles_Click);
            // 
            // toolbtn_clearRow
            // 
            this.toolbtn_clearRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_clearRow.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_clearRow.Image")));
            this.toolbtn_clearRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_clearRow.Name = "toolbtn_clearRow";
            this.toolbtn_clearRow.Size = new System.Drawing.Size(96, 22);
            this.toolbtn_clearRow.Text = "清除当前选中行";
            this.toolbtn_clearRow.Click += new System.EventHandler(this.toolbtn_clearRow_Click);
            // 
            // toolbtn_clearAll
            // 
            this.toolbtn_clearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_clearAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_clearAll.Image")));
            this.toolbtn_clearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_clearAll.Name = "toolbtn_clearAll";
            this.toolbtn_clearAll.Size = new System.Drawing.Size(60, 22);
            this.toolbtn_clearAll.Text = "清空全部";
            this.toolbtn_clearAll.Click += new System.EventHandler(this.toolbtn_clearAll_Click);
            // 
            // toolbtn_importRow
            // 
            this.toolbtn_importRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_importRow.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_importRow.Image")));
            this.toolbtn_importRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_importRow.Name = "toolbtn_importRow";
            this.toolbtn_importRow.Size = new System.Drawing.Size(96, 22);
            this.toolbtn_importRow.Text = "导入当前选中行";
            this.toolbtn_importRow.Click += new System.EventHandler(this.toolbtn_importRow_Click);
            // 
            // toolbtn_importAll
            // 
            this.toolbtn_importAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_importAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_importAll.Image")));
            this.toolbtn_importAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_importAll.Name = "toolbtn_importAll";
            this.toolbtn_importAll.Size = new System.Drawing.Size(60, 22);
            this.toolbtn_importAll.Text = "导入全部";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 504);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "GemmyLanguageTool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jsondgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonmaindgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.page_language.ResumeLayout(false);
            this.page_upload.ResumeLayout(false);
            this.page_upload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fileUpload)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage page_language;
        private System.Windows.Forms.TabPage page_upload;
        private System.Windows.Forms.DataGridView dgv_fileUpload;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtn_addFiles;
        private System.Windows.Forms.ToolStripButton toolbtn_addFolderFiles;
        private System.Windows.Forms.ToolStripButton toolbtn_clearRow;
        private System.Windows.Forms.ToolStripButton toolbtn_clearAll;
        private System.Windows.Forms.ToolStripButton toolbtn_importRow;
        private System.Windows.Forms.ToolStripButton toolbtn_importAll;
        private System.Windows.Forms.ListBox lbx_partType;
        private System.Windows.Forms.ListBox lbx_Language;
        private System.Windows.Forms.ListBox lbx_Lock;
    }
}

