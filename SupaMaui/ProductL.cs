using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupaMaui
{

    public class ProductL
    {

        public int Id { get; set; }

        public DateTime Created_at { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public float Cost { get; set; }

        public int Count { get; set; }

        public string Img { get; set; }
    }
}
