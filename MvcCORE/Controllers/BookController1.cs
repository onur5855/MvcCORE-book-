using Microsoft.AspNetCore.Mvc;
using MvcCORE.Infrastructure.RepoSitories.Interface.EntityRepo;
using MvcCORE.Models.Entities.Concrete;
using MvcCORE.Models.Enum;
using MvcCORE.Models.VMSSSSS;

namespace MvcCORE.Controllers
{
    public class BookController1 : Controller
    {
        private readonly IAuthorRepository autRepo;
        private readonly IBookRepository bookRepo;
        private readonly IDetailsRepository detayRepo;

        public BookController1(IAuthorRepository autRepo,IBookRepository bookRepo,IDetailsRepository detayRepo)
        {
            this.autRepo = autRepo;
            this.bookRepo = bookRepo;
            this.detayRepo = detayRepo;
        }
        void FillAuthor()
        {
            ViewBag.AuthorList = autRepo.GetDefaults(a => a.status != Status.Passive);
            
        }

        public IActionResult Crete()
        {
            FillAuthor();
            return View();
        }
        [HttpPost]
        public IActionResult Crete(CreateBookVmsssss model)
        {
            if (ModelState.IsValid)
            {
                Details details = new Details();
                details.Summary = model.Summary;
                details.Description = model.DetailDescription;

                Book book = new Book();
                book.PageNumber = model.PageNumber;
                book.Name = model.Name;
                book.Description = model.Description;

                book.AuthorID = model.AuthorID;
                book.BookAuthor = autRepo.GetDefault(a => a.ID == model.AuthorID);

                book.BookDetails = details;//kitabın detayı eklendi
                bookRepo.Create(book);//

                details.BookID = book.ID;
                detayRepo.Update(details);
                return RedirectToAction("List");
            }
            FillAuthor();
             return View(model);
        }

        public IActionResult List()
        {
            return View(bookRepo.GetDefaults(a=>a.status!=Status.Passive));
        }
        
        public IActionResult Deteils(int id)
        {
            return View(bookRepo.GetDefault(a=>a.ID==id));
        }
        public IActionResult Delete(int id)
        {
            Book deleted=bookRepo.GetDefault(a=>a.ID==id);
            bookRepo.Delete(deleted);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            FillAuthor();
            Book updated = bookRepo.GetDefault(a => a.ID == id);
            Details details=detayRepo.GetDefault(a=>a.ID== updated.DetailsID);
            UpdateBookVmsssss vm =new UpdateBookVmsssss();
            vm.Name = updated.Name;
            vm.PageNumber = updated.PageNumber;
            vm.ID= updated.ID;
            vm.Description= updated.Description;
            vm.AuthorID = updated.AuthorID;     //kitapdan geeln bilgiler


            vm.Summary= details.Summary;        //detaydan gelen bilgilerr
            vm.DetailDescription = details.Description;


            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(UpdateBookVmsssss model)
        {
            if (ModelState.IsValid)
            {
                Book updated = bookRepo.GetDefault(a => a.ID == model.ID);

                updated.Name = model.Name;
                updated.PageNumber = model.PageNumber;
                updated.Description = model.Description;
                updated.AuthorID = model.AuthorID;
                updated.BookAuthor = autRepo.GetDefault(a => a.ID == model.ID);
                updated.BookDetails.Summary = model.Summary;
                updated.BookDetails.Description = model.DetailDescription;
                bookRepo.Update(updated);
                return RedirectToAction("List");

            }
            FillAuthor();
            return View(model);
        }


    }
}
