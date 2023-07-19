public class UserInfo
{
    public int User_Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string First_Name { get; set; } = string.Empty;
    public string Last_Name { get; set; } = string.Empty;
    public int? Age { get; set; }
    public string Password_Hash { get; set; } = string.Empty;
}