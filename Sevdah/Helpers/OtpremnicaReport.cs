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
    public class OtpremnicaReport
    {
        int _totalColumns = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        OtpremnicaReportVM _otpremnicaPodaci = new OtpremnicaReportVM();

        public byte[] PrepareReport(OtpremnicaReportVM otpremnicaPodaci)
        {
            _otpremnicaPodaci = otpremnicaPodaci;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 10f, 50f, 50f });


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

            _fontStyle = FontFactory.GetFont("Tahoma", 13f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Pržionica kafe", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 13f, 1);
            _pdfPCell = new PdfPCell(new Phrase("O.R \"Sevdah\"", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("BISCE POLJE b.b", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("Mostar", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("Tel: 061-164-879", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("Email: sewdah@gmail.com", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("ŽIRO-RACUN br. 194-105-11436011-88", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("Pro Credit Bank", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("ID: 4327537010006", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("PDV: 327537010006", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            // PODACI O KUPCU


            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
            _pdfPCell = new PdfPCell(new Phrase("SUBJEKT:", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 5f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(this._otpremnicaPodaci._kupac.NazivKupca, _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase(this._otpremnicaPodaci._kupac.Grad.Naziv, _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            if (_otpremnicaPodaci._kupac.NazivKupca == "---")
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
                _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }
            else
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
                _pdfPCell = new PdfPCell(new Phrase("ID: " + _otpremnicaPodaci._kupac.ID_broj, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }

            if (_otpremnicaPodaci._kupac.NazivKupca == "---")
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
                _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = Rectangle.BOTTOM_BORDER;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
            }
            else
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
                _pdfPCell = new PdfPCell(new Phrase("PDV: " + this._otpremnicaPodaci._kupac.PDV_broj, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = Rectangle.BOTTOM_BORDER;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPCell.PaddingBottom = 10f;
                _pdfTable.AddCell(_pdfPCell);
            }

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            if (_otpremnicaPodaci._otpremnica.Revers == false)
            {
                _pdfPCell = new PdfPCell(new Phrase("Otpremnica br.  " + _otpremnicaPodaci._otpremnica.OtpremnicaID, _fontStyle));
            }
            else
            {
                _pdfPCell = new PdfPCell(new Phrase("Revers br.  " + _otpremnicaPodaci._otpremnica.OtpremnicaID, _fontStyle));
            }
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 13f;
            _pdfPCell.PaddingBottom = 20f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();
        }
        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);

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

            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            int brojac = 1;
            foreach (OtpremnicaProizvod stavka in _otpremnicaPodaci._listaStavki)
            {
                _pdfPCell = new PdfPCell(new Phrase((brojac++).ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(stavka.Proizvod.Naziv.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(stavka.KolicinaKG.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();
            }



            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Datum: " + this._otpremnicaPodaci._otpremnica.Datum.ToShortDateString(), _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 15f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            if (_otpremnicaPodaci._otpremnica.Revers == false)
            {
                _pdfPCell = new PdfPCell(new Phrase("                 Robu preuzeo:                                                                                                        Direktor:\n\n\n     -----------------------------------------                                                                           ----------------------------------------", _fontStyle));
            }
            else
            {
                _pdfPCell = new PdfPCell(new Phrase("                 Robu preuzeo:                                                                                                     Robu odobrio:\n\n\n     -----------------------------------------                                                                           ----------------------------------------", _fontStyle));
            }
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 155f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
    }
}
