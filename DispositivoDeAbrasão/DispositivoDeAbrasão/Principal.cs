using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;

namespace DispositivoDeAbrasão
{
    public partial class Principal : Form
    {
        private ToolStripMenuItem velocidadeSelecionada;
        private ToolStripMenuItem portaSelecionada;
        private SerialPort conectorSerial;

        public Principal()
        {
            InitializeComponent();

            conectorSerial = new SerialPort();
            conectorSerial.DataReceived += onDadoRecebido;

            AtualizarBotoes(0);

            AdicionarBaudRates();
            InserirPortas();
            PreencherTextBox();

        }

        private void PreencherTextBox()
        {
            txtCarga.Text = "em kg";
            txtData.Text = "dd/MM/yyyy";
            txtVelocidade.Text = "em RPM";
            txtDistancia.Text = "em cm";
            txtDiametro.Text = "em mm";
            txtMassa.Text = "em mg";
            txtVelManu.Text = "em RPM";

        }

        private void InserirPortas()
        {
            string[] portas = SerialPort.GetPortNames();

            if (portas.Length == 0)
            {
                itemAbrirPorta.Enabled = false;
                itemAbrirPorta.Text = "Sem porta COM disponível";
            }
            else
            {
                for (int i = 0; i < portas.Length; i++)
                {

                    ToolStripMenuItem porta = new ToolStripMenuItem(portas[i], null, onClickPorta, portas[i]);

                    itemAbrirPorta.DropDownItems.Add(porta);
                }
            }

            
        }

