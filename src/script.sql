create table Users(
   id BIGINT NOT NULL AUTO_INCREMENT,
   user_name VARCHAR(20) NOT NULL,
   password VARCHAR(20) NOT NULL,
   idade INT NOT NULL,
   nome VARCHAR(20) NOT NULL,
   sobrenome VARCHAR(20) NOT NULL,
   PRIMARY KEY ( id )
);