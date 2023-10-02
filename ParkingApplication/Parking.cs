using System.Text;

namespace ParkingApplication
{
    internal class Parking
    {
        private List<Car> _cars = new List<Car>();
        private int _countOfSeats;
        private string _name;
        public Parking(int countOfSeats, string name)
        {
            _countOfSeats = countOfSeats;
            _name = name;
        }
        public void GetCar(Car car)
        {
            if (_countOfSeats == _cars.Count)
            {
                Console.WriteLine("Error! All parking spaces are occupied");
                return;
            }

            if (car.Parking != null) 
            {
                Console.WriteLine("Error! Car already is on park");
                return;
            }

            _cars.Add(car);
            car.Parking = this;
            car.ArrivalTime = DateTime.Now;
            car.DepartureTime = default;
            Console.WriteLine("The car was parked successfully!");
        }
        public void RemoveCar(Car car)
        {
            if (car.Parking != this)
            {
                Console.WriteLine("Error! There is no such car in the parking lot");
                return;
            }
            _cars.Remove(car);
            car.Parking = null;
            car.DepartureTime = DateTime.Now;
            Console.WriteLine("The car was successfully driven away!");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Name of park: {_name}, Count of seats: {_countOfSeats}\nCars on park:\n");
            foreach (Car car in _cars)
            {
                sb.Append(car.ToString());
                sb.AppendLine($" Arrival time: {car.ArrivalTime}");
            }
            return sb.ToString();
        }
    }
}
