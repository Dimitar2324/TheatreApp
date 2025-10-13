namespace TheatreApp.Web.ViewModels.Play
{
    public class AllPlaysIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
