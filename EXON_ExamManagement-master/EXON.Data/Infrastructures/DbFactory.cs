namespace EXON.Data.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private static RMDbContext dbContext;

        public RMDbContext Init()
        {
            return dbContext ?? (dbContext = new RMDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}