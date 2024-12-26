﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() 
        {

            var result = _blogService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(Blog blog) 
        {

            var result = _blogService.Add(blog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(Blog blog) 
        {

            var result = _blogService.Delete(blog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(Blog blog)
        {

            var result = _blogService.Update(blog); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _blogService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
