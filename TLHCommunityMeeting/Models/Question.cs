namespace TLHCommunityMeeting.Models;

public class Question
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string DiscordUserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}