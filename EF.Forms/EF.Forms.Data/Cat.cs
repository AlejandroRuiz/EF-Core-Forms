using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EF.Forms.Data
{
	public class Cat
    {
        [Key]
        public int CatId { get; set; }

        public string Name { get; set; }

        public int MeowsPerSecond { get; set; }
    }
}
