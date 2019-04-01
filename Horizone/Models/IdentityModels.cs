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
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Collaboration> Collaborations { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DictionaryTocharian> DictionaryTocharians { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Number>Numbers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<WordClass> WordClasses { get; set; }
        public DbSet<WordSubClass> WordSubClasses { get; set; }
        public DbSet<ImageManuscript> ImageManuscripts { get; set; }
        public DbSet<ImageNews> ImageNews { get; set; }
        public DbSet<ImageCollaboration> ImageCollaborations { get; set; }
        public DbSet<VisualAid> VisualAids { get; set; }        
        public DbSet<Manuscript> Manuscripts { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<TochPhrase> TochPhrases { get; set; }
        public DbSet<TochStory> TochStorys { get; set; }
        public DbSet<NamePlace> NamePlaces { get; set; }
        public DbSet<ThemeStory> ThemeStorys { get; set; }
        public DbSet<SourceStory> SourceStorys { get; set; }
        public DbSet<ProperNoun> ProperNouns { get; set; }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<TochLanguage> TochLanguages { get; set; }
        public DbSet<Bibliography> Bibliographys { get; set; }
        public DbSet<LinkAndPress> LinkAndPresses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Activity> Activitys { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<AboutProject> AboutProjets { get; set; }     
        public DbSet<AnalyseMaterial> AnalyseMaterials { get; set; }
        public DbSet<ImageUV> ImageUVs { get; set; }
        public DbSet<ImageAnalyse> ImageAnalyses { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
    }
}