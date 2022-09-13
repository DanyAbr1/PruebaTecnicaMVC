using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMVC.Models
{
    public class Persona
    {
        // Máximo de 20 caracteres
        public int Id { get; set; }
        [MaxLength(20,ErrorMessage ="El campo {0}, no puede agregar mas de {1} caracteres")]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Sexo { get; set; }
        public string Email { get; set; }
    }
}
