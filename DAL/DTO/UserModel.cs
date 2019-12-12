using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BasefugeesWebApp.DAL.DTO
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "User_Id")] public Guid User_Id { get; set; }

        [DataMember(Name = "Username")] public string Username { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "Firstname")] public string Firstname { get; set; }

        [DataMember(Name = "Email")] public string Email { get; set; }

        [DataMember(Name = "Location")] public string Location { get; set; }

        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Password")] public string Password { get; set; }

        [DataMember(Name = "Facebook_id")] public string Facebook_id { get; set; }

        [DataMember(Name = "Facebook_token")] public string Facebook_token { get; set; }

        [DataMember(Name = "Status")] public string Status { get; set; }

        [DataMember(Name = "Bio")] public string Bio { get; set; }

        [DataMember(Name = "Twitter_id")] public string Twitter_id { get; set; }

        [DataMember(Name = "Opentocontact")] public bool? Opentocontact { get; set; }

        [DataMember(Name = "Experience")] public int Experience { get; set; }

        [DataMember(Name = "ResetPasswordToken")]
        public string ResetPasswordToken { get; set; }

        [DataMember(Name = "ResetPasswordExpires")]
        public DateTime? ResetPasswordExpires { get; set; }
    }

    [DataContract]
    public class EmailCheckModel
    {
        [DataMember(Name = "emailRecipient")] public string Email { get; set; }
    }

    [DataContract]
    public class UserLoginModel
    {
        [DataMember(Name = "email")] public string Email { get; set; }

        [DataMember(Name = "password")] public string Password { get; set; }
    }

    [DataContract]
    public class UserLoginResponseModel
    {
        [DataMember(Name = "user")] public UserModel User { get; set; }

        [DataMember(Name = "token")] public string Token { get; set; }
    }
}
