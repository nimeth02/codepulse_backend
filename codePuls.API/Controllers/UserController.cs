using codePuls.Application.Common.ResponseModels;
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace codePuls.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ILogger<UserController> logger, IUserService userService) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IUserService _userService = userService;

        [HttpGet("{projectId}")]
        public async Task<ActionResult> GetAllUserByProjectIdAsync(Guid projectId)
        {
            var users = await _userService.GetAllUserByProjectIdAsync(projectId);

            var response = new SuccessResponse<IEnumerable<UserResponseDto>>
            {
                Data = users,
                Message = "Users retrived successfully.",
                StatusCode = StatusCodes.Status200OK,
                Success = true
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(CreateProjectUsersRequestDto request)
        {
            var createdUsers = await _userService.CreateUsersAsync(request.ProjectId, request.Users);

            var response = new SuccessResponse<IEnumerable<UserResponseDto>>
            {
                Data = createdUsers,
                Message = "Users created successfully.",
                StatusCode = StatusCodes.Status201Created,
                Success = true
            };
            return Created("api/user", response);
        }
    }
}