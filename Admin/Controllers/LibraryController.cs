using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.DAL;
using Admin.Models;
using System.Data.Entity;

namespace Admin.Controllers
{
    public class LibraryController : Controller
    {
        AdminContext db = new AdminContext();

        // GET: Library
        public ActionResult Index()
        {
            var items = from i in db.LibraryItem.Include(d => d.LibraryItemGroup).Include(d => d.LibraryItemType)
                        //where i.Title == ""
                        orderby i.Title ascending
                        select i;

            return View(items);
        }

        public ActionResult Details(int id)
        {
            LibraryItem item = new LibraryItem();
            item = db.LibraryItem.Find(id);

            return View(item);
        }

        // GET: test/Create
        public ActionResult Create()
        {
            PopulateDDL();
            return View();
        }

        // POST: test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LibraryItem item = new LibraryItem();

                    TryUpdateModel(item);

                    db.LibraryItem.Add(item);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void PopulateDDL(object selectedGroupName = null, object selectedTypeName = null)
        {
            // populate DropDownList for ItemGroup
            var ItemGroup = from d in db.LibraryItemGroup
                                   orderby d.GroupName
                                   select d;
            ViewBag.LibraryItemGroupID = new SelectList(ItemGroup, "LibraryItemGroupID", "GroupName", selectedGroupName);

            // populate DropDownList for ItemType
            var ItemType = from e in db.LibraryItemType
                            orderby e.TypeName
                            select e;
            ViewBag.LibraryItemTypeID = new SelectList(ItemType, "LibraryItemTypeID", "TypeName", selectedTypeName);

        }

        // GET: test/Edit/5
        public ActionResult Edit(int id)
        {
            LibraryItem item = new LibraryItem();
            item = db.LibraryItem.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: test/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(LibraryItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: test/Delete/5
        public ActionResult Delete(int id)
        {
            LibraryItem item = new LibraryItem();
            item = db.LibraryItem.Find(id);

            return View(item);
        }

        // POST: test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                LibraryItem item = new LibraryItem();
                item = db.LibraryItem.Find(id);
                db.LibraryItem.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}