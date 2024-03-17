using System.Text.Json;
using Domain.Entities;
using Infrastructure.MockData.Models;

namespace Infrastructure.Repositories;

public class MockPublicHolidayRepository : IPublicHolidayRepository
{
    private const string FileDataPath = "../Infrastructure/MockData/Data/mock-publichol-data.json";
    
    private readonly List<PublicHoliday> _data;
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        IncludeFields = true
    };

    public MockPublicHolidayRepository()
    {
        // Parse JSON file to string
        string json = File.ReadAllText(FileDataPath);
        if (String.IsNullOrWhiteSpace(json))
        {
            throw new InvalidDataException(
                "Could not read contents of source data file, or source data file was empty");
        }
        
        // Deserialize JSON string to list of mock types
        List<MockCountryResponse>? deserializedData = JsonSerializer.Deserialize<List<MockCountryResponse>>(json, _serializerOptions);
        
        if (deserializedData == null)
        {
            _data = new List<PublicHoliday>();
        }
        else
        {
            // Map deserialized mock data into PublicHoliday entities
            List<PublicHoliday> mappedData = new List<PublicHoliday>();
            foreach (var country in deserializedData)
            {
                var parsedLocation = _GetLocationFromResponseSummary(country.Summary);

                foreach (var publicHoliday in country.Items)
                {
                    var mappedPublicHoliday = new PublicHoliday
                    {
                        Name = publicHoliday.Summary,
                        StartDate = publicHoliday.Start.Date,
                        EndDate = publicHoliday.End.Date,
                        Location = new UserLocation
                        {
                            Country = parsedLocation.Country
                        }
                    };
                
                    mappedData.Add(mappedPublicHoliday);                   
                }
            }

            _data = mappedData;
        }
    }
    
    public List<PublicHoliday> GetAllInDateRange(DateTime startDate, DateTime endDate)
    {
        var results = _data.FindAll(holiday => holiday.StartDate >= startDate && holiday.EndDate <= endDate);
        return results;
    }
    
    private static UserLocation _GetLocationFromResponseSummary(string responseSummary)
    {
        string[] extractedCountry = responseSummary.Split("Holidays in ");
        
        if (extractedCountry.Length == 0)
            throw new InvalidOperationException("Summary value not in expected format, couldn't find country.");
        
        return new UserLocation { Country = extractedCountry[1] };
    }
}