
namespace DispositivoDeAbrasão
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemFerramentas = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbrirPorta = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFecharPorta = new System.Windows.Forms.ToolStripMenuItem();
            this.itemVelocidade = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAtualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExp = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAbortar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMassa = new System.Windows.Forms.TextBox();
            this.btnSalvarExp = new System.Windows.Forms.Button();
            this.btnIniciarExp = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCarga = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAmostra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRebolo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiametro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVelocidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.tabManuais = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassosManu = new System.Windows.Forms.TextBox();
            this.txtVelManu = new System.Windows.Forms.TextBox();
            this.btnAntiHorario = new System.Windows.Forms.Button();
            this.btnHorario = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabExp.SuspendLayout();
            this.tabManuais.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFerramentas,
            this.itemSobre});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // itemFerramentas
            // 
            this.itemFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbrirPorta,
            this.itemFecharPorta,
            this.itemVelocidade,
            this.itemAtualizar});
            this.itemFerramentas.Name = "itemFerramentas";
            this.itemFerramentas.Size = new System.Drawing.Size(104, 26);
            this.itemFerramentas.Text = "Ferramentas";
            // 
            // itemAbrirPorta
            // 
            this.itemAbrirPorta.Name = "itemAbrirPorta";
            this.itemAbrirPorta.Size = new System.Drawing.Size(281, 26);
            this.itemAbrirPorta.Text = "Abrir Porta";
            // 
            // itemFecharPorta
            // 
            this.itemFecharPorta.Name = "itemFecharPorta";
            this.itemFecharPorta.Size = new System.Drawing.Size(281, 26);
            this.itemFecharPorta.Text = "Fechar Porta";
            this.itemFecharPorta.Click += new System.EventHandler(this.itemFecharPorta_Click);
            // 
            // itemVelocidade
            // 
            this.itemVelocidade.Name = "itemVelocidade";
            this.itemVelocidade.Size = new System.Drawing.Size(281, 26);
            this.itemVelocidade.Text = "Velocidade de Comunicação";
            // 
            // itemAtualizar
            // 
            this.itemAtualizar.Name = "itemAtualizar";
            this.itemAtualizar.Size = new System.Drawing.Size(281, 26);
            this.itemAtualizar.Text = "Atualizar Portas";
            this.itemAtualizar.Click += new System.EventHandler(this.itemAtualizar_Click);
            // 
            // itemSobre
            // 
            this.itemSobre.Name = "itemSobre";
            this.itemSobre.Size = new System.Drawing.Size(62, 26);
            this.itemSobre.Text = "Sobre";
            this.itemSobre.Click += new System.EventHandler(this.itemSobre_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExp);
            this.tabControl1.Controls.Add(this.tabManuais);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabExp
            // 
            this.tabExp.BackColor = System.Drawing.Color.LightGray;
            this.tabExp.Controls.Add(this.btnReset);
            this.tabExp.Controls.Add(this.btnAbortar);
            this.tabExp.Controls.Add(this.label9);
            this.tabExp.Controls.Add(this.txtMassa);
            this.tabExp.Controls.Add(this.btnSalvarExp);
            this.tabExp.Controls.Add(this.btnIniciarExp);
            this.tabExp.Controls.Add(this.label7);
            this.tabExp.Controls.Add(this.txtCarga);
            this.tabExp.Controls.Add(this.label8);
            this.tabExp.Controls.Add(this.txtAmostra);
            this.tabExp.Controls.Add(this.label6);
            this.tabExp.Controls.Add(this.txtRebolo);
            this.tabExp.Controls.Add(this.label5);
            this.tabExp.Controls.Add(this.txtDiametro);
            this.tabExp.Controls.Add(this.label4);
            this.tabExp.Controls.Add(this.txtDistancia);
            this.tabExp.Controls.Add(this.label3);
            this.tabExp.Controls.Add(this.txtVelocidade);
            this.tabExp.Controls.Add(this.label2);
            this.tabExp.Controls.Add(this.txtData);
            this.tabExp.Controls.Add(this.label1);
            this.tabExp.Controls.Add(this.txtNome);
            this.tabExp.Location = new System.Drawing.Point(4, 25);
            this.tabExp.Name = "tabExp";
            this.tabExp.Padding = new System.Windows.Forms.Padding(3);
            this.tabExp.Size = new System.Drawing.Size(792, 391);
            this.tabExp.TabIndex = 0;
            this.tabExp.Text = "Experimento";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(604, 284);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(147, 35);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Recomeçar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAbortar
            // 
            this.btnAbortar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbortar.Location = new System.Drawing.Point(604, 231);
            this.btnAbortar.Name = "btnAbortar";
            this.btnAbortar.Size = new System.Drawing.Size(147, 35);
            this.btnAbortar.TabIndex = 20;
            this.btnAbortar.Text = "Abortar Exp";
            this.btnAbortar.UseVisualStyleBackColor = true;
            this.btnAbortar.Click += new System.EventHandler(this.btnAbortar_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 365);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Massa retirada";
            // 
            // txtMassa
            // 
            this.txtMassa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMassa.Location = new System.Drawing.Point(144, 364);
            this.txtMassa.Name = "txtMassa";
            this.txtMassa.Size = new System.Drawing.Size(105, 22);
            this.txtMassa.TabIndex = 18;
            // 
            // btnSalvarExp
            // 
            this.btnSalvarExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarExp.Location = new System.Drawing.Point(637, 348);
            this.btnSalvarExp.Name = "btnSalvarExp";
            this.btnSalvarExp.Size = new System.Drawing.Size(147, 37);
            this.btnSalvarExp.TabIndex = 17;
            this.btnSalvarExp.Text = "Salvar Exp";
            this.btnSalvarExp.UseVisualStyleBackColor = true;
            this.btnSalvarExp.Click += new System.EventHandler(this.btnSalvarExp_Click);
            // 
            // btnIniciarExp
            // 
            this.btnIniciarExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciarExp.Location = new System.Drawing.Point(604, 178);
            this.btnIniciarExp.Name = "btnIniciarExp";
            this.btnIniciarExp.Size = new System.Drawing.Size(147, 35);
            this.btnIniciarExp.TabIndex = 16;
            this.btnIniciarExp.Text = "Iniciar Exp";
            this.btnIniciarExp.UseVisualStyleBackColor = true;
            this.btnIniciarExp.Click += new System.EventHandler(this.btnIniciarExp_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Distância";
            // 
            // txtCarga
            // 
            this.txtCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarga.Location = new System.Drawing.Point(541, 132);
            this.txtCarga.Name = "txtCarga";
            this.txtCarga.Size = new System.Drawing.Size(209, 22);
            this.txtCarga.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Velocidade";
            // 
            // txtAmostra
            // 
            this.txtAmostra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmostra.Location = new System.Drawing.Point(542, 103);
            this.txtAmostra.Name = "txtAmostra";
            this.txtAmostra.Size = new System.Drawing.Size(209, 22);
            this.txtAmostra.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Modelo do rebolo";
            // 
            // txtRebolo
            // 
            this.txtRebolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRebolo.Location = new System.Drawing.Point(542, 75);
            this.txtRebolo.Name = "txtRebolo";
            this.txtRebolo.Size = new System.Drawing.Size(209, 22);
            this.txtRebolo.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(403, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Diâmetro do rebolo";
            // 
            // txtDiametro
            // 
            this.txtDiametro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiametro.Location = new System.Drawing.Point(542, 47);
            this.txtDiametro.Name = "txtDiametro";
            this.txtDiametro.Size = new System.Drawing.Size(209, 22);
            this.txtDiametro.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Carga";
            // 
            // txtDistancia
            // 
            this.txtDistancia.Location = new System.Drawing.Point(89, 132);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(209, 22);
            this.txtDistancia.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amostra";
            // 
            // txtVelocidade
            // 
            this.txtVelocidade.Location = new System.Drawing.Point(89, 103);
            this.txtVelocidade.Name = "txtVelocidade";
            this.txtVelocidade.Size = new System.Drawing.Size(209, 22);
            this.txtVelocidade.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(89, 75);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(209, 22);
            this.txtData.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(89, 47);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(209, 22);
            this.txtNome.TabIndex = 0;
            // 
            // tabManuais
            // 
            this.tabManuais.BackColor = System.Drawing.Color.LightGray;
            this.tabManuais.Controls.Add(this.label12);
            this.tabManuais.Controls.Add(this.label11);
            this.tabManuais.Controls.Add(this.label10);
            this.tabManuais.Controls.Add(this.txtPassosManu);
            this.tabManuais.Controls.Add(this.txtVelManu);
            this.tabManuais.Controls.Add(this.btnAntiHorario);
            this.tabManuais.Controls.Add(this.btnHorario);
            this.tabManuais.Location = new System.Drawing.Point(4, 25);
            this.tabManuais.Name = "tabManuais";
            this.tabManuais.Padding = new System.Windows.Forms.Padding(3);
            this.tabManuais.Size = new System.Drawing.Size(792, 391);
            this.tabManuais.TabIndex = 1;
            this.tabManuais.Text = "Controles manuais";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(493, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "Uma volta possui 200 passos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Passos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Velocidade";
            // 
            // txtPassosManu
            // 
            this.txtPassosManu.Location = new System.Drawing.Point(315, 67);
            this.txtPassosManu.Name = "txtPassosManu";
            this.txtPassosManu.Size = new System.Drawing.Size(170, 22);
            this.txtPassosManu.TabIndex = 3;
            // 
            // txtVelManu
            // 
            this.txtVelManu.Location = new System.Drawing.Point(315, 39);
            this.txtVelManu.Name = "txtVelManu";
            this.txtVelManu.Size = new System.Drawing.Size(170, 22);
            this.txtVelManu.TabIndex = 2;
            // 
            // btnAntiHorario
            // 
            this.btnAntiHorario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAntiHorario.Location = new System.Drawing.Point(489, 212);
            this.btnAntiHorario.Name = "btnAntiHorario";
            this.btnAntiHorario.Size = new System.Drawing.Size(197, 100);
            this.btnAntiHorario.TabIndex = 1;
            this.btnAntiHorario.Text = "Girar no sentido anti-horário";
            this.btnAntiHorario.UseVisualStyleBackColor = true;
            this.btnAntiHorario.Click += new System.EventHandler(this.btnAntiHorario_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHorario.Location = new System.Drawing.Point(106, 212);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Size = new System.Drawing.Size(197, 100);
            this.btnHorario.TabIndex = 0;
            this.btnHorario.Text = "Girar no sentido horário";
            this.btnHorario.UseVisualStyleBackColor = true;
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Dispositivo de Abrasão - UESC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabExp.ResumeLayout(false);
            this.tabExp.PerformLayout();
            this.tabManuais.ResumeLayout(false);
            this.tabManuais.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemFerramentas;
        private System.Windows.Forms.ToolStripMenuItem itemSobre;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExp;
        private System.Windows.Forms.TabPage tabManuais;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRebolo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiametro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVelocidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMassa;
        private System.Windows.Forms.Button btnSalvarExp;
        private System.Windows.Forms.Button btnIniciarExp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCarga;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAmostra;
        private System.Windows.Forms.ToolStripMenuItem itemAbrirPorta;
        private System.Windows.Forms.ToolStripMenuItem itemFecharPorta;
        private System.Windows.Forms.ToolStripMenuItem itemVelocidade;
        private System.Windows.Forms.ToolStripMenuItem itemAtualizar;
        private System.Windows.Forms.Button btnAbortar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAntiHorario;
        private System.Windows.Forms.Button btnHorario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPassosManu;
        private System.Windows.Forms.TextBox txtVelManu;
        private System.Windows.Forms.Label label12;
    }
}

