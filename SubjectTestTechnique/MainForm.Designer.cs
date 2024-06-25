using BankReconciliationMV;

namespace SubjectTestTechnique
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
            this.components = new System.ComponentModel.Container();
            this.buttonImportAccounting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewBank = new System.Windows.Forms.DataGridView();
            this.dataGridViewAccounting = new System.Windows.Forms.DataGridView();
            this.openFileDialogCSV = new System.Windows.Forms.OpenFileDialog();
            this.textBoxReconcile = new System.Windows.Forms.TextBox();
            this.buttonReconcile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelReconcileResult = new System.Windows.Forms.Label();
            this.toolTipError = new System.Windows.Forms.ToolTip(this.components);
            this.buttonImportBank = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounting)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImportAccounting
            // 
            this.buttonImportAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportAccounting.Location = new System.Drawing.Point(1472, 13);
            this.buttonImportAccounting.Name = "buttonImportAccounting";
            this.buttonImportAccounting.Size = new System.Drawing.Size(175, 29);
            this.buttonImportAccounting.TabIndex = 3;
            this.buttonImportAccounting.Text = "Import Accounting CSV";
            this.buttonImportAccounting.UseVisualStyleBackColor = true;
            this.buttonImportAccounting.Click += new System.EventHandler(this.buttonImportAccounting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bank";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1354, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Accounting";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBank, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewAccounting, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 47);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1635, 596);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // dataGridViewBank
            // 
            this.dataGridViewBank.AllowUserToAddRows = false;
            this.dataGridViewBank.AllowUserToDeleteRows = false;
            this.dataGridViewBank.AllowUserToOrderColumns = true;
            this.dataGridViewBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBank.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewBank.Name = "dataGridViewBank";
            this.dataGridViewBank.RowHeadersWidth = 51;
            this.dataGridViewBank.RowTemplate.Height = 29;
            this.dataGridViewBank.Size = new System.Drawing.Size(811, 590);
            this.dataGridViewBank.TabIndex = 1;
            this.dataGridViewBank.SelectionChanged += new System.EventHandler(this.dataGridViewBank_SelectionChanged);
            // 
            // dataGridViewAccounting
            // 
            this.dataGridViewAccounting.AllowUserToAddRows = false;
            this.dataGridViewAccounting.AllowUserToDeleteRows = false;
            this.dataGridViewAccounting.AllowUserToOrderColumns = true;
            this.dataGridViewAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAccounting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounting.Location = new System.Drawing.Point(820, 3);
            this.dataGridViewAccounting.Name = "dataGridViewAccounting";
            this.dataGridViewAccounting.RowHeadersWidth = 51;
            this.dataGridViewAccounting.RowTemplate.Height = 29;
            this.dataGridViewAccounting.Size = new System.Drawing.Size(812, 590);
            this.dataGridViewAccounting.TabIndex = 2;
            this.dataGridViewAccounting.SelectionChanged += new System.EventHandler(this.dataGridViewAccounting_SelectionChanged);
            // 
            // openFileDialogCSV
            // 
            this.openFileDialogCSV.FileName = "openFileDialogCSV";
            // 
            // textBoxReconcile
            // 
            this.textBoxReconcile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxReconcile.Location = new System.Drawing.Point(12, 656);
            this.textBoxReconcile.Name = "textBoxReconcile";
            this.textBoxReconcile.Size = new System.Drawing.Size(125, 27);
            this.textBoxReconcile.TabIndex = 7;
            // 
            // buttonReconcile
            // 
            this.buttonReconcile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReconcile.Location = new System.Drawing.Point(143, 655);
            this.buttonReconcile.Name = "buttonReconcile";
            this.buttonReconcile.Size = new System.Drawing.Size(94, 29);
            this.buttonReconcile.TabIndex = 8;
            this.buttonReconcile.Text = "Reconcile";
            this.buttonReconcile.UseVisualStyleBackColor = true;
            this.buttonReconcile.Click += new System.EventHandler(this.buttonReconcile_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reconcile Rate:";
            // 
            // labelReconcileResult
            // 
            this.labelReconcileResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelReconcileResult.AutoSize = true;
            this.labelReconcileResult.Location = new System.Drawing.Point(365, 659);
            this.labelReconcileResult.Name = "labelReconcileResult";
            this.labelReconcileResult.Size = new System.Drawing.Size(0, 20);
            this.labelReconcileResult.TabIndex = 10;
            // 
            // buttonImportBank
            // 
            this.buttonImportBank.Location = new System.Drawing.Point(62, 13);
            this.buttonImportBank.Name = "buttonImportBank";
            this.buttonImportBank.Size = new System.Drawing.Size(175, 29);
            this.buttonImportBank.TabIndex = 11;
            this.buttonImportBank.Text = "Import Bank CSV";
            this.buttonImportBank.UseVisualStyleBackColor = true;
            this.buttonImportBank.Click += new System.EventHandler(this.buttonImportBank_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1659, 695);
            this.Controls.Add(this.buttonImportBank);
            this.Controls.Add(this.labelReconcileResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonReconcile);
            this.Controls.Add(this.textBoxReconcile);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonImportAccounting);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Bank Reconsiliation ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controller _controller;
        private Button buttonImportAccounting;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridViewBank;
        private DataGridView dataGridViewAccounting;
        private OpenFileDialog openFileDialogCSV;
        private TextBox textBoxReconcile;
        private Button buttonReconcile;
        private Label label3;
        private Label labelReconcileResult;
        private ToolTip toolTipError;
        private Button buttonImportBank;
    }
}