namespace ParkingApplication
{
    internal class Car
    {
        public CarBrands Brand { get; set; }
        public string Model { get; set; }
        public Colours Color { get; set; }
        public string Number { get; set; }
        public Parking? Parking { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public Car(CarBrands carBrand, string model, Colours color, string number)
        {
            Brand = carBrand;
            Model = model;
            Color = color;
            Number = number;
        }
        public override string ToString()
        {
            return $"{Brand} {Model}, Color: {Color}, Number: {Number}";
        }
    }
}
