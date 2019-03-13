using MoviesSite.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSite.App.ViewModels
{
    /*
     * a "view model" is a type of model in the MVC pattern
     * that is tightly bound to a particular view
     * 
     * basically when the (business logic) models that we have in our application
     * don't match exactly what the view needs in order to have its data,
     * then we make a new class meant for that view to use.
     * 
     * often, with layered architecture (multiple projects with separated concerns)
     * the MVC layer is not really using our business logic classes and definitely not
     * our EF entity classes. instead it's using view models to be each view's model.
     */
    public class MovieViewModel
    {
        public int Id { get; set; }

        /*
         * we use attributes from DataAnnotations library to tell MVC
         * what things to check for automatic client-side validation
         * (using jQuery Unobtrusive JS library, behind the scenes)
         * and server-side validation (using ModelState)
         */

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required] // now default value (1/1/1 won't be accepted)
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public List<Genre> Genres { get; set; }

        // here we can provide other info the view may need
        //public string LoggedInUser { get; set; }
    }
}
