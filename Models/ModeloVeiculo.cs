﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    public class ModeloVeiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [RegularExpression(@"^(?![-.0-9]+$)[A-Za-z0-9\s.-]+$",
            ErrorMessage = "O nome do modelo não pode conter apenas números, pontos e hífens")]
        [Required(ErrorMessage = "Insira o modelo do veículo")]
        [StringLength(100, ErrorMessage = "O nome do modelo não pode exceder 100 caracteres.")]
        public string NomeModelo { get; set; }

        [Required(ErrorMessage = "Insira a marca do veículo")]
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

    }
}
