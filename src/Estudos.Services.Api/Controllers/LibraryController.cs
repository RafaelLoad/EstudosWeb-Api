//using Estudos.Application.Interfaces;
//using Estudos.Domain.Entities;
//using Estudos.Domain.ViewModel;
//using Microsoft.AspNetCore.Mvc;

//namespace Estudos.Services.Api.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class LibraryController : ControllerBase
//    {
//        private readonly ILibraryService _libraryService;
//        private readonly ILogger<LibraryController> _logger;

//        public LibraryController
//        (
//            ILogger<LibraryController> logger, 
//            ILibraryService libraryService
//        )
//        {
//            _logger = logger;
//            _libraryService = libraryService;
//        }


//        [HttpPost("Create")]
//        public async Task<IActionResult> Add(LibraryViewModel obj)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }
//            _libraryService.Add(obj);

//            return NoContent();
//        }

//        [HttpGet("GetById/Id")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            return Ok(_libraryService.GetById(id));
//        }

//        [HttpGet("GetAll")]
//        public async Task<IActionResult> GetAll(string nomeProduto)
//        {
//            var obj = new LibraryViewModel
//            {
//                Nome = "a",
//                Sobrenome = "b"
//            };

//            return Ok(_libraryService.GetAll(obj));
//        }

//        [HttpGet("Alter")]
//        public async Task<IActionResult> Alter(LibraryViewModel obj)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            return Ok(_libraryService.Alter(obj));
//        }

//        [HttpDelete("Delete")]
//        public async Task<IActionResult> Delete(LibraryViewModel obj)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            return Ok(_libraryService.Delete(obj));
//        }
//    }
//}