﻿using ManageAPI.Model;
using ManageAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ManageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpPost("GetPaging")]
        public async Task<IActionResult> GetPaging([FromBody]PageInfo paging)
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(10));

                var result = await _schoolRepository.GetPaging(paging);

                source.Token.ThrowIfCancellationRequested();
                return Ok(result);
            }
            catch (TaskCanceledException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(10));

                var result = await _schoolRepository.GetAll();

                source.Token.ThrowIfCancellationRequested();
                return Ok(result);
            }
            catch (TaskCanceledException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(10));

                var result = await _schoolRepository.GetByID(id);

                source.Token.ThrowIfCancellationRequested();
                return Ok(result);
            }
            catch (TaskCanceledException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(10));

                await _schoolRepository.Delete(id);

                source.Token.ThrowIfCancellationRequested();
                return Ok();
            }
            catch (TaskCanceledException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(School entity)
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(10));

                entity.UpdatedDate = DateTime.Now;
                await _schoolRepository.Update(entity);

                source.Token.ThrowIfCancellationRequested();
                return Ok();
            }
            catch (TaskCanceledException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(School entity)
        {
            try
            { 
                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(TimeSpan.FromSeconds(10));

                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;

                await _schoolRepository.Add(entity);
                source.Token.ThrowIfCancellationRequested();
                return Ok();
            }
            catch (TaskCanceledException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
