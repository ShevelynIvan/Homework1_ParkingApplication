using System.Text;

namespace ParkingApplication
{
    internal class Parking
    {
        /// <summary>
        /// List of cars on park
        /// </summary>
        private List<Car> _cars = new List<Car>();
        private int _countOfSeats;
        
        /// <summary>
        /// Count of seats on park. Can't be less than 1
        /// </summary>
        public int CountOfSeats
        {
            get { return _countOfSeats; }
            set 
            {
                if (value < 1)
                    value = 1;

                _countOfSeats = value;
            }
        }
        
        /// <summary>
        /// Id of parking
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Name of parking
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adress of parking
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="countOfSeats">Count of seats. If less than 1 then the default value will be set to 1</param>
        /// <param name="name">Name of parking</param>
        /// <param name="address">Address of parking</param>
        public Parking(int countOfSeats, string name, string address)
        {
            Id = Guid.NewGuid();
            CountOfSeats = countOfSeats;
            Name = name;
            Address = address;
        }

        /// <summary>
        /// Add car to the parking lot
        /// </summary>
        /// <param name="car">Object of car</param>
        public void AcceptCar(Car car)
        {
            if (_countOfSeats == _cars.Count)
            {
                Console.WriteLine("Error! All parking spaces are occupied");
                return;
            }

            if (car.Parking != null)
            {
                Console.WriteLine($"Error! {car.Brand} {car.Model} already is on park '{car.Parking.Name}'");
                return;
            }

            _cars.Add(car);
            car.Parking = this;
            car.ArrivalTime = DateTime.Now;
            car.DepartureTime = default;
            Console.WriteLine($"The car {car.Brand} {car.Model} was parked successfully!");
        }
        
        /// <summary>
        /// Remove car from the parking lot
        /// </summary>
        /// <param name="id">Id of car that you want to remove</param>
        public void RemoveCar(Guid id)
        {
            Car? car = _cars.Find(x => x.Id.Equals(id));
            if (car == null)
            {
                Console.WriteLine("Error! There is no such car in the parking lot");
                return;
            }

            _cars.Remove(car);
            car.Parking = null;
            car.DepartureTime = DateTime.Now;
            Console.WriteLine($"The car {car.Brand} {car.Model} was successfully driven away!");
        }

        /// <summary>
        /// Shows free places on park
        /// </summary>
        public void ShowFreePlacesOnPark()
        {
            int countOfOccupiedPlaces = _cars.Count;
            int countOfFreePlaces = _countOfSeats - countOfOccupiedPlaces;
            Console.WriteLine($"There are {countOfFreePlaces} free spaces in the '{Name}' parking lot");
        }

        /// <summary>
        /// Shows information about park, count of free and occupied places, cars on park.
        /// </summary>
        /// <returns>Return string message</returns>
        public string GetStateMessage()
        {
            int countOfOccupiedPlaces = _cars.Count;
            int countOfFreePlaces = _countOfSeats - countOfOccupiedPlaces;
            StringBuilder sb = new StringBuilder(
                $"\nName of park: {Name}\n" +
                $"Count of all seats: {_countOfSeats}\n" +
                $"Count of occupied seats: {countOfOccupiedPlaces}\n" +
                $"Count of free seats: {countOfFreePlaces}\n" +
                $"Cars on park:");
            if (countOfOccupiedPlaces == 0)
            {
                sb.Append(" 0");
            }
            else
            {
                sb.AppendLine();
                foreach (Car car in _cars)
                {
                    sb.Append($"{car.ToString()}");
                    sb.AppendLine($" Arrival time: {car.ArrivalTime}");
                }
            }
            return sb.ToString();
        }
    }
}
