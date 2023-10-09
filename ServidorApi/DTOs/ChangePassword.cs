using System.ComponentModel.DataAnnotations;

using ServidorApi.Data;

public class ChangePasswordDto
{
    [Required]
    public string OldPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }
}
