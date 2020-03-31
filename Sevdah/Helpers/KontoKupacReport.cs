using iTextSharp.text;
using iTextSharp.text.pdf;
using Sevdah.Data;
using Sevdah.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Helpers
{
    public class KontoKupacReport
    {
       
        int _totalColumns = 5;
        Document _document;
        Font _fontStyle;
        Font _fontStyle1;
        PdfPTable _pdfTable = new PdfPTable(5);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        KupacKontoKartica _redovi = new KupacKontoKartica();
       

        public byte[] PrepareReport(KupacKontoKartica redovi)
        {
            _redovi = redovi;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 50f, 50f, 50f, 50f,50f});


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
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            // PODACI O KUPCU


            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Subjekt:", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 5f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            if (_redovi.KupacId == 20 || _redovi.KupacId == 23) // u slucaju da se izdaje konto kartica za Bingo jer u bazi imaju 2 binga ( sjever i jug )
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfPCell = new PdfPCell(new Phrase("Bingo d.o.o. Tuzla", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfPCell = new PdfPCell(new Phrase(""));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = Rectangle.BOTTOM_BORDER;
                _pdfPCell.PaddingBottom = 5f;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);

            }
            else
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfPCell = new PdfPCell(new Phrase(_redovi.NazivKupca, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfPCell = new PdfPCell(new Phrase(_redovi.AdresaKupca + "," + _redovi.Grad, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = Rectangle.BOTTOM_BORDER;
                _pdfPCell.PaddingBottom = 5f;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
            }
        



            _fontStyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell = new PdfPCell(new Phrase("KONTO KARTICA", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 5;
            _pdfPCell.PaddingTop = 13f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 2);
            _pdfPCell = new PdfPCell(new Phrase("Period od " + _redovi.DatumOd.ToShortDateString() + " do " + _redovi.DatumDo.ToShortDateString() + ":", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingBottom = 10f;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


        }
        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Datum", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Vezni dok.", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Duguje", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Potražuje", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Saldo", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

         
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            int brojac = 1;
            foreach (var stavka in _redovi.redovi)
            {
                

                _pdfPCell = new PdfPCell(new Phrase(stavka.Datum.ToShortDateString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(stavka.VezniDokument, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.Duguje,2).ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.Potrazuje, 2).ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.Saldo, 2).ToString()+" KM", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();
            }
            /* _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
             _pdfPCell = new PdfPCell(new Phrase("Ukupno: " + Math.Round(this._racunPodaci.racun.UkupnoBezPDV, 2).ToString() + " KM", _fontStyle));
             _pdfPCell.Colspan = _totalColumns;
             _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
             _pdfPCell.Border = 0;
             _pdfPCell.BackgroundColor = BaseColor.WHITE;
             _pdfPCell.ExtraParagraphSpace = 0;
             _pdfTable.AddCell(_pdfPCell);
             _pdfTable.CompleteRow();*/

            _fontStyle1 = FontFactory.GetFont("Tahoma", 12f, 1);


            _pdfPCell = new PdfPCell(new Phrase("", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Promet u periodu: ", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 7f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(Math.Round(_redovi.SumaDuguje,2).ToString() + " KM", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 7f;
            _pdfPCell.PaddingBottom = 7f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(Math.Round(_redovi.SumaPotrazuje,2).ToString() + " KM", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 10f;
            _pdfPCell.PaddingBottom = 7f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(Math.Round(_redovi.Saldo, 2).ToString() + " KM", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 7f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();



            _fontStyle1 = FontFactory.GetFont("Tahoma", 12f, 1);


            _pdfPCell = new PdfPCell(new Phrase("", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Prethodno dugovanje: ", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 7f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(Math.Round(_redovi.prethodnoDugovanje, 2).ToString() + " KM", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 7f;
            _pdfPCell.PaddingBottom = 7f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Ukupno sa prethodnim dugovanjem: ", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 10f;
            _pdfPCell.PaddingBottom = 7f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(Math.Round(_redovi.Saldo + _redovi.prethodnoDugovanje, 2).ToString() + " KM", _fontStyle1));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.PaddingTop = 7f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();






        }
    }
}
