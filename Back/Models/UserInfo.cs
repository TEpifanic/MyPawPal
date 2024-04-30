﻿public class UserInfo
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<DogInfo> Dogs { get; set; } = new List<DogInfo>();
}