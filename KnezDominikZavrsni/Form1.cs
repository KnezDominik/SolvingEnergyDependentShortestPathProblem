using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using System.Threading;
using FibonacciHeap;
using System.Reflection;
using static KnezDominikZavrsni.Form1;

namespace KnezDominikZavrsni
{
    public partial class Form1 : Form
    {
        Dictionary<int, Vrh> listaVrhova;
        FibonacciHeap<Vrh, double> heap;
        List<Vrh> put;
        List<Vrh> listaMarkera=new List<Vrh>();
        GMarkerGoogle[] poljeMarkeraZamjena = new GMarkerGoogle[2];
        StreamReader citanje = new StreamReader("updatedGraphZg.txt");
        int brMarkera = 0;
        int brRuta=0;
        int zapamtiIDpocetka;
        double zapamtiVrijemePocetka;
        double vrijemePocetka = 0;
        Vrh pocetak,zavrsetak;
        bool dijkstraSpremna = false;
        bool premaEnergiji=false;
        bool premaEnergijiIspis = false; 
        bool imaPocetnogMarkera = false;
        bool podatciUcitani=false;
        bool dogodilaSeZamjena=false;
        string izbor;
        Vrh zapamtiVrhPocetak, zapamtiVrhZavrsetak;
        Vrh vBrisanje;
        Vrh vEnergija = new Vrh();
        //Gmap
        GMapOverlay markerOverlay = new GMapOverlay("markerOverlay");
        GMapOverlay rutaOverlay = new GMapOverlay("rutaOverlay");
        GMapOverlay poligonOverlay = new GMapOverlay("poligonOverlay");
        GMapRoute ruta;
        GMapPolygon poligon;
        //UI
        private IconButton currentButton;
        bool sideBarExpanded= false;

        //int brojVrhova, brojBridova;

        //Klasa za vrh
        public class Vrh
        {
            public int linkID { get; set; }
            public double xPocetak { get; set; }
            public double yPocetak { get; set; }
            public double xZavrsetak { get; set; }
            public double yZavrsetak { get; set; }
            public int duljinaLinka { get; set; }
            public int brzinaLinka { get; set; }
            public int ogranicenjeBrzine { get; set; }
            public int tipLinka { get; set; }
            public int zastavicaSmjera { get; set; }
            public List<int> listaSusjednihLinkova { get; set; }
            public double brzinaSlobodnogToka { get; set; }
            public double prosjecnaBrzina { get; set; }
            public double[] profilBrzine { get; set; }
            public double prosjecnaEnergija { get; set; }
            public double[] profilEnergije { get; set; }
            public GMapMarker marker { get; set; }
            public GMapRoute ruta { get; set; }

            //Dio za graf
            public double tezina { get; set; }
            public Vrh prethodni { get; set; }
            public double tezinaEnergija { get; set; }
            public double ukupnaEnergija { get; set; }
            public double ukupnaDuljina { get; set; }
            public double vrijemePolaska { get; set; }            
            public bool obraden { get; set; }

            public void reset()
            {
                tezina = double.MaxValue;
                prethodni = null;
                tezinaEnergija = double.MaxValue;
            }
        }

        public Form1()
        {
            InitializeComponent();
            listaVrhova = new Dictionary<int, Vrh>();
            //UI
            hideSubMenu();
            sideBar.Width = sideBar.MinimumSize.Width;
            //sakriva minimize,maximize,close
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;       
        }
        //UI
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        //Metoda za dijkstru
        public List<Vrh> Dijkstra(Vrh pocetak, Vrh zavrsetak)
        {
            if (premaEnergiji)
            {
                string vrijeme = txtVrijeme.Text;
                string[] d = vrijeme.Split(':');
                int sati = Convert.ToInt32(d[0]);
                int min = Convert.ToInt32(d[1]);
                int sek = Convert.ToInt32(d[2]);
                vrijemePocetka = (sati * 60) + min + (sek / 60.0);

                if (zapamtiIDpocetka != pocetak.linkID ||zapamtiVrijemePocetka!=vrijemePocetka)
                {
                    if (txtVrijeme.Text == "00:00:00")
                    {
                        //pocetak.vrijemePolaska = vrijemePocetka;
                        //vEnergija.vrijemePolaska = vrijemePocetka;
                        BellmanFord();
                        izbor = "energija prosjecna";
                        FibonacciHeapMetoda(izbor);
                        premaEnergijiIspis = true;
                    }
                    else
                    {
                        //pocetak.vrijemePolaska=vrijemePocetka;
                        //vEnergija.vrijemePolaska = vrijemePocetka;
                        BellmanFord();
                        izbor = "energija profil";
                        FibonacciHeapMetoda(izbor);
                        premaEnergijiIspis = true;
                    }
                }
            }
            else 
            {
                if (zapamtiIDpocetka != pocetak.linkID)
                {
                    izbor = "duljina";
                    FibonacciHeapMetoda(izbor);
                    premaEnergijiIspis = false;
                }
            }            

            //Izrada puta            
            put = new List<Vrh>();
            Vrh trenutni = zavrsetak;
            do
            {
                put.Insert(0, trenutni);
                trenutni = trenutni.prethodni;
            } while (trenutni != null);
            return put;
        }
        
