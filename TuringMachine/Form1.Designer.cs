namespace TuringMachine
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblActualPosition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentTransition = new System.Windows.Forms.Label();
            this.btnDoStep = new System.Windows.Forms.Button();
            this.btnDoExecution = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoadInput = new System.Windows.Forms.Button();
            this.lbl_LeftPart = new System.Windows.Forms.Label();
            this.lblRightPart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Máquina de Turing";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(14, 73);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(167, 20);
            this.txtPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adjuntar definición de la MT";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 70);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cargar MT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblActualPosition
            // 
            this.lblActualPosition.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblActualPosition.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualPosition.ForeColor = System.Drawing.Color.Red;
            this.lblActualPosition.Location = new System.Drawing.Point(454, 307);
            this.lblActualPosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblActualPosition.Name = "lblActualPosition";
            this.lblActualPosition.Size = new System.Drawing.Size(16, 22);
            this.lblActualPosition.TabIndex = 5;
            this.lblActualPosition.Text = "_";
            this.lblActualPosition.Click += new System.EventHandler(this.lblActualPosition_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(558, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "ESTADO ACTUAL";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(820, 136);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(15, 22);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(558, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "ÚLTIMA TRANSICIÓN";
            // 
            // lblCurrentTransition
            // 
            this.lblCurrentTransition.AutoSize = true;
            this.lblCurrentTransition.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTransition.Location = new System.Drawing.Point(820, 171);
            this.lblCurrentTransition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentTransition.Name = "lblCurrentTransition";
            this.lblCurrentTransition.Size = new System.Drawing.Size(15, 22);
            this.lblCurrentTransition.TabIndex = 9;
            this.lblCurrentTransition.Text = "-";
            // 
            // btnDoStep
            // 
            this.btnDoStep.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoStep.Location = new System.Drawing.Point(9, 159);
            this.btnDoStep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoStep.Name = "btnDoStep";
            this.btnDoStep.Size = new System.Drawing.Size(100, 33);
            this.btnDoStep.TabIndex = 10;
            this.btnDoStep.Text = ">>";
            this.btnDoStep.UseVisualStyleBackColor = true;
            this.btnDoStep.Click += new System.EventHandler(this.btnDoStep_Click);
            // 
            // btnDoExecution
            // 
            this.btnDoExecution.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoExecution.Location = new System.Drawing.Point(123, 159);
            this.btnDoExecution.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoExecution.Name = "btnDoExecution";
            this.btnDoExecution.Size = new System.Drawing.Size(100, 33);
            this.btnDoExecution.TabIndex = 11;
            this.btnDoExecution.Text = "RUN";
            this.btnDoExecution.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(14, 118);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(167, 20);
            this.txtInput.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Entrada";
            // 
            // btnLoadInput
            // 
            this.btnLoadInput.Location = new System.Drawing.Point(194, 115);
            this.btnLoadInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadInput.Name = "btnLoadInput";
            this.btnLoadInput.Size = new System.Drawing.Size(104, 25);
            this.btnLoadInput.TabIndex = 14;
            this.btnLoadInput.Text = "Importar cinta";
            this.btnLoadInput.UseVisualStyleBackColor = true;
            this.btnLoadInput.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_LeftPart
            // 
            this.lbl_LeftPart.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LeftPart.Location = new System.Drawing.Point(19, 307);
            this.lbl_LeftPart.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_LeftPart.Name = "lbl_LeftPart";
            this.lbl_LeftPart.Size = new System.Drawing.Size(435, 22);
            this.lbl_LeftPart.TabIndex = 15;
            this.lbl_LeftPart.Text = "_";
            this.lbl_LeftPart.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_LeftPart.Click += new System.EventHandler(this.lbl_LeftPart_Click);
            // 
            // lblRightPart
            // 
            this.lblRightPart.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightPart.Location = new System.Drawing.Point(470, 307);
            this.lblRightPart.Margin = new System.Windows.Forms.Padding(0);
            this.lblRightPart.Name = "lblRightPart";
            this.lblRightPart.Size = new System.Drawing.Size(416, 22);
            this.lblRightPart.TabIndex = 16;
            this.lblRightPart.Text = "_";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(900, 408);
            this.Controls.Add(this.lblRightPart);
            this.Controls.Add(this.lbl_LeftPart);
            this.Controls.Add(this.btnLoadInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnDoExecution);
            this.Controls.Add(this.btnDoStep);
            this.Controls.Add(this.lblCurrentTransition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblActualPosition);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Proyecto Lenguaje Formales y Autómatas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblActualPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentTransition;
        private System.Windows.Forms.Button btnDoStep;
        private System.Windows.Forms.Button btnDoExecution;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoadInput;
        private System.Windows.Forms.Label lbl_LeftPart;
        private System.Windows.Forms.Label lblRightPart;
    }
}

