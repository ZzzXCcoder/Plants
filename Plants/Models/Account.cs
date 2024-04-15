using Plants.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WebApplication1.Models
{
    public class Account
    {
        public Account(Guid id, string name, string login, string hashedPassword)
        {
            Id = id;
            Name = name;
            Login = login;
            HashedPassword = hashedPassword;
        }
        public Account(Guid id, string name, string login, string hashedPassword, string Image)
        {
            Id = id;
            Name = name;
            Login = login;
            HashedPassword = hashedPassword;
        }
        public Guid Id { get; set; }
        /// <summary>
        /// Profile_name
        /// </summary>
        public string Name { get; set; }

        public string Login { get; set; }

        public string HashedPassword { get; set; }
        public string ImagePath { get; set; } = "";

        public List<Account_and_plant> accounts_in_table { get; set; }

        public static Account Creaate (Guid id, string name, string login, string hashedPassword)
        {
            return new Account(id, name, login, hashedPassword);

        }





    }
}
