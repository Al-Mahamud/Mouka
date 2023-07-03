using Mauka.Entities;
using Mouka.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouka.Services
{
    public class ReportService
    {
        public Report GetReport(int ID)
        {
            using (var context = new MoukaContext())
            {
                return context.Reports.Find(ID);
            }
        }
        public List<Report> GetReports()
        {
            using (var context = new MoukaContext())
            {
                return context.Reports.ToList();
            }
        }
        public void SaveReport(Report report)
        {
            using (var context = new MoukaContext())
            {
                context.Reports.Add(report);

                context.SaveChanges();
            }
        }

        public void UpdateReport(Report report)
        {
            using (var context = new MoukaContext())
            {
                context.Entry(report).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteReport(int ID)
        {
            using (var context = new MoukaContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

                var report = context.Reports.Find(ID);
                context.Reports.Remove(report);

                context.SaveChanges();
            }
        }
        

    }
}
