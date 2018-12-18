void setup() {
pinMode(3,OUTPUT);
pinMode(4,OUTPUT);
pinMode(5,OUTPUT);
pinMode(6,OUTPUT);
pinMode(7,OUTPUT);
pinMode(8,OUTPUT);
pinMode(9,OUTPUT);
pinMode(10,OUTPUT);
pinMode(11,OUTPUT);
Serial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:
if(Serial.available()){
  int a=Serial.read();
  if(a=='1'){
    digitalWrite(3,HIGH);
  }
  else if(a=='0'){
    digitalWrite(3,LOW);
  }
  if(a=='2'){
    digitalWrite(4,HIGH);
  }
  else if(a=='3'){
    digitalWrite(4,LOW);
  }
  if(a=='4'){
    digitalWrite(5,HIGH);
  }
  else if(a=='5'){
    digitalWrite(5,LOW);
  }
  if(a=='6'){
    digitalWrite(6,HIGH);
  }
  else if(a=='7'){
    digitalWrite(6,LOW);
  }
  if(a=='8'){
    digitalWrite(7,HIGH);
  }
  else if(a=='9'){
    digitalWrite(7,LOW);
  }
  if(a=='x'){
    digitalWrite(8,HIGH);
  }
  else if(a=='y'){
    digitalWrite(8,LOW);
  }
  if(a=='z'){
    digitalWrite(9,HIGH);
  }
  else if(a=='t'){
    digitalWrite(9,LOW);
  }
  if(a=='s'){
    digitalWrite(10,HIGH);
  }
  else if(a=='m'){
    digitalWrite(10,LOW);
  }
   if(a=='c'){
    digitalWrite(11,HIGH);
  }
  else if(a=='i'){
    digitalWrite(11,LOW);
  }
  }
  
}

