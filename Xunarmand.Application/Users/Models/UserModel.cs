using System.Text.Json.Serialization;
using Xunarmand.Domain.Enums;

namespace Xunarmand.Application.Users.Models;

public class UserModel
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string PasswordHash { get; set; } = default!;

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the birthday of the user.
    /// </summary>
    [JsonIgnore]
    public Role Role { get; set; } = Role.User;
}