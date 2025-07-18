using Microsoft.Extensions.Logging;
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Application.Interfaces;
using codePuls.Domain.Entities;
using CodePuls.Domain.Interfaces.Repositories;
using Mapster;
using codePuls.Application.Exeptions;

namespace codePuls.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ProjectService> _logger;


        public ProjectService(IProjectRepository projectRepository, ILogger<ProjectService> logger) 
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<ProjectResponseDto> GetProjectByIdAsync(Guid id)
        {
            var project=await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                throw new NotFoundException("No Project found for the given criteria.");
            }
            return project.Adapt<ProjectResponseDto>();
        }
        public async Task<IEnumerable<ProjectResponseDto>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            if (projects == null || !projects.Any())
            {
                throw new NotFoundException("No Project found for the given criteria.");
            }
            return projects.Adapt<IEnumerable<ProjectResponseDto>>();
        }

     
        public async Task<ProjectResponseDto> CreateProjectAsync(ProjectRequestDto project)
        {
                var existingProject = await _projectRepository.GetProjectByNodeIdAsync(project.NodeId);
                if (existingProject != null) 
                {
                    return existingProject.Adapt<ProjectResponseDto>();
                }
                var projectEntity = project.Adapt<Project>();
                var createdProject = await _projectRepository.CreateProjectAsync(projectEntity);

                if (createdProject == null)
                    throw new ApplicationException("Project creation failed.");

                return createdProject.Adapt<ProjectResponseDto>();
        }

    }
}
