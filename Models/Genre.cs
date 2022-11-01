using System.Text.Json.Serialization;

namespace BookClub_app.Models
{


    [JsonConverter(typeof(JsonStringEnumConverter))]//to see the name of enum classes
    public enum Genre
    {
        Fantasy = 1,
        Horror = 2,
        Romance = 3,
        Thriller = 4,
        Classics = 5,
        Historical = 6,

        Selfhelp = 7,
    }
}