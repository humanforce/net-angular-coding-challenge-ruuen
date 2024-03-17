using System.Text.Json;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class MockTicketRepository : ITicketRepository
{
    private const string FileDataPath = "../Infrastructure/MockData/Data/mock-ticket-data.json";
    private readonly List<Ticket> _data;
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    
    public MockTicketRepository()
    {
        // Parse JSON file to string
        string json = File.ReadAllText(FileDataPath);
        if (String.IsNullOrWhiteSpace(json))
        {
            throw new InvalidDataException(
                "Could not read contents of source data file, or source data file was empty");
        }
        
        // Deserialize JSON string to list of sprints
        List<Ticket>? deserializedData = JsonSerializer.Deserialize<List<Ticket>>(json, _serializerOptions);
        
        // Save data or empty array if no data was deserialized
        _data = deserializedData ?? new List<Ticket>();
    }
    public List<Ticket> GetAllBySprint(int sprintId)
    {
        var results = _data.FindAll(ticket => ticket.Fields.Sprints[0].Id == sprintId);
        return results;
    }
}