namespace Agenda.Formularios
{
    partial class frmHome
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
            this.btnFrmAgenda = new System.Windows.Forms.Button();
            this.btnFrmProdutos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFrmAgenda
            // 
            this.btnFrmAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrmAgenda.Location = new System.Drawing.Point(37, 56);
            this.btnFrmAgenda.Name = "btnFrmAgenda";
            this.btnFrmAgenda.Size = new System.Drawing.Size(75, 23);
            this.btnFrmAgenda.TabIndex = 0;
            this.btnFrmAgenda.Text = "Agenda";
            this.btnFrmAgenda.UseVisualStyleBackColor = true;
            this.btnFrmAgenda.Click += new System.EventHandler(this.btnFrmAgenda_Click);
            // 
            // btnFrmProdutos
            // 
            this.btnFrmProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrmProdutos.Location = new System.Drawing.Point(173, 48);
            this.btnFrmProdutos.Name = "btnFrmProdutos";
            this.btnFrmProdutos.Size = new System.Drawing.Size(75, 38);
            this.btnFrmProdutos.TabIndex = 1;
            this.btnFrmProdutos.Text = "Cadastrar Produto";
            this.btnFrmProdutos.UseVisualStyleBackColor = true;
            this.btnFrmProdutos.Click += new System.EventHandler(this.btnFrmProdutos_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 132);
            this.Controls.Add(this.btnFrmProdutos);
            this.Controls.Add(this.btnFrmAgenda);
            this.Name = "frmHome";
            this.Text = "HOME";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmAgenda;
        private System.Windows.Forms.Button btnFrmProdutos;
    }
}