namespace Application.Profiles.Dto;

public class ProfileOutput
{
    public string status { get; set; } = "success";
    public List<UserDto> user { get; set; } = default!;
    public string timestamp { get; set; } = default!;
    public string fact { get; set; } = default!;
}
