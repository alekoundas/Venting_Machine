namespace FrontEnd
{
    partial class VentingMachineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentingMachineForm));
            this.AvailableProductsListBox = new System.Windows.Forms.ListBox();
            this.CartListBox = new System.Windows.Forms.ListBox();
            this.buttdfg = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AvailableProductsListBox
            // 
            this.AvailableProductsListBox.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.AvailableProductsListBox, "AvailableProductsListBox");
            this.AvailableProductsListBox.FormattingEnabled = true;
            this.AvailableProductsListBox.Name = "AvailableProductsListBox";
            // 
            // CartListBox
            // 
            this.CartListBox.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.CartListBox, "CartListBox");
            this.CartListBox.FormattingEnabled = true;
            this.CartListBox.Name = "CartListBox";
            // 
            // buttdfg
            // 
            resources.ApplyResources(this.buttdfg, "buttdfg");
            this.buttdfg.Name = "buttdfg";
            this.buttdfg.UseVisualStyleBackColor = true;
            this.buttdfg.Click += new System.EventHandler(this.AddToCartOnClick);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Purchace);
            // 
            // BalanceLabel
            // 
            resources.ApplyResources(this.BalanceLabel, "BalanceLabel");
            this.BalanceLabel.Name = "BalanceLabel";
            // 
            // TotalLabel
            // 
            resources.ApplyResources(this.TotalLabel, "TotalLabel");
            this.TotalLabel.Name = "TotalLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RemoveFromCartClick);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ClearCartClick);
            // 
            // VentingMachineForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttdfg);
            this.Controls.Add(this.CartListBox);
            this.Controls.Add(this.AvailableProductsListBox);
            this.Name = "VentingMachineForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AvailableProductsListBox;
        private System.Windows.Forms.ListBox CartListBox;
        private System.Windows.Forms.Button buttdfg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

