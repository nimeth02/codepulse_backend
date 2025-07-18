using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Application.Interfaces;
using codePuls.Domain.Entities;
using CodePuls.Domain.Interfaces.Repositories;
using Mapster;
using Microsoft.Extensions.Logging;

namespace codePuls.Application.Services
{
    public class CodeRepositoryService(ICodeReositoryReository codeRepositoryService, ILogger<ProjectService> logger) : ICodeRepositoryService
    {
        private readonly ICodeReositoryReository _codeRepositoryrepository = codeRepositoryService;
        private readonly ILogger<ProjectService> _logger = logger;

        public async Task<IEnumerable<CodeRepositoryResponseDto>> GetAllByProjectIdAsync(Guid ProjectId)
        {
            var codeRepositories = await _codeRepositoryrepository.GetAllByProjectIdAsync(ProjectId);
            //if (codeRepositories == null || !codeRepositories.Any())
            //{
            //    throw new NotFoundException("No codeRepositories found for the given criteria.");
            //}
            return codeRepositories.Adapt<IEnumerable<CodeRepositoryResponseDto>>();
        }

        public async Task<IEnumerable<CodeRepositoryResponseDto>> CreateRepositoriesAsync(Guid projectId, CodeRepositoryRequestDto[] codeRepositories)

        {
            //with dto class
            //foreach (CodeRepositoryRequestDto item in codeRepositories)
            //{
            //    item.ProjectId = projectId;
            //}

            var updatedRequests = codeRepositories.Select(repo => repo with { ProjectId = projectId }).ToArray();


            var codeRepositoryEntities = codeRepositories.Adapt<List<CodeRepository>>();

            var codeRepositoryNodeIds = codeRepositoryEntities.Select(p => p.NodeId).ToList();

            var existingCodeRepositoryNodeIds = await _codeRepositoryrepository.GetExistingCodeRepositoryNodeIdsAsync(codeRepositoryNodeIds);

            var newCodeRepositories = codeRepositoryEntities.Where(pr => !existingCodeRepositoryNodeIds.Any(e => e == pr.NodeId)).ToList();

            var createdCodeRepositories = await _codeRepositoryrepository.CreateRepositoriesAsync(newCodeRepositories);

            if (createdCodeRepositories == null || !createdCodeRepositories.Any())
                throw new ApplicationException("Repositories creation failed. No Repositories were created.");

            return createdCodeRepositories.Adapt<IEnumerable<CodeRepositoryResponseDto>>();
        }
    }
}