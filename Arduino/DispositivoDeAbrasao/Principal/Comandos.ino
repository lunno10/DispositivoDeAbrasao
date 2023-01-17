
//Função que executa o sequenciamento de experimento
void ExecutarExperimento(double velocidade, double distancia, double diametro){

  //Cálculos necessários para saber a distância que o motor deve girar e o intervalo entre os pulsos para dar um passo para saber a velocidade (dada em RPM)
  double passos = (distancia*2000)/(3.1415*diametro);
  double intervalo = 60000000/(200*velocidade);

  //Estabele a magnetização do eixo
  digitalWrite(enable,LOW);

  //Informa que o experimento foi iniciado
  EnviarRespostas(1);

  //Executa os passos até que se chegue na quantidade calculada
  for(int i = 0; i<passos; i++){

    //Envia os pulsos com duty cicle de 50%
    digitalWrite(step,HIGH);
    delayMicroseconds(intervalo/2);
    digitalWrite(step,LOW);
    delayMicroseconds(intervalo/2);

    //Verifica se há alguma informação chegando pela porta serial, que seria a informação de abortar o experimento, que é a única que realiza alguma ação dentro desse loop
    if(Serial.available()>0){
      String stop = Serial.readStringUntil('\n');

      // Verifica se é o comando de abortar o experimento
      if(stop == "STOP#0"){
        
        //Avisa que o experimento foi abortado
        EnviarRespostas(3);

        //Corta o método ExecutarExperimento
        return;
      }
      
    }
  }
  //Avisa que o experimento foi finalizado caso 
  EnviarRespostas(2);
}

//Função que executa comandos manuais
void ExecutarManual(int velocidade, int sentido, int passos){

  //Calcula o intervalo entre pulsos para definir a velocidade de giro (dada em RPM)
  int intervalo = 60000000/(200*velocidade);

  //Estabelece magnetização do eixo e abaixo o sentido de giro
  digitalWrite(enable,LOW);
  digitalWrite(dir,sentido);

  //Executa os passos até que se chegue na quantidade informada
  for(int i = 0; i<passos; i++){
    
    //Envia os pulsos com duty cicle de 50%
    digitalWrite(step,HIGH);
    delayMicroseconds(intervalo/2);
    digitalWrite(step,LOW);
    delayMicroseconds(intervalo/2);
  }

  //Reestabelece sentido e giro padrão
  digitalWrite(dir,LOW);

  //Informa que o comando manual foi realizado e qual foi o sentido
  if(sentido == 0){
    EnviarRespostas(4);
  }
  if(sentido == 1){
    EnviarRespostas(5);
  }

}