        public void FibonacciHeapMetoda(string izbor)
        {
            if (izbor!="BellmanFord")
            {
                Dictionary<int, FibonacciHeapNode<Vrh, double>> sviUHeapu = new Dictionary<int, FibonacciHeapNode<Vrh, double>>();
                heap = new FibonacciHeap<Vrh, double>(double.MaxValue);
                FibonacciHeapNode<Vrh, double> pocetakHeapNode = null;
                foreach (Vrh vReset in listaVrhova.Values)
                {
                    vReset.tezina = double.MaxValue;
                    vReset.obraden = false;
                    vReset.prethodni = null;
                    vReset.vrijemePolaska = 0;
                    vReset.ukupnaDuljina = 0;
                    vReset.ukupnaEnergija = 0;
                    FibonacciHeapNode<Vrh, double> node = new FibonacciHeapNode<Vrh, double>(vReset, vReset.tezina);
                    if (vReset == pocetak)
                    {
                        vReset.tezina = 0;
                        vReset.vrijemePolaska=vrijemePocetka;
                        pocetakHeapNode = node;
                    }
                    else
                    {
                        heap.Insert(node);
                    }
                    sviUHeapu[vReset.linkID] = node;
                }
                int i = 0;
                Vrh v1;
                if (izbor == "energija prosjecna")
                {
                    while (!heap.IsEmpty())
                    {
                        FibonacciHeapNode<Vrh, double> najbolji = null;
                        if (i == 0)
                        {
                            najbolji = pocetakHeapNode;
                            i++;
                        }
                        else
                        {
                            najbolji = heap.RemoveMin();
                        }
                        najbolji.Data.obraden = true;
                        if (!heap.IsEmpty())
                        {
                            v1 = najbolji.Data;
                            foreach (int linkID in v1.listaSusjednihLinkova)
                            {
                                if (listaVrhova.ContainsKey(linkID))
                                {
                                    Vrh v2 = listaVrhova[linkID];
                                    double vrijemePutovanjaIzmeduV1iV2 = (v1.duljinaLinka) / (v1.prosjecnaBrzina * (1000.0 / 60.0));
                                    //double vrijemePutovanjaIzmeduV1iV2 = (v1.duljinaLinka) / (v1.prosjecnaBrzina * (1000 / 60));
                                    double vrijemeDolaskaDoV2 = v1.vrijemePolaska + vrijemePutovanjaIzmeduV1iV2;
                                    if (v2.obraden)
                                    {
                                        continue;
                                    }
                                    if (v2.tezina > v1.tezina + v2.prosjecnaEnergija + v1.tezinaEnergija - v2.tezinaEnergija)
                                    {
                                        FibonacciHeapNode<Vrh, double> nodeToUpdate = sviUHeapu[v2.linkID];
                                        v2.tezina = v1.tezina + v2.prosjecnaEnergija + v1.tezinaEnergija - v2.tezinaEnergija;
                                        v2.prethodni = v1;
                                        v2.vrijemePolaska = vrijemeDolaskaDoV2;
                                        heap.DecreaseKey(nodeToUpdate, v2.tezina);
                                        //za ispis
                                        v2.ukupnaDuljina = v1.ukupnaDuljina + v1.duljinaLinka;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (izbor == "energija profil")
                {

                    while (!heap.IsEmpty())
                    {
                        FibonacciHeapNode<Vrh, double> najbolji = null;
                        if (i == 0)
                        {
                            najbolji = pocetakHeapNode;
                            i++;
                        }
                        else
                        {
                            najbolji = heap.RemoveMin();
                        }
                        najbolji.Data.obraden = true;
                        if (!heap.IsEmpty())
                        {
                            v1 = najbolji.Data;
                            foreach (int linkID in v1.listaSusjednihLinkova)
                            {
                                if (listaVrhova.ContainsKey(linkID))
                                {
                                    Vrh v2 = listaVrhova[linkID];
                                    int indeksProfila = Convert.ToInt32(v1.vrijemePolaska / 5);
                                    double vrijemePutovanjaIzmeduV1iV2 = (v1.duljinaLinka) / (v1.profilBrzine[indeksProfila] * (1000.0 / 60.0));
                                    double vrijemeDolaskaDoV2 = v1.vrijemePolaska + vrijemePutovanjaIzmeduV1iV2;
                                    if (v2.obraden)
                                    {
                                        continue;
                                    }
                                    if (v2.tezina > v1.tezina + v2.profilEnergije[indeksProfila] + v1.tezinaEnergija - v2.tezinaEnergija)
                                    {
                                        FibonacciHeapNode<Vrh, double> nodeToUpdate = sviUHeapu[v2.linkID];
                                        v2.tezina = v1.tezina + v2.profilEnergije[indeksProfila] + v1.tezinaEnergija - v2.tezinaEnergija;
                                        v2.prethodni = v1;
                                        v2.vrijemePolaska = vrijemeDolaskaDoV2;
                                        heap.DecreaseKey(nodeToUpdate, v2.tezina);
                                        //za ispis
                                        v2.ukupnaDuljina = v1.ukupnaDuljina + v1.duljinaLinka;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (izbor == "duljina")
                {
                    while (!heap.IsEmpty())
                    {
                        FibonacciHeapNode<Vrh, double> najbolji = null;
                        if (i == 0)
                        {
                            najbolji = pocetakHeapNode;
                            i++;
                        }
                        else
                        {
                            najbolji = heap.RemoveMin();
                        }
                        najbolji.Data.obraden = true;
                        if (!heap.IsEmpty())
                        {
                            v1 = najbolji.Data;
                            foreach (int linkID in v1.listaSusjednihLinkova)
                            {
                                if (listaVrhova.ContainsKey(linkID))
                                {
                                    Vrh v2 = listaVrhova[linkID];
                                    double vrijemePutovanjaIzmeduV1iV2 = (v1.duljinaLinka) / (v1.prosjecnaBrzina * (1000.0 / 60.0));
                                    //double vrijemePutovanjaIzmeduV1iV2 = (v1.duljinaLinka /v1.prosjecnaBrzina)*60/1000;
                                    double vrijemeDolaskaDoV2 = v1.vrijemePolaska + vrijemePutovanjaIzmeduV1iV2;
                                    if (v2.obraden)
                                    {
                                        continue;
                                    }
                                    if (v2.tezina > v1.tezina + v1.duljinaLinka)
                                    {
                                        FibonacciHeapNode<Vrh, double> nodeToUpdate = sviUHeapu[v2.linkID];
                                        v2.tezina = v1.tezina + v1.duljinaLinka;
                                        v2.prethodni = v1;
                                        v2.vrijemePolaska = vrijemeDolaskaDoV2;
                                        heap.DecreaseKey(nodeToUpdate, v2.tezina);
                                        //za ispis
                                        v2.ukupnaEnergija = v1.ukupnaEnergija + v1.prosjecnaEnergija;
                                    }
                                }
                            }
                        }
                    }                    
                }                               
            }            
            else 
            {
                Dictionary<int, FibonacciHeapNode<Vrh, double>> sviUHeapu = new Dictionary<int, FibonacciHeapNode<Vrh, double>>();
                heap = new FibonacciHeap<Vrh, double>(double.MaxValue);
                FibonacciHeapNode<Vrh, double> pocetakHeapNode = null;
                foreach (Vrh vReset in listaVrhova.Values)
                {
                    vReset.tezina = double.MaxValue;
                    vReset.obraden = false;
                    vReset.prethodni = null;
                    vReset.vrijemePolaska = 0;
                    FibonacciHeapNode<Vrh, double> node = new FibonacciHeapNode<Vrh, double>(vReset, vReset.tezina);
                    if (vReset == vEnergija)
                    {
                        vReset.tezina = 0;
                        vReset.vrijemePolaska = vrijemePocetka;
                        pocetakHeapNode = node;
                    }
                    else
                    {
                        heap.Insert(node);
                    }
                    sviUHeapu[vReset.linkID] = node;
                }
                int i = 0;
                Vrh v1;
                if (vrijemePocetka==0)
                {
                    while (!heap.IsEmpty())
                    {
                        FibonacciHeapNode<Vrh, double> najbolji = null;
                        if (i == 0)
                        {
                            najbolji = pocetakHeapNode;
                            i++;
                        }
                        else
                        {
                            najbolji = heap.RemoveMin();
                        }
                        najbolji.Data.obraden = true;
                        if (!heap.IsEmpty())
                        {
                            v1 = najbolji.Data;
                            foreach (int linkID in v1.listaSusjednihLinkova)
                            {
                                if (listaVrhova.ContainsKey(linkID))
                                {
                                    Vrh v2 = listaVrhova[linkID];
                                    if (v2.tezinaEnergija > v1.tezinaEnergija + v2.prosjecnaEnergija)
                                    {
                                        FibonacciHeapNode<Vrh, double> nodeToUpdate = sviUHeapu[v2.linkID];
                                        v2.tezinaEnergija = v1.tezinaEnergija + v2.prosjecnaEnergija;
                                        heap.DecreaseKey(nodeToUpdate, v2.tezina);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    while (!heap.IsEmpty())
                    {
                        FibonacciHeapNode<Vrh, double> najbolji = null;
                        if (i == 0)
                        {
                            najbolji = pocetakHeapNode;
                            i++;
                        }
                        else
                        {
                            najbolji = heap.RemoveMin();
                        }
                        najbolji.Data.obraden = true;
                        if (!heap.IsEmpty())
                        {
                            v1 = najbolji.Data;
                            foreach (int linkID in v1.listaSusjednihLinkova)
                            {
                                if (listaVrhova.ContainsKey(linkID))
                                {
                                    Vrh v2 = listaVrhova[linkID];
                                    int indeksProfila = Convert.ToInt32(v1.vrijemePolaska / 5);
                                    double vrijemePutovanjaIzmeduV1iV2 = (v1.duljinaLinka) / (v1.profilBrzine[indeksProfila] * (1000.0 / 60.0));
                                    double vrijemeDolaskaDoV2 = v1.vrijemePolaska + vrijemePutovanjaIzmeduV1iV2;
                                    if (v2.tezinaEnergija > v1.tezinaEnergija + v2.profilEnergije[indeksProfila])
                                    {
                                        FibonacciHeapNode<Vrh, double> nodeToUpdate = sviUHeapu[v2.linkID];
                                        v2.tezinaEnergija = v1.tezinaEnergija + v2.profilEnergije[indeksProfila];
                                        v2.vrijemePolaska = vrijemeDolaskaDoV2;
                                        heap.DecreaseKey(nodeToUpdate, v2.tezina);
                                    }
                                }
                            }
                        }
                    }                
                }                
            }                                     
        }        

        //Metoda koja postavlja Zagreb u centar mape
        private void gMap_Load(object sender, EventArgs e)
        {
            gMap.DragButton = MouseButtons.Right;
            gMap.CanDragMap = true;
            gMap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.Position = new GMap.NET.PointLatLng(45.813, 15.977);
            gMap.MinZoom = 3;
            gMap.MaxZoom = 19;
            gMap.Zoom = 12;
            gMap.ShowCenter = false;
        }
        
        private void gMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    txtIspis.Clear();
                    PointLatLng tockaNaMapi = gMap.FromLocalToLatLng(e.X, e.Y);
                    if (poligon.IsInside(tockaNaMapi))
                    {
                        if (imaPocetnogMarkera == false && podatciUcitani)
                        {
                            pocetak = PronadiNajbliziLink(tockaNaMapi);
                            StaviPlaviMarker(tockaNaMapi,pocetak);
                            listaMarkera.Add(pocetak);
                            imaPocetnogMarkera = true;
                            brMarkera++;
                        }
                        else if (podatciUcitani)
                        {
                            zavrsetak = PronadiNajbliziLink(tockaNaMapi);
                            StaviCrveniMarker(tockaNaMapi,zavrsetak);
                            listaMarkera.Add(zavrsetak);
                            dijkstraSpremna = true;
                            brMarkera++;
                        }
                    }
                    else
                    {
                        hideSubMenu();
                        DisableButton();
                        txtIspis.ForeColor = Color.Red;
                        btnMeni.BackColor = Color.FromArgb(110, 0, 0);
                        if (sideBarExpanded)
                        {
                            txtIspis.Text = "Greška! Točka je izvan mreže";
                        }
                        else
                        {
                            txtIspis.Text = "Greška!";
                        }
                    }
                }
            }
            catch (Exception)
            {
                hideSubMenu();
                DisableButton();
                txtIspis.ForeColor = Color.Red;
                btnMeni.BackColor = Color.FromArgb(110, 0, 0);
                if (sideBarExpanded)
                {
                    txtIspis.Text = "Greška! Učitajte podatke";
                }
                else
                {
                    txtIspis.Text = "Greška!";
                }
                imaPocetnogMarkera = false;
                brMarkera = 0;
            }            
        }
        private Vrh PronadiNajbliziLink(PointLatLng tockaNaMapi)
        {
            Vrh v3 = null;
            double minUdaljenost = double.MaxValue;
            foreach (Vrh v4 in listaVrhova.Values)
            {
                double udaljenost = getDistanceFromPointToClosestPointOnLine(v4.xPocetak, v4.yPocetak, v4.xZavrsetak, v4.yZavrsetak, tockaNaMapi.Lng, tockaNaMapi.Lat);
                if (udaljenost < minUdaljenost)
                {
                    minUdaljenost = udaljenost;
                    v3 = v4;
                }
            }
            return v3;
        }
        public static double getDistanceFromPointToClosestPointOnLine(double lx1, double ly1, double lx2, double ly2, double px, double py)
        {
            //Vektorski racuna najblizu posctku
            double[] vec_l1P = new double[2] { px - lx1, py - ly1 };
            double[] vec_l1l2 = new double[2] { lx2 - lx1, ly2 - ly1 };

            double mag = Math.Pow(vec_l1l2[0], 2) + Math.Pow(vec_l1l2[1], 2);
            double prod = vec_l1P[0] * vec_l1l2[0] + vec_l1P[1] * vec_l1l2[1];
            double normDist = prod / mag;

            double clX = lx1 + vec_l1l2[0] * normDist;
            double clY = ly1 + vec_l1l2[1] * normDist;

            //Ukoliko je projkekcije izvan granica linije, korigirati na najblizu tocku na liniji
            double minLX = Math.Min(lx1, lx2);
            double minLY = Math.Min(ly1, ly2);
            double maxLX = Math.Max(lx1, lx2);
            double maxLY = Math.Max(ly1, ly2);
            if (clX < minLX)
            {
                clX = minLX;
            }
            if (clY < minLY)
            {
                clY = minLY;
            }

            if (clX > maxLX)
            {
                clX = maxLX;
            }
            if (clY > maxLY)
            {
                clY = maxLY;
            }
            //Vrati zracnu udaljenost u metrima izmedu najblize tocke na liniji i zadane tocke
            return airalDistHaversine(px, py, clX, clY);
        }

        //Pomocna metoda koja racuna zračunu udaljenost u metrima između dvije lokacije koristeći model zemlje kao kugla
        public static double airalDistHaversine(double lon1, double lat1, double lon2, double lat2)
        {

            double R = 6371000; // metres
            double phi1 = lat1 * Math.PI / 180; // φ, λ in radians
            double phi2 = lat2 * Math.PI / 180;
            double deltaphi = (lat2 - lat1) * Math.PI / 180;
            double deltaLambda = (lon2 - lon1) * Math.PI / 180;

            double a = Math.Sin(deltaphi / 2) * Math.Sin(deltaphi / 2) +
                      Math.Cos(phi1) * Math.Cos(phi2) *
                      Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double d = R * c;
            return d;
        }

        //Metode za stavljanje markera
        private void StaviPlaviMarker(PointLatLng tocka,Vrh v)
        {
            var marker = new GMarkerGoogle(tocka, GMarkerGoogleType.blue_dot);
            marker.ToolTipText = "ID ovog linka je " + pocetak.linkID;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Transparent;
            marker.ToolTip.TextPadding = new Size(20, 20);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            v.marker = marker;
            gMap.Overlays.Add(markerOverlay);
            markerOverlay.Markers.Add(marker);
        }
        private void StaviCrveniMarker(PointLatLng tocka, Vrh v)
        {
            var marker = new GMarkerGoogle(tocka, GMarkerGoogleType.red_dot);
            marker.ToolTipText = "ID ovog linka je " + zavrsetak.linkID;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Transparent;
            marker.ToolTip.TextPadding = new Size(20, 20);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            v.marker = marker;
            gMap.Overlays.Add(markerOverlay);
            markerOverlay.Markers.Add(marker);                  
        }        
        
        //Pozivanje dijsktre
        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded==false)
            {
                sideBarTimer.Start();
            }
            hideSubMenu();
            ActivateButton(sender);
            rutaOverlay.Routes.Clear();
            dogodilaSeZamjena = false;

            if (dijkstraSpremna&&brMarkera>=2)
            {
                for (int i = 0; i < listaMarkera.Count; i++)
                {
                    if (listaMarkera[i].marker != pocetak.marker)
                    {
                        List<Vrh> put = Dijkstra(pocetak, listaMarkera[i]);
                        zapamtiIDpocetka = pocetak.linkID;
                        zapamtiVrijemePocetka=vrijemePocetka;
                        IscrtajRutu(put, listaMarkera[i]);
                        ruta.IsVisible = true;
                        currentButton.BackColor = Color.BlueViolet;
                        btnMeni.BackColor = Color.FromArgb(69, 22, 113);
                    }
                }
            }
            else
            {
                txtIspis.ForeColor = Color.Red;
                txtIspis.Text = "Greška!";
                txtIspis.AppendText(" Postavite početak i završetak");
                currentButton.BackColor = Color.Red;
                btnMeni.BackColor = Color.FromArgb(110,0,0);
            }            
        }

        //Metoda za iscrtavanje rute        
        private void IscrtajRutu(List<Vrh> put, Vrh v)
        {
            List<PointLatLng> listaKordinata = new List<PointLatLng>();

            foreach (Vrh v5 in put)
            {
                listaKordinata.Add(new PointLatLng(v5.yPocetak, v5.xPocetak));
                listaKordinata.Add(new PointLatLng(v5.yZavrsetak, v5.xZavrsetak));
            }
            ruta = new GMapRoute(listaKordinata, "ruta");
            gMap.Overlays.Add(rutaOverlay);
            rutaOverlay.Routes.Add(ruta);
            ruta.Stroke = new Pen(Color.Black, 3);
            brRuta++;
            ruta.IsHitTestVisible = true; //bez ovog se nemoze kliknut na rutu
            v.ruta = ruta;
        }      
        
        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded == false)
            {
                sideBarTimer.Start();
            }
            hideSubMenu();
            ActivateButton(sender);
            //Ucitavanje podataka u listu vrhova 
            try
            {
                vEnergija.listaSusjednihLinkova = new List<int>();
                vEnergija.linkID = 1;
                vEnergija.tezinaEnergija = 0;
                vEnergija.duljinaLinka = 0;
                vEnergija.vrijemePolaska = 0;                

                while (!citanje.EndOfStream)
                {
                    string s = citanje.ReadLine().Replace('.', ',');
                    string[] d = s.Split(';');
                    int linkID = Convert.ToInt32(d[0]);
                    double xPocetak = Convert.ToDouble(d[1]);
                    double yPocetak = Convert.ToDouble(d[2]);
                    double xZavrsetak = Convert.ToDouble(d[3]);
                    double yZavrsetak = Convert.ToDouble(d[4]);
                    int duljinaLinka = Convert.ToInt32(d[5]);
                    int brzinaLinka = Convert.ToInt32(d[6]);
                    int ogranicenjeBrzine = Convert.ToInt32(d[7]);
                    int tipLinka = Convert.ToInt32(d[8]);
                    int zastavicaSmjera = Convert.ToInt32(d[9]);
                    double brzinaSlobodnogToka = Convert.ToDouble(d[11]);
                    double prosjecnaBrzina = Convert.ToDouble(d[12]);
                    double prosjecnaEnergija = Convert.ToDouble(d[15]);
                    Vrh vSvi = new Vrh
                    {
                        linkID = linkID,
                        xPocetak = xPocetak,
                        yPocetak = yPocetak,
                        xZavrsetak = xZavrsetak,
                        yZavrsetak = yZavrsetak,
                        duljinaLinka = duljinaLinka,
                        brzinaLinka = brzinaLinka,
                        ogranicenjeBrzine = ogranicenjeBrzine,
                        tipLinka = tipLinka,
                        zastavicaSmjera = zastavicaSmjera,
                        brzinaSlobodnogToka = brzinaSlobodnogToka,
                        prosjecnaBrzina = prosjecnaBrzina,
                        prosjecnaEnergija = prosjecnaEnergija                        
                    };
                    vSvi.listaSusjednihLinkova = new List<int>();
                    string[] susjedniID = d[10].Split('|');
                    for (int i = 0; i < susjedniID.Length; i++)
                    {
                        vSvi.listaSusjednihLinkova.Add(Convert.ToInt32(susjedniID[i]));
                        //brojBridova++;
                    }
                    vSvi.profilBrzine = new double[288];
                    string[] brzina = d[13].Split('|');
                    for (int i = 0; i < brzina.Length; i++)
                    {
                        vSvi.profilBrzine[i] = Convert.ToDouble(brzina[i]);
                    }
                    vSvi.profilEnergije = new double[288];
                    string[] energija = d[17].Split('|');
                    for (int i = 0; i < energija.Length; i++)
                    {
                        vSvi.profilEnergije[i] = Convert.ToDouble(energija[i]);
                    }
                    vEnergija.listaSusjednihLinkova.Add(vSvi.linkID);
                    vSvi.reset();
                    listaVrhova[linkID] = vSvi;
                    //brojVrhova++;
                }
                vEnergija.profilBrzine = listaVrhova[233703].profilBrzine;
                StvoriPoligon(listaVrhova);

                //Bellman Ford
                /*listaVrhova.Add(vEnergija.linkID, vEnergija);
                pocetak= vEnergija;
                izbor = "BellmanFord";
                FibonacciHeapMetoda(izbor);
                listaVrhova.Remove(vEnergija.linkID);*/

                citanje.Close();
                txtIspis.ForeColor = Color.Green;
                txtIspis.Text = "Podatci uspješno učitani!";
                currentButton.BackColor = Color.Green;
                btnMeni.BackColor = Color.DarkGreen;
                podatciUcitani = true;
                //MessageBox.Show("Broj vrhova: " + brojVrhova + "\n" + "Broj Bridova: " + brojBridova + "\n" + "Razlomak: " + brojBridova * 1.0 / brojVrhova);
             }
            catch (Exception ex)
            {
                txtIspis.ForeColor = Color.Red;
                txtIspis.Text = "Greška! "+ex.Message;
                currentButton.BackColor = Color.Red;
                btnMeni.BackColor = Color.DarkRed;
            }            
        }

        public void BellmanFord()
        {
            listaVrhova.Add(vEnergija.linkID, vEnergija);
            //pocetakEnergija = vEnergija;
            izbor = "BellmanFord";
            FibonacciHeapMetoda(izbor);
            listaVrhova.Remove(vEnergija.linkID);
        }

        public void StvoriPoligon(Dictionary<int, Vrh> listaVrhova)
        {
            List<PointLatLng> listaKordinata = new List<PointLatLng>();
            //podaci samo za ovo podrucje
            List<int> vrhID = new List<int>() {202768,200427,200384,200255,201483,211095,229993,230736,233777,233703,400621,401658,400247,400255,-385603,391268,-382165,382579,381473,202768};
            for (int i = 0; i < vrhID.Count; i++)
            {
                listaKordinata.Add(new PointLatLng(listaVrhova[vrhID[i]].yPocetak, listaVrhova[vrhID[i]].xPocetak));
                listaKordinata.Add(new PointLatLng(listaVrhova[vrhID[i]].yZavrsetak, listaVrhova[vrhID[i]].xZavrsetak));
            }

            poligon = new GMapPolygon(listaKordinata, "Zagreb");
            //gMap.Overlays.Add(poligonOverlay);
            poligonOverlay.Polygons.Add(poligon);
        }

        private void btnObrisiMarker_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded == false)
            {
                sideBarTimer.Start();
            }
            try
            {
                ActivateButton(sender);
                hideSubMenu();
                currentButton.BackColor = Color.FromArgb(55, 150, 150);
                btnMeni.BackColor = Color.FromArgb(39, 105, 105);
                if (brMarkera == 0)
                {
                    currentButton.BackColor = Color.Red;
                    txtIspis.ForeColor = Color.Red;
                    txtIspis.Text = "Greška! Nema postavljenih markera";
                    currentButton.BackColor = Color.Red;
                    btnMeni.BackColor = Color.FromArgb(110, 0, 0);
                }
                markerOverlay.Markers.Clear();
                brMarkera = 0;
                rutaOverlay.Routes.Clear();
                brRuta = 0;
                imaPocetnogMarkera = false;
                listaMarkera.Clear();
                poljeMarkeraZamjena = new GMarkerGoogle[2];
            }
            catch (Exception)
            {
            }
        }
        private void gMap_OnMarkerDoubleClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (item is GMarkerGoogle marker)
                {
                    foreach (Vrh v in listaMarkera)
                    {
                        if (v.marker == marker)
                        {
                            vBrisanje = v;
                            break;
                        }
                    }
                    markerOverlay.Markers.Remove(marker);
                    brMarkera--;
                    listaMarkera.Remove(vBrisanje);

                    if (marker.Type==GMarkerGoogleType.blue_dot)
                    {
                        foreach (Vrh vrh in listaMarkera) //ako nema ovog izbacuje gresku kod brisanja markera jer se uz marker brise i ruta
                        {
                            vrh.ruta = null;
                        }
                    }
                    if (dogodilaSeZamjena)
                    {
                        if (vBrisanje == zapamtiVrhPocetak)
                        {
                            rutaOverlay.Routes.Clear();
                            brRuta = 0;
                            foreach (Vrh vrh in listaMarkera) //ako nema ovog izbacuje gresku kod brisanja markera jer se uz marker brise i ruta
                            {
                                vrh.ruta = null;
                            }
                        }
                        else
                        {
                            if (vBrisanje.ruta != null)
                            {
                                rutaOverlay.Routes.Remove(vBrisanje.ruta);
                                brRuta--;
                            }
                        }
                    }
                    else
                    {
                        if (vBrisanje == pocetak)
                        {
                            rutaOverlay.Routes.Clear();
                            brRuta = 0;
                            imaPocetnogMarkera = false;
                        }
                        else
                        {
                            if (vBrisanje.ruta!=null)
                            {
                                rutaOverlay.Routes.Remove(vBrisanje.ruta);
                                brRuta--;
                            }
                        }
                    }
                }
            }
        }
        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (item is GMarkerGoogle marker)
                {
                    foreach(GMarkerGoogle markerPlavi in markerOverlay.Markers)
                    {
                        if (markerPlavi.Type == GMarkerGoogleType.blue_dot)
                        {
                            poljeMarkeraZamjena[0] = markerPlavi;
                            break;
                        }
                    }
                    if (marker.Type != GMarkerGoogleType.blue_dot)
                    {
                        poljeMarkeraZamjena[1] = marker;
                        txtIspis.ForeColor = Color.Gainsboro;
                        txtIspis.Text = "Dodan marker za zamjenu";
                    }
                    else
                    {
                        poljeMarkeraZamjena = new GMarkerGoogle[2];
                        txtIspis.ForeColor = Color.Gainsboro;
                        txtIspis.Text = "Početni marker ne može biti zamijenjen!";
                    }
                }
            }
        }

        private void btnObrisiRutu_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded == false)
            {
                sideBarTimer.Start();
            }
            ActivateButton(sender);
            currentButton.BackColor = Color.DarkOrange;
            btnMeni.BackColor = Color.FromArgb(153, 84, 0);
            hideSubMenu();
            if (brRuta == 0)
            {
                currentButton.BackColor = Color.Red;
                txtIspis.ForeColor = Color.Red;
                txtIspis.Text = "Greška! Nema rute";
                currentButton.BackColor = Color.Red;
                btnMeni.BackColor = Color.FromArgb(110, 0, 0);
            }
            else
            {
                foreach (Vrh vrh in listaMarkera) //ako nema ovog izbacuje gresku kod brisanja markera jer se uz marker brise i ruta
                {
                    vrh.ruta = null;
                }
            }
            rutaOverlay.Routes.Clear();
            brRuta=0;
        }
        private void gMap_OnRouteDoubleClick(GMapRoute item, MouseEventArgs e) 
        {
            if (e.Button == MouseButtons.Right)
            {
                if (item is GMapRoute ruta)
                {
                    rutaOverlay.Routes.Remove(ruta);
                    brRuta--;
                }
            }
        }
        private void gMap_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sideBarExpanded == false)
                {
                    sideBarTimer.Start();
                }
                if (item is GMapRoute ruta)
                {                   
                    if (premaEnergijiIspis)
                    {
                        foreach (Vrh v in listaMarkera)
                        {
                            if (v.ruta == ruta)
                            {
                                txtIspis.ForeColor = Color.Gainsboro;
                                txtIspis.Text = "Duljina puta je " + Math.Round(v.ukupnaDuljina/1000, 1) + " km, potrošnja energije je " + Math.Round(v.tezina, 4) + " kWh, a vrijeme putovanja je " + Math.Round(v.vrijemePolaska-vrijemePocetka, 2) + " min";
                                //MessageBox.Show("Duljina puta je " + Math.Round(v.ukupnaDuljina / 1000, 1) + " km, potrošnja energije je " + Math.Round(v.tezina, 4) + " kWh, a vrijeme putovanja je " + Math.Round(v.vrijemePolaska - vrijemePocetka, 2) + " min");
                                //MessageBox.Show("Route length " + Math.Round(v.ukupnaDuljina / 1000, 1) + " km " + "\n" + "Energy consumption je " + Math.Round(v.tezina, 4) + " kWh " + "\n" + "Travel time: " + Math.Round(v.vrijemePolaska - vrijemePocetka, 0) + " min");

                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (Vrh v in listaMarkera)
                        {
                            if (v.ruta == ruta)
                            {
                                txtIspis.ForeColor = Color.Gainsboro;
                                txtIspis.Text = "Duljina puta je " + Math.Round(v.tezina / 1000, 1) + " km, potrošnja energije je " + Math.Round(v.ukupnaEnergija, 4) + " kWh, a vrijeme putovanja je " + Math.Round(v.vrijemePolaska- vrijemePocetka, 2) + " min";
                                //MessageBox.Show("Duljina puta je " + Math.Round(v.tezina / 1000, 1) + " km, potrošnja energije je " + Math.Round(v.ukupnaEnergija, 4) + " kWh, a vrijeme putovanja je " + Math.Round(v.vrijemePolaska - vrijemePocetka, 2) + " min");
                                //MessageBox.Show("Route length: " + Math.Round(v.tezina / 1000, 1) + " km "+ "\n"+ "Energy consumption: " + Math.Round(v.ukupnaEnergija, 4) + " kWh "+"\n"+ "Travel time: " + Math.Round(v.vrijemePolaska - vrijemePocetka, 0) + " min");

                                break;
                            }
                        }
                    }
                }
                panelSubMenuVrijeme.Visible = false;
            }
        }
       
        private void btnNacinRutiranja_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded == false)
            {
                sideBarTimer.Start();
            }
            ActivateButton(sender);
            currentButton.BackColor = Color.CornflowerBlue;
            btnMeni.BackColor = Color.FromArgb(60, 89, 142);
            showSubMenu(panelSubMenuNacin);
        }

