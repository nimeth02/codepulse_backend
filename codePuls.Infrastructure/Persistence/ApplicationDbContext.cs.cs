using Microsoft.EntityFrameworkCore;
using codePuls.Domain.Entities;


namespace codePuls.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<CodeRepository> CodeRepositories { get; set; }

        public DbSet<PullRequest> PullRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // USER CONFIG
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasMany(u => u.ProjectMemberships)
                      .WithOne(om => om.User)
                      .HasForeignKey(om => om.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(u => u.TeamMemberships)
                      .WithOne(tm => tm.User)
                      .HasForeignKey(tm => tm.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(u => u.CodeRepositoryContributions)
                      .WithOne(cc => cc.User)
                      .HasForeignKey(cc => cc.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(u => u.PullRequests)
                      .WithOne(pr => pr.User)
                      .HasForeignKey(pr => pr.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(p => p.NodeId).IsUnique();
            });

            // ORGANIZATION CONFIG
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(o => o.ProjectId);
                entity.HasMany(o => o.Members)
                      .WithOne(om => om.Project)
                      .HasForeignKey(om => om.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(o => o.Teams) 
                      .WithOne(t => t.Project)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(o => o.CodeRepositories)
                      .WithOne(c => c.Project)
                      .HasForeignKey(c => c.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(p => p.NodeId).IsUnique();
            });

            // ORGANIZATION MEMBER CONFIG (Join table)
            modelBuilder.Entity<ProjectMember>(entity =>
            {

                entity.HasKey(om => new { om.ProjectId, om.UserId });

                entity.HasOne(om => om.Project)
                      .WithMany(o => o.Members)
                      .HasForeignKey(om => om.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(om => om.User)
                      .WithMany(u => u.ProjectMemberships)
                      .HasForeignKey(om => om.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Team CONFIG
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);
                entity.HasMany(t => t.Members)
                      .WithOne(om => om.Team)
                      .HasForeignKey(om => om.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(t => t.Project)
                      .WithMany(o => o.Teams) 
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(p => p.NodeId).IsUnique();
            });


            // TEAM MEMBER CONFIG (Join table)
            modelBuilder.Entity<TeamMember>(entity =>
            {

                entity.HasKey(tm => new { tm.TeamId, tm.UserId });

                entity.HasOne(tm => tm.Team)
                      .WithMany(t => t.Members)
                      .HasForeignKey(tm => tm.TeamId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(tm => tm.User)
                      .WithMany(u => u.TeamMemberships)
                      .HasForeignKey(tm => tm.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

            });


            // CodeRepository CONFIG
            modelBuilder.Entity<CodeRepository>(entity =>
            {
                entity.HasKey(c => c.CodeRepositoryId);
                entity.HasOne(c => c.Project)
                      .WithMany(o => o.CodeRepositories)
                      .HasForeignKey(c => c.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(c => c.Contributors)
                      .WithOne(cc=> cc.CodeRepository)
                      .HasForeignKey(cc => cc.CodeRepositoryId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(c => c.PullRequests)
                      .WithOne(pr => pr.CodeRepository)
                      .HasForeignKey(pr => pr.CodeRepositoryId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(p => p.NodeId).IsUnique();

            });

            // CodeRepositoryContributor MEMBER CONFIG (Join table)
            modelBuilder.Entity<CodeRepositoryContributor>(entity =>
            {
                entity.HasKey(cc => new { cc.CodeRepositoryId, cc.UserId });

                entity.HasOne(cc => cc.CodeRepository)
                      .WithMany(c => c.Contributors)
                      .HasForeignKey(cc => cc.CodeRepositoryId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(cc => cc.User)
                      .WithMany(u => u.CodeRepositoryContributions)
                      .HasForeignKey(om => om.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // PullRequests CONFIG
            modelBuilder.Entity<PullRequest>(entity =>
            {
                entity.HasKey(p => p.PullRequestId);
                entity.HasIndex(pr => pr.PRClosedAt);// indexings
                entity.HasIndex(pr => pr.PRMergedAt);// indexings
                entity.HasOne(p => p.User)
                      .WithMany(u => u.PullRequests)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.CodeRepository)
                      .WithMany(c => c.PullRequests)
                      .HasForeignKey(p => p.CodeRepositoryId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Project)
                     .WithMany(p => p.PullRequests)
                     .HasForeignKey(p => p.ProjectId)
                     .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(p => p.NodeId).IsUnique();
            });



        }
    }
}
