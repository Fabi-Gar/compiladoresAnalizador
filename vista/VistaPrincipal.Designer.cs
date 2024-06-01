namespace compiladoresAnalizador
{
    partial class VistaPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtErrores = new System.Windows.Forms.TextBox();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(427, 519);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(125, 23);
            this.btnAnalizar.TabIndex = 0;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese su bloque de codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(12, 25);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCodigo.Size = new System.Drawing.Size(540, 159);
            this.txtCodigo.TabIndex = 3;
            // 
            // txtErrores
            // 
            this.txtErrores.Location = new System.Drawing.Point(12, 373);
            this.txtErrores.Multiline = true;
            this.txtErrores.Name = "txtErrores";
            this.txtErrores.ReadOnly = true;
            this.txtErrores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrores.Size = new System.Drawing.Size(540, 116);
            this.txtErrores.TabIndex = 4;
            // 
            // lstTokens
            // 
            this.lstTokens.FormattingEnabled = true;
            this.lstTokens.Location = new System.Drawing.Point(12, 218);
            this.lstTokens.Name = "lstTokens";
            this.lstTokens.Size = new System.Drawing.Size(540, 121);
            this.lstTokens.TabIndex = 5;
            // 
            // VistaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 554);
            this.Controls.Add(this.lstTokens);
            this.Controls.Add(this.txtErrores);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnalizar);
            this.Name = "VistaPrincipal";
            this.Text = "Analizador Lexico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtErrores;
        public System.Windows.Forms.ListBox lstTokens;
    }
}

