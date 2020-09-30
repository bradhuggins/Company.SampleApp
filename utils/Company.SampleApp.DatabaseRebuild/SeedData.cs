#region Using Statements
using Company.SampleApp.Data.Ef;
#endregion

namespace Company.SampleApp.DatabaseRebuild
{
    public class SeedData
    {
        private readonly AppDbContext _context;
        public SeedData(AppDbContext context)
        {
            _context = context;
            this.Seed();
        }

        private void Seed()
        {
			this.SeedChildResources();
			this.SeedResources();

            _context.SaveChanges();
        }
		
		private void SeedChildResources() 
		{
			foreach (var item in new Domain.MockData.Models.ChildResources().SeedData())
			{
				_context.ChildResources.Add(item);
			}
		}

		private void SeedResources() 
		{
			foreach (var item in new Domain.MockData.Models.Resources().SeedData())
			{
				_context.Resources.Add(item);
			}
		}



    }
}
