﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _departmentService = departmentService;
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindALL();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindALL();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
