# Schedule Control
  <img src="https://i.imgur.com/qMSek4h.png" alt="Logo" >
  <br/>

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)

## SOBRE A API

  <p>A API consiste em registro de pacientes, medicos e consultas</p>
  
  <p>Suas principais funcionalidades são:</p>
  
  :heavy_check_mark: `Funcionalidade 1:` Realizar cadastro dos pacientes.
  
  :heavy_check_mark: `Funcionalidade 2:` Realizar cadastro dos medicos.
  
  :heavy_check_mark: `Funcionalidade 3:` Visualizar lista de pacientes.
  
  :heavy_check_mark: `Funcionalidade 4:` Visualizar lista de medicos.
  
  :heavy_check_mark: `Funcionalidade 5:` Registrar uma consulta nova.
  
  :heavy_check_mark: `Funcionalidade 6:` Visualizar a lista de consultas e saber quais pacientes e medicos tem consultas em horários específicos.
  
  ## OBSERVAÇÕES
  
  **CONSULTATION TIME** é a quantidade de horas que o médico passa com seu paciente em consulta
  <p>A parte dos horários se você cadastrar uma consulta onde o consultation time do doctor for 1, e o horário da consulta for 17:00 por exemplo, você não podera marcar consultas as 16:00 nem as 18:00, pois ainda vai contar como horario da consulta do doctor, assim terá que marcar as 15:59 ou as 17:01 e assim sucessivamente</p>
  
  Clique aqui para ver um vídeo de teste da API no swagger [Youtube](https://studio.youtube.com/video/yKGAlpAddZo/edit)
  
  ## TESTES UNITÁRIOS(Podem ser encontrados no ScheduleControlTest)
  <p> Os testes unitários consistem em: </p>
  
  * Criação
  * Procura por ID
  * Procura por nome
  * Procura por email
   <img src="https://i.imgur.com/29zVcUy.jpg" alt="Testes unitários" >
  
  ## TABELAS DO BANCO DE DADOS
  
  <p>Esse sistema está utilizando 3 tabelas</p>
  
  * Pacientes 
  * Medicos
  * Agendamentos de Consulta
  
  ## FERRAMENTAS UTILIZADAS
  
  - ``ASP.NET``
  - ``.NET Core 5``
  - ``Entity Framework``
  - ``SQL``
  - ``Swagger``
  - ``MsTest``
  - ``Heroku (Deploy)``
  
  ## AUTOR
    
   <img src="https://i.imgur.com/2dT2j1U.jpg" alt="Logo" whith="100" height="100"> | <p>Contate-me👇</p> <a href="https://www.linkedin.com/in/lucas-reluz-493549220/" target="_blank"><img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white" target="_blank"></a>
   | :---: | :---:
