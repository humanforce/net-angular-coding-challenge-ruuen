namespace Infrastructure.MockData.Models;

// This model is used for System.Text.Json to parse input file schema
// I've consolidated 3 endpoint objs into one array within the data file, normally you'd make a separate GCal API call for each country
// These are later mapped into my domain entities.
public class MockPublicHolidayResponse
{
    public required string Summary { get; set; }
    public required Start Start { get; set; }
    public required End End { get; set; }
}

public class Start
{
    public DateTime Date { get; set; }
}

public class End
{
    public DateTime Date { get; set; }
}