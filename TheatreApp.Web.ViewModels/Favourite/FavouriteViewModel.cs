namespace TheatreApp.Web.ViewModels.Favourite
{
    public class FavouriteViewModel
    {
        public string PlayId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
