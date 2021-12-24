using API.Repository;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
    where Entity : class
    where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<Entity> Get()
        {

            try
            {
                var result = repository.Get();
                if (result.Count() > 0)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = $" {result.Count()} Data Berhasil Didapatkan" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] silahkan tambah data" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }

        [HttpGet("{Key}")]
        public ActionResult<Entity> Get(Key key)
        {

            try
            {
                var result = repository.Get(key);
                if (result != null)
                {
                    return Ok(new { status = StatusCodes.Status200OK, result, message = $" Data Berhasil Didapatkan dengan parameter {key}" });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] dengan paramter {key}" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }
        [HttpPost]
        public ActionResult<Entity> Post(Entity entity)
        {
            try
            {
                var result = repository.Insert(entity);
                switch (result)
                {
                    case 1:
                        return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                        break;
                    default:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database [{ControllerContext.ActionDescriptor.ControllerName}]" });
                        break;
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }
        [HttpPut]
        public ActionResult<Entity> Put(Entity entity)
        {
            try
            {
                var result = repository.Update(entity);
                switch (result)
                {
                    case 1:
                        return Ok(new { status = StatusCodes.Status200OK, result, message = $"Data Berhasil Diubah dan Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                        break;
                    default:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal diubah di[{ControllerContext.ActionDescriptor.ControllerName}]" });
                        break;
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }

        }
        [HttpDelete("{key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            try
            {
                var result = repository.Delete(key);
                switch (result)
                {
                    case 1:
                        return Ok(new { status = StatusCodes.Status200OK, result, message = "Data Berhasil Dihapus" });
                        break;
                    default:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data {key} Tidak ditemukan  atau sudah dihapus di[{ControllerContext.ActionDescriptor.ControllerName}]" });
                        break;
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }

        }
    }
}
