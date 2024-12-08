using Lesson_56_HT.Models;

namespace Lesson_56_HT.Repositories
{
    public class CityRepository
    {
        public List<City> CityList { get; set; }
        public CityRepository() { 
            CityList = new List<City>()
            {
                new City(1, "Dubai", 
                "Dubai’s unique blend of modern luxury, rich cultural heritage, and diverse attractions make it a top choice for travelers seeking a memorable and exciting trip. Whether you’re looking for adventure, relaxation, shopping, or cultural experiences, Dubai has something to offer everyone.",
                new()
                {
                    {"World-Class Entertainment and Leisure", "From desert safaris and dune bashing to indoor skiing and skydiving, Dubai offers a\r\n                                plethora of activities for thrill-seekers. The Dubai Fountain, with its choreographed\r\n                                water shows set to music, is a spectacle not to be missed. Dubai also hosts numerous\r\n                                events and festivals throughout the year, such as the Dubai Shopping Festival and the\r\n                                Dubai Food Festival, ensuring there’s always something exciting happening." },
                    {"Luxurious Shopping Experiences", "Dubai is a paradise for shoppers. The Dubai Mall, the largest shopping mall in the world, boasts over 1,200 shops, an indoor theme park, an ice rink, and even an aquarium. The Mall of the Emirates offers a unique shopping experience with its indoor ski resort, Ski Dubai. For a more traditional shopping experience, the Gold Souk and Spice Souk in Deira are must-visit destinations." },
                    {"Rich Cultural Heritage", "While Dubai is known for its modernity, it also has a rich cultural heritage. The Dubai\r\n                                Museum, housed in the Al Fahidi Fort, provides a glimpse into the city’s past. The Al\r\n                                Fahidi Historical Neighborhood offers a look at traditional Emirati architecture and\r\n                                culture. Visitors can also explore the Jumeirah Mosque, one of the few mosques in Dubai\r\n                                open to non-Muslim visitors, to learn about Islamic culture." }
                }
                )
            };
        }

        public City? GetCityById(int id)
        {
            return CityList.FirstOrDefault(c => c.ID == id);
        }
    }
}
