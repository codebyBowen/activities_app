using System;

namespace Domain;
// table in DB
public class Activity
{
    // called Id so its primary key, otherwise you need to define a Pkey called [key]. 
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime Date { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }

    // location props

    public required string City {get; set;}
    public required string Venue {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}


}
