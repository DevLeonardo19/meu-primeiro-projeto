CREATE DATABASE Comp_Aerea


CREATE TABLE Aviao (

	Avi_id INT PRIMARY KEY IDENTITY,
	Capacidade INT,
	Modelo varchar(100)
)

CREATE TABLE Times(

	Tim_id INT PRIMARY KEY IDENTITY,
	Cat_tim VARCHAR(50),
	Nome_tim VARCHAR(50)
)

CREATE TABLE Estado(
	Estado_sigla VARCHAR(5) PRIMARY KEY,
	Estado_nome VARCHAR(50)
)



CREATE TABLE Cidade(
	Cod_ibge INT PRIMARY KEY,
	Cid_nome VARCHAR(50),
	Estado_sigla VARCHAR(5),

	CONSTRAINT fk_estado_cidade
	FOREIGN KEY (Estado_sigla)
	REFERENCES Estado(Estado_sigla)
)


CREATE TABLE Voos(
	Voo_id INT PRIMARY KEY IDENTITY,
	Avi_id INT,
	Tim_id INT,
	Hora_prev_partida TIME,
	Voo_dt_partida DATE,
	Hora_prev_chegada TIME,
	Voo_dt_chegada DATE,
	Cod_ibge_ori INT,
	Cod_ibge_des INT
)


ALTER TABLE Voos
	ADD
	CONSTRAINT fk_voo_aviao
	FOREIGN KEY (Avi_id)
	REFERENCES Aviao (Avi_id),

	CONSTRAINT fk_voo_time
	FOREIGN KEY (Tim_id)
	REFERENCES Times (Tim_id),

	CONSTRAINT fk_voo_cid_ori
	FOREIGN KEY (Cod_ibge_ori)
	REFERENCES Cidade (Cod_ibge),

	CONSTRAINT fk_voo_cid_dest
	FOREIGN KEY (Cod_ibge_des)
	REFERENCES Cidade (Cod_ibge)		





	







