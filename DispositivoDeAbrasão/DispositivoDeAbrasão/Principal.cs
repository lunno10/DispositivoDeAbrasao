//Inclusão de namespaces que serão utilizadas

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;

//Definição do nome da namespace
namespace DispositivoDeAbrasão
{
    //Inicio da classe Principal (nosso form do software), que herda tudo que um Form (outra classe) tem
    public partial class Principal : Form
    {
        //Criação de objetos para guardar qual informação foi clicada no menu
        private ToolStripMenuItem velocidadeSelecionada;
        private ToolStripMenuItem portaSelecionada;

        //Criação de um objeto para estabeler a conexão serial e enviar as informações
        private SerialPort conectorSerial;

        public Principal()
        {
            InitializeComponent();

            //Instancia o objeto da conexão serial
            conectorSerial = new SerialPort();
            //Estabele qual método será chamado quando houver um evento de recepção de dados pela porta serial
            conectorSerial.DataReceived += onDadoRecebido;

            //Chama a função de tratar botões
            AtualizarBotoes(0);

            //Chama a função para adicionar os baud rates como opção no menu
            AdicionarBaudRates();
            //Chama a função para adicionar as portas COM disponíveis como opção no menu
            InserirPortas();
            //Chama a função para inserir os textos iniciais nos campos de texto para dar informações ao usuário
            PreencherTextBox();

        }

        //Método que preenche os textos iniciais, onde txtXXXX é o nome do campo e .Text é a propriedade do campo desejada
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

        //Método que insere as opções de porta no menu
        private void InserirPortas()
        {
            //String para receber nomes das portas
            string[] portas = SerialPort.GetPortNames();

            //Verifica se não existe porta, se for diz que não há porta disponível e deixa o menu de portas inativo
            if (portas.Length == 0)
            {
                itemAbrirPorta.Enabled = false;
                itemAbrirPorta.Text = "Sem porta COM disponível";
            }
            //se existir aguma porta, ela é adicionada ao submenu de portas
            else
            {
                //Adiciona as portas no menu conforme a quantidade de portas
                for (int i = 0; i < portas.Length; i++)
                {
                    //Cria e instancia objeto, passando como parâmetro o método onClickPorta para chamar o que será feito caso o botão seja apertado
                    ToolStripMenuItem porta = new ToolStripMenuItem(portas[i], null, onClickPorta, portas[i]);

                    //Adiciona de fato a porta no menu de Portas
                    itemAbrirPorta.DropDownItems.Add(porta);
                }
            }

            
        }

