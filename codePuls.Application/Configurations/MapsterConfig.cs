using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Domain.Entities;
using Mapster;

namespace codePuls.Application.Configurations
{

    public static class MapsterConfig
    {
        public static void ConfigureMappings()
        {
 
            TypeAdapterConfig<Project, ProjectResponseDto>.NewConfig();
            TypeAdapterConfig<ProjectRequestDto, Project>.NewConfig()
                            .ConstructUsing(src => new Project(
                                src.ProjectName,
                                src.NodeId,
                                src.AvatarUrl,
                                src.DisplayName,
                                src.ProjectCreatedAt,
                                src.ProjectUpdatedAt)); 
            //TypeAdapterConfig<User, UserResponseDto>.NewConfig();
            //TypeAdapterConfig<UserRequestDto, User>.NewConfig()
            //                .ConstructUsing(src => new User(
            //                    src.UserName, 
            //                    src.NodeId,
            //                    src.AvatarUrl,
            //                    src.DisplayName,
            //                    src.UserCreatedAt,
            //                    src.UserUpdatedAt));
            //TypeAdapterConfig<Team, TeamResponseDto>.NewConfig();
            //TypeAdapterConfig<TeamRequestDto, Team>.NewConfig()
            //    .ConstructUsing(src => new Team(
            //        src.NodeId,      
            //        src.TeamName,
            //        src.Description
            //        //src.ProjectId
            //    ));
            //TypeAdapterConfig<TeamMemberRequestDto, TeamMember>.NewConfig();


            //TypeAdapterConfig<CodeRepository, CodeRepositoryRequestDto>.NewConfig();
            //TypeAdapterConfig<CodeRepositoryRequestDto, CodeRepository>.NewConfig().ConstructUsing(src => new CodeRepository(
            //                    src.NodeId,
            //                    src.CodeRepositoryName,
            //                    src.FullName,
            //                    src.ProjectId
            //                    ));
            //TypeAdapterConfig<PullRequest, PullRequestRequestDto>.NewConfig();
            //TypeAdapterConfig<PullRequestRequestDto, PullRequest>.NewConfig()
            //                .ConstructUsing(src => new PullRequest(
            //                    src.NodeId,
            //                    src.Number,
            //                    src.State,
            //                    src.Commits,
            //                    src.Additions,
            //                    src.Deletions,
            //                    src.ChangedFiles,
            //                    src.PRCreatedAt,
            //                    src.PRUpdatedAt,
            //                    src.PRMergedAt,
            //                    src.PRClosedAt,
            //                    src.CodeRepositoryId,
            //                    src.UserId,
            //                    src.ProjectId
            //                ));
        }
    }
}
