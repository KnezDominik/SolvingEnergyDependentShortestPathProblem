namespace KnezDominikZavrsni
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.sideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMeni = new FontAwesome.Sharp.IconButton();
            this.btnUcitaj = new FontAwesome.Sharp.IconButton();
            this.btnDijkstra = new FontAwesome.Sharp.IconButton();
            this.btnObrisiMarker = new FontAwesome.Sharp.IconButton();
            this.btnObrisiRutu = new FontAwesome.Sharp.IconButton();
            this.btnNacinRutiranja = new FontAwesome.Sharp.IconButton();
            this.panelSubMenuNacin = new System.Windows.Forms.Panel();
            this.btnPremaDuljini = new FontAwesome.Sharp.IconButton();
            this.btnPremaEnergiji = new FontAwesome.Sharp.IconButton();
            this.btnVrijeme = new FontAwesome.Sharp.IconButton();
            this.panelSubMenuVrijeme = new System.Windows.Forms.Panel();
            this.btnVrijemeReset = new FontAwesome.Sharp.IconButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtVrijeme = new System.Windows.Forms.TextBox();
            this.btnZamjena = new FontAwesome.Sharp.IconButton();
            this.txtIspis = new System.Windows.Forms.RichTextBox();
            this.panelSlide = new System.Windows.Forms.Panel();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.sideBar.SuspendLayout();
            this.panelSubMenuNacin.SuspendLayout();
            this.panelSubMenuVrijeme.SuspendLayout();
            this.panelSlide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemory = 5;
            this.gMap.Location = new System.Drawing.Point(54, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(1600, 1073);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMap_OnMarkerClick);
            this.gMap.OnMarkerDoubleClick += new GMap.NET.WindowsForms.MarkerDoubleClick(this.gMap_OnMarkerDoubleClick);
            this.gMap.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.gMap_OnRouteClick);
            this.gMap.OnRouteDoubleClick += new GMap.NET.WindowsForms.RouteDoubleClick(this.gMap_OnRouteDoubleClick);
            this.gMap.Load += new System.EventHandler(this.gMap_Load);
            this.gMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseDoubleClick);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.sideBar.Controls.Add(this.btnMeni);
            this.sideBar.Controls.Add(this.btnUcitaj);
            this.sideBar.Controls.Add(this.btnDijkstra);
            this.sideBar.Controls.Add(this.btnObrisiMarker);
            this.sideBar.Controls.Add(this.btnObrisiRutu);
            this.sideBar.Controls.Add(this.btnNacinRutiranja);
            this.sideBar.Controls.Add(this.panelSubMenuNacin);
            this.sideBar.Controls.Add(this.btnVrijeme);
            this.sideBar.Controls.Add(this.panelSubMenuVrijeme);
            this.sideBar.Controls.Add(this.btnZamjena);
            this.sideBar.Controls.Add(this.txtIspis);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 0);
            this.sideBar.MaximumSize = new System.Drawing.Size(260, 0);
            this.sideBar.MinimumSize = new System.Drawing.Size(62, 0);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(260, 1053);
            this.sideBar.TabIndex = 1;
            // 
            // btnMeni
            // 
            this.btnMeni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnMeni.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMeni.FlatAppearance.BorderSize = 0;
            this.btnMeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeni.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMeni.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.btnMeni.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMeni.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMeni.IconSize = 32;
            this.btnMeni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeni.Location = new System.Drawing.Point(0, 3);
            this.btnMeni.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnMeni.Name = "btnMeni";
            this.btnMeni.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMeni.Size = new System.Drawing.Size(260, 80);
            this.btnMeni.TabIndex = 0;
            this.btnMeni.Text = "    Meni";
            this.btnMeni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeni.UseVisualStyleBackColor = false;
            this.btnMeni.Click += new System.EventHandler(this.btnMeni_Click);
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnUcitaj.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUcitaj.FlatAppearance.BorderSize = 0;
            this.btnUcitaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUcitaj.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUcitaj.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUcitaj.IconChar = FontAwesome.Sharp.IconChar.Spinner;
            this.btnUcitaj.IconColor = System.Drawing.Color.Gainsboro;
            this.btnUcitaj.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUcitaj.IconSize = 32;
            this.btnUcitaj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUcitaj.Location = new System.Drawing.Point(0, 89);
            this.btnUcitaj.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUcitaj.Size = new System.Drawing.Size(260, 60);
            this.btnUcitaj.TabIndex = 1;
            this.btnUcitaj.Text = "   Učitaj podatke";
            this.btnUcitaj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUcitaj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUcitaj.UseVisualStyleBackColor = false;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // btnDijkstra
            // 
            this.btnDijkstra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnDijkstra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDijkstra.FlatAppearance.BorderSize = 0;
            this.btnDijkstra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDijkstra.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDijkstra.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDijkstra.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnDijkstra.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDijkstra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDijkstra.IconSize = 32;
            this.btnDijkstra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDijkstra.Location = new System.Drawing.Point(0, 155);
            this.btnDijkstra.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnDijkstra.Name = "btnDijkstra";
            this.btnDijkstra.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDijkstra.Size = new System.Drawing.Size(260, 60);
            this.btnDijkstra.TabIndex = 2;
            this.btnDijkstra.Text = "    Pronađi rutu";
            this.btnDijkstra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDijkstra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDijkstra.UseVisualStyleBackColor = false;
            this.btnDijkstra.Click += new System.EventHandler(this.btnDijkstra_Click);
            // 
            // btnObrisiMarker
            // 
            this.btnObrisiMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnObrisiMarker.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnObrisiMarker.FlatAppearance.BorderSize = 0;
            this.btnObrisiMarker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisiMarker.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiMarker.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnObrisiMarker.IconChar = FontAwesome.Sharp.IconChar.LocationDot;
            this.btnObrisiMarker.IconColor = System.Drawing.Color.Gainsboro;
            this.btnObrisiMarker.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnObrisiMarker.IconSize = 32;
            this.btnObrisiMarker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObrisiMarker.Location = new System.Drawing.Point(0, 221);
            this.btnObrisiMarker.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnObrisiMarker.Name = "btnObrisiMarker";
            this.btnObrisiMarker.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnObrisiMarker.Size = new System.Drawing.Size(260, 60);
            this.btnObrisiMarker.TabIndex = 6;
            this.btnObrisiMarker.Text = "    Obriši markere";
            this.btnObrisiMarker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObrisiMarker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnObrisiMarker.UseVisualStyleBackColor = false;
            this.btnObrisiMarker.Click += new System.EventHandler(this.btnObrisiMarker_Click);
            // 
            // btnObrisiRutu
            // 
            this.btnObrisiRutu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnObrisiRutu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnObrisiRutu.FlatAppearance.BorderSize = 0;
            this.btnObrisiRutu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisiRutu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiRutu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnObrisiRutu.IconChar = FontAwesome.Sharp.IconChar.Route;
            this.btnObrisiRutu.IconColor = System.Drawing.Color.Gainsboro;
            this.btnObrisiRutu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnObrisiRutu.IconSize = 32;
            this.btnObrisiRutu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObrisiRutu.Location = new System.Drawing.Point(0, 287);
            this.btnObrisiRutu.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnObrisiRutu.Name = "btnObrisiRutu";
            this.btnObrisiRutu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnObrisiRutu.Size = new System.Drawing.Size(260, 60);
            this.btnObrisiRutu.TabIndex = 8;
            this.btnObrisiRutu.Text = "    Obriši rute";
            this.btnObrisiRutu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObrisiRutu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnObrisiRutu.UseVisualStyleBackColor = false;
            this.btnObrisiRutu.Click += new System.EventHandler(this.btnObrisiRutu_Click);
            // 
            // btnNacinRutiranja
            // 
            this.btnNacinRutiranja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnNacinRutiranja.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNacinRutiranja.FlatAppearance.BorderSize = 0;
            this.btnNacinRutiranja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNacinRutiranja.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNacinRutiranja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNacinRutiranja.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.btnNacinRutiranja.IconColor = System.Drawing.Color.Gainsboro;
            this.btnNacinRutiranja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNacinRutiranja.IconSize = 32;
            this.btnNacinRutiranja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNacinRutiranja.Location = new System.Drawing.Point(0, 353);
            this.btnNacinRutiranja.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnNacinRutiranja.Name = "btnNacinRutiranja";
            this.btnNacinRutiranja.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNacinRutiranja.Size = new System.Drawing.Size(260, 60);
            this.btnNacinRutiranja.TabIndex = 9;
            this.btnNacinRutiranja.Text = "    Način rutiranja";
            this.btnNacinRutiranja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNacinRutiranja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNacinRutiranja.UseVisualStyleBackColor = false;
            this.btnNacinRutiranja.Click += new System.EventHandler(this.btnNacinRutiranja_Click);
            // 
            // panelSubMenuNacin
            // 
            this.panelSubMenuNacin.Controls.Add(this.btnPremaDuljini);
            this.panelSubMenuNacin.Controls.Add(this.btnPremaEnergiji);
            this.panelSubMenuNacin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuNacin.Location = new System.Drawing.Point(3, 419);
            this.panelSubMenuNacin.Name = "panelSubMenuNacin";
            this.panelSubMenuNacin.Size = new System.Drawing.Size(260, 120);
            this.panelSubMenuNacin.TabIndex = 10;
            // 
            // btnPremaDuljini
            // 
            this.btnPremaDuljini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnPremaDuljini.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPremaDuljini.FlatAppearance.BorderSize = 0;
            this.btnPremaDuljini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPremaDuljini.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPremaDuljini.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPremaDuljini.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.btnPremaDuljini.IconColor = System.Drawing.Color.Gainsboro;
            this.btnPremaDuljini.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPremaDuljini.IconSize = 26;
            this.btnPremaDuljini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPremaDuljini.Location = new System.Drawing.Point(0, 60);
            this.btnPremaDuljini.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnPremaDuljini.Name = "btnPremaDuljini";
            this.btnPremaDuljini.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnPremaDuljini.Size = new System.Drawing.Size(260, 60);
            this.btnPremaDuljini.TabIndex = 12;
            this.btnPremaDuljini.Text = "    Prema duljini";
            this.btnPremaDuljini.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPremaDuljini.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPremaDuljini.UseVisualStyleBackColor = false;
            this.btnPremaDuljini.Click += new System.EventHandler(this.btnPremaDuljini_Click);
            // 
            // btnPremaEnergiji
            // 
            this.btnPremaEnergiji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnPremaEnergiji.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPremaEnergiji.FlatAppearance.BorderSize = 0;
            this.btnPremaEnergiji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPremaEnergiji.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPremaEnergiji.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPremaEnergiji.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.btnPremaEnergiji.IconColor = System.Drawing.Color.Gainsboro;
            this.btnPremaEnergiji.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPremaEnergiji.IconSize = 26;
            this.btnPremaEnergiji.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPremaEnergiji.Location = new System.Drawing.Point(0, 0);
            this.btnPremaEnergiji.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnPremaEnergiji.Name = "btnPremaEnergiji";
            this.btnPremaEnergiji.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnPremaEnergiji.Size = new System.Drawing.Size(260, 60);
            this.btnPremaEnergiji.TabIndex = 11;
            this.btnPremaEnergiji.Text = "    Prema energiji";
            this.btnPremaEnergiji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPremaEnergiji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPremaEnergiji.UseVisualStyleBackColor = false;
            this.btnPremaEnergiji.Click += new System.EventHandler(this.btnPremaEnergiji_Click);
            // 
            // btnVrijeme
            // 
            this.btnVrijeme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnVrijeme.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVrijeme.FlatAppearance.BorderSize = 0;
            this.btnVrijeme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVrijeme.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVrijeme.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVrijeme.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            this.btnVrijeme.IconColor = System.Drawing.Color.Gainsboro;
            this.btnVrijeme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVrijeme.IconSize = 32;
            this.btnVrijeme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVrijeme.Location = new System.Drawing.Point(0, 545);
            this.btnVrijeme.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnVrijeme.Name = "btnVrijeme";
            this.btnVrijeme.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVrijeme.Size = new System.Drawing.Size(260, 60);
            this.btnVrijeme.TabIndex = 11;
            this.btnVrijeme.Text = "    Vrijeme rutiranja";
            this.btnVrijeme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVrijeme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVrijeme.UseVisualStyleBackColor = false;
            this.btnVrijeme.Click += new System.EventHandler(this.btnVrijeme_Click);
            // 
            // panelSubMenuVrijeme
            // 
            this.panelSubMenuVrijeme.Controls.Add(this.btnVrijemeReset);
            this.panelSubMenuVrijeme.Controls.Add(this.richTextBox1);
            this.panelSubMenuVrijeme.Controls.Add(this.txtVrijeme);
            this.panelSubMenuVrijeme.Location = new System.Drawing.Point(3, 611);
            this.panelSubMenuVrijeme.Name = "panelSubMenuVrijeme";
            this.panelSubMenuVrijeme.Size = new System.Drawing.Size(260, 110);
            this.panelSubMenuVrijeme.TabIndex = 12;
            // 
            // btnVrijemeReset
            // 
            this.btnVrijemeReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVrijemeReset.FlatAppearance.BorderSize = 0;
            this.btnVrijemeReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVrijemeReset.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVrijemeReset.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVrijemeReset.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.btnVrijemeReset.IconColor = System.Drawing.Color.Gainsboro;
            this.btnVrijemeReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVrijemeReset.IconSize = 32;
            this.btnVrijemeReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVrijemeReset.Location = new System.Drawing.Point(0, 50);
            this.btnVrijemeReset.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnVrijemeReset.Name = "btnVrijemeReset";
            this.btnVrijemeReset.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnVrijemeReset.Size = new System.Drawing.Size(260, 60);
            this.btnVrijemeReset.TabIndex = 2;
            this.btnVrijemeReset.Text = "   Resetiraj vrijeme";
            this.btnVrijemeReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVrijemeReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVrijemeReset.UseVisualStyleBackColor = true;
            this.btnVrijemeReset.Click += new System.EventHandler(this.btnVrijemeReset_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.richTextBox1.Location = new System.Drawing.Point(0, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(260, 34);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Upišite vrijeme početka rutiranja u text box";
            // 
            // txtVrijeme
            // 
            this.txtVrijeme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.txtVrijeme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVrijeme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVrijeme.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtVrijeme.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVrijeme.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtVrijeme.Location = new System.Drawing.Point(0, 0);
            this.txtVrijeme.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtVrijeme.Name = "txtVrijeme";
            this.txtVrijeme.Size = new System.Drawing.Size(260, 16);
            this.txtVrijeme.TabIndex = 0;
            this.txtVrijeme.Text = "00:00:00";
            this.txtVrijeme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnZamjena
            // 
            this.btnZamjena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnZamjena.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnZamjena.FlatAppearance.BorderSize = 0;
            this.btnZamjena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZamjena.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZamjena.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnZamjena.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.btnZamjena.IconColor = System.Drawing.Color.Gainsboro;
            this.btnZamjena.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnZamjena.IconSize = 32;
            this.btnZamjena.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZamjena.Location = new System.Drawing.Point(0, 727);
            this.btnZamjena.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnZamjena.Name = "btnZamjena";
            this.btnZamjena.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnZamjena.Size = new System.Drawing.Size(260, 60);
            this.btnZamjena.TabIndex = 15;
            this.btnZamjena.Text = "    Zamjeni marker";
            this.btnZamjena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZamjena.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZamjena.UseVisualStyleBackColor = false;
            this.btnZamjena.Click += new System.EventHandler(this.btnZamjena_Click);
            // 
            // txtIspis
            // 
            this.txtIspis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.txtIspis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIspis.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIspis.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIspis.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtIspis.Location = new System.Drawing.Point(3, 793);
            this.txtIspis.Name = "txtIspis";
            this.txtIspis.Size = new System.Drawing.Size(257, 108);
            this.txtIspis.TabIndex = 16;
            this.txtIspis.Text = "";
            // 
            // panelSlide
            // 
            this.panelSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panelSlide.Controls.Add(this.btnMaximize);
            this.panelSlide.Controls.Add(this.btnMinimize);
            this.panelSlide.Controls.Add(this.btnClose);
            this.panelSlide.Controls.Add(this.pictureBox1);
            this.panelSlide.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSlide.Location = new System.Drawing.Point(260, 0);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(1285, 84);
            this.panelSlide.TabIndex = 2;
            this.panelSlide.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSlide_MouseDown);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.btnMaximize.IconColor = System.Drawing.Color.DarkOrange;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 15;
            this.btnMaximize.Location = new System.Drawing.Point(1219, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(30, 30);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.Text = "iconButton3";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.btnMinimize.IconColor = System.Drawing.Color.Green;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 15;
            this.btnMinimize.Location = new System.Drawing.Point(1183, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "iconButton2";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.btnClose.IconColor = System.Drawing.Color.Red;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 15;
            this.btnClose.Location = new System.Drawing.Point(1255, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "iconButton1";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::KnezDominikZavrsni.Properties.Resources.fpz_logo_wide_hr;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(374, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sideBarTimer
            // 
            this.sideBarTimer.Interval = 3;
            this.sideBarTimer.Tick += new System.EventHandler(this.sideBarTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 1053);
            this.Controls.Add(this.panelSlide);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.gMap);
            this.MinimumSize = new System.Drawing.Size(900, 740);
            this.Name = "Form1";
            this.Text = "Form1";
            this.sideBar.ResumeLayout(false);
            this.panelSubMenuNacin.ResumeLayout(false);
            this.panelSubMenuVrijeme.ResumeLayout(false);
            this.panelSubMenuVrijeme.PerformLayout();
            this.panelSlide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.FlowLayoutPanel sideBar;
        private System.Windows.Forms.Panel panelSlide;
        private FontAwesome.Sharp.IconButton btnMeni;
        private FontAwesome.Sharp.IconButton btnUcitaj;
        private FontAwesome.Sharp.IconButton btnDijkstra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer sideBarTimer;
        private FontAwesome.Sharp.IconButton btnObrisiMarker;
        private FontAwesome.Sharp.IconButton btnObrisiRutu;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnNacinRutiranja;
        private System.Windows.Forms.Panel panelSubMenuNacin;
        private FontAwesome.Sharp.IconButton btnPremaDuljini;
        private FontAwesome.Sharp.IconButton btnPremaEnergiji;
        private FontAwesome.Sharp.IconButton btnVrijeme;
        private System.Windows.Forms.Panel panelSubMenuVrijeme;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtVrijeme;
        private FontAwesome.Sharp.IconButton btnZamjena;
        private System.Windows.Forms.RichTextBox txtIspis;
        private FontAwesome.Sharp.IconButton btnVrijemeReset;
    }
}

