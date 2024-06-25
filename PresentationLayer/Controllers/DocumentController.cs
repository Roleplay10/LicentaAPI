using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
                _documentService = documentService;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> AddDocument(string id, [FromForm] IFormFile document, [FromForm] string type)
        {
                if (document == null || document.Length == 0)
                {
                        return BadRequest("File is empty or not provided.");
                }
                await _documentService.AddDocument(id, document, type);
                return Ok();
        }
}