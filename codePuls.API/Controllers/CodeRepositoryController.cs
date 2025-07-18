using codePuls.Application.Common.ResponseModels;
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace codePuls.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeRepositoryController(ILogger<CodeRepositoryController> logger, ICodeRepositoryService codeRepositoryService) : ControllerBase
    {
        private readonly ILogger<CodeRepositoryController> _logger = logger;
        private readonly ICodeRepositoryService _codeRepositoryService = codeRepositoryService;

        [HttpGet("{projectId}")]
        public async Task<ActionResult> GetAllByProjectIdAsync(Guid ProjectId)
        {
            var codeRepositories = await _codeRepositoryService.GetAllByProjectIdAsync(ProjectId);
            var response = new SuccessResponse<IEnumerable<CodeRepositoryResponseDto>>
            {
                Data = codeRepositories,
                Message = "Repositories retrieved  successfully.",
                StatusCode = StatusCodes.Status200OK,
                Success = true
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRepositoriesAsync(CreateCodeRepositoriesDto request)
        {
            var codeRepositories = await _codeRepositoryService.CreateRepositoriesAsync(request.ProjectId, request.CodeRepositories);
            var response = new SuccessResponse<IEnumerable<CodeRepositoryResponseDto>>
            {
                Data = codeRepositories,
                Message = "Repositories created  successfully.",
                StatusCode = StatusCodes.Status201Created,
                Success = true
            };
            return Created("api/codeRepository", response);
        }
    }
}