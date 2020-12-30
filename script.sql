create table enderecos(
   endereco_id BIGINT NOT NULL AUTO_INCREMENT,
   cep VARCHAR(8) NOT NULL,
   bairro VARCHAR(20),
   cidade VARCHAR(20),
   end VARCHAR(100),
   uf VARCHAR(2),
   PRIMARY KEY ( endereco_id )
);

CREATE TABLE `users` (
  `user_id` bigint NOT NULL AUTO_INCREMENT,
  `endereco_id` BIGINT NOT NULL,
  `user_name` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `idade` int NOT NULL,
  `nome` varchar(20) NOT NULL,
  `sobrenome` varchar(20) NOT NULL,
  foreign key (endereco_id) references enderecos (endereco_id),
  PRIMARY KEY (`user_id`)
);