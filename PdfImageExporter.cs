using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text;
using System.Drawing;

namespace PDFModifierCSV {
    class PdfImageExporter : IRenderListener {

        private iTextSharp.text.Rectangle pageSize;

        private string currentPdfPath;

        private int currentPage;

        public System.Drawing.Image RenderedImage {
            get;
            private set;
        }

        public System.Drawing.Image ExtractImageFromPDF(string pdfPath, PdfReader pdfReader, int pageNo = 0) {
            PdfDictionary pdfPage = pdfReader.GetPageN(pageNo + 1);

            this.currentPdfPath = pdfPath;
            this.currentPage = pageNo;

            pageSize = pdfReader.GetPageSize(pageNo + 1);

            PdfReaderContentParser parser = new PdfReaderContentParser(pdfReader);
            //612x792
            parser.ProcessContent(pageNo + 1, this);

            return RenderedImage;
                //ExtractImageFromDictionary(pdfPage, pdfReader);
        }

        public void RenderImage(ImageRenderInfo renderInfo) {
            var image = renderInfo.GetImage();
            try {
                var drawingImage = image.GetDrawingImage();
                RenderedImage = drawingImage;
            } catch (Exception) {
                //extract image using 
                ExtractUsingGhostScript(renderInfo.GetImageCTM());
            }
        }

        private void ExtractUsingGhostScript(Matrix coordinates) {
            float x = coordinates[Matrix.I31];
            float y = coordinates[Matrix.I32];
            float w = coordinates[Matrix.I11];
            float h = coordinates[Matrix.I22];

            using (var rasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer()) {
                rasterizer.Open(currentPdfPath);

                var pageWidth = pageSize.Width;
                var pageHeight = pageSize.Height;

                using (Bitmap img = (Bitmap)rasterizer.GetPage(120, 120, currentPage + 1)) {
                    int rectX = (int)(img.Width * x / pageWidth);
                    int rectY = (int)(img.Height * y / pageHeight);
                    int rectW = (int)(img.Width * w / pageWidth);
                    int rectH = (int)(img.Height * h / pageHeight);

                    RenderedImage = img.Clone(new System.Drawing.Rectangle(rectX, rectY, rectW, rectH), img.PixelFormat);
                }

            }

        }


        public void RenderText(TextRenderInfo renderInfo) {
            
        }

        public void BeginTextBlock() {

        }

        public void EndTextBlock() {

        }

    }

}
