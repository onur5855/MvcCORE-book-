using Microsoft.AspNetCore.Mvc;
using MvcCORE.Infrastructure.RepoSitories.Interface.EntityRepo;
using MvcCORE.Models.DataTransferObject.AuthorDTO;
using MvcCORE.Models.Entities.Concrete;
using MvcCORE.Models.Enum;

namespace MvcCORE.Controllers
{
    public class AuthorController1 : Controller
    {
        private readonly IAuthorRepository repo;

        public AuthorController1(IAuthorRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AuthorCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author();
                author.LastName = dto.LastName;
                author.FirstName = dto.FirstName;
                repo.Create(author);
                return RedirectToAction("List");
            }
            else return View(dto);
        }

        public IActionResult List()
        {
            return View(repo.GetDefaults(a=>a.status!=Status.Passive));
        }

        public IActionResult Update(int id)
        {
            Author author = repo.GetDefault(a => a.ID == id);
            AuthorUpdateDTO DTO = new AuthorUpdateDTO();
            DTO.LastName = author.LastName;
            DTO.FirstName = author.FirstName;
            DTO.ID = author.ID;

            return View(DTO);
        }
        [HttpPost]
        public IActionResult Update(AuthorUpdateDTO dto)
        {
            Author author = repo.GetDefault(a => a.ID == dto.ID);//guncellenecek eleman

            author.LastName = dto.LastName;
            author.FirstName = dto.FirstName;
            repo.Update(author);
            return RedirectToAction("list");
        }
        public IActionResult Detail(int id)
        {
            return View(repo.GetDefault(a=>a.ID==id));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Author author = repo.GetDefault(a => a.ID == id);
           
            return View(author);
        }
        [HttpPost]
        public IActionResult Delete(Author model)
        {
            Author author = repo.GetDefault(a => a.ID == model.ID);
            repo.Delete(author);
            return RedirectToAction("List");
        }


    }
}
