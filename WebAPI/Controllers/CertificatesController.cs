﻿using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController :BaseController
    {
        ICertificateService _certificateService;

        public CertificatesController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _certificateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(Certificate certificate)
        {

            var result = _certificateService.Add(certificate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(Certificate certificate)
        {

            var result = _certificateService.Delete(certificate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(Certificate certificate)
        {

            var result = _certificateService.Update(certificate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("updatecertificate")]
        public IActionResult UpdateCertificate(CertificatesDto certificatesDto) 
        {
            int userId = GetUserIdFromToken();
            certificatesDto.UserId = userId;
            var result = _certificateService.UpdateCertificate(certificatesDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _certificateService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getByUserId")]
        public IActionResult getByUserId() 
        {
            int userId = GetUserIdFromToken();
            var result = _certificateService.GetByUserId(userId);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
