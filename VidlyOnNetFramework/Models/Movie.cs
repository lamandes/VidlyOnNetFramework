using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VidlyOnNetFramework.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GenreType GenreType { get; set; }
        //Foreign Key for Genre type
        public byte GenreTypeId { get; set; }
        //Nullable and only show store as YYYY-MM-DD
        [Column(TypeName="Date")]
        public DateTime? ReleaseDate  { get; set; }
        //Nullable and only show store as YYYY-MM-DD
        [Column(TypeName = "Date")]
        public DateTime? DateAdded { get; set; }
        public int NumInStock { get; set; }
    }
}