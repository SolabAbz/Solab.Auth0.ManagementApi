using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Solab.Auth0.ManagementApi
{
    public class Auth0AuthenticationApiClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly string authenticationApiAddress;
        private readonly String apiAccessToken;
        private readonly JsonSerializerSettings serializerSettings;

        public Auth0AuthenticationApiClient(String authenticationApiAddress, String apiAccessToken)
        {
            this.authenticationApiAddress = authenticationApiAddress;
            this.apiAccessToken = apiAccessToken;

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(authenticationApiAddress); ;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiAccessToken);

            serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
            };
        }

        public async Task<Group[]> GetGroupsAsync()
        {
            var groupResponse = await httpClient.GetAsJsonAsync<GetGroupsResponse>("groups", serializerSettings);

            return groupResponse.Groups;
        }

        public async Task<Group> CreateGroupAsync(GroupCreateRequest groupCreateRequest)
        {
            var newGroup = await httpClient.PostAsJsonAsync<Group>("groups", groupCreateRequest, serializerSettings);

            return newGroup;
        }

        public async Task<Group> GetGroupAsync(String id)
        {
            var group = await httpClient.GetAsJsonAsync<Group>($"groups/{id}", serializerSettings);

            return group;
        }

        public async Task DeleteGroupAsync(string id)
        {
            var response = await httpClient.DeleteAsync($"groups/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGroupAsync(GroupUpdateRequest updateRequest)
        {
            var response = await httpClient.PutAsJsonAsync($"groups/{updateRequest.Id}", updateRequest, serializerSettings);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Role[]> GetGroupRolesAsync(String groupdId)
        {
            var roles = await httpClient.GetAsJsonAsync<Role[]>($"groups/{groupdId}/roles", serializerSettings);
            return roles;
        }

        public async Task<Group[]> GetNestedGroupsAsync(String parentGroupId)
        {
            var nestedGroups = await httpClient.GetAsJsonAsync<Group[]>($"groups/{parentGroupId}/nested", serializerSettings);
            return nestedGroups;
        }

        public async Task AddNestedGroupAsync(String parentGroupId, String[] nestedGroupIds)
        {
            var response = await httpClient.PatchAsJsonAsync($"groups/{parentGroupId}/nested", nestedGroupIds, serializerSettings);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveNestedGroupAsync(String parentGroupId, String[] nestedGroupIds)
        {
            var response = await httpClient.DeleteAsJsonAsync($"groups/{parentGroupId}/nested", nestedGroupIds, serializerSettings);
            response.EnsureSuccessStatusCode();
        }

        public async Task<User[]> GetGroupMembersAsync(String groupId)
        {
            var response = await httpClient.GetAsJsonAsync<GetMembersResponse>($"groups/{groupId}/members", serializerSettings);

            return response.Users;
        }

        public async Task AddGroupMembersAsync(String groupId, String[] userIds)
        {
            var response = await httpClient.PatchAsJsonAsync($"groups/{groupId}/members", userIds, serializerSettings);

            response.EnsureSuccessStatusCode();
        }


        public async Task DeleteGroupMembersAsync(String groupId, String[] userIds)
        {
            var response = await httpClient.DeleteAsJsonAsync($"groups/{groupId}/members", userIds, serializerSettings);

            response.EnsureSuccessStatusCode();
        }


        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}