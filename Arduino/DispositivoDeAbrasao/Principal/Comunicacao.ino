
//Função que realiza o tratamento dos comandos que chega pela porta serial
void TratarComando(String cmd){

//Verificação se é um dos dois comandos padrão válidos
//Se não for nenhum dos dois, chama o método EnviarResposta passando a informação de comando inválido (que é representada pelo 0 no parâmetro da função)
//AUTO# seria comando para sequenciamento de experimento e MANU# seria algum comando manual
  if(!cmd.startsWith("AUTO#")&&!cmd.startsWith("MANU#")){

      EnviarRespostas(0);

      return;

  }

//A partir daqui a informação é tratada. A variável parametros recebe uma parte da string cmd, a partir da posição 5, que é onde inicia os VALUES (ou parâmetros)
//Declara as variáveis que vão receber os parâmetros
  String parametros = cmd.substring(5);
  String velocidade;
  String distancia;
  String diametro;
  String sentido;
  String passos;

//Busca saber a posição das duas vírgulas para separar as informações
  int primeiroIndice = parametros.indexOf(',');
  int ultimoIndice = parametros.lastIndexOf(',');

//Verifica se é o comando AUTO
  if(cmd.startsWith("AUTO")){

    //Sendo o comando AUTO, pega os parâmetros com base nas posições das vírgulas, o que foi verificado logo acima, antes do if
    velocidade = parametros.substring(0,primeiroIndice);
    distancia = parametros.substring(primeiroIndice + 1, ultimoIndice);
    diametro = parametros.substring(ultimoIndice + 1);

//Converte os parâmetros de String para double
    double velocidadeToInt = velocidade.toInt();
    double distanciaToInt = distancia.toInt();
    double diametroToInt = diametro.toInt();

//Chama a função de executar experimento passando os parâmetros
    ExecutarExperimento(velocidadeToInt, distanciaToInt, diametroToInt);
  }
//Verifica se é o comando MANU e faz os mesmos passos que na verificação de AUTO
  if(cmd.startsWith("MANU")){
    velocidade = parametros.substring(0,primeiroIndice);
    sentido = parametros.substring(primeiroIndice + 1, ultimoIndice);
    passos = paramtros.substring(ultimoIndice + 1);

    int velocidadeToInt = velocidade.toInt();
    int sentidoToInt = sentido.toInt();
    int passosToInt = passos.toInt();

    ExecutarManual(velocidadeToInt, sentidoToInt, passosToInt);
  }

}

//Função que envia respostas pela linha serial, recebendo como parâmetro qual será a resposta
void EnviarRespostas(int resposta){

  switch(resposta){

//Comando não reconhecido
    case 0:
      Serial.println("0");
      break;

//Experimento iniciado
    case 1:
      Serial.println("1");
      break;

//Experimento finalizado
    case 2:
      Serial.println("2");
      break;

//Experimento abortado
    case 3:
      Serial.println("3");
      break;

//Comando manual de sentido horário realizado com sucesso
    case 4:
      Serial.println("4");
      break;

//Comando manual de sentido anti-horário realizado com sucesso
    case 5:
      Serial.println("5");
      break;  
  }

}