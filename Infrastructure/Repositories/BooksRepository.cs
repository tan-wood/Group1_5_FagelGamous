using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BooksRepository : GeneralRepository<Book>
    {
        public BooksRepository(MummyContext context) : base(context)
        {
        }
    }
}
