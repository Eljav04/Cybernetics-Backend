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
                "Dubai’s unique blend of modern luxury, rich cultural heritage, and diverse attractions make it a top choice for travelers seeking a memorable and exciting trip.",
                new()
                {
                    {"World-Class Entertainment and Leisure", "From desert safaris and dune bashing to indoor skiing and skydiving, Dubai offers a\r\n                                plethora of activities for thrill-seekers. The Dubai Fountain, with its choreographed\r\n                                water shows set to music, is a spectacle not to be missed." },
                    {"Luxurious Shopping Experiences", "Dubai is a paradise for shoppers. The Dubai Mall, the largest shopping mall in the world, boasts over 1,200 shops, an indoor theme park, an ice rink, and even an aquarium. The Mall of the Emirates offers a unique shopping experience with its indoor ski resort, Ski Dubai. For a more traditional shopping experience, the Gold Souk and Spice Souk in Deira are must-visit destinations." },
                    {"Rich Cultural Heritage", "While Dubai is known for its modernity, it also has a rich cultural heritage. The Dubai\r\n                                Museum, housed in the Al Fahidi Fort, provides a glimpse into the city’s past. The Al\r\n                                Fahidi Historical Neighborhood offers a look at traditional Emirati architecture and\r\n                                culture. Visitors can also explore the Jumeirah Mosque, one of the few mosques in Dubai\r\n                                open to non-Muslim visitors, to learn about Islamic culture." }
                }
                ),
                new City(2, "Berlin",
                "Berlin, the capital of Germany, is a vibrant city known for its historical landmarks, modern culture, and artistic flair. With a unique mix of past and present, Berlin offers visitors a fascinating experience.",
                new()
                {
                    {"Historical Landmarks", "Berlin is home to iconic historical sites like the Brandenburg Gate, the Berlin Wall, and Checkpoint Charlie. Visitors can explore the remnants of the Berlin Wall at the East Side Gallery or visit the Reichstag building for a glimpse into Germany’s political history."},
                    {"Dynamic Arts and Culture Scene", "Berlin boasts a thriving arts scene, with numerous galleries, museums, and theaters. The Museum Island, a UNESCO World Heritage Site, is a must-visit for art and history enthusiasts. The city’s vibrant nightlife and music festivals add to its cultural allure."},
                    {"Green Spaces and Recreation", "Despite its urban landscape, Berlin offers plenty of green spaces. Tiergarten Park and Tempelhofer Feld are popular spots for picnics, cycling, and relaxation. The city’s canals and lakes provide opportunities for boating and other water activities."}
                }
                ),

                new City(3, "Paris",
                "Paris, the City of Light, is renowned for its romance, elegance, and timeless beauty. It’s a global hub for art, fashion, gastronomy, and culture.",
                new()
                {
                    {"Iconic Landmarks", "Paris is home to world-famous landmarks such as the Eiffel Tower, Notre-Dame Cathedral, and the Louvre Museum. Visitors can enjoy breathtaking views of the city from Montmartre or a serene cruise along the Seine River."},
                    {"Gastronomy and Café Culture", "Paris offers a culinary paradise with its patisseries, bistros, and Michelin-starred restaurants. Don’t miss the chance to enjoy a classic croissant or a glass of wine at a charming Parisian café."},
                    {"Art and Fashion", "The city is a haven for art lovers, with iconic museums like the Louvre and the Musée d'Orsay. Paris is also a global fashion capital, hosting events like Paris Fashion Week and offering high-end shopping along the Champs-Élysées."}
                }
                ),

                new City(4, "Mexico City",
                "Mexico City, the vibrant capital of Mexico, blends rich history, colorful traditions, and a lively contemporary culture. It’s a city full of surprises and charm.",
                new()
                {
                    {"Historical and Cultural Sites", "Mexico City is rich in history, with landmarks like the ancient ruins of Teotihuacan and the historic center’s Zócalo Square. The National Museum of Anthropology offers fascinating insights into Mexico’s heritage."},
                    {"Gastronomic Delights", "The city is a food lover’s paradise, offering everything from street tacos to gourmet cuisine. Don’t miss the chance to try authentic dishes like tamales, mole, and churros."},
                    {"Vibrant Arts and Festivals", "Mexico City is a hub for art and culture, with world-class museums like the Frida Kahlo Museum and the Palacio de Bellas Artes. The city’s festivals, such as Day of the Dead celebrations, are a unique and unforgettable experience."}
                }
                ),

                new City(5, "New Delhi",
                "New Delhi, the capital of India, is a bustling metropolis that seamlessly blends ancient history with modern living. It’s a city full of contrasts and endless exploration opportunities.",
                new()
                {
                    {"Historical Monuments", "New Delhi is home to iconic landmarks like the Red Fort, Humayun’s Tomb, and India Gate. Visitors can explore the historic Qutub Minar complex or stroll through the serene Lodhi Gardens."},
                    {"Cultural Diversity", "The city’s vibrant culture is evident in its diverse festivals, markets, and cuisine. Chandni Chowk, one of the oldest markets, offers a sensory overload of sights, sounds, and flavors."},
                    {"Modern Attractions", "New Delhi also boasts modern attractions like the Lotus Temple and Akshardham Temple. The city’s thriving art scene and bustling nightlife make it a dynamic destination."}
                }
                ),

                new City(6, "Madrid",
                "Madrid, the capital of Spain, is a city known for its vibrant energy, artistic treasures, and lively atmosphere. It’s a destination that combines tradition with modernity.",
                new()
                {
                    {"World-Class Museums", "Madrid is home to the Golden Triangle of Art, which includes the Prado Museum, Reina Sofia Museum, and Thyssen-Bornemisza Museum. These institutions house masterpieces by artists like Velázquez, Goya, and Picasso."},
                    {"Lively Streets and Squares", "The city’s bustling squares, such as Puerta del Sol and Plaza Mayor, are perfect for soaking in the vibrant atmosphere. Visitors can also enjoy the lively markets like Mercado de San Miguel."},
                    {"Culinary Excellence", "Madrid’s culinary scene offers everything from traditional tapas to modern gastronomy. Don’t miss trying local specialties like churros with chocolate or a classic Spanish omelette."}
                }
                ),

                new City(7, "New York",
                "New York City, the Big Apple, is a global hub for culture, business, and entertainment. It’s a city that never sleeps and offers something for everyone.",
                new()
                {
                    {"Iconic Landmarks", "New York City is famous for landmarks like the Statue of Liberty, Times Square, and Central Park. Visitors can also enjoy breathtaking views from the Empire State Building or One World Observatory."},
                    {"Cultural Melting Pot", "The city’s cultural diversity is reflected in its neighborhoods, such as Chinatown, Little Italy, and Harlem. Visitors can explore world-class museums like the Metropolitan Museum of Art and the Museum of Modern Art (MoMA)."},
                    {"Broadway and Nightlife", "New York’s entertainment scene is unparalleled, with Broadway shows, live music venues, and trendy bars. The city’s nightlife ensures there’s always something happening."}
                }
                ),

                new City(8, "Thailand",
                "Thailand is a tropical paradise known for its stunning beaches, vibrant culture, and warm hospitality. It’s a dream destination for travelers seeking beauty and adventure.",
                new()
                {
                    {"Pristine Beaches", "Thailand offers idyllic beaches like Phuket, Krabi, and Koh Samui, where visitors can enjoy crystal-clear waters and vibrant coral reefs. These destinations are perfect for snorkeling, diving, and relaxing."},
                    {"Rich Culture and History", "The country’s cultural heritage is evident in its ornate temples, such as Wat Arun and Wat Phra Kaew. Visitors can also explore ancient ruins in Ayutthaya and Sukhothai."},
                    {"Exotic Cuisine", "Thai food is renowned worldwide for its flavors. From street food to fine dining, dishes like pad Thai, green curry, and mango sticky rice are must-tries."}
                }
                ),

                new City(9, "Bali",
                "Bali, known as the Island of the Gods, is a tropical haven with stunning natural beauty, spiritual culture, and world-class hospitality. It’s a perfect escape for relaxation and adventure.",
                new()
                {
                    {"Breathtaking Landscapes", "Bali is famous for its lush rice terraces, volcanic mountains, and pristine beaches. Visitors can explore the Tegallalang Rice Terraces or hike up Mount Batur for a spectacular sunrise."},
                    {"Spiritual Experiences", "The island’s spiritual charm is evident in its temples, such as Uluwatu Temple and Tanah Lot. Visitors can also participate in traditional Balinese ceremonies and yoga retreats."},
                    {"Adventure and Relaxation", "Bali offers a mix of thrilling activities like surfing, diving, and jungle trekking. For relaxation, visitors can enjoy world-class spas, beach resorts, and tranquil settings."}
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
