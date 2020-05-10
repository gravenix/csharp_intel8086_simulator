namespace symulator_rejestru
{
    partial class MainForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.field_ax = new System.Windows.Forms.Label();
            this.field_bx = new System.Windows.Forms.Label();
            this.field_cx = new System.Windows.Forms.Label();
            this.field_dx = new System.Windows.Forms.Label();
            this.text_input = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "BX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "CX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "DX";
            // 
            // field_ax
            // 
            this.field_ax.AutoSize = true;
            this.field_ax.Location = new System.Drawing.Point(39, 9);
            this.field_ax.Name = "field_ax";
            this.field_ax.Size = new System.Drawing.Size(0, 13);
            this.field_ax.TabIndex = 1;
            // 
            // field_bx
            // 
            this.field_bx.AutoSize = true;
            this.field_bx.Location = new System.Drawing.Point(39, 22);
            this.field_bx.Name = "field_bx";
            this.field_bx.Size = new System.Drawing.Size(0, 13);
            this.field_bx.TabIndex = 1;
            // 
            // field_cx
            // 
            this.field_cx.AutoSize = true;
            this.field_cx.Location = new System.Drawing.Point(39, 35);
            this.field_cx.Name = "field_cx";
            this.field_cx.Size = new System.Drawing.Size(0, 13);
            this.field_cx.TabIndex = 1;
            // 
            // field_dx
            // 
            this.field_dx.AutoSize = true;
            this.field_dx.Location = new System.Drawing.Point(40, 48);
            this.field_dx.Name = "field_dx";
            this.field_dx.Size = new System.Drawing.Size(0, 13);
            this.field_dx.TabIndex = 1;
            // 
            // text_input
            // 
            this.text_input.Location = new System.Drawing.Point(106, 70);
            this.text_input.Name = "text_input";
            this.text_input.Size = new System.Drawing.Size(140, 20);
            this.text_input.TabIndex = 2;
            this.text_input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onType);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Wpisz polecenie:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 102);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_input);
            this.Controls.Add(this.field_dx);
            this.Controls.Add(this.field_cx);
            this.Controls.Add(this.field_bx);
            this.Controls.Add(this.field_ax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label field_ax;
        private System.Windows.Forms.Label field_bx;
        private System.Windows.Forms.Label field_cx;
        private System.Windows.Forms.Label field_dx;
        private System.Windows.Forms.TextBox text_input;
        private System.Windows.Forms.Label label5;
    }
}

