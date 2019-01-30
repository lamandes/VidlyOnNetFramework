using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyOnNetFramework.Models
{
    public class GenreType
    {
        //Unique Id for each genre 0-255
        public byte Id { get; set; }
        public string TypeName { get; set; }
    }
}