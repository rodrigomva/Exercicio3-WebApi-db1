using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Mvc.ViewModel
{
    public class VagaPesoViewModel
    {
        public int VagaPesoId { get; set; }
        public int VagaId { get; set; }
        public virtual VagaViewModel Vaga { get; set; }

        public int TecnologiaId { get; set; }
        public virtual TecnologiaViewModel Tecnologia { get; set; }

        [Range(typeof(decimal), "0", "100",ErrorMessage = "Peso deve ser entre 0 á 100")]
        public decimal Peso { get; set; }
    }
}