        private void btnPremaEnergiji_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            currentButton.BackColor = Color.FromArgb(60, 89, 142);
            btnMeni.BackColor = Color.FromArgb(60, 89, 142);
            if (premaEnergiji==false)
            {
                zapamtiIDpocetka = 0;
            }
            premaEnergiji = true;
            btnPremaEnergiji.IconChar = IconChar.CircleXmark;
            btnPremaDuljini.IconChar = IconChar.Circle;
        }

        private void btnPremaDuljini_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            currentButton.BackColor = Color.FromArgb(60, 89, 142);
            btnMeni.BackColor = Color.FromArgb(60, 89, 142);
            if (premaEnergiji == true)
            {
                zapamtiIDpocetka = 0;
            }
            premaEnergiji = false;
            btnPremaDuljini.IconChar = IconChar.CircleXmark;
            btnPremaEnergiji.IconChar = IconChar.Circle;
        }
        private void btnVrijeme_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded == false)
            {
                sideBarTimer.Start();
            }            
            ActivateButton(sender);
            currentButton.BackColor = Color.FromArgb(145, 145, 55);
            btnMeni.BackColor = Color.FromArgb(87, 87, 33);
            showSubMenu(panelSubMenuVrijeme);            
        }
        private void btnVrijemeReset_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            currentButton.BackColor = Color.FromArgb(87, 87, 33);
            btnMeni.BackColor = Color.FromArgb(87, 87, 33);
            txtVrijeme.Text = "00:00:00";
        }
        private void btnMeni_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            btnMeni.BackColor = Color.FromArgb(50, 50, 50);
            hideSubMenu();
            sideBarTimer.Start();
        }
        private void btnZamjena_Click(object sender, EventArgs e)
        {
            if (sideBarExpanded == false)
            {
                sideBarTimer.Start();
            }
            ActivateButton(sender);
            currentButton.BackColor = Color.FromArgb(106, 90, 80);
            btnMeni.BackColor = Color.FromArgb(53, 45, 40);
            hideSubMenu();
            try
            {
                if (poljeMarkeraZamjena[0] != null && poljeMarkeraZamjena[1] != null)
                {
                    markerOverlay.Markers.Remove(poljeMarkeraZamjena[0]);
                    markerOverlay.Markers.Remove(poljeMarkeraZamjena[1]);
                    foreach (Vrh v in listaMarkera)
                    {
                        if (v.marker == poljeMarkeraZamjena[0])
                        {
                            zapamtiVrhPocetak = v;
                        }
                        if (v.marker == poljeMarkeraZamjena[1])
                        {
                            zapamtiVrhZavrsetak = v;
                        }
                    }
                    poljeMarkeraZamjena[0] = new GMarkerGoogle(zapamtiVrhZavrsetak.marker.Position, GMarkerGoogleType.blue_dot);
                    poljeMarkeraZamjena[0].ToolTipText = "ID ovog linka je " + zapamtiVrhZavrsetak.linkID;
                    poljeMarkeraZamjena[0].ToolTip.Fill = Brushes.Black;
                    poljeMarkeraZamjena[0].ToolTip.Foreground = Brushes.White;
                    poljeMarkeraZamjena[0].ToolTip.Stroke = Pens.Transparent;
                    poljeMarkeraZamjena[0].ToolTip.TextPadding = new Size(20, 20);
                    poljeMarkeraZamjena[0].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    zapamtiVrhZavrsetak.marker = poljeMarkeraZamjena[0];
                    poljeMarkeraZamjena[1] = new GMarkerGoogle(zapamtiVrhPocetak.marker.Position, GMarkerGoogleType.red_dot);
                    poljeMarkeraZamjena[1].ToolTipText = "ID ovog linka je " + zapamtiVrhPocetak.linkID;
                    poljeMarkeraZamjena[1].ToolTip.Fill = Brushes.Black;
                    poljeMarkeraZamjena[1].ToolTip.Foreground = Brushes.White;
                    poljeMarkeraZamjena[1].ToolTip.Stroke = Pens.Transparent;
                    poljeMarkeraZamjena[1].ToolTip.TextPadding = new Size(20, 20);
                    poljeMarkeraZamjena[1].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    zapamtiVrhPocetak.marker = poljeMarkeraZamjena[1];
                    markerOverlay.Markers.Add(poljeMarkeraZamjena[0]);
                    markerOverlay.Markers.Add(poljeMarkeraZamjena[1]);
                    pocetak = zapamtiVrhZavrsetak;
                    poljeMarkeraZamjena = new GMarkerGoogle[2];
                    dogodilaSeZamjena = true;
                }
                else
                {
                    currentButton.BackColor = Color.Red;
                    txtIspis.ForeColor = Color.Red;
                    txtIspis.Text = "Greška! Nema odabranog markera";
                    currentButton.BackColor = Color.Red;
                    btnMeni.BackColor = Color.FromArgb(110, 0, 0);
                }
            }
            catch (Exception)
            {
                currentButton.BackColor = Color.Red;
                txtIspis.ForeColor = Color.Red;
                txtIspis.Text = "Greška! Nema odabranog markera";
                currentButton.BackColor = Color.Red;
                btnMeni.BackColor = Color.FromArgb(110, 0, 0);
            }
        }


        //UI
        private void ActivateButton(object btnSender)
        {
            txtIspis.Clear();
            if (btnSender != null)
            {
                if (currentButton != (IconButton)btnSender)
                {
                    DisableButton();
                    currentButton = (IconButton)btnSender;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                                                   
                }
            }
        }
        private void DisableButton()
        {
            if (currentButton == btnPremaDuljini)
            {
                foreach (Control previousBtn in panelSubMenuNacin.Controls)
                {
                    if (previousBtn.GetType() == typeof(IconButton))
                    {
                        previousBtn.BackColor = Color.FromArgb(10, 10, 10);
                        previousBtn.ForeColor = Color.Gainsboro;
                        previousBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                        
                        btnMeni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    }
                }
            }
            else if (currentButton == btnPremaEnergiji)
            {
                foreach (Control previousBtn in panelSubMenuNacin.Controls)
                {
                    if (previousBtn.GetType() == typeof(IconButton))
                    {
                        previousBtn.BackColor = Color.FromArgb(10, 10, 10);
                        previousBtn.ForeColor = Color.Gainsboro;
                        previousBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                        
                        btnMeni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    }
                }
            }
            else if (currentButton == btnVrijemeReset)
            {
                foreach (Control previousBtn in panelSubMenuVrijeme.Controls)
                {
                    if (previousBtn.GetType() == typeof(IconButton))
                    {
                        previousBtn.BackColor = Color.FromArgb(10, 10, 10);
                        previousBtn.ForeColor = Color.Gainsboro;
                        previousBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnMeni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    }
                }
            }
            else
            {
                foreach (Control previousBtn in sideBar.Controls)
                {
                    if (previousBtn.GetType() == typeof(IconButton))
                    {
                        previousBtn.BackColor = Color.FromArgb(10, 10, 10);
                        previousBtn.ForeColor = Color.Gainsboro;
                        previousBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnMeni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {                        
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }        

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }       

        private void panelSlide_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }        

        private void hideSubMenu()
        {
            panelSubMenuNacin.Visible = false;
            panelSubMenuVrijeme.Visible = false;
        }        

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        

        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpanded)
            {
                sideBar.Width -= 10;
                if (sideBar.Width == sideBar.MinimumSize.Width)
                {
                    txtIspis.Clear();                    
                    sideBarExpanded = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width == sideBar.MaximumSize.Width)
                {
                    sideBarExpanded = true;
                    sideBarTimer.Stop();
                }
            }
        }              
    }    
}
