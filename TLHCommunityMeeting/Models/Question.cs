using System.ComponentModel.DataAnnotations;

namespace TLHCommunityMeeting.Models;

public class Question
{
    public int QuestionId { get; set; }
    [Required, Display(Name = "Question")]
    public string QuestionText { get; set; } = string.Empty;
    [Display(Name = "Réponse")]
    public string Answer { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Identifiant Discord")]
    public string DiscordUserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}