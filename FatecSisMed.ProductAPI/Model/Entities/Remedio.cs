﻿
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FatecSisMed.MedicoAPI.Model.Entities
{
    public class Remedio
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string Preco { get; set; }

        public Marca? Marca { get; set; }
        public int MarcaId { get; set; }
    }
}
