using IVYmodaONLINE.Models;
using IVYmodaONLINE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVYmodaONLINE.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/Product
        /*        public ActionResult Index(int? page)
                {
                    IEnumerable<Product> items = _dbContext.Products.OrderByDescending(x => x.Id);
                    var pageSize = 10;
                    if (page == null)
                    {
                        page = 1;
                    }
                    var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                    items = items.ToPagedList(pageIndex, pageSize);
                    ViewBag.PageSize = pageSize;
                    ViewBag.Page = page;
                    return View();
                }*/
        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            var pageNumber = (page ?? 1);

            IEnumerable<Product> items = _dbContext.Products.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(_dbContext.Productcategories.ToList(), "Id", "Title");
            return View();
        }
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rdDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rdDefault[0])
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDeFault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDeFault = false
                            });
                        }
                    }
                }
                model.createDate = DateTime.Now;
                model.Modifiedrdate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = IVYmodaONLINE.Models.Common.Filter.FilterChar(model.Title);
                _dbContext.Products.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(_dbContext.Productcategories.ToList(), "Id", "Title");
            return View(model);
        }*/
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rdDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rdDefault[0])
                        {
                            _dbContext.ProductImages.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDeFault = true
                            });
                        }
                        else
                        {
                            _dbContext.ProductImages.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDeFault = false
                            });
                        }
                    }
                }
                model.createDate = DateTime.Now;
                model.Modifiedrdate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = IVYmodaONLINE.Models.Common.Filter.FilterChar(model.Title);
                _dbContext.Products.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(_dbContext.Productcategories.ToList(), "Id", "Title");
            return View(model);
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                model.createDate = DateTime.Now;
                model.Modifiedrdate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = IVYmodaONLINE.Models.Common.Filter.FilterChar(model.Title);

                // Thêm sản phẩm vào bảng Products
                _dbContext.Products.Add(model);
                _dbContext.SaveChanges(); // Lưu để có ID của sản phẩm

                if (Images != null && Images.Count > 0)
                {
                    var productImages = new List<ProductImage>();

                    for (int i = 0; i < Images.Count; i++)
                    {
                        var isDefault = (i + 1 == rDefault[0]);

                        var productImage = new ProductImage
                        {
                            ProductId = model.Id, // Lấy ID của sản phẩm vừa thêm
                            Image = Images[i],
                            IsDeFault = isDefault
                        };

                        productImages.Add(productImage);
                    }

                    // Thêm danh sách ảnh vào bảng ProductImage
                    _dbContext.ProductImages.AddRange(productImages);
                    _dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.ProductCategory = new SelectList(_dbContext.Productcategories.ToList(), "Id", "Title");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategory = new SelectList(_dbContext.Productcategories.ToList(), "Id", "Title");
            var item = _dbContext.Products.Find(id);
            return View(item);
        }
    }
}