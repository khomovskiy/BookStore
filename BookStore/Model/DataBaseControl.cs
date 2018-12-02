using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class DataBaseControl
    {
        static DataBaseControl _DBControlInstance;
        public DatabaseContext Ctx { get; set; }
        public class DatabaseContext : DbContext
        {
            public DatabaseContext() : base("defaultConnection") { }

            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }

            
        }

        public class DbInitialize :  DropCreateDatabaseAlways<DatabaseContext>
        {
            protected override void Seed(DatabaseContext ctx)
            {
                Author a1 = new Author { FirstName = "Firstname 1", LastName = "Lastname 1" };
                Author a2 = new Author { FirstName = "Firstname 2", LastName = "Lastname 2" };
                Author a3 = new Author { FirstName = "Firstname 3", LastName = "Lastname 3" };

                ctx.Books.AddRange(new Book[] {
                new Book {
                    Pages = 200,
                    Title = "Title 1",
                    Authors = new List<Author> { a1, a3 }
                },
                new Book
                {
                    Pages = 450,
                    Title = "Title 2",
                    Authors = new List<Author> { a2, a3 }
                }
            });

                ctx.SaveChanges();
            }
        }
        private DataBaseControl()
        {
            Database.SetInitializer(new DbInitialize());
            Ctx = new DatabaseContext();
        }
        public static DataBaseControl GetDataBaseControlInstance()
        {
            if (_DBControlInstance is null) _DBControlInstance = new DataBaseControl();
            return _DBControlInstance;
        }

        

    }
}
