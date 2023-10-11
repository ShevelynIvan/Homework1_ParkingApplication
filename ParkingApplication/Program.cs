namespace ParkingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Car bmwX1 = new Car(CarBrands.BMW, "X1", new Color(), "AX1111КХ");
            Car bmwX2 = new Car(CarBrands.BMW, "X2", new Color(), "AX2222КХ");
            Car bmwX3 = new Car(CarBrands.BMW, "X3", new Color(), "AX3333КХ");
            Car bmwX4 = new Car(CarBrands.BMW, "X4", new Color(), "AX4444КХ");
            Car bmwX5 = new Car(CarBrands.BMW, "X5", new Color(), "AX5555КХ");
            cars.Add(bmwX1);
            cars.Add(bmwX2);
            cars.Add(bmwX3);
            cars.Add(bmwX4);
            cars.Add(bmwX5);
            
            bmwX5.ChangeColor(256,-1,100,124);

            Car opelAstra = new Car(CarBrands.Opel, "Astra", new Color(55, 150, 300, 5), "AX1234КХ");
            Car hyundaiI30 = new Car(CarBrands.Hyundai, "i30", new Color(), "AX8888КХ");

            using (Parking supermarketParking = new Parking(10, "Supermarket Parking", "vul. Oksany Petrysenko 30"))
            {
                supermarketParking.AcceptCar(bmwX1);
                supermarketParking.AcceptCar(cars);
                Console.WriteLine(supermarketParking.GetStateMessage());
                Thread.Sleep(1000);
                
                supermarketParking.CountOfSeats = 1;
                Console.WriteLine(supermarketParking.GetStateMessage());
                
                supermarketParking.RemoveCar(cars);
                supermarketParking.AcceptCar(opelAstra);
                supermarketParking.AcceptCar(hyundaiI30);
                Console.WriteLine(supermarketParking.GetStateMessage());
            }

            using (Parking justParking = new Parking(-10, "Street parking", "vul. Ivana Franka 4"))
            {
                justParking.AcceptCar(bmwX5);
            }
        }
    }
}