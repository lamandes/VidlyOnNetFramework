using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyOnNetFramework.Dtos
{
    public class MovieDto
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        //Foreign Key for Genre type
        public byte GenreTypeId { get; set; }
        //Nullable and only show store as YYYY-MM-DD
        
        public DateTime? ReleaseDate { get; set; }
        //Nullable and only show store as YYYY-MM-DD
       
        public int NumInStock { get; set; }
    }
}