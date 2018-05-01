using Newtonsoft.Json;
using System;

namespace Solab.Auth0.ManagementApi
{
    internal class GetGroupsResponse
    {
        public Group[] Groups { get; set; }
        public int Total { get; set; }
    }

    public class Group
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Nested { get; set; }
        public string[] Mappings { get; set; }
        public string[] Members { get; set; }
        public string[] Roles { get; set; }
    }

    public class GroupCreateRequest
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }
    }

    public class GroupUpdateRequest
    {
        public String Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }
    }

    public class Role
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string ApplicationType { get; set; }
        public string ApplicationId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public object[] Permissions { get; set; }
        public object[] Users { get; set; }
    }


    internal class GetMembersResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("users")]
        public User[] Users { get; set; }
    }

    public class User
    {
        public string UserId { get; set; }
        public string GivenName { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Picture { get; set; }
        public string Nickname { get; set; }
        public Identity[] Identities { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastPasswordReset { get; set; }
        public AppMetadata AppMetadata { get; set; }
        public string LastIp { get; set; }
        public DateTime LastLogin { get; set; }
        public int LoginsCount { get; set; }

    }

    public class Identity
    {
        public string Connection { get; set; }
        public string UserId { get; set; }
        public string Provider { get; set; }
        public bool IsSocial { get; set; }
    }

    public class AppMetadata
    {
        public Authorization Authorization { get; set; }
    }

    public class Authorization
    {
        public object[] Groups { get; set; }
        public object[] Roles { get; set; }
        public object[] Permissions { get; set; }
    }
}
