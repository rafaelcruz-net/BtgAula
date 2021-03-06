﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Dominio
{
    public class Cliente : IEntity
    {
        public Int32 Id { get; set; }
        
        public string Nome { get; set; }

        public String CPF { get; set; }

        public String Agencia { get; set; }

        public String Conta { get; set; }

        public String Estado { get; set; }
    }
}