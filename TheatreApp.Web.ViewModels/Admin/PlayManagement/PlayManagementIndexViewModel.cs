namespace TheatreApp.Web.ViewModels.Admin.PlayManagement
{
    public class PlayManagementIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public int Duration { get; set; }
        public bool IsDeleted { get; set; }
    }
}
