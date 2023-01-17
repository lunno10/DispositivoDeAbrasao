//Definição das constantes, fazendo referência a qual porta do driver do motor de passo está conectada
//Ex: porta 9 do arduino está conectada na porta DIR do driver, então quando eu fizer referência a porta 9, chamarei ela de DIR no programa

#define dir 9
#define step 8
#define enable 7

//Função SETUP, que executa somente uma vez ao ligar o arduino

void setup() {

  pinMode(dir, OUTPUT); //Definição do pino DIR como saída
  pinMode(step, OUTPUT); //Definição do pino STEP como saída
  pinMode(enable, OUTPUT); //Definição do pino ENABLE como saída

  Serial.begin(115200); //Inicia comunicação Serial e estabele BaudRate como sendo 115200

//Define valores iniciais para os pinos, atribuindo estado lógico 0 ou desenergizado
  digitalWrite(dir,LOW); 
  digitalWrite(enable,LOW);

}

// Função LOOP, que fica executando o tempo todo depois da função SETUP

void loop() {
  
  //No LOOP há apenas a verificação de se há informação na porta serial, já que o arduino só realiza comandos provenientes do software
  if(Serial.available()>0){

// Se houver informação, lê a mesma até que encontre um \n, que é a indicação de final da linha e atribui à variável cmd
    String cmd = Serial.readStringUntil('\n');

//Chama a função tratar comando passando a variável com as informações que chegaram pela porta serial
    TratarComando(cmd);
  }

}


