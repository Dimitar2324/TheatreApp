namespace TheatreApp.Web.ViewModels.Play
{
    public class PlayDetailsViewModel
    {
        public string Id { get; set; } = null!; 
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string ScreenWriter { get; set; } = null!;
        public int Duration { get; set; }
        public string ReleaseDate { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
