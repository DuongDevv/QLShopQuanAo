namespace QLShopQuanAo.Views.Main.Order
{
    partial class frmPayment
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDCustomerPay = new System.Windows.Forms.TextBox();
            this.txtNameCustomerPay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustomerTotalAmountPay = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCustomerChange = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomerAmountTendered = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên khách hàng:";
            // 
            // txtIDCustomerPay
            // 
            this.txtIDCustomerPay.Location = new System.Drawing.Point(189, 85);
            this.txtIDCustomerPay.Name = "txtIDCustomerPay";
            this.txtIDCustomerPay.ReadOnly = true;
            this.txtIDCustomerPay.Size = new System.Drawing.Size(202, 22);
            this.txtIDCustomerPay.TabIndex = 3;
            // 
            // txtNameCustomerPay
            // 
            this.txtNameCustomerPay.Location = new System.Drawing.Point(189, 134);
            this.txtNameCustomerPay.Name = "txtNameCustomerPay";
            this.txtNameCustomerPay.ReadOnly = true;
            this.txtNameCustomerPay.Size = new System.Drawing.Size(202, 22);
            this.txtNameCustomerPay.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng hóa đơn:";
            // 
            // lblCustomerTotalAmountPay
            // 
            this.lblCustomerTotalAmountPay.AutoSize = true;
            this.lblCustomerTotalAmountPay.Location = new System.Drawing.Point(186, 182);
            this.lblCustomerTotalAmountPay.Name = "lblCustomerTotalAmountPay";
            this.lblCustomerTotalAmountPay.Size = new System.Drawing.Size(94, 16);
            this.lblCustomerTotalAmountPay.TabIndex = 6;
            this.lblCustomerTotalAmountPay.Text = "Tổng hóa đơn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tiền thừa:";
            // 
            // lblCustomerChange
            // 
            this.lblCustomerChange.AutoSize = true;
            this.lblCustomerChange.Location = new System.Drawing.Point(186, 266);
            this.lblCustomerChange.Name = "lblCustomerChange";
            this.lblCustomerChange.Size = new System.Drawing.Size(16, 16);
            this.lblCustomerChange.TabIndex = 8;
            this.lblCustomerChange.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tiền khách trả:";
            // 
            // txtCustomerAmountTendered
            // 
            this.txtCustomerAmountTendered.Location = new System.Drawing.Point(189, 222);
            this.txtCustomerAmountTendered.Name = "txtCustomerAmountTendered";
            this.txtCustomerAmountTendered.Size = new System.Drawing.Size(202, 22);
            this.txtCustomerAmountTendered.TabIndex = 10;
            this.txtCustomerAmountTendered.TextChanged += new System.EventHandler(this.txtCustomerAmountTendered_TextChanged);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPay.Location = new System.Drawing.Point(325, 266);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(115, 48);
            this.btnPay.TabIndex = 11;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCancel.Location = new System.Drawing.Point(446, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 48);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 331);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtCustomerAmountTendered);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCustomerChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCustomerTotalAmountPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNameCustomerPay);
            this.Controls.Add(this.txtIDCustomerPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPayment";
            this.Text = "frmHoaDonBanSanPham";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDCustomerPay;
        private System.Windows.Forms.TextBox txtNameCustomerPay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCustomerTotalAmountPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomerChange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomerAmountTendered;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
    }
}