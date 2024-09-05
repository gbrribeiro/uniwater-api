using System.ComponentModel.DataAnnotations.Schema;

namespace UniWater_API.Models
{
    public class Recording
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; } = "";
        public string Operation { get; set; } = "";
        public DateTime OperationDate { get; set; }

    }
}
