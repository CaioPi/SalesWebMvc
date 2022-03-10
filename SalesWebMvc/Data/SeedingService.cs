using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Sellers.Any() ||
                _context.SalesRecords.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Eletronics");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria", "maria@gmail.com", new DateTime(1919, 4, 24), 1500.0, d2);
            Seller s3 = new Seller(3, "Caio", "caio@gmail.com", new DateTime(2000, 4, 21), 1300.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2022, 01, 05), 2.500, SaleStatus.Billed, s3);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2022, 07, 13), 2.900, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2);
            _context.Sellers.AddRange(s1, s2);
            _context.SalesRecords.AddRange(r1, r2);
            _context.SaveChanges();
        }
    }
}
