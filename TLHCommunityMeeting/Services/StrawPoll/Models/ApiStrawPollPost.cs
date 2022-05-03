using Newtonsoft.Json;

namespace TLHCommunityMeeting.Services.StrawPoll.Models;

public class ApiStrawPollPost
{
    public class PollMeta
    {
        [JsonProperty("description")] public string? Description { get; set; }
        [JsonProperty("location")] public string? Location { get; set; }
    }

    public class Media
    {
        [JsonProperty("path")] public object? Path { get; set; }
    }

    public class PollOption
    {
        [JsonProperty("value")] public string? Value { get; set; }
    }

    public class PollConfig
    {
        [JsonProperty("is_private")] public int IsPrivate { get; set; }
        [JsonProperty("allow_comments")] public int AllowComments { get; set; }
        [JsonProperty("multiple_choice_min")] public object? MultipleChoiceMin { get; set; }
        [JsonProperty("multiple_choice_max")] public object? MultipleChoiceMax { get; set; }
        [JsonProperty("is_multiple_choice")] public int IsMultipleChoice { get; set; } = 1;
        [JsonProperty("require_voter_names")] public int RequireVoterNames { get; set; }
        [JsonProperty("duplication_checking")] public string? DuplicationChecking { get; set; } = "ip";
        [JsonProperty("deadline_at")] public object? DeadlineAt { get; set; }
        [JsonProperty("status")] public string? Status { get; set; } = "draft";
    }

    public class Root
    {
        [JsonProperty("type")] public string? Type { get; set; } = "multiple_choice";
        [JsonProperty("title")] public string? Title { get; set; }
        [JsonProperty("poll_meta")] public PollMeta? PollMeta { get; set; }
        [JsonProperty("media")] public Media? Media { get; set; }
        [JsonProperty("poll_options")] public List<PollOption>? PollOptions { get; set; }
        [JsonProperty("poll_config")] public PollConfig? PollConfig { get; set; }
    }
}