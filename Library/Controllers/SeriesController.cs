using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.ApiModels;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {

        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: api/<SeriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var series = _seriesService.GetAll().ToApiModels();
            return Ok(series);
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var series = _seriesService.Get(id).ToApiModel();
            if (series == null) return null;
            return Ok(series);
        }

        // POST api/<SeriesController>
        [HttpPost]
        public IActionResult Post([FromBody] SeriesModel newSeries)
        {
            var series = _seriesService.Add(newSeries.ToDomainModel());
            if (series == null) return BadRequest();
            return CreatedAtAction("Get", new { newSeries.Id }, newSeries);
        }

        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] SeriesModel updatedSeries)
        {
            var series = _seriesService.Update(updatedSeries.ToDomainModel());
            if (series == null) BadRequest();
            return Ok(series);
        }


        // TODO Check delete function with nick or amy
        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _seriesService.Remove(id);
            return NoContent();
        }
    }
}
