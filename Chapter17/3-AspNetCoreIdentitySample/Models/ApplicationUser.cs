using System;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string CityName { get; set; }

    public DateTime JobBeginDate { get; set; }
}