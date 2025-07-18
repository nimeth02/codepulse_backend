using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using codePuls.Application.DTOs;
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Application.Interfaces;
using codePuls.Domain.Entities;
using CodePuls.Domain.Interfaces.Repositories;
using Mapster;
using codePuls.Domain.Interfaces.Repositories;
using codePuls.Domain.Interfaces;
using codePuls.Application.Exeptions;

namespace codePuls.Application.Services
{
    public class UserService(IUserRepository userRepository, IProjectMembershipRepository projectMembershipRepository, ILogger<UserService> logger, ITransactionManager transactionManager) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IProjectMembershipRepository _projectMembershipRepository = projectMembershipRepository;
        private readonly ITransactionManager _transactionManager = transactionManager;
        private readonly ILogger<UserService> _logger = logger;

        public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("No users found for the given criteria.");
            }
            return user.Adapt<UserResponseDto>();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(Guid id)
        {
            var users = await _userRepository.GetAllUsersAsync(id);
            //if (users == null || !users.Any())
            //{
            //    throw new NotFoundException("No users found for the given criteria.");
            //}
            return users.Adapt<IEnumerable<UserResponseDto>>();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUserByProjectIdAsync(Guid projectId)
        {
            var users = await _userRepository.GetAllUserByProjectIdAsync(projectId);
            //if (users == null || !users.Any())
            //{
            //    throw new NotFoundException("No users found for the given criteria.");
            //}
            return users.Adapt<IEnumerable<UserResponseDto>>();
        }

        public async Task<IEnumerable<UserResponseDto>> CreateUsersAsync(Guid projectId, UserRequestDto[] users)
        {
            await _transactionManager.BeginTransactionAsync();

            var userEntities = users.Adapt<User[]>();
            var userNodeIds = userEntities.Select(u => u.NodeId).ToList();

            var existingUserIds = await _userRepository.GetExistingUserNodeIdsAndUserIdsAsync(userNodeIds);

            var newUsers = userEntities.Where(u => !existingUserIds.Any(e => e.NodeId == u.NodeId)).ToArray();

            var createdUsers = await CreateNewUsersAndAssignToProject(projectId, newUsers);
            //IEnumerable<User> createdUsers = [];
            //bool createNewUserProjectMembership;
            //if (newUsers.Any())
            //{
            //    createdUsers = await _userRepository.CreateUsersAsync(newUsers);

            //    if (createdUsers == null || !createdUsers.Any())
            //        throw new ApplicationException("User creation failed. No users were created.");

            //    var newUsermemberships = createdUsers.Select(user => new ProjectMember(projectId, user.UserId)).ToList();

            //    createNewUserProjectMembership = await _projectMembershipRepository.CreateProjectMembershipAsync(newUsermemberships);
            //    if (!createNewUserProjectMembership)
            //        throw new ApplicationException("Failed to assign new users to project");

            //}

            var existingUserUserIds = existingUserIds.Select(e => e.UserId).ToList();
            var existingMembershipUserIds = await _projectMembershipRepository.GetExistingMembershipNodeIdsAsync(projectId, existingUserUserIds);

            var existingUsersNewMembershipIds = existingUserIds.Where(u => !existingMembershipUserIds.Any(e => e == u.UserId)).ToArray();
            var existingUsersNewMemberships = existingUsersNewMembershipIds.Select(user => new ProjectMember(projectId, user.UserId)).ToList();

            await AssignExistingUsersToProject(projectId, existingUsersNewMemberships);

            //if (existingUsersNewMemberships.Any())
            //{
            //    var createExistingUserProjectMembership = await _projectMembershipRepository.CreateProjectMembershipAsync(existingUsersNewMemberships);

            //    if (createExistingUserProjectMembership == false)
            //        throw new ApplicationException("Failed to assign existing users to project");

            //}

            await _transactionManager.CommitTransactionAsync();

            return createdUsers.Adapt<IEnumerable<UserResponseDto>>();
        }

        private async Task<IEnumerable<User>> CreateNewUsersAndAssignToProject(Guid projectId, User[] newUsers)
        {
            IEnumerable<User> createdUsers = [];
            bool createNewUserProjectMembership;
            if (newUsers == null || !newUsers.Any())
                return [];

            createdUsers = await _userRepository.CreateUsersAsync(newUsers);

            if (createdUsers == null || !createdUsers.Any())
                throw new ApplicationException("User creation failed. No users were created.");

            var newUsermemberships = createdUsers.Select(user => new ProjectMember(projectId, user.UserId)).ToList();

            createNewUserProjectMembership = await _projectMembershipRepository.CreateProjectMembershipAsync(newUsermemberships);
            if (!createNewUserProjectMembership)
                throw new ApplicationException("Failed to assign new users to project");

            return createdUsers;
        }

        private async Task AssignExistingUsersToProject(Guid projectId, List<ProjectMember> existingUsersNewMemberships)
        {
            if (existingUsersNewMemberships.Any())
            {
                var createExistingUserProjectMembership = await _projectMembershipRepository.CreateProjectMembershipAsync(existingUsersNewMemberships);

                if (createExistingUserProjectMembership == false)
                    throw new ApplicationException("Failed to assign existing users to project");
            }
        }
    }
}