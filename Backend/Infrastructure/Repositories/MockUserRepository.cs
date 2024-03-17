using System.Text.Json;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class MockUserRepository : IUserRepository
{
    private const string FileDataPath = "../Infrastructure/MockData/Data/mock-user-data.json";
    
    private readonly List<User> _data;
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public MockUserRepository()
    {
        // Parse JSON file to string
        string json = File.ReadAllText(FileDataPath);
        if (String.IsNullOrWhiteSpace(json))
        {
            throw new InvalidDataException(
                "Could not read contents of source data file, or source data file was empty");
        }
        
        // Deserialize JSON string to list of sprints
        List<User>? deserializedData = JsonSerializer.Deserialize<List<User>>(json, _serializerOptions);
        
        // Save data or empty array if no data was deserialized
        _data = deserializedData ?? new List<User>();
    }
    
    public List<User> GetAll()
    {
        return _data;
    }
}