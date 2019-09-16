using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ddd.DotNet.MvcWebApi.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF/CNPJ")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo 11 caracteres")]
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistryDate { get; set; }
    }
}