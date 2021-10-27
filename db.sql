CREATE DATABASE cadastro_estudante;

USE cadastro_estudante;

CREATE TABLE Curso
(
CodCurso INTEGER AUTO_INCREMENT PRIMARY KEY,
CodCoordenador INTEGER NOT NULL,
Nome VARCHAR(80) NOT NULL,
CargaHoraria INTEGER NOT NULL,
Modalidade VARCHAR(30) NOT NULL,
Estagio BOOLEAN NOT NULL
);

 

CREATE TABLE Estudante
(
MatEstudante INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30) NOT NULL,
Idade INTEGER NOT NULL,
Graduado BOOLEAN NOT NULL,
Telefone VARCHAR(11) NOT NULL,
Endereco VARCHAR(100) NOT NULL,
Email VARCHAR(30) NOT NULL,
RespFinanceiro BOOLEAN NOT Null,
CodCurso INTEGER,
FOREIGN KEY (CodCurso) references Curso(CodCurso)
);

 

CREATE TABLE Bolsa
(
CodBolsa INTEGER AUTO_INCREMENT PRIMARY KEY,
Ano YEAR NOT NULL,
Edital VARCHAR(30) NOT NULL,
Percentual FLOAT NOT NULL
);

 

CREATE TABLE Pode_ser
(
DataInicio VARCHAR(30) NOT NULL,
DataFim VARCHAR(30) NOT NULL,
MatEstudante INTEGER NOT NULL,
CodBolsa INTEGER NOT NULL,
BolsaAtiva BOOL NOT NULL,
FOREIGN KEY (MatEstudante) references Estudante(MatEstudante),
FOREIGN KEY (CodBolsa) references Bolsa(CodBolsa),
CONSTRAINT Primaria PRIMARY KEY (MatEstudante, CodBolsa)
);

 

CREATE TABLE Concedente
(
CodConcedente INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30) NOT NULL
);

 

CREATE TABLE Possui
(
CodBolsa INTEGER,
CodConcedente INTEGER,
CONSTRAINT Primaria2 PRIMARY KEY (CodBolsa, CodConcedente),
FOREIGN KEY (CodBolsa) references Bolsa(CodBolsa),
FOREIGN KEY (CodConcedente) references Concedente(CodConcedente)
);

 

CREATE TABLE Departamento
(
CodDepartamento INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30) NOT NULL
);

 

CREATE TABLE Professor
(
MatProfessor INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30) NOT NULL,
Telefone VARCHAR(11) NOT NULL,
Endereco VARCHAR(100) NOT NULL,
Email VARCHAR(30) NOT NULL
);

 

CREATE TABLE Trabalha
(
CodDepartamento INTEGER,
MatProfessor INTEGER,
CONSTRAINT Primaria3 PRIMARY KEY (CodDepartamento, MatProfessor),
FOREIGN KEY (CodDepartamento) references Departamento(CodDepartamento),
FOREIGN KEY (MatProfessor) references Professor(MatProfessor)
);

 

CREATE TABLE Disciplina
(
CodDisciplina INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30)
);

 

CREATE TABLE Leciona
(
MatProfessor INTEGER,
Ano INTEGER,
CodDisciplina INTEGER,
CONSTRAINT Primaria3 PRIMARY KEY (MatProfessor, CodDisciplina),
FOREIGN KEY (MatProfessor) references Professor(MatProfessor),
FOREIGN KEY (CodDisciplina) references Disciplina(CodDisciplina)
);
 
CREATE TABLE Tem
(
CodDisciplina INTEGER,
CodCurso INTEGER,
CONSTRAINT Primaria4 PRIMARY KEY (CodDisciplina, CodCurso),
FOREIGN KEY (CodDisciplina) references Disciplina(CodDisciplina),
FOREIGN KEY (CodCurso) references Curso(CodCurso)
);

 

CREATE TABLE Tipo
(
CodTipo INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30)
);

 

CREATE TABLE Area
(
CodArea INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30)
);

 

ALTER TABLE Curso ADD CodDepartamento INTEGER, ADD FOREIGN KEY (CodDepartamento) references Departamento(CodDepartamento);
ALTER TABLE Curso ADD CodTipo INTEGER, ADD FOREIGN KEY (CodTipo) references Tipo(CodTipo);
ALTER TABLE Curso ADD CodArea INTEGER, ADD FOREIGN KEY (CodArea) references Area(CodArea);
ALTER TABLE Curso ADD FOREIGN KEY (CodCoordenador) references Professor(MatProfessor);

 

INSERT INTO 
    Professor(MatProfessor, Nome, Telefone, Endereco, Email)
VALUES
    ("001", "Frank Nobre", "35988452154", "Avenida Presidente Prudente, Bairro Centro, Nº 45", "frank.nobre@hotmail.com"),
    ("002", "João Cesar", "35999478521", "Rua Assis Moreira, Bairro Joaquim Sales, Nº 158", "joao.cesar@hotmail.com"),
    ("003", "Elias Lasmar", "35998545240", "Rua Vila Vera Cruz, Bairro Vale do Sol, Nº 741", "elias.lasmar@hotmail.com");

 

INSERT INTO 
    Curso(CodCoordenador, Nome, CargaHoraria, Modalidade, Estagio, CodDepartamento, CodTipo, CodArea)
VALUES
    (1, "Análise e Desenvolvimento de Sistemas", 2833, "Semipresencial" , False, NULL,NULL,NULL),
    (2, "Filosofia", 1512, "Presencial", True, NULL,NULL,NULL),
    (3, "Biologia", 3200, "Presencial", True, NULL,NULL,NULL);
 
INSERT INTO 
    Estudante(Nome, Idade, Graduado, Telefone, Endereco, Email, RespFinanceiro, CodCurso)
VALUES
    ("Marcos Silva", "32", FALSE, "35998542105", "Rua 14 de Agosto, Bairro Vila Murad, Nº 55", "marcos.silva@gmail.com", TRUE, 1),
    ("Wellyton Oliveira", "30", TRUE, "35987858452", "Rua Artur Nogueira, Bairro Centenário, Nº 99", "wellyton.oliveira@gmail.com", FALSE, 2),
    ("Paulo Nogueira", "34" , FALSE, "35998524510", "Rua Vinte de Maio, Bairro Campestre II, Nº 35", "paulo.nogueira@gmail.com", TRUE, 3);
    
INSERT INTO 
    Bolsa(Ano, Edital, Percentual)
VALUES
    (2020, "Edital /2020_01", 50),
    (2017, "Edital /2017_03", 100),
    (2019, "Edital /2019_01", 75);

 

INSERT INTO
    Pode_ser(MatEstudante, CodBolsa, DataInicio, DataFim, BolsaAtiva)
VALUES
    (1, 3, "2020-02-10", "2022-02-10", TRUE),
    (3, 2, "2017-03-01", "2021-03-01", TRUE),
    (2, 1, "2019-02-15", "2024-02-15", TRUE);
    
INSERT INTO 
    Concedente( Nome)
VALUES
    ("João da Cunha"),
    ("Severino Dias"),
    ("Belanino Mendonça");
    
INSERT INTO
    Departamento(Coddepartamento, Nome)
VALUES
    (NULL, "Análise e Des. Sist."),
    (NULL, "Administração"),
    (NULL, "Veterinária");
    
INSERT INTO
    Disciplina(Coddisciplina, Nome)
VALUES
    (NULL, "Banco de Dados II"),
    (NULL, "Contabilidade Geral"),
    (NULL, "Cardiologia");

 

INSERT INTO 
    Leciona (MatProfessor, Ano , CodDisciplina)
VALUES
    (1,2015,2),
    (3,2020,1),
    (2,2017,3);
    
INSERT INTO 
    Tipo(Nome) 
VALUES
    ("Computação"),
    ("Direitos Humanos"),
    ("Cientista"); 
 
INSERT INTO 
    Area(Nome) 
VALUES 
    ("exatas"),
    ("Humanas"),
    ("Biologicas");
    
INSERT INTO
    Leciona(MatProfessor, CodDisciplina)
VALUES
    (1,1);


# Views de consultas complexas

 

create view Contagem_estudantes_graduados as select count(Curso.CodCurso),AVG(idade) from Curso join Estudante on Curso.CodCurso = Estudante.MatEstudante where Estudante.Graduado = true;

 

create view diferenca as select Estudante.Nome from Curso join Estudante on Curso.CodCurso = Estudante.MatEstudante where Curso.Nome Not in ( select Nome from Curso where Nome = "Filosofia") GROUP BY Curso.Nome;


# Trigger
# REDUZIR CARGA HORARIA DO UM DETERMIANDO CURSO
DELIMITER //
CREATE TRIGGER
  tg_Bolsa_ativa
BEFORE UPDATE ON
  Estudante
FOR EACH ROW
BEGIN
  IF (NEW.Graduado <> OLD.Graduado) AND (NEW.Graduado = TRUE)
  THEN
    UPDATE 
      Pode_ser
    SET 
            Pode_ser.BolsaAtiva = FALSE
        WHERE
            Pode_ser.MatEstudante = OLD.MatEstudante;
  END IF;
END;
//
DELIMITER ;

UPDATE
    Estudante SET Estudante.Graduado = TRUE WHERE MatEstudante =1;

 
 