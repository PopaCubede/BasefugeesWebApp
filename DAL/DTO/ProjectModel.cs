using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BasefugeesWebApp.DAL.DTO
{
    [DataContract]
    public class ProjectModel
    {
        [DataMember(Name = "Project_Id")] public Guid Project_Id { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [DataMember(Name = "Location")] public string Location { get; set; }

        [DataMember(Name = "Stage")] public string Stage { get; set; }

        [DataMember(Name = "Url")] public string Url { get; set; }

        [DataMember(Name = "Description")] public string Description { get; set; }

        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "SupportNeeded")] public string SupportNeeded { get; set; }

        [DataMember(Name = "Featured")] public bool Featured { get; set; }

        [DataMember(Name = "Privacy")] public string Privacy { get; set; }

        [DataMember(Name = "Box1")] public string Box1 { get; set; }

        [DataMember(Name = "Box2")] public string Box2 { get; set; }

        [DataMember(Name = "Vertical")] public string Vertical { get; set; }

        [DataMember(Name = "NbEmployees")] public string NbEmployees { get; set; }

        [DataMember(Name = "FacebookUrl")] public string FacebookUrl { get; set; }

        [DataMember(Name = "LinkedinUrl")] public string LinkedinUrl { get; set; }

        [DataMember(Name = "TwitterUrl")] public string TwitterUrl { get; set; }

        [DataMember(Name = "GitUrl")] public string GitUrl { get; set; }

        [DataMember(Name = "AngellistUrl")] public string AngellistUrl { get; set; }

        [DataMember(Name = "BloggerUrl")] public string BloggerUrl { get; set; }

        [DataMember(Name = "WebsiteUrl")] public string WebsiteUrl { get; set; }

        [DataMember(Name = "InstagramUrl")] public string InstagramUrl { get; set; }

        [DataMember(Name = "YoutubeUrl")] public string YoutubeUrl { get; set; }

        [DataMember(Name = "UserRole")] public string UserRole { get; set; }

        [DataMember(Name = "TeamMembers")] public Guid[] TeamMembers { get; set; }

        [DataMember(Name = "TeamPartneredOrgas")]
        public Guid[] TeamPartneredOrgas { get; set; }

        [DataMember(Name = "ProjectInspiredBy")]
        public Guid[] ProjectInspiredBy { get; set; }

        [DataMember(Name = "ProjectDonors")] public Guid[] ProjectDonors { get; set; }

        [DataMember(Name = "ProjectInvestors")]
        public Guid[] ProjectInvestors { get; set; }
    }
}
