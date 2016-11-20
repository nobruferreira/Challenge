using Challenge.Domain.ValueObjects.MarvelApi.Character;
using System.Collections.Generic;

namespace Challenge.Domain.ValueObjects.MarvelApi
{
    public class Data
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public List<Result> results { get; set; }
    }
}
