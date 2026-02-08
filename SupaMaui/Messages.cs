using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaMaui
{
    [Table("messages")]
    public class Messages : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }
        [Column("message")]
        public string Message { get; set; }
        [Column("sender_id")]
        public Guid SenderId { get; set; }
        [Column("recipient_id")]
        public Guid RecipientId { get; set; }
    }
}
