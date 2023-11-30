using System;
using System.Reflection;
class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Add more properties as needed
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    // Add more properties as needed
}

class Program
{
    static void MapProperties(Source source, Destination destination)
    {
         

        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] destProperties = typeof(Destination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destinationPropertty in destProperties)

              if ( sourceProperty.Name == destinationPropertty.Name && sourceProperty.PropertyType == destinationPropertty.PropertyType)
              {
                    destinationPropertty.SetValue(destination, sourceProperty.GetValue(source));
                    break;
              }
        }
    }

    static void Main()
    {
        Source source = new Source { Id = 1, Name = "SourceName" };
        Destination destination = new Destination { Id = 0, Name = "", Description = "" };

        MapProperties(source, destination);

        // Displaying values in the Destination class
        Console.WriteLine("Mapped Properties in Destination:");
        Console.WriteLine($"Id: {destination.Id}");
        Console.WriteLine($"Name: {destination.Name}");
        Console.WriteLine($"Description: {destination.Description}");
        Console.ReadKey();


    }
}




