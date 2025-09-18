using Microsoft.AspNetCore.Mvc;
using DenemeYapiyorum.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using System.Linq;

public class RaporController : Controller
{
    private readonly DbBaglantisi _context;

    public RaporController(DbBaglantisi context)
    {
        _context = context;
    }

    public IActionResult ExportExcel()
    {
        // ✅ EPPlus 8 uyumlu lisans ayarı
        ExcelPackage.License.SetNonCommercialPersonal("Kullanıcı Adınız");

        var kisiler = _context.Kisiler.ToList();
        var arabalar = _context.Arabalar.ToList();

        using var package = new ExcelPackage();

        // 🧾 Kişiler Sayfası
        var wsKisiler = package.Workbook.Worksheets.Add("Kisiler");
        wsKisiler.Cells[1, 1].Value = "ID";
        wsKisiler.Cells[1, 2].Value = "Ad";
        wsKisiler.Cells[1, 3].Value = "Soyad";
        wsKisiler.Cells[1, 4].Value = "TC";

        using (var range = wsKisiler.Cells[1, 1, 1, 4])
        {
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        int row = 2;
        foreach (var k in kisiler)
        {
            wsKisiler.Cells[row, 1].Value = k.KisiId;
            wsKisiler.Cells[row, 2].Value = k.KisiAdi;
            wsKisiler.Cells[row, 3].Value = k.KisiSoyadi;
            wsKisiler.Cells[row, 4].Value = k.KisiTc;
            row++;
        }

        wsKisiler.Cells[wsKisiler.Dimension.Address].AutoFitColumns();

        // 🚗 Arabalar Sayfası
        var wsArabalar = package.Workbook.Worksheets.Add("Arabalar");
        wsArabalar.Cells[1, 1].Value = "ID";
        wsArabalar.Cells[1, 2].Value = "Araba Adı";
        wsArabalar.Cells[1, 3].Value = "Renk";
        wsArabalar.Cells[1, 4].Value = "Model";

        using (var range = wsArabalar.Cells[1, 1, 1, 4])
        {
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        row = 2;
        foreach (var a in arabalar)
        {
            wsArabalar.Cells[row, 1].Value = a.ArabaId;
            wsArabalar.Cells[row, 2].Value = a.ArabaAdi;
            wsArabalar.Cells[row, 3].Value = a.ArabaRengi;
            wsArabalar.Cells[row, 4].Value = a.ArabaModeli;
            row++;
        }

        wsArabalar.Cells[wsArabalar.Dimension.Address].AutoFitColumns();

        // 📤 Excel dosyasını tarayıcıya gönder
        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        var fileName = $"KisiVeAraba_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

        return File(stream,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName);
    }
}
