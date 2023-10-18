using Microsoft.AspNetCore.Mvc;
using restful_crud_asp.net.Models;
using restful_crud_asp.Services;

namespace restful_crud_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase{
        
        private readonly LanguageService _languageService;

        public LanguageController(LanguageService languageService){
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Language>>> SelectAll(){
            var list = await _languageService.SelectAll();

            if(list != null){
                return Ok(list);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> SelectById(int id){
            
            var language = await _languageService.SelectById(id);

            if(language != null){
                return Ok(language);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateLanguage([FromBody] Language language){
            await _languageService.CreateLanguage(language);
            return CreatedAtAction("SelectById", new {id=language.language_id}, language);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, [FromBody] Language language){
            
            var existingLanguage = await _languageService.SelectById(id);

            if (existingLanguage == null)
            {
             return NotFound();
            }

    // Update the existingLanguage object with the new values
            existingLanguage.Name = language.Name;

            await _languageService.UpdateLanguage(existingLanguage);

            return Ok(existingLanguage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id){

            var language = await _languageService.SelectById(id);

            if (language == null){
                return NotFound();
                }

            await _languageService.DeleteLanguage(language);
            return NoContent();

        }
    }

}