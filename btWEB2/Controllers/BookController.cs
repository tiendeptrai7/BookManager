using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btWEB2.Models;

namespace btWEB2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        Model1 context = new Model1();
        // GET: ListBook
        public ActionResult ListBook()
        {
            var listBook = context.Books.ToList();
            return View(listBook);
        }

        [Authorize]
        public ActionResult Buy (int id)
        {
            Model1 context = new Model1();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }    
            return View(book);
        }


        // CREATE
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Title, Description, Author, Images, Price")] Models.Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Books.AddOrUpdate(book);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            context.SaveChanges();
            var books = context.Books.ToList();
            return View("ListBook", books);
        }



        // EDIT: Book
        [Authorize]
        public ActionResult Edit(int id)
        {
            Models.Book book = context.Books.FirstOrDefault(x => x.ID == id);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Book book)
        {
            Models.Book book1 = context.Books.SingleOrDefault(x => x.ID == id);
            book1.Title = book.Title;
            book1.Description = book.Description;
            book1.Author = book.Author;
            book1.Images = book.Images;
            book1.Price = book.Price;
            context.Books.AddOrUpdate(book1);
            context.SaveChanges();
            var books = context.Books.ToList();
            return View("ListBook", books);
        }



        [Authorize]
        // DELETE: Book
        public ActionResult Delete(int id)
        {
            Models.Book book = context.Books.FirstOrDefault(x => x.ID == id);
            ViewBag.IDBook = book.ID;
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int id)
        {
            Models.Book book = context.Books.FirstOrDefault(x => x.ID == id);
            ViewBag.IDBook = book.ID;
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }


        public ActionResult Details(int id)
        {
            Models.Book book = context.Books.FirstOrDefault(x => x.ID == id);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(book);
        }





    }
}