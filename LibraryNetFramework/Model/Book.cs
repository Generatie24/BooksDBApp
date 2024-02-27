using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNetFramework.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Describe { get; set; }
        public int CountryId { get; set; }

        public override string ToString()
        {
            return $"{Title} {Author} {Price} {CountryId}";
        }
    }
}
