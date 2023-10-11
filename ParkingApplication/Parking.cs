using System.Text;

namespace ParkingApplication
{
    internal class Parking : IDisposable
    {
        /// <summary>
        /// List of cars on park
        /// </summary>
        private List<Car> _cars = new List<Car>();
        private int _countOfSeats;
        
        /// <summary>
        /// Count of seats on park. Can't be less than 1 and less than count of cars on park already
        /// </summary>
        public int CountOfSeats
        {
            get { return _countOfSeats; }
            set 
            {
                if (value < 1)
                    value = 1;

                if(_cars.Count() > value)
                    value = _cars.Count;

                _countOfSeats = value;
            }
        }
        
        /// <summary>
        /// Id of parking
        /// </summary>
        public Guid Id { get; private set; }

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
        /// Constructor with parameters. Name set to default.
        /// </summary>
        /// <param name="countOfSeats">Count of seats. If less than 1 then the default value will be set to 1</param>
        /// <param name="address">Address of parking</param>
        public Parking(int countOfSeats, string address)
        {
            Id = Guid.NewGuid();
            CountOfSeats = countOfSeats;
            Name = "unknown";
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
        /// Add list of car to parking lot
        /// </summary>
        /// <param name="cars">List of car that you want to add in park</param>
        /// <remarks>Add cars only if parking has enough places. 
        /// If car from list has been parked before, this car are just being skipped.</remarks>
        public void AcceptCar(IEnumerable<Car> cars)
        {
            if (_cars.Count + cars.Count() > _countOfSeats)
            {
                Console.WriteLine("Error! Not enough places to park all cars.");
                return;
            }

            foreach (Car car in cars)
            {
                if (car == null)
                    continue;

                if (car.Parking != null)
                {
                    Console.WriteLine($"Error! {car.Brand} {car.Model} already is on park '{car.Parking.Name}'");
                    continue;
                }

                _cars.Add(car);
                car.Parking = this;
                car.ArrivalTime = DateTime.Now;
                car.DepartureTime = default;
                Console.WriteLine($"The car {car.Brand} {car.Model} was parked successfully!");
            }
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
        /// Remove list of cars from the parking lot
        /// </summary>
        /// <param name="cars">List of car that you want to remove from park</param>\
        /// <remarks>If a car from the list isn't in the park, it's being skipped.</remarks>
        public void RemoveCar(IEnumerable<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (car == null)
                    continue;

                Car? carToDelete = _cars.Find(x => x.Id.Equals(car.Id));
                if (carToDelete == null)
                {
                    Console.WriteLine($"Error! There is no {car.Brand} {car.Model} in the parking lot");
                    continue;
                }

                _cars.Remove(carToDelete);
                carToDelete.Parking = null;
                carToDelete.DepartureTime = DateTime.Now;
                Console.WriteLine($"The car {carToDelete.Brand} {carToDelete.Model} was successfully driven away!");
            }
        }

        /// <summary>
        /// Shows free places on park
        /// </summary>
        public void ShowFreePlacesOnPark()
        {
            Console.WriteLine($"There are {GetFreePlaces()} free spaces in the '{Name}' parking lot");
        }

        /// <summary>
        /// Shows information about park, count of free and occupied places, cars on park.
        /// </summary>
        /// <returns>Return string message</returns>
        public string GetStateMessage()
        {
            StringBuilder sb = new StringBuilder(
                $"\nName of park: {Name}\n" +
                $"Count of all seats: {_countOfSeats}\n" +
                $"Count of occupied seats: {_cars.Count}\n" +
                $"Count of free seats: {GetFreePlaces()}\n" +
                $"Cars on park:");
            if (_cars.Count == 0)
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

        /// <summary>
        /// Helper method for calculation free places in park
        /// </summary>
        /// <returns>Returns count of free places</returns>
        private int GetFreePlaces() => _countOfSeats - _cars.Count;
        
        /// <summary>
        /// Disposing method
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine($"Parking '{this.Name}', {this.Address}, are closing. All cars will be driven away");
            foreach (Car car in _cars.ToList())
            {
                _cars.Remove(car);
                car.Parking = null;
                car.DepartureTime = DateTime.Now;
                Console.WriteLine($"The car {car.Brand} {car.Model} was successfully driven away!");
            }
            _cars.Clear();
            Console.WriteLine($"Parking '{this.Name}', {this.Address}, are closed. All cars was driven away\n");
        }
    }
}
