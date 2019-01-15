using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Horizone.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Horizone", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Colaborateur> Colaborateurs { get; set; }
        public DbSet<ObjectManuscript> ObjectManuscripts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DictionaryTocharian> DictionaryTocharians { get; set; }
        public DbSet<ImageDictionary> ImageDictionarys { get; set; }
        public DbSet<ImageManuscript> ImageManuscripts { get; set; }
        public DbSet<ImageNews> ImageNews { get; set; }
        public DbSet<Manuscript> Manuscripts { get; set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<Provenience> Proveniences { get; set; }
        public DbSet<TextContent> TextContents { get; set; }
        public DbSet<TochPhrase> TochPhrases { get; set; }
        public DbSet<TochStory> TochStorys { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Transcription> Transcriptions { get; set; }
        public DbSet<Bibliography> Bibliographys { get; set; }
        public DbSet<MainContent> MainContents { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Activity> Activitys { get; set; }
    }
}