        public void onClickPorta(object sender, EventArgs e)
        {
            if (portaSelecionada != null)
            {
                portaSelecionada.Checked = false;
            }

            portaSelecionada = (ToolStripMenuItem)sender;
            portaSelecionada.Checked = true;

            if (!conectorSerial.IsOpen)
            {
                conectorSerial.PortName = portaSelecionada.Name;
                conectorSerial.BaudRate = int.Parse(velocidadeSelecionada.Name);
                try {
                    conectorSerial.Open();
                }
                catch
                {
                    portaSelecionada.Checked = false;
                    portaSelecionada = null;
                }

                if (conectorSerial.IsOpen)
                {
                    MessageBox.Show("Conexão estabelecida com a porta " +
                    conectorSerial.PortName + " e velocidade de comunicação de " + conectorSerial.BaudRate + " baud/s","Conexão estabelecida com sucesso!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    HabilitarControles(false);
                }
                else
                {
                    MessageBox.Show("Não foi possível estabelecer conexão. Atualize as portas e tente novamente", "Conexão não estabelecida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public delegate void SerialDelegate(string valor);

        public void onDadoRecebido(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string dadoRecebido = conectorSerial.ReadLine();

                object[] parametros = new object[1];
                parametros[0] = dadoRecebido;

                SerialDelegate delegar = new SerialDelegate(TratarDados);

                BeginInvoke(delegar, parametros);
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro no recebimento de dados!");
            }
        }

        //0 = Comando inválido, 1 = Experimento iniciado, 2 = Experimento finalizado, 3 = Experimento abortado,
        //4 = Comando manual no sentido horário realizado, 5 = Comando manual no sentido anti-horário realizado
        private void TratarDados(string valor)
        {

            try
            {
                int comando = int.Parse(valor);

                switch (comando)
                {
                    case 0:
                        MessageBox.Show("Comando entendido como inválido pelo controlador", "Comando inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                        AtualizarBotoes(1);
                        MessageBox.Show("Experimento iniciado com sucesso", "Experimento iniciado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        AtualizarBotoes(2);
                        MessageBox.Show("Experimento finalizado com sucesso", "Experimento finalizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 3:
                        MessageBox.Show("Experimento abortado com sucesso", "Experimento abortado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        AtualizarBotoes(3);
                        break;
                    case 4:
                        MessageBox.Show("Comando manual no sentido horário realizado", "Comando manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 5:
                        MessageBox.Show("Comando manual no sentido anti-horário realizado", "Comando manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("O valor recebido não pôde ser tratado", "Falha de comunicação", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void AdicionarBaudRates()
        {
            List<int> baudRates = new List<int>();
            baudRates.Add(4800);
            baudRates.Add(9600);
            baudRates.Add(19200);
            baudRates.Add(38400);
            baudRates.Add(57600);
            baudRates.Add(115200);
            baudRates.Add(230400);

            for (int i = 0; i < baudRates.Count; i++)
            {
                string baudRate = baudRates[i].ToString();

                ToolStripMenuItem vel = new ToolStripMenuItem(baudRate,
                    null, onClickVelocidade, baudRate);
                itemVelocidade.DropDownItems.Add(vel);

                if (baudRate == "9600")
                {
                    velocidadeSelecionada = vel;
                    vel.Checked = true;
                }
            }
        }

        private void onClickVelocidade(object sender, EventArgs e)
        {
            velocidadeSelecionada.Checked = false;
            velocidadeSelecionada = (ToolStripMenuItem)sender;
            velocidadeSelecionada.Checked = true;
        }

        private void itemFecharPorta_Click(object sender, EventArgs e)
        {
            if (this.conectorSerial.IsOpen)
            {
                this.conectorSerial.Close();

                MessageBox.Show("Conexão encerrada");

                HabilitarControles(true);

                portaSelecionada.Checked = false;

                itemAbrirPorta.Enabled = true;
            }
        }

        private void HabilitarControles(bool ativo)
        {
            itemAbrirPorta.Enabled = ativo;
            itemFecharPorta.Enabled = !ativo;
            itemVelocidade.Enabled = ativo;
            itemAtualizar.Enabled = ativo;
        }

        private void btnSalvarExp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Preencheu a quantidade de massa retirada?", "Confirma inicio?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                OpenFileDialog caixaArquivo = new OpenFileDialog();
                caixaArquivo.DefaultExt = "txt";
                caixaArquivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                DialogResult resultado = caixaArquivo.ShowDialog();


                if (resultado == DialogResult.OK)
                {
                    string nomeArquivo = caixaArquivo.FileName;
                    string linhas = File.ReadAllText(nomeArquivo);
                    string expAtual;

                    expAtual = txtNome.Text + ";" + txtData.Text + ";" + txtAmostra.Text + ";" + txtCarga.Text + ";"
                        + txtDiametro.Text + ";" + txtRebolo.Text + ";" + txtVelocidade.Text + ";" + txtDistancia.Text + ";" + txtMassa.Text;
                    linhas += "\n" + expAtual;

                    File.WriteAllText(nomeArquivo, linhas);
                }


            }
        }

        private void btnIniciarExp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Preencheu adequadamente todos os campos?", "Confirma inicio?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (conectorSerial.IsOpen)
                {
                    conectorSerial.WriteLine("AUTO#" + txtVelocidade.Text + "," + txtDistancia.Text + "," + txtDiametro.Text);
                }
                else AtualizarBotoes(2);
                     //MessageBox.Show("Conexão não estabelecida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void AtualizarBotoes(int estado)
        {

            //0 = pronto, 1 = experimento em andamento, 2 = experimento finalizado; 3 = exp abortado
            switch (estado)
            {
                case 0:
                    if (conectorSerial.IsOpen)
                    {
                        HabilitarControles(false);
                    }
                    else HabilitarControles(true);
                    btnSalvarExp.Enabled = false;
                    btnIniciarExp.Enabled = true;
                    txtAmostra.Enabled = true;
                    txtNome.Enabled = true;
                    txtData.Enabled = true;
                    txtVelocidade.Enabled = true;
                    txtDistancia.Enabled = true;
                    txtDiametro.Enabled = true;
                    txtRebolo.Enabled = true;
                    txtCarga.Enabled = true;
                    txtMassa.Enabled = true;
                    btnAbortar.Enabled = false;
                    btnReset.Enabled = false;
                    break;
                case 1:

                    HabilitarControles(false);
                    itemFecharPorta.Enabled = false;
                    btnSalvarExp.Enabled = false;
                    btnIniciarExp.Enabled = false;
                    txtAmostra.Enabled = false;
                    txtNome.Enabled = false;
                    txtData.Enabled = false;
                    txtVelocidade.Enabled = false;
                    txtDistancia.Enabled = false;
                    txtDiametro.Enabled = false;
                    txtRebolo.Enabled = false;
                    txtCarga.Enabled = false;
                    txtMassa.Enabled = false;
                    btnAbortar.Enabled = true;
                    btnReset.Enabled = false;
                    break;
                case 2:
                    if (conectorSerial.IsOpen)
                    {
                        HabilitarControles(false);
                    }
                    else HabilitarControles(true);
                    btnSalvarExp.Enabled = true;
                    btnIniciarExp.Enabled = false;
                    txtAmostra.Enabled = false;
                    txtNome.Enabled = false;
                    txtData.Enabled = false;
                    txtVelocidade.Enabled = false;
                    txtDistancia.Enabled = false;
                    txtDiametro.Enabled = false;
                    txtRebolo.Enabled = false;
                    txtCarga.Enabled = false;
                    txtMassa.Enabled = true;
                    btnReset.Enabled = true;
                    break;
                case 3:
                    if (conectorSerial.IsOpen)
                    {
                        HabilitarControles(false);
                    }
                    else HabilitarControles(true);
                    btnSalvarExp.Enabled = false;
                    btnIniciarExp.Enabled = false;
                    txtAmostra.Enabled = false;
                    txtNome.Enabled = false;
                    txtData.Enabled = false;
                    txtVelocidade.Enabled = false;
                    txtDistancia.Enabled = false;
                    txtDiametro.Enabled = false;
                    txtRebolo.Enabled = false;
                    txtCarga.Enabled = false;
                    txtMassa.Enabled = false;
                    btnAbortar.Enabled = false;
                    btnReset.Enabled = true;
                    break;
            }
        }

        private void btnAbortar_Click(object sender, EventArgs e)
        {
            if (conectorSerial.IsOpen)
            {
                conectorSerial.WriteLine("STOP#0");
            }
            else MessageBox.Show("Conexão não estabelecida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            AtualizarBotoes(0);
        }

        private void itemSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software desenvolvido como TCC do aluno Lunno Cincurá\nVersão: 1.0\nContato:lunnocincura@gmail.com", "Sobre", MessageBoxButtons.OK);
        }

        private void itemAtualizar_Click(object sender, EventArgs e)
        {
            string[] portas = SerialPort.GetPortNames();

            if (portas.Length == 0)
            {
                itemAbrirPorta.Enabled = false;
                itemAbrirPorta.Text = "Sem porta COM disponível";
            }
            else
            {
                for (int i = 0; i < portas.Length; i++)
                {

                    itemAbrirPorta.Enabled = true;
                    itemAbrirPorta.Text = "Abrir Porta";
                    ToolStripMenuItem porta = new ToolStripMenuItem(portas[i], null, onClickPorta, portas[i]);

                    itemAbrirPorta.DropDownItems.Add(porta);
                }
            }

        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Preencheu adequadamente todos os campos?", "Confirma comando?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (conectorSerial.IsOpen)
                {
                    conectorSerial.WriteLine("MANU#" + txtVelManu.Text + "," + "0" + "," + txtPassosManu.Text);
                }
                else MessageBox.Show("Conexão não estabelecida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAntiHorario_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Preencheu adequadamente todos os campos?", "Confirma comando?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (conectorSerial.IsOpen)
                {
                    conectorSerial.WriteLine("MANU#" + txtVelManu.Text + "," + "1" + "," + txtPassosManu.Text);
                }
                else MessageBox.Show("Conexão não estabelecida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
