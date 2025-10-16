using Application.Profiles.Dto;
using Domain.Profiles;
using MediatR;
using System.Text.Json;

namespace Application.Profiles.Queries.GetMe;

public class GetMeQueryHandler : IRequestHandler<GetMeQuery, ProfileOutput>
{
    private readonly HttpClient _httpClient;
    public GetMeQueryHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ProfileOutput> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var userDto = new List<UserDto>();

        userDto.Add(new UserDto
        {
            email = "<tunwashed@gmail.com>",
            name = "<Tunwashe Daniel>",
            stack = "<C#/.NET>"
        });


        var response = await _httpClient.GetAsync(catFactUrlConsts.CAT_FACT_URL, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var catFact = JsonSerializer.Deserialize<CatFactDto>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (catFact == null)
        {
            throw new Exception("CatFact is Null");
        }

        catFact.Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        var profieOutput = new ProfileOutput()
        {
            user = userDto,
            timestamp = "<" + catFact.Timestamp + ">",
            fact = "<" + catFact.Fact + ">"
        };

        return profieOutput;
    }
}
