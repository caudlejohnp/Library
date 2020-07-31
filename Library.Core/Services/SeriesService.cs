using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public class SeriesService :ISeriesService
    {
        private readonly ISeriesRepository _seriesRepo;

        public SeriesService(ISeriesRepository seriesRepo)
        {
            _seriesRepo = seriesRepo;
        }

        public Series Add(Series series)
        {
            return _seriesRepo.Add(series);
        }

        public Series Get(int id)
        {
            return _seriesRepo.Get(id);
        }

        public IEnumerable<Series> GetAll()
        {
            return _seriesRepo.GetAll();
        }

        public void Remove(int id)
        {
            var removeSeries = _seriesRepo.Get(id);
            _seriesRepo.Remove(removeSeries);
        }

        public Series Update(Series updatedSeries)
        {
            return _seriesRepo.Update(updatedSeries);
        }
    }
}
