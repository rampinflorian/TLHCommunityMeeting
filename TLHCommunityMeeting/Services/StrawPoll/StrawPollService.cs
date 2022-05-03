using System.Text;
using Newtonsoft.Json;
using TLHCommunityMeeting.Data;
using TLHCommunityMeeting.Forms;
using TLHCommunityMeeting.Services.StrawPoll.Models;

namespace TLHCommunityMeeting.Services.StrawPoll;

public class StrawPollService
{
    private readonly ApplicationDbContext _context;
    private const string StrawPollApiKey = "ffdd7992-c3f5-11ec-aa22-dc1badba9dec";

    public StrawPollService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ApiStrawPollGet.Root>> GetStrawPollsAsync()
    {
        var strawPolls = new List<ApiStrawPollGet.Root>();
        var dbStrawpolls = _context.StrawPolls.ToList();

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("X-API-Key", StrawPollApiKey);

        foreach (var strawPoll in dbStrawpolls)
        {
            var response = await httpClient.GetAsync($"https://api.strawpoll.com/v2/polls/{strawPoll.ApiPath}");
            var content = await response.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<ApiStrawPollGet.Root>(content);

            if (deserializedObject.Poll is not null)
            {
                strawPolls.Add(deserializedObject);
            }
        }

        return strawPolls;
    }

    public async Task<ApiStrawPollGet.Root?> CreateStrawPollAsync(StrawPollForm strawPollForm)
    {
        var root = new ApiStrawPollPost.Root()
        {
            Title = strawPollForm.Title,
            PollOptions = _GetListFromStringSeparator(strawPollForm.Options, ';')
        };

        var json = JsonConvert.SerializeObject(root);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        const string url = "https://api.strawpoll.com/v2/polls";
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("X-API-Key", StrawPollApiKey);


        var response = await httpClient.PostAsync(url, data);

        var content = await response.Content.ReadAsStringAsync();
        var deserializedObject = JsonConvert.DeserializeObject<ApiStrawPollGet.Root>(content);
        return deserializedObject;
    }

    public async Task<bool> DeleteStrawPollAsync(TLHCommunityMeeting.Models.StrawPoll strawPoll)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("X-API-Key", StrawPollApiKey);

        var content = await httpClient.DeleteAsync($"https://api.strawpoll.com/v2/polls/{strawPoll.ApiPath}");
        
        return true;

    }

    private static List<ApiStrawPollPost.PollOption> _GetListFromStringSeparator(string input, char separator)
    {
        var inputList = input.Split(separator);
        var list = inputList.Select(item => new ApiStrawPollPost.PollOption() { Value = item }).ToList();

        return (list);
    }
}