using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRecordProject.Domain.Abstract;
using TestRecordProject.Domain.Entities;
using TestRecordProject.Domain.TRPContext;

namespace TestRecordProject.Domain.Concrete
{
    public class EFTestRepository : IRepository<Test>
    {
        EFDbContext context = new EFDbContext();
        public IQueryable<Test> QueryEntities
        {
            get
            {
               return context.tests;
            }
        }

        public void DeleteEntities(Test t)
        {
            using (EFDbContext context = new EFDbContext())
            {
                Test dbEntry = context.tests.Find(t.id);
                if (dbEntry != null)
                {
                    context.tests.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
        }

        public void SaveEntities(Test t)
        {
            using (EFDbContext context = new EFDbContext())
            {
                if (t.id == 0)
                {
                    context.tests.Add(t);
                }
                else
                {
                    Test dbEntry = context.tests.Find(t.id);
                    if (dbEntry != null)
                    {
                        dbEntry.id = t.id;
                        dbEntry.name = t.name;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
