using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TotalStat
{
    public class DBManager
    {        
        public async void ScreenContextAdd(List<Screen> screenList)
        {
            ScreenContext db = new ScreenContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                var lol = db.Screens.AddRange(screenList);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;                
            }
        }
        public async void ScreenContextRemoveDate(DateTime date)
        {
            ScreenContext db = new ScreenContext();
            var dates = db.Screens.Where(p => p.Date == date);
            if (dates.Count() > 0)
            {
                db.Screens.RemoveRange(dates);
                await db.SaveChangesAsync();
                MessageBox.Show("Удаление DATA за " + date + " успешно завершено!");
            }
            else
            {
                MessageBox.Show("Дата не найдена!");
            }
        }
        public async void DescriptionContextAdd(List<Description> addFinvizToTable)
        {
            DescriptionContext db = new DescriptionContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                db.Database.ExecuteSqlCommand($"{Localize.Trunc}[{Localize.Finviz}]");
                db.Descriptions.AddRange(addFinvizToTable);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;                
            }
        }
        public async void BusinessContextAdd(List<Business> addAboutToTable)
        {
            BusinessContext db = new BusinessContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                db.Database.ExecuteSqlCommand($"{Localize.Trunc}[{Localize.About}]");
                db.Businesses.AddRange(addAboutToTable);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public async void SectorContextAdd(List<Sector> sectorList, int sectorLevel)
        {
            SectorContext db = new SectorContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                var delete_old_information = db.Sectors.Where(p => p.SectorLevel == sectorLevel);
                if (delete_old_information != null)
                {
                    db.Sectors.RemoveRange(delete_old_information);
                }
                db.Sectors.AddRange(sectorList);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public async void ReportContextAdd(List<Report> addReportToTable)
        {
            ReportContext db = new ReportContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                db.Reports.AddRange(addReportToTable);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public async void ReportContextAdd(Report report)
        {
            ReportContext db = new ReportContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                db.Reports.Add(report);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public async void ReportContextRemove(DateTime date)
        {
            ReportContext db = new ReportContext();
            var dates = db.Reports.Where(p => p.Date == date);
            if (dates.Count() == 0)
            {
                MessageBox.Show("Дата не найдена!");
            }
            else
            {
                db.Reports.RemoveRange(dates);
                await db.SaveChangesAsync();
                MessageBox.Show("Удаление репортов за " + date + "  успешно завершено!");
            }
        }
        public async void DividendContextAdd(List<Dividend> addDividendsToTable)
        {
            DividendContext db = new DividendContext();
            var transaction = db.Database.BeginTransaction();
            try
            {
                db.Dividends.AddRange(addDividendsToTable);
                await db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;                
            }
        }
        public async void DividendContextRemove(DateTime date)
        {
            DividendContext db = new DividendContext();
            var dates = db.Dividends.Where(p => p.Date == date);
            if (dates.Count() == 0)
            {
                MessageBox.Show("Дата не найдена!");
            }
            else
            {
                db.Dividends.RemoveRange(dates);
                await db.SaveChangesAsync();
                MessageBox.Show("Удаление дивидендов за " + date + " успешно завершено!");
            }
        }

    }


}

