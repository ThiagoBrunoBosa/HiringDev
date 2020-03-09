using System.ComponentModel.DataAnnotations;

namespace BosaApi.Teste.Models
{
    public class YouTubeResponse
    {
        /// <summary>
        /// Código
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string SearchDsc { get; set; }
    }
}
