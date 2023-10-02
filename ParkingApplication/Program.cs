namespace ParkingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car bmwX5 = new Car(CarBrands.BMW, "X5", Colours.Black, "AX7777КХ");
            Car opelAstra = new Car(CarBrands.Opel, "Astra", Colours.Red, "AX1234КХ");
            Parking SupermarketParking = new Parking(10, "Supermarket Parking");
            Parking justParking = new Parking(1, "Street parking");

            justParking.GetCar(bmwX5);
            justParking.GetCar(opelAstra);
            SupermarketParking.GetCar(bmwX5);

            SupermarketParking.GetCar(opelAstra);
            justParking.RemoveCar(bmwX5);
            Thread.Sleep(1000);
            SupermarketParking.GetCar(bmwX5);
            Console.WriteLine(SupermarketParking);
        }
    }
}