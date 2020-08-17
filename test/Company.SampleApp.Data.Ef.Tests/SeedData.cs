#region Using Statements
#endregion

namespace Company.SampleApp.Data.Ef.Tests
{
    public class SeedData
    {
        private readonly MockDbContext _context;
        public SeedData(MockDbContext context)
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
			foreach (var item in new Domain.MockData.Models.ChildResources().GetAll())
			{
				_context.ChildResources.Add(item);
			}
		}

		private void SeedResources() 
		{
			foreach (var item in new Domain.MockData.Models.Resources().GetAll())
			{
				_context.Resources.Add(item);
			}
		}



    }
}
