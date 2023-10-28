﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAPI.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public string Descricao { get; set; }
        public string Habitat { get; set; }
        public string Pais { get; set; }
        public string Alimentacao { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string Curiosidades { get; set; }
        public string Imagem { get; set; }
    }
}