namespace Intermoda.Maquilado.Wip.Reports
{
    partial class BarcodeTag
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Barcodes.EAN13Encoder eaN13Encoder1 = new Telerik.Reporting.Barcodes.EAN13Encoder();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.Barcode = new Telerik.Reporting.Barcode();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.Estilo = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.Talla = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.ColorCodigo = new Telerik.Reporting.TextBox();
            this.ColorNombre = new Telerik.Reporting.TextBox();
            this.Descripcion = new Telerik.Reporting.TextBox();
            this.Composicion = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Barcode,
            this.textBox1,
            this.Estilo,
            this.textBox2,
            this.Talla,
            this.textBox3,
            this.ColorCodigo,
            this.ColorNombre,
            this.Descripcion,
            this.Composicion});
            this.detail.Name = "detail";
            // 
            // Barcode
            // 
            this.Barcode.Encoder = eaN13Encoder1;
            this.Barcode.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.1000000536441803D), Telerik.Reporting.Drawing.Unit.Cm(1.6999999284744263D));
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.79990005493164062D));
            this.Barcode.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.Barcode.Value = "742586055977";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010002215276472271D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.textBox1.Value = "Estilo:";
            // 
            // Estilo
            // 
            this.Estilo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.70029979944229126D), Telerik.Reporting.Drawing.Unit.Cm(0.2000001072883606D));
            this.Estilo.Name = "Estilo";
            this.Estilo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.89980012178421021D), Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D));
            this.Estilo.Style.Font.Bold = true;
            this.Estilo.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.Estilo.Value = "PR908AH";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.6002999544143677D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.5998002290725708D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.textBox2.Value = "Talla:";
            // 
            // Talla
            // 
            this.Talla.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.2003002166748047D), Telerik.Reporting.Drawing.Unit.Cm(0.2000001072883606D));
            this.Talla.Name = "Talla";
            this.Talla.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D));
            this.Talla.Style.Font.Bold = true;
            this.Talla.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.Talla.Value = "M";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.textBox3.Value = "Color:";
            // 
            // ColorCodigo
            // 
            this.ColorCodigo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.70029979944229126D), Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522D));
            this.ColorCodigo.Name = "ColorCodigo";
            this.ColorCodigo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.39970022439956665D), Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D));
            this.ColorCodigo.Style.Font.Bold = true;
            this.ColorCodigo.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.ColorCodigo.Value = "1S";
            // 
            // ColorNombre
            // 
            this.ColorNombre.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.2003003358840942D), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D));
            this.ColorNombre.Name = "ColorNombre";
            this.ColorNombre.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.ColorNombre.Style.Font.Bold = true;
            this.ColorNombre.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.ColorNombre.Value = "Rojo Brillante";
            // 
            // Descripcion
            // 
            this.Descripcion.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4998998641967773D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
            this.Descripcion.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.Descripcion.Value = "Camiseta Polo";
            // 
            // Composicion
            // 
            this.Composicion.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.Composicion.Name = "Composicion";
            this.Composicion.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4998998641967773D), Telerik.Reporting.Drawing.Unit.Cm(0.59980005025863647D));
            this.Composicion.Style.Font.Bold = true;
            this.Composicion.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.Composicion.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Composicion.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Composicion.Value = "50% POLY 50% ALGODON";
            // 
            // BarcodeTag
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "BarcodeTag";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(2.500300407409668D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        public Telerik.Reporting.Barcode Barcode;
        private Telerik.Reporting.TextBox textBox1;
        public Telerik.Reporting.TextBox Estilo;
        private Telerik.Reporting.TextBox textBox2;
        public Telerik.Reporting.TextBox Talla;
        private Telerik.Reporting.TextBox textBox3;
        public Telerik.Reporting.TextBox ColorCodigo;
        public Telerik.Reporting.TextBox ColorNombre;
        public Telerik.Reporting.TextBox Descripcion;
        public Telerik.Reporting.TextBox Composicion;
    }
}