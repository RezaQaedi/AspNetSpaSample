using System.ComponentModel.DataAnnotations;

namespace AspCoreSpaSample;

public class LoginForm
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Passoword { get; set; }
}