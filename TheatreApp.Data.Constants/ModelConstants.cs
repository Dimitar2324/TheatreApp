namespace TheatreApp.Data.Constants
{
    public static class ModelConstants
    {
        public static class PlayConstants
        {
            public const int TitleMaxLength = 100;
            public const int TitleMinLength = 3;
            public const int AuthorNameMaxLength = 800;
            public const int AuthorNameMinLength = 5;
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 10;
            public const int GenreNameMaxLength = 50;
            public const int GenreNameMinLength = 5;
            public const int DurationMaxLength = 500;
            public const int DurationMinLength = 1;
            public const int DirectorNameMaxLength = 800;
            public const int DirectorNameMinLength = 5;
            public const int ScreenWriterNameMaxLength = 800;
            public const int ScreenWriterNameMinLength = 5;
            public const int ImageUrlMaxLength = 2048;
        }

        public static class PerformanceConstants
        {
            public const int HallNameMaxLength = 100;
            public const int AvailableSeatsCountDefaultValue = 0;
        }
    }
}
