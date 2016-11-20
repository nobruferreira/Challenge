using System;
using System.Collections.Generic;
using System.Linq;
namespace Challenge.Domain.ValueObjects.MarvelApi.Character
{
    public class Comics
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public int returned { get; set; }
    }
}
