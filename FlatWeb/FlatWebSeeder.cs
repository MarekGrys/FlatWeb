using FlatWeb.Entities;

namespace FlatWeb
{
    public class FlatWebSeeder
    {
        private readonly FlatWebDbContext _dbContext;

        public FlatWebSeeder(FlatWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();

                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User
                {
                    Login = "PanMarcin123",
                    Password = "GdzieJestAPI123",
                    Name = "Pan",
                    Surname = "Marcin",
                    PhoneNumber = "123456789",
                    Email = "PanMarcin123@wpf.pl",
                    Flats = new List<Flat>()
                    {
                        new Flat
                        {
                            SquareMetrage = 40,
                            RoomQuantity = 2,
                            FloorNumber = 2,
                            Price = 1500.70m,
                            Description = "Mieszkanie w niższej cenie ale za to standardy jeszcze niższe",
                            WhenAdded = DateTime.Now,


                            Address = new Address()
                            {
                                City = "Gliwice",
                                Street = "Pana Marcina",
                                StreetNumber = 20,
                                FlatNumber = 8,
                                PostalCode = "44-100",
                            }

                        },
                        new Flat
                        {
                            SquareMetrage = 60,
                            RoomQuantity = 3,
                            FloorNumber = 1,
                            Price = 2060.57m,
                            Description = "Niby 3 pokoje, ale 2 z nich nie mają prądu",
                            WhenAdded = new DateTime(2023,12,23),
                            Address = new Address()
                            {
                                City = "Gliwice",
                                Street = "Pana Marcina",
                                StreetNumber = 20,
                                FlatNumber = 12,
                                PostalCode = "44-100",
                            }
                        },
                        new Flat
                        {
                            SquareMetrage = 38,
                            RoomQuantity = 2,
                            FloorNumber = 4,
                            Price = 1360.21m,
                            Description = "Bieda taka, że aż nie ma co piszczeć",
                            WhenAdded = new DateTime(2023,10,15),
                            Address = new Address()
                            {
                                City = "Gliwice",
                                Street = "Pana Marcina",
                                StreetNumber = 20,
                                FlatNumber = 23,
                                PostalCode = "44-100",
                            }
                        }
                    }

                },
                new User
                {
                    Login = "GrzegorzRozen1",
                    Password = "12344321",
                    Name = "Grzegorz",
                    Surname = "Rozen",
                    PhoneNumber = "098765432",
                    Email = "Grzegoroze@wpf.pl",
                    Flats = new List<Flat>()
                    {
                        new Flat
                        {
                            SquareMetrage = 52,
                            RoomQuantity = 3,
                            FloorNumber = 2,
                            Price = 1650.55m,
                            Description = "Taniej u nas to byłoby za darmo",
                            WhenAdded = new DateTime(2024,01,02),


                            Address = new Address()
                            {
                                City = "Gliwice",
                                Street = "Adwokatów Diabła",
                                StreetNumber = 66,
                                FlatNumber = 6,
                                PostalCode = "44-100",
                            }

                        },
                    }
                },
                new User
                {
                    Login = "Albertzweistein01",
                    Password = "432112346789",
                    Name = "Albert",
                    Surname = "Zweistein",
                    PhoneNumber = "192837465",
                    Email = "Zweibert@wpf.pl",
                },
                new User
                {
                    Login = "Niewiemcoto123",
                    Password = "9089786756",
                    Name = "Jan",
                    Surname = "Nowak",
                    PhoneNumber = "546372819",
                    Email = "Janowak123@wpf.pl",
                },
                new User
                {
                    Login = "Hubert1",
                    Password = "Hubertańczyk",
                    Name = "Hubert",
                    Surname = "Hubert",
                    PhoneNumber = "098712345",
                    Email = "Huberthubert@hubert.pl",

                }

            };
            return users;
            
        }
    }
}
