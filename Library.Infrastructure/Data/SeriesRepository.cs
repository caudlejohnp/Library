using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Core.Models;
using Library.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly AppDbContext _dbContext;

        public SeriesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Series Add(Series series)
        {
            _dbContext.Add(series);
            _dbContext.SaveChanges();
            return series;
        }

        public Series Get(int id)
        {
            return _dbContext.Series
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Series> GetAll()
        {
            return _dbContext.Series
                .Include(b => b.Books)
                .ThenInclude(a => a.Author)
                .ToList();
        }

        public void Remove(Series removeSeries)
        {
            _dbContext.Series.Remove(removeSeries);
            _dbContext.SaveChanges();
        }

        public Series Update(Series updatedSeries)
        {
            var currentSeries = _dbContext.Series.Find(updatedSeries.Id);
            if (currentSeries == null) return null;

            _dbContext.Entry(currentSeries)
                .CurrentValues
                .SetValues(updatedSeries);

            _dbContext.Series.Update(currentSeries);
            _dbContext.SaveChanges();
            return currentSeries;
        }
    }
}
