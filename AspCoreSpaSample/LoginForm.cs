using System.ComponentModel.DataAnnotations;

namespace AspCoreSpaSample;

public class LoginForm
{
    public string UserName { get; set; }

    public string Password { get; set; }
}