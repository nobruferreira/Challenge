namespace Challenge.Domain.ValueObjects.MarvelApi.Character
{
    public class CharacterRootObject
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        public Data data { get; set; }
    }
}
