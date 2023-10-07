namespace ParkingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car bmwX5 = new Car(CarBrands.BMW, "X5", new Color(), "AX7777КХ");
      
            bmwX5.ChangeColor(256,-1,100,99);

            Car opelAstra = new Car(CarBrands.Opel, "Astra", new Color(55, 150, 300, 5), "AX1234КХ");

            Parking supermarketParking = new Parking(10, "Supermarket Parking","vul. Oksany Petrysenko 30");
            Parking justParking = new Parking(-10, "Street parking", "vul. Ivana Franka 4");

            justParking.AcceptCar(bmwX5);

            justParking.ShowFreePlacesOnPark();
           
            justParking.AcceptCar(opelAstra);
            
            Console.WriteLine(justParking.GetStateMessage());
            
            supermarketParking.AcceptCar(bmwX5);
            
            supermarketParking.AcceptCar(opelAstra);
            justParking.RemoveCar(bmwX5.Id);
            Thread.Sleep(1000);
            supermarketParking.AcceptCar(bmwX5);

            Console.WriteLine(justParking.GetStateMessage());
            Console.WriteLine(supermarketParking.GetStateMessage());
        }
    }
}