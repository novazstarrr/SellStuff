namespace DataAccess.Repositories
{
    internal abstract class BaseRepository
    {
        protected ApplicationDbContext Context { get; set; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
