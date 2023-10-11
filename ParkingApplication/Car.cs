using System.Drawing;

namespace ParkingApplication
{
    internal class Car
    {
        /// <summary>
        /// Color of car. The appropriate method is used to change
        /// </summary>
        private Color _color;

        /// <summary>
        /// Property Id of car 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Brand of car
        /// </summary>
        public CarBrands Brand { get; set; }

        /// <summary>
        /// Model of car
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Number of car
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Displays the parking lot where the car is parked. Null if not found anywhere
        /// </summary>
        public Parking? Parking { get; set; }

        /// <summary>
        /// Arrival time to the parking lot. Default value if not on parking. 
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Departure time from parking lot. Default value if hasn't left the parking lot yet.
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Constructor with full parameters 
        /// </summary>
        /// <param name="carBrand">Brand of car</param>
        /// <param name="model">Model of car</param>
        /// <param name="color">Object of color for car</param>
        /// <param name="number">Number of car</param>
        public Car(CarBrands carBrand, string model, Color color, string number)
        {
            Id = Guid.NewGuid();
            Brand = carBrand;
            Model = model;
            _color = color;
            Number = number;
        }

        /// <summary>
        /// Constructor with parameters. Color set to white.
        /// </summary>
        /// <param name="carBrand">Brand of car</param>
        /// <param name="model">Model of car</param>
        /// <param name="number">Number of car</param>
        public Car(CarBrands carBrand, string model, string number)
        {
            Id = Guid.NewGuid();
            _color = new Color();
            Brand = carBrand;
            Model = model;
            Number = number;
        }

        /// <summary>
        /// Method to change color of car
        /// </summary>
        /// <param name="newColor">Object of new color</param>
        public void ChangeColor(Color newColor)
        {
            _color = newColor;
        }

        /// <summary>
        /// Method to change color of car
        /// </summary>
        /// <param name="red">Part of red</param>
        /// <param name="green">Part of green</param>
        /// <param name="blue">Part of blue</param>
        /// <param name="opacity">Opacity of all color</param>
        public void ChangeColor(int red, int green, int blue, int opacity)
        {
            _color.Red = red;
            _color.Green = green;
            _color.Blue = blue;
            _color.Opacity = opacity;
        }

        /// <summary>
        /// Overridden ToString method 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Brand} {Model}, Number: {Number} Color: {_color.ToString()}.";
        }
    }
}
