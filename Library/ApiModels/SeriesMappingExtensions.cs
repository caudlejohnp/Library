﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.ApiModels
{
    public static class SeriesMappingExtensions
    {
        public static SeriesModel ToApiModel(this Series series)
        {
            return new SeriesModel
            {
                Id = series.Id,
                SeriesName = series.SeriesName,
                SeriesNumber = series.SeriesNumber
            };
        }

        public static Series ToDomainModel(this SeriesModel seriesModel)
        {
            return new Series
            {
                Id = seriesModel.Id,
                SeriesNumber = seriesModel.SeriesNumber,
                SeriesName = seriesModel.SeriesName
            };
        }

        public static IEnumerable<SeriesModel> ToApiModels(this IEnumerable<Series> series)
        {
            return series.Select(s => s.ToApiModel());
        }

        public static IEnumerable<Series> ToDomainModels(this IEnumerable<SeriesModel> seriesModels)
        {
            return seriesModels.Select(s => s.ToDomainModel());
        }
    }
}
