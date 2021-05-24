
namespace JaiVendas.Presentation.WinApp
{
    partial class FormCustomerEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVatNumber = new System.Windows.Forms.TextBox();
            this.groupAddresses = new System.Windows.Forms.GroupBox();
            this.groupPhones = new System.Windows.Forms.GroupBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dgvAddresses = new System.Windows.Forms.DataGridView();
            this.dgvPhones = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupAddresses.SuspendLayout();
            this.groupPhones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtVatNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(248, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(407, 23);
            this.txtName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "VAT Number";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(580, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.Location = new System.Drawing.Point(7, 50);
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.ReadOnly = true;
            this.txtVatNumber.Size = new System.Drawing.Size(218, 23);
            this.txtVatNumber.TabIndex = 0;
            // 
            // groupAddresses
            // 
            this.groupAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAddresses.Controls.Add(this.dgvAddresses);
            this.groupAddresses.Location = new System.Drawing.Point(12, 174);
            this.groupAddresses.Name = "groupAddresses";
            this.groupAddresses.Size = new System.Drawing.Size(672, 116);
            this.groupAddresses.TabIndex = 1;
            this.groupAddresses.TabStop = false;
            this.groupAddresses.Text = "Addresses";
            // 
            // groupPhones
            // 
            this.groupPhones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPhones.Controls.Add(this.dgvPhones);
            this.groupPhones.Location = new System.Drawing.Point(12, 296);
            this.groupPhones.Name = "groupPhones";
            this.groupPhones.Size = new System.Drawing.Size(672, 111);
            this.groupPhones.TabIndex = 2;
            this.groupPhones.TabStop = false;
            this.groupPhones.Text = "Phones";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(6, 91);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(59, 19);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // dgvAddresses
            // 
            this.dgvAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvAddresses.BackgroundColor = System.Drawing.Color.White;
            this.dgvAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddresses.Location = new System.Drawing.Point(5, 22);
            this.dgvAddresses.Name = "dgvAddresses";
            this.dgvAddresses.RowTemplate.Height = 25;
            this.dgvAddresses.Size = new System.Drawing.Size(571, 88);
            this.dgvAddresses.TabIndex = 0;
            // 
            // dgvPhones
            // 
            this.dgvPhones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPhones.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhones.Location = new System.Drawing.Point(6, 17);
            this.dgvPhones.Name = "dgvPhones";
            this.dgvPhones.RowTemplate.Height = 25;
            this.dgvPhones.Size = new System.Drawing.Size(571, 88);
            this.dgvPhones.TabIndex = 1;
            // 
            // FormCustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 429);
            this.Controls.Add(this.groupPhones);
            this.Controls.Add(this.groupAddresses);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCustomerEdit";
            this.Text = "Edit Customer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupAddresses.ResumeLayout(false);
            this.groupPhones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupAddresses;
        private System.Windows.Forms.GroupBox groupPhones;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVatNumber;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridView dgvAddresses;
        private System.Windows.Forms.DataGridView dgvPhones;
    }
}