namespace MovieApp.DataLayer.Models
{
    public class MovieDetails
    {
        public string tconst { get; set; }
        public string primarytitle { get; set; }
        public string originaltitle { get; set; }
        public bool isadult { get; set; }
        public string? startyear { get; set; }
        public string? endyear { get; set; }
        public int? runtimeminutes { get; set; }
        public string? genres { get; set; }
    }
}
