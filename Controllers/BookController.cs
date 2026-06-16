using Microsoft.AspNetCore.Mvc;
using ORM1.Data;
using ORM1.Models;

namespace ORM1.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository;

        public BookController(BookRepository repository)
        {
            _repository = repository;
        }

        // Danh sách
        public IActionResult Index()
        {
            var books = _repository.GetAll();
            return View(books);
        }

        // Form thêm
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repository.Add(book);
            return RedirectToAction(nameof(Index));
        }

        // Form sửa
        public IActionResult Edit(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _repository.Update(book);
            return RedirectToAction(nameof(Index));
        }

        // Xóa
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}