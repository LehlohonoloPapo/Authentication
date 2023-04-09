namespace Auth.Models
{
    public class AuthResponse: Roles
    {
      
        public string Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


    }
    public class Roles
    {
    public string RoleId { get; set; }
    public string RoleName { get; set; }

}
}
