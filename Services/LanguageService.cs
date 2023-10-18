using Microsoft.EntityFrameworkCore;
using restful_crud_asp.Data;
using restful_crud_asp.net.Models;

namespace restful_crud_asp.Services{
    public class LanguageService{
        private readonly LanguageContext _context;

        public LanguageService(LanguageContext context){
            _context = context;
        }

        public async Task<List<Language>> SelectAll(){
            return await _context.Language.ToListAsync();
        }

        public async Task<Language> SelectById(int id){
            return await _context.Language.FindAsync(id);
        }

        public async Task CreateLanguage(Language language){
            _context.Language.Add(language);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLanguage(Language language){
            _context.Entry(language).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLanguage(Language language){
            _context.Language.Remove(language);
            await _context.SaveChangesAsync();
        }

    }
}