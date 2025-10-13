using System.ComponentModel.DataAnnotations;

using static TheatreApp.Data.Constants.ModelConstants;

namespace TheatreApp.Web.ViewModels.Play
{
    public class PlayEditFormModel
    {
        public string Id { get; set; } = String.Empty;


        [Required(ErrorMessage = "Play title field is required!")]
        [MaxLength(PlayConstants.TitleMaxLength, ErrorMessage = "Title length must be at most 100 characters long!")]
        [MinLength(PlayConstants.TitleMinLength, ErrorMessage = "Title length must be minimum 3 characters!")]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = "Play author is required!")]
        [MaxLength(PlayConstants.AuthorNameMaxLength, ErrorMessage = "Author name must be at most 800 characters long!")]
        [MinLength(PlayConstants.AuthorNameMinLength, ErrorMessage = "Author name must be minimum 5 characters long!")]
        public string Author { get; set; } = null!;


        [Required(ErrorMessage = "Description is required!")]
        [MaxLength(PlayConstants.DescriptionMaxLength, ErrorMessage = "Description must be at most 1000 characters long!")]
        [MinLength(PlayConstants.DescriptionMinLength, ErrorMessage = "Description must be minimum 10 characters!")]
        public string Description { get; set; } = null!;


        [Required(ErrorMessage = "Play genre is required!")]
        [MaxLength(PlayConstants.GenreNameMaxLength, ErrorMessage = "Genre must be at most 50 characters long!")]
        [MinLength(PlayConstants.GenreNameMinLength, ErrorMessage = "Genre must be minimum 5 characters!")]
        public string Genre { get; set; } = null!;


        [Required(ErrorMessage = "Director name is required!")]
        [MaxLength(PlayConstants.DirectorNameMaxLength, ErrorMessage = "Director name must be at most 800 characters long!")]
        [MinLength(PlayConstants.DirectorNameMinLength, ErrorMessage = "Director name must be minimum 5 characters!")]
        public string Director { get; set; } = null!;


        [Required(ErrorMessage = "ScreeWriter is requiered!")]
        [MaxLength(PlayConstants.ScreenWriterNameMaxLength, ErrorMessage = "ScreenWriter name must be at most 800 characters long!")]
        [MinLength(PlayConstants.ScreenWriterNameMinLength, ErrorMessage = "ScreenWriter name must be minimum 5 characters!")]
        public string ScreenWriter { get; set; } = null!;


        [Required(ErrorMessage = "Duration is required!")]
        [Range(PlayConstants.DurationMinLength, PlayConstants.DurationMaxLength, ErrorMessage = "Duration must be between 1 and 500 minutes!")]
        public int Duration { get; set; }


        [Required(ErrorMessage = "Release date is required!")]
        public string ReleaseDate { get; set; } = null!;


        [MaxLength(PlayConstants.ImageUrlMaxLength, ErrorMessage = "ImageUrl must be at most 2048 characters long!")]
        public string? ImageUrl { get; set; }
    }
}
