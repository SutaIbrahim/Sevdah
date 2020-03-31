using iTextSharp.text;
using iTextSharp.text.pdf;
using Sevdah.Models;
using Sevdah.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Helpers
{
    public class SkladisteReport
    {
        int _totalColumns = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        SkladistePrikaziPdfVM _skladistePodaci = new SkladistePrikaziPdfVM();
        DateTime datum = DateTime.Now;

        public byte[] PrepareReport(SkladistePrikaziPdfVM skladistePodaci)
        {
            _skladistePodaci = skladistePodaci;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] {20f, 50f, 50f});


            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();
        }
        private void ReportHeader()
        {
            //Image slika = Image.GetInstance("https://image.ibb.co/n6Afax/rsz_sevdahlogo_color_v1.png");
            //_document.Add(slika);

            Image slika = Image.GetInstance("wwwroot/images/SevdahLogo_Color_v1.png");
            slika.ScaleAbsoluteHeight(70);
            slika.ScaleAbsoluteWidth(51);
            _document.Add(slika);

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Pržionica kafe", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("O.R \"Sevdah\"", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("BISCE POLJE b.b", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Mostar", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Tel: 061-164-879", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Email: sewdah@gmail.com", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("ŽIRO-RACUN br. 194-105-11436011-88", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Pro Credit Bank", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("ID: 4327537010006", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("PDV: 327537010006", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingBottom = 20f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 16f, 1);
            _pdfPCell = new PdfPCell(new Phrase("STANJE SKLADIŠTA", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingBottom = 15f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();



        }
        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);

            _pdfPCell = new PdfPCell(new Phrase("R.Br.", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Naziv artikla", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Kolicina u kg", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

                             

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            int serialNumber = 1;
            int brojac = 1;
            foreach (Skladiste stavka in _skladistePodaci._listaProizvoda)
            {
                _pdfPCell = new PdfPCell(new Phrase((brojac++).ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(stavka.VrstaKafe.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.KolicinaUKg,2).ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();
            }


            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DATUM: " + datum.ToShortDateString(), _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 10f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

        }
    }
}
