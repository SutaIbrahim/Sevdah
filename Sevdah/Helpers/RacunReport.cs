using iTextSharp.text;
using iTextSharp.text.pdf;
using Sevdah.Models;
using Sevdah.ViewModel;
using System;
using System.IO;

namespace Sevdah.Helpers
{
    public class RacunReport
    {
        int _totalColumns = 8;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(8);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        RacuniReportVM _racunPodaci = new RacuniReportVM();

        public byte[] PrepareReport(RacuniReportVM racunPodaci)
        {
            _racunPodaci = racunPodaci;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 12f, 77f, 68f, 40f, 40f, 40f, 41f, 42f });


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
            _pdfPCell = new PdfPCell(new Phrase("Južni Logor (Dolina Sunca) bb", _fontStyle));
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


            _fontStyle = FontFactory.GetFont("Tahoma", 13f, 1);
            _pdfPCell = new PdfPCell(new Phrase("KUPAC:", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 5f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(this._racunPodaci.racun.Kupac.NazivKupca, _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase(this._racunPodaci.racun.Kupac.Grad.Naziv, _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            if (_racunPodaci.racun.Kupac.NazivKupca == "---")
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
                _pdfPCell = new PdfPCell(new Phrase("ID: " + this._racunPodaci.racun.Kupac.ID_broj, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }

            if (_racunPodaci.racun.Kupac.NazivKupca == "---")
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
                _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = Rectangle.BOTTOM_BORDER;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPCell.PaddingBottom = 10f;
                _pdfTable.AddCell(_pdfPCell);
            }
            else
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1, BaseColor.DARK_GRAY);
                _pdfPCell = new PdfPCell(new Phrase("PDV: " + this._racunPodaci.racun.Kupac.PDV_broj, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = Rectangle.BOTTOM_BORDER;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPCell.PaddingBottom = 10f;
                _pdfTable.AddCell(_pdfPCell);
            }

            if (_racunPodaci.racun.Kupac.NazivKupca != "---")
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
                _pdfPCell = new PdfPCell(new Phrase("Broj racuna: " + this._racunPodaci.racun.BrojRacuna, _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.PaddingTop = 10f;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
            }
            else
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
                _pdfPCell = new PdfPCell(new Phrase("Broj racuna: ---", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.PaddingTop = 10f;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
            }

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Broj fiskalnog racuna: " + this._racunPodaci.racun.BrojFiskalnogRacuna, _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 2f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Broj narudžbe: " + this._racunPodaci.racun.BrojNarudzbe, _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 2f;
            _pdfPCell.PaddingBottom = 15f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();
        }

        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

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

            _pdfPCell = new PdfPCell(new Phrase("Bar kod", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Kolicina u kg", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cijena bez PDV-a", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Rabat %", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Iznos rabata", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Iznos bez PDV-a", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
            int serialNumber = 1;
            int brojac = 1;
            foreach (RacunProizvod stavka in _racunPodaci.listaStavki)
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

                _pdfPCell = new PdfPCell(new Phrase(stavka.Proizvod.BarKod.ToString(), _fontStyle));
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

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.CijenaBezPDV * (1 / stavka.Proizvod.Masa), 2).ToString() + " KM", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(stavka.Rabat.ToString() + "%", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.IznosRabata, 2).ToString() + " KM", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Math.Round(stavka.IznosBezPDV, 2).ToString() + " KM", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.PaddingTop = 5f;
                _pdfPCell.PaddingBottom = 5f;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 2);
            _pdfPCell = new PdfPCell(new Phrase("Ukupno: " + Math.Round(this._racunPodaci.racun.UkupnoBezPDV, 2).ToString() + " KM", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 10f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 2);
            _pdfPCell = new PdfPCell(new Phrase("PDV " + (this._racunPodaci.racun.PDV * 100).ToString() + "%: " + Math.Round(this._racunPodaci.racun.UkupnoBezPDV * this._racunPodaci.racun.PDV, 2) + " KM", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 5);
            _pdfPCell = new PdfPCell(new Phrase("Ukupno za naplatu: " + Math.Round((this._racunPodaci.racun.UkupnoBezPDV + (this._racunPodaci.racun.UkupnoBezPDV * (this._racunPodaci.racun.PDV))), 2).ToString() + " KM", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1, BaseColor.DARK_GRAY);
            _pdfPCell = new PdfPCell(new Phrase("NAPOMENA: Akciza uracunata u cijenu ", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 10f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DATUM: " + this._racunPodaci.racun.Datum.ToShortDateString(), _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            if (_racunPodaci.racun.Kupac.NazivKupca == "---")
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
                _pdfPCell = new PdfPCell(new Phrase("Nacin placanja: Gotovina", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
            }
            else
            {
                var virmanDani = _racunPodaci.racun.Kupac.VirmanDani;
                if (!virmanDani.HasValue) virmanDani = 10;

                _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
                _pdfPCell = new PdfPCell(new Phrase($"Nacin placanja: Virmanom u roku od {virmanDani} dana", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
            }

            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("                 Robu preuzeo:                                                                                                                       Direktor:\n\n\n     -----------------------------------------                                                                                          ----------------------------------------", _fontStyle));
            _pdfPCell.Colspan = _totalColumns;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.PaddingTop = 107f;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }

        public Image GenerateBarCode()
        {
            iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
            bc.TextAlignment = Element.ALIGN_CENTER;
            bc.Code = "anything";
            bc.StartStopText = false;
            bc.CodeType = iTextSharp.text.pdf.Barcode128.CODE128;
            bc.Extended = true;
            //bc.Font = null;

            var outputStream = new MemoryStream();
            var pdfWriter = PdfWriter.GetInstance(_document, outputStream);
            PdfContentByte cb = new PdfContentByte(pdfWriter);

            iTextSharp.text.Image PatImage1 = bc.CreateImageWithBarcode(null, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

            return PatImage1;
            //PatImage1.ScaleToFit(160, 20);


            //PdfPTable p_detail1 = new PdfPTable(1);
            //p_detail1.WidthPercentage = 100;

            //PdfPCell barcideimage = new PdfPCell(PatImage1);
            ////barcideimage.Colspan = 2;
            //barcideimage.HorizontalAlignment = 2;
            //barcideimage.Border = 0;
            //p_detail1.AddCell(barcideimage);

            //l1.Add(p_detail1);
        }

    }
}
