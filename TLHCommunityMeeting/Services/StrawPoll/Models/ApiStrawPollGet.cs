using Newtonsoft.Json;

namespace TLHCommunityMeeting.Services.StrawPoll.Models;

public class ApiStrawPollGet
{
    public class UserMeta
    {
        [JsonProperty("about")] public object? About { get; set; }
        [JsonProperty("country_code")] public string? CountryCode { get; set; }
        [JsonProperty("monthly_points")] public int MonthlyPoints { get; set; }
        [JsonProperty("total_points")] public int TotalPoints { get; set; }
        [JsonProperty("website")] public object? Website { get; set; }
    }

    public class Creator
    {
        [JsonProperty("avatar_path")] public string? AvatarPath { get; set; }
        [JsonProperty("created_at")] public int CreatedAt { get; set; }
        [JsonProperty("displayname")] public string? DisplayName { get; set; }
        [JsonProperty("status")] public string? Status { get; set; }
        [JsonProperty("subscription")] public string? Subscription { get; set; }
        [JsonProperty("user_meta")] public UserMeta? UserMeta { get; set; }
        [JsonProperty("username")] public string? Username { get; set; }
    }

    public class PollConfig
    {
        [JsonProperty("allow_comments")] public bool AllowComments { get; set; }
        [JsonProperty("allow_indeterminate")] public bool AllowIndeterminate { get; set; }
        [JsonProperty("allow_other_option")] public bool AllowOtherOption { get; set; }
        [JsonProperty("allow_vpn_users")] public bool AllowVpnUsers { get; set; }
        [JsonProperty("custom_design_colors")] public object? CustomDesignColors { get; set; }
        [JsonProperty("deadline_at")] public object? DeadlineAt { get; set; }
        [JsonProperty("duplication_checking")] public string? DuplicationChecking { get; set; }
        [JsonProperty("edit_vote_permissions")] public string? EditVotePermissions { get; set; }
        [JsonProperty("force_appearance")] public object? ForceAppearance { get; set; }
        [JsonProperty("hide_participants")] public bool HideParticipants { get; set; }
        [JsonProperty("is_multiple_choice")] public bool IsMultipleChoice { get; set; }
        [JsonProperty("is_private")] public bool IsPrivate { get; set; }
        [JsonProperty("multiple_choice_max")] public int MultipleChoiceMax { get; set; }
        [JsonProperty("multiple_choice_min")] public int MultipleChoiceMin { get; set; }
        [JsonProperty("number_of_winners")] public int NumberOfWinners { get; set; }
        [JsonProperty("randomize_options")] public bool RandomizeOptions { get; set; }
        [JsonProperty("require_voter_names")] public bool RequireVoterNames { get; set; }
        [JsonProperty("results_visibility")] public string? ResultsVisibility { get; set; }
        [JsonProperty("send_notifications")] public bool SendNotifications { get; set; }
        [JsonProperty("send_webhooks")] public bool SendWebhooks { get; set; }
        [JsonProperty("use_custom_design")] public bool UseCustomDesign { get; set; }
        [JsonProperty("vote_type")] public string? VoteType { get; set; }
    }

    public class PollMeta
    {
        [JsonProperty("comment_count")] public int CommentCount { get; set; }
        [JsonProperty("creator_country")] public string? CreatorCountry { get; set; }
        [JsonProperty("description")] public string? Description { get; set; }
        [JsonProperty("last_vote_at")] public object? LastVoteAt { get; set; }
        [JsonProperty("location")] public string? Location { get; set; }
        [JsonProperty("participant_count")] public int ParticipantCount { get; set; }
        [JsonProperty("pin_code_expired_at")] public object? PinCodeExpiredAt { get; set; }
        [JsonProperty("timezone")] public object? Timezone { get; set; }
        [JsonProperty("view_count")] public int ViewCount { get; set; }
        [JsonProperty("vote_count")] public int VoteCount { get; set; }
    }

    public class PollOption
    {
        [JsonProperty("date")] public object? Date { get; set; }
        [JsonProperty("description")] public object? Description { get; set; }
        [JsonProperty("id")] public string? Id { get; set; }
        [JsonProperty("is_all_day")] public int IsAllDay { get; set; }
        [JsonProperty("max_votes")] public int MaxVotes { get; set; }
        [JsonProperty("position")] public int Position { get; set; }
        [JsonProperty("secondary")] public object? Secondary { get; set; }
        [JsonProperty("type")] public string? Type { get; set; }
        [JsonProperty("value")] public string? Value { get; set; }
        [JsonProperty("vote_count")] public int VoteCount { get; set; }
    }

    public class Poll
    {
        [JsonProperty("created_at")] public int CreatedAt { get; set; }
        [JsonProperty("creator")] public Creator? Creator { get; set; }
        [JsonProperty("id")] public string? Id { get; set; }
        [JsonProperty("is_results_visible")] public bool IsResultsVisible { get; set; }
        [JsonProperty("is_votable")] public bool IsVotable { get; set; }
        [JsonProperty("media")] public object? Media { get; set; }
        [JsonProperty("path")] public string? Path { get; set; }
        [JsonProperty("pin_code")] public object? PinCode { get; set; }
        [JsonProperty("poll_config")] public PollConfig? PollConfig { get; set; }
        [JsonProperty("poll_meta")] public PollMeta? PollMeta { get; set; }
        [JsonProperty("poll_options")] public List<PollOption>? PollOptions { get; set; }
        [JsonProperty("reset_at")] public object? ResetAt { get; set; }
        [JsonProperty("results_key")] public string? ResultsKey { get; set; }
        [JsonProperty("results_path")] public string? ResultsPath { get; set; }
        [JsonProperty("slug")] public object? Slug { get; set; }
        [JsonProperty("status")] public string? Status { get; set; }
        [JsonProperty("title")] public string? Title { get; set; }
        [JsonProperty("type")] public string? Type { get; set; }
        [JsonProperty("updated_at")] public object? UpdatedAt { get; set; }
        [JsonProperty("url")] public string? Url { get; set; }
        [JsonProperty("version")] public string? Version { get; set; }
    }

    public class Root
    {
        [JsonProperty("poll")] public Poll? Poll { get; set; }
        [JsonProperty("success")] public int Success { get; set; }
    }


}