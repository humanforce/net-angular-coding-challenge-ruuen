using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Ticket
{
    public required string Id { get; set; }
    public required string Self { get; set; }
    public required TicketFields Fields { get; set; }
    
}

public class TicketFields
{
    public TicketPriority? Priority { get; set; }
    public required TicketStatus Status { get; set; }
    public required string Summary { get; set; }
    // Sprint relationship in JSON response defined by field name "customfield_10020"
    [JsonPropertyName("customfield_10020")]
    public required List<Sprint> Sprints { get; set; }
    // Story Points in JSON response defined by field name "customfield_10016"
    [JsonPropertyName("customfield_10016")]
    public required double StoryPoints { get; set; }
}

public class TicketPriority
{
    public required string Name { get; set; }
}

public class TicketStatus
{
    public required string Name { get; set; }
}