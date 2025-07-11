using Azure.Core;
using codePuls.Application.Common.ResponseModels;
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Application.Interfaces;
using codePuls.Application.Services;
using codePuls.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace codePuls.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _logger;
        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProjectsAsync()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            var response = new SuccessResponse<IEnumerable<ProjectResponseDto>>
            {
                Data = projects,
                Message = "Projects retrieved successfully.",
                StatusCode = StatusCodes.Status200OK,
                Success = true
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync(ProjectRequestDto project)
        {
            var createdProject = await _projectService.CreateProjectAsync(project);
            var response = new SuccessResponse<ProjectResponseDto>
            {
                Data = createdProject,
                Message = "Project created successfully.",
                StatusCode = StatusCodes.Status201Created,
                Success = true
            };
            return StatusCode(StatusCodes.Status201Created, response);
           
        }
    }
}