        //Método que marca a porta selecionada e estebele comunicação serial com a mesma porta
        public void onClickPorta(object sender, EventArgs e)
        {
            //Verifica se o objeto tem algum valor e se tiver, desmarca a porta anteriormente clicada
            if (portaSelecionada != null)
            {
                portaSelecionada.Checked = false;
            }

            //Atribui ao objeto a referência da nova porta selecionada
            portaSelecionada = (ToolStripMenuItem)sender;
            portaSelecionada.Checked = true;

            //Verifica se n há conexão aberta com alguma porta e conecta se for o caso passando os parâmetros para o objeto que faz a conexão
            if (!conectorSerial.IsOpen)
            {
                conectorSerial.PortName = portaSelecionada.Name;
                conectorSerial.BaudRate = int.Parse(velocidadeSelecionada.Name);
                try {
                    conectorSerial.Open();
                }
                catch //Se houver problemas na abertura da porta, ela é desmarcada e o software volta ao estágio anterior
                {
                    portaSelecionada.Checked = false;
                    portaSelecionada = null;
                }

                if (conectorSerial.IsOpen) //Mensagem de confirmação de conexão estabelecida
                {
                    MessageBox.Show("Conexão estabelecida com a porta " +
                    conectorSerial.PortName + " e velocidade de comunicação de " + conectorSerial.BaudRate + " baud/s","Conexão estabelecida com sucesso!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    HabilitarControles(false);
                }
                else //Mensagem que indica falha de comunicação
                {
                    MessageBox.Show("Não foi possível estabelecer conexão. Atualize as portas e tente novamente", "Conexão não estabelecida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Cria novo delegate para o problema das informações em threads diferentes
        public delegate void SerialDelegate(string valor);

        //Método que trata os dados recebidos na porta serial
        public void onDadoRecebido(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Lê a linha serial
                string dadoRecebido = conectorSerial.ReadLine();

                //Passa o dado recebido para a variável que vai no delegate
                object[] parametros = new object[1];
                parametros[0] = dadoRecebido;

                SerialDelegate delegar = new SerialDelegate(TratarDados);

                //Chama o delegate responsável por tratar os dados passando os dados recebidos como parâmetros
                BeginInvoke(delegar, parametros);
            }

            catch (Exception erro) //Mensagem de erro no recebimento de dados caso ocorra algum problema no código acima
            {
                MessageBox.Show(erro.Message, "Erro no recebimento de dados!");
            }
        }

        //Método que trata as mensagens que chegam do arduino
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
        //Método que adiciona os baud rates na lista do menu baud rates
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

                //Instancia o objeto e estabele o método que executa no evento de click
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

        //Método que executa quando uma velocidade é clicada
        private void onClickVelocidade(object sender, EventArgs e)
        {
            velocidadeSelecionada.Checked = false;
            //Atribui ao objeto qual foi o menu clicado
            velocidadeSelecionada = (ToolStripMenuItem)sender;
            velocidadeSelecionada.Checked = true;
        }

        //Método que encerra a conexão
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

        //Método que controla os botões do menu
        private void HabilitarControles(bool ativo)
        {
            itemAbrirPorta.Enabled = ativo;
            itemFecharPorta.Enabled = !ativo;
            itemVelocidade.Enabled = ativo;
            itemAtualizar.Enabled = ativo;
        }

        //Método que abre a caixa de diálogo para salvar dados e posteriormente adiciona os dados nas linhas subsequentes
        private void btnSalvarExp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Preencheu a quantidade de massa retirada?", "Confirma inicio?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //Cria objeto de caixa de busca, estabele filtros e abre o objeto
                OpenFileDialog caixaArquivo = new OpenFileDialog();
                caixaArquivo.DefaultExt = "txt";
                caixaArquivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                DialogResult resultado = caixaArquivo.ShowDialog();

                //Ao clicar ok, salva o caminho do arquivo, lê as linhas do arquivo
                if (resultado == DialogResult.OK)
                {
                    string nomeArquivo = caixaArquivo.FileName;
                    string linhas = File.ReadAllText(nomeArquivo);
                    string expAtual;

                    //Atribui à variável os dados do experimento atual
                    expAtual = txtNome.Text + ";" + txtData.Text + ";" + txtAmostra.Text + ";" + txtCarga.Text + ";"
                        + txtDiametro.Text + ";" + txtRebolo.Text + ";" + txtVelocidade.Text + ";" + txtDistancia.Text + ";" + txtMassa.Text;
                    //Adiciona as informações na variável contexto o texto do arquivo
                    linhas += "\n" + expAtual;

                    //Sobrescreve o arquivo contento os novos dados
                    File.WriteAllText(nomeArquivo, linhas);
                }


            }
        }

        //Método que executa o sequenciamento de experimento quando o botão iniciar é apertado
        private void btnIniciarExp_Click(object sender, EventArgs e)
        {
            //Caixa de confirmação
            if (DialogResult.Yes == MessageBox.Show("Preencheu adequadamente todos os campos?", "Confirma inicio?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //Caso aperte ok, enviar dados do experimento pela linha serial
                if (conectorSerial.IsOpen)
                {
                    conectorSerial.WriteLine("AUTO#" + txtVelocidade.Text + "," + txtDistancia.Text + "," + txtDiametro.Text);
                }
                //Caso contrário, dá a mensagem de erro 
                else
                     MessageBox.Show("Conexão não estabelecida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        //Método que habilita ou não os botões de acordo com as informações que chegam do arduino
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

        //Método que envia o comando de abortar experimento para o arduino quando o botão abortar é apertado
        private void btnAbortar_Click(object sender, EventArgs e)
        {
            if (conectorSerial.IsOpen)
            {
                conectorSerial.WriteLine("STOP#0");
            }
            else MessageBox.Show("Conexão não estabelecida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método que reinicia estado dos botões permitindo um novo experimento, quando o botão reinicar é apertado
        private void btnReset_Click(object sender, EventArgs e)
        {
            AtualizarBotoes(0);
        }

        //Método que mostra as informações do botão sobre num popup, quando o botão sobre é apertado
        private void itemSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software desenvolvido como TCC do aluno Lunno Cincurá\nVersão: 1.0\nContato:lunnocincura@gmail.com", "Sobre", MessageBoxButtons.OK);
        }

        //Método que atualiza as portas, semelhante ao método de inserir portas
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

        //Método que envia comando manual pro arduino para girar no sentido horário
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

        //Método que envia comando manual pro arduino para girar no sentido anti-horário
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
