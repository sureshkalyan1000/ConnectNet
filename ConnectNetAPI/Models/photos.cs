using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectNet.Models
{
    [Table("photo")]
    public class photos
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int PublicId { get; set; }

        //Navigation property
        public int AppUserId { get; set; }
        public AppUser appuser { get; set; }

    }
}
