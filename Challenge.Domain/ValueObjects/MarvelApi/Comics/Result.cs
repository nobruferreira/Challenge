namespace Challenge.Domain.ValueObjects.MarvelApi.Comics
{
    public class Result
    {
        public int id { get; set; }
        public string title { get; set; }
        public int issueNumber { get; set; }
        public string description { get; set; }
        public Thumbnail thumbnail { get; set; }
    }
}