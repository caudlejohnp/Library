using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface ISeriesService
    {
        Series Add(Series series);
        Series Get(int id);
        IEnumerable<Series> GetAll();
        void Remove(int id);
        Series Update(Series updatedSeries);
    }
}
