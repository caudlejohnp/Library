using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface ISeriesRepository
    {
        //Create
        Series Add(Series series);

        //Read
        Series Get(int id);

        //Update
        Series Update(Series updatedSeries);

        //Remove
        void Remove(Series removeSeries);

        //List
        IEnumerable<Series> GetAll();
    }
}
