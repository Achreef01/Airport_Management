// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, 4ARCTIC!");
////Plane p1 = new Plane();
////p1.Capacity = 200;
////p1.ManufactureDate = new DateTime(2024, 01, 29);
////p1.PlaneType = PlaneType.Boing;
////p1.PlaneId = 1;
////Console.WriteLine(p1.ToString());

////Plane p2 = new Plane(PlaneType.Airbus, 300, new DateTime(2024, 01, 29));

////Console.WriteLine(p2.ToString());


//Plane p3 = new Plane
//{
//    Capacity=250,
//    ManufactureDate= new DateTime(2024, 01, 29),
//    PlaneType = PlaneType.Boing

//};
//Console.WriteLine(p3.ToString());

//Passenger pass1 = new Passenger
//{   FullName = new FullName
//        { 
//        FirstName = "nesrine",
//        LastName = "naouar"
//        },
//    EmailAddress = "nesrine.naouar@esprit.tn"

//};

//Console.WriteLine(pass1.CheckProfile("nesrine","naouar"));

//Console.WriteLine(pass1.CheckProfile("nesrine", "naouar", "nesrine.naouar@esprit.tn"));

//FlightMethods fm = new FlightMethods 
//{ 
//    Flights = TestData.listFlights 
//};

//Passenger pass2 = new Passenger 
//{
//    FullName = new FullName
//    {
//        FirstName = "nesrine",
//        LastName = "naouar"
//    },
//};
//Console.WriteLine("Before: " +pass2.ToString());
//pass2.UpperFullName();
//Console.WriteLine("After: " + pass2.ToString());

AMContext context = new AMContext();
//context.Planes.Add(TestData.BoingPlane);
//context.Flights.Add(TestData.flight2);
//context.SaveChanges();  

Console.WriteLine(context.Flights.First().MyPlane.Capacity);