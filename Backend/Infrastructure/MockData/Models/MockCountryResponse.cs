using System.Text.Json.Serialization;

namespace Infrastructure.MockData.Models;

// This model is used for System.Text.Json to parse input file schema
// I've consolidated 3 endpoint objs into one array within the data file, normally you'd make a separate GCal API call for each country
// These are later mapped into my domain entities.
public class MockCountryResponse
{
    public required string Summary { get; set; }
    public required List<MockPublicHolidayResponse> Items { get; set; }
}