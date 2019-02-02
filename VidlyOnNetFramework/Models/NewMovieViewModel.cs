using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VidlyOnNetFramework.Models
{
    public class NewMovieViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        //Foreign Key for Genre type
        [Display(Name = "Genre")]
        public byte GenreTypeId { get; set; }

        //Nullable and only show store as YYYY-MM-DD
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(0, 100)]
        public int NumInStock { get; set; }


        //Constructor
        public NewMovieViewModel(IEnumerable<GenreType> genreTypes)
        {
            this.ID = 0;
            this.GenreTypes = genreTypes;
        }

        public NewMovieViewModel(Movie movie, IEnumerable<GenreType> genreTypes)
        {
            this.ID = movie.ID;
            this.Name = movie.Name;
            this.GenreTypes = genreTypes;
            this.GenreTypeId = movie.GenreTypeId;
            this.ReleaseDate = movie.ReleaseDate;
            this.NumInStock = movie.NumInStock;
        }
    }
}