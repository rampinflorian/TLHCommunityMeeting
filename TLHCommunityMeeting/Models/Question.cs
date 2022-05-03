using System.ComponentModel.DataAnnotations;

namespace TLHCommunityMeeting.Models;

public class Question
{
    public int QuestionId { get; set; }
    [Required(ErrorMessage = "Le sujet est obligatoire"), Display(Name = "Sujet")]
    public string Subject { get; set; } = string.Empty;
    [Required(ErrorMessage = "La question est obligatoire"), Display(Name = "Question")]
    public string QuestionText { get; set; } = string.Empty;
    [Display(Name = "Réponse")]
    public string Answer { get; set; } = string.Empty;
    [Required(ErrorMessage = "L'identifiant discord est obligatoire (ex : ABCD#1234)")][Display(Name = "Identifiant Discord")]
    public string DiscordUserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? MeetingAt { get; set; } = null;
}