namespace DotnetAPIProject.Models.DTOs
{
    public class AccountDto
    {
        //public int Id { get; set; }
        public required string Fullname { get; set; }

        public required string Email { get; set; }
        public required string PassWord { get; set; }


    }
}
