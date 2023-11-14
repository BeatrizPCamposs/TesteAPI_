-- Criando banco e colocando em uso
create database dbZooAPI;
use dbZooAPI;

-- Criação da tabela para tipos de animais
CREATE TABLE tbTipoAnimal (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL
);

-- Criação da tabela para animais
CREATE TABLE tbAnimal (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    tipo_id INT,
    FOREIGN KEY (tipo_id) REFERENCES tbTipoAnimal(id),
    descricao VARCHAR(100),
    habitat VARCHAR(100),
    pais VARCHAR(50),
    alimentacao VARCHAR(100),
    peso VARCHAR(20),
    altura VARCHAR(20),
    curiosidades TEXT,
    imagem VARCHAR(255)
);

-- Inserir um tipo de animal - tbTipoAnimal
INSERT INTO tbTipoAnimal (nome) VALUES ('mamífero');
INSERT INTO tbTipoAnimal (nome) VALUES ('Aves');

-- Inserir um animal - tbAnimal
INSERT INTO tbAnimal (nome, tipo_id, descricao, habitat, pais, alimentacao, peso, altura, curiosidades, imagem) 
VALUES (
    'Leão',
    1,
    'O leão é um grande felino conhecido por sua juba.',
    'Savanas da África',
    'África',
    'Carnívora',
    '150-250 kg',
    '1 à 5 metros',
    'Os leões vivem em grupos sociais chamados de matilhas.',
    'https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Lion_waiting_in_Namibia.jpg/420px-Lion_waiting_in_Namibia.jpg'
);

-- Exibindo tabelas
SELECT * FROM tbTipoAnimal;
SELECT * FROM tbAnimal;

-- Adicionando identificador para conexão
CREATE USER 'zoo'@'localhost' IDENTIFIED WITH mysql_native_password BY '12345678';
GRANT ALL PRIVILEGES ON dbzooapi.* TO 'zoo'@'localhost' WITH GRANT OPTION;

-- Excluir banco
-- drop database dbZooAPI;
