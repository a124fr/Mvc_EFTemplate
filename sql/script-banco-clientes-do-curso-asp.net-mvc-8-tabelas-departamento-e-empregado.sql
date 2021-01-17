use Cadastro;

CREATE TABLE Departamentos
(
	Id INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
		
	CONSTRAINT DepartamentosPK PRIMARY KEY (Id)
);

CREATE TABLE Empregados
(
	Id INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Sobrenome VARCHAR(50) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	DepartamentoId INT NOT NULL,
	
	CONSTRAINT EmpregadoPK PRIMARY KEY (Id),
	CONSTRAINT DepartamentoIdFK FOREIGN KEY(DepartamentoId) REFERENCES Departamentos(Id)		
);


