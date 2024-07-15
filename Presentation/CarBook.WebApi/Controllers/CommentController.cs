﻿using CarBook.Application.Features.Mediator.Commands.CommentCommand;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;

        public CommentController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList() 
        {
            var values=_commentRepository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment) 
        {
            _commentRepository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id) 
        {
            var value =_commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value=_commentRepository.GetById(id);
            return Ok(value);
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _commentRepository.GetCommentByBlogId(id);
            return Ok(value);
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog (int id)
        {
            var value=_commentRepository.GetCountCommentByBlog(id);
            return Ok(value);
        }
        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand comment)
        {
            await _mediator.Send(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }
    }
}