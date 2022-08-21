# Schedule Control
  <img src="https://i.imgur.com/qMSek4h.png" alt="Logo" >
  <br/>

Clique aqui para acessar! -> [Schedule Control Swagger](https://schedulecontrollucas.herokuapp.com/index.html)

## SOBRE A API

  <p>A API consiste em registro de pacientes, medicos e consultas</p>
  
  <p>Suas principais funcionalidades são:</p>
  
  :heavy_check_mark: `Funcionalidade 1:` Realizar cadastro dos pacientes.
  
  :heavy_check_mark: `Funcionalidade 2:` Realizar cadastro dos medicos.
  
  :heavy_check_mark: `Funcionalidade 3:` Visualizar lista de pacientes.
  
  :heavy_check_mark: `Funcionalidade 4:` Visualizar lista de medicos.
  
  :heavy_check_mark: `Funcionalidade 5:` Registrar uma consulta nova.
  
  :heavy_check_mark: `Funcionalidade 6:` Visualizar a lista de consultas e saber quais pacientes e medicos tem consultas em horários específicos.
  
  ## EXPLICANDO AS REQUISIÇÕES
  
  <p>APPOINTMENT</p>
  
  - ``Create New Appointment - Cria uma nova consulta a partir dos médicos e pacientes cadastrados``
  - ``Delete Appointment By Id - Deleta uma consulta pelo ID``
  - ``Get Appointment By Id - Pega uma Consulta pelo ID``
  - ``Get All Appointments - Pega todas as consultas e consegue ver as consultas marcadas de medicos e pacientes``
  - ``Update Appointment - Consegue Atualizar a data/hora da consulta e também o Doutor``
  
  <p>DOCTOR</p>
  
  - ``Create New Doctor - Cria um novo médico``
  - ``Get All Doctors - Pega todos os médicos cadastrados``
  - ``Update Doctor - Te possibilita atualizar a area de atuação do médico``
  - ``Get Doctor By Id - Pega um médico pelo ID``
  - ``Get Doctor By OccupationArea - Pega um médico pela area de ocupação``
  - ``Delete Doctor By Id - Deleta um médico pelo ID``
  
  <p>PATIENT</p>
  
  - ``Create New Patient - Cria um novo paciente``
  - ``Get Patient By Id - Pega um paciente pelo ID``
  - ``Get Patient By Email - Pega o paciente pelo email``
  - ``Get All Patients - Pega todos os pacientes cadastrados``
  - ``Delete Patient By Id - Deleta um paciente pelo ID``
  
  ## OBSERVAÇÕES
  
  **CONSULTATION TIME** é a quantidade de horas que o médico passa com seu paciente em consulta
  <p>A parte dos horários se você cadastrar uma consulta onde o consultation time do doctor for 1, e o horário da consulta for 17:00 por exemplo, você não podera marcar consultas as 16:00 nem as 18:00, pois ainda vai contar como horario da consulta do doctor, assim terá que marcar as 15:59 ou as 17:01 e assim sucessivamente, sempre 1 minuto antes ou depois</p>
  
  Clique aqui para ver um vídeo de teste da API no swagger [Youtube](https://studio.youtube.com/video/yKGAlpAddZo/edit)
  
  ## TESTES UNITÁRIOS(Podem ser encontrados no ScheduleControlTest)
  <p> Os testes unitários consistem em: </p>
  
  * Criação
  * Procura por ID
  * Procura por nome
  * Procura por email
   <img src="https://i.imgur.com/o8TM5kR.png" alt="Testes unitários" >
  
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
