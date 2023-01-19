using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Dosya");
            workSheet.Cells[1, 1].Value = "Ürün Adı";
            workSheet.Cells[1, 2].Value = "Ürün Kategorisi";
            workSheet.Cells[1, 3].Value = "Ürün Stok";

            workSheet.Cells[2, 1].Value = "Mercimek";
            workSheet.Cells[2, 2].Value = "Bakliyat";
            workSheet.Cells[2, 3].Value = "785 Kg";


            workSheet.Cells[3, 1].Value = "Buğday";
            workSheet.Cells[3, 2].Value = "Bakliyat";
            workSheet.Cells[3, 3].Value = "785 Kg";

            workSheet.Cells[4, 1].Value = "Havuç";
            workSheet.Cells[4, 2].Value = "Sebze";
            workSheet.Cells[4, 3].Value = "167 Kg";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");
        }
        public List<ContactModel> ContactList()
		{
            List<ContactModel> contacts = new List<ContactModel>();
			using (var context = new AgricultureContext())
			{
                contacts = context.Contacts.Select(x => new ContactModel
                {
                    Id=x.ContactID,
                    Name = x.Name,
                    Date = x.Date,
                    Mail = x.Mail,
                    Message = x.Message,
                }).ToList();
			}
            return contacts;
		}
        public IActionResult MessageReport()
		{
			using (var workBook = new XLWorkbook())
			{
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mesaj Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
				foreach (var contact in ContactList())
				{
                    workSheet.Cell(contactRowCount, 1).Value = contact.Id;
                    workSheet.Cell(contactRowCount, 2).Value = contact.Name;
                    workSheet.Cell(contactRowCount, 3).Value = contact.Mail;
                    workSheet.Cell(contactRowCount, 4).Value = contact.Message;
                    workSheet.Cell(contactRowCount, 5).Value = contact.Date.ToString("dd/MM/yyyy");
                    contactRowCount++;
				}
				using (var stream = new MemoryStream())
				{
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporu.xlsx");
				}
			}
		}
        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcements = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                announcements = context.Announcements.Select(x => new AnnouncementModel
                {
                    Id = x.AnnouncementID,
                    Title = x.Title,
                    Date = x.Date,
                    Description = x.Description,
                    Status = x.Status,
                    
                }).ToList();
            }
            return announcements;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Duyuru Açıklaması";
                workSheet.Cell(1, 4).Value = "Duyuru Durumu";
                workSheet.Cell(1, 5).Value = "Duyuru Tarihi";

                int announcementRowCount = 2;
                foreach (var announcement in AnnouncementList())
                {
                    workSheet.Cell(announcementRowCount, 1).Value =announcement.Id;
                    workSheet.Cell(announcementRowCount, 2).Value = announcement.Title;
                    workSheet.Cell(announcementRowCount, 3).Value = announcement.Description;
                    workSheet.Cell(announcementRowCount, 4).Value = announcement.Status == true ? "Aktif" : "Pasif";
                    workSheet.Cell(announcementRowCount, 5).Value = announcement.Date.ToString("dd/MM/yyyy");
                    announcementRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    Guid id = Guid.NewGuid();
                    var fileName = id.ToString();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.xlsx");
                }
            }
        }

    }
}
