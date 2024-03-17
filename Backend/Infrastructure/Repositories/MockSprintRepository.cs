using System.Text.Json;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class MockSprintRepository : ISprintRepository
{
    private const string FileDataPath = "../Infrastructure/MockData/Data/mock-sprint-data.json";
    
    private readonly List<Sprint> _data;
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public MockSprintRepository()
    {
        // Parse JSON file to string
        string json = File.ReadAllText(FileDataPath);
        if (String.IsNullOrWhiteSpace(json))
        {
            throw new InvalidDataException(
                "Could not read contents of source data file, or source data file was empty");
        }
        
        // Deserialize JSON string to list of sprints
        List<Sprint>? deserializedData = JsonSerializer.Deserialize<List<Sprint>>(json, _serializerOptions);
        
        // Save data or empty array if no data was deserialized
        _data = deserializedData ?? new List<Sprint>();
    }

    public Sprint? GetById(int sprintId)
    {
        Sprint? result = _data.FirstOrDefault(sprint => sprint.Id == sprintId);
        return result;
    }

    public Sprint? GetByDates(DateTime startDate, DateTime endDate)
    {
        Sprint? result = _data.FirstOrDefault(sprint => sprint.StartDate == startDate && sprint.EndDate == endDate);
        return result;
    }

    public Sprint GetCurrentOrLast()
    {
        // Try to get active sprint based on current date
        DateTime currentDate = DateTime.Now;
        Sprint? currentSprint = _data.FirstOrDefault(sprint => sprint.StartDate <= currentDate && sprint.EndDate > currentDate);

        // If none found, get and return the most recent one
        if (currentSprint == null)
        {
            Sprint mostRecentSprint = _data.Slice(_data.Count - 1, 1)[0];
            return mostRecentSprint;
        }

        // Return the currently active sprint
        return currentSprint;
    }

    public List<Sprint> GetPreviousSprintsById(int sprintId, int maxPrevCount)
    {
        // Get index of target sprint
        int targetSprint = _data.FindIndex(sprint => sprint.Id == sprintId);
        
        // Return empty list if no sprint found, or if sprint found is first in the list
        if (targetSprint <= 0)
        {
            return new List<Sprint>();
        }
        
        // Init loop iterator
        int currentIndex = targetSprint - 1;
        // Up to the max previous count, store each previous sprint,
        List<Sprint> prevSprints = new List<Sprint>();
        for (int i = maxPrevCount; i > 0; i--)
        {
            // Don't process if a negative-index call will occur, this means we've got all available items
            if (currentIndex < 0)
            {
                break;
            }
            
            prevSprints.Add(_data[currentIndex]);
            currentIndex--;
        }
        
        // Return found previous sprints
        return prevSprints;
    }
}