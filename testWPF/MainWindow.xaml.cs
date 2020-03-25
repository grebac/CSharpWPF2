using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Maps.MapControl.WPF;
using MyCartographyObjects;


namespace testWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region variables
        private string _objetSelect = "";
        private string _action = "";
        private List<TextBox> _listTextBox = new List<TextBox>();
        //Excel.Application app = null;
        //Excel.Workbook wb = null;
        //Excel.Worksheet ws = null;
        MapPolygon polygon = null;
        MapPolyline polyline = null;
        Pushpin pin = null;
        Polygon polygonPerso = null;
        Polyline polylinePerso = null;
        POI poiPerso = null;
        MyPersonalMapData MyPersonalMap = new MyPersonalMapData("sami", "caberg");
        #endregion
        

        #region propriété
        public string ObjetSelect
        {
            get { return _objetSelect; }
            set { _objetSelect = value; }
        }

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public List<TextBox> ListTextBox
        {
            get { return _listTextBox; }
            set { _listTextBox = value; }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        #region defineAction
        private void BouttonCreation_Click(object sender, RoutedEventArgs e)
        {
            if (Action == "creer")
            {
                BouttonCreation.IsChecked = false;
                Action = "";

                ObjetSelect = "";
                BouttonPOI.IsChecked = false;
                BouttonTrajet.IsChecked = false;
                BouttonSurface.IsChecked = false;
            }
            else
                Action = "creer";
        }

        private void BouttonModification_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
            Action = "";
            BouttonModification.IsChecked = false;
        }

        private void BouttonSuppression_Click(object sender, RoutedEventArgs e)
        {
            if (Action == "supprimer")
            {
                Action = "";
                BouttonModification.IsChecked = false;
            }
            else
            {
                Action = "supprimer";

                ObjetSelect = "";
                BouttonPOI.IsChecked = false;
                BouttonTrajet.IsChecked = false;
                BouttonSurface.IsChecked = false;
            }
        }
        #endregion

        #region defineObjet
        private void BouttonPOI_Click(object sender, RoutedEventArgs e)
        {
            if (ObjetSelect == "POI")
            {
                ObjetSelect = "";
                BouttonPOI.IsChecked = false;
            }
            else
            if(Action != "")
            {
                ObjetSelect = "POI";
                initObjet();
            }
            else
            {
                MessageBox.Show("selectionnez d'abord une action");
                BouttonPOI.IsChecked = false;
            }
        }

        private void BouttonTrajet_Click(object sender, RoutedEventArgs e)
        {
            if (ObjetSelect == "Polyline")
            {
                ObjetSelect = "";
                BouttonTrajet.IsChecked = false;
            }
            if (Action != "")
            {
                ObjetSelect = "Polyline";
                initObjet();
            }
            else
            {
                MessageBox.Show("selectionnez d'abord une action");
                BouttonTrajet.IsChecked = false;
            }
        }

        private void BouttonSurface_Click(object sender, RoutedEventArgs e)
        {
            if (ObjetSelect == "Polygon")
            {
                ObjetSelect = "";
                BouttonSurface.IsChecked = false;
            }
            if (Action != "")
            {
                ObjetSelect = "Polygon";
                initObjet();
            }
            else
            {
                MessageBox.Show("selectionnez d'abord une action");
                BouttonSurface.IsChecked = false;
            }
        }
        #endregion

        #region import/export
        private void BouttonImportPOI_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
        }

        private void BouttonExportPOI_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
        }

        private void BouttonImportTrajet_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
        }

        private void BouttonExportTrajet_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
        }
        #endregion

        #region file
        private void BouttonFileExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("fin du programme");
            System.Windows.Application.Current.Shutdown();
        }

        private void BouttonFileOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
            /*
            app = new Excel.Application();
            app.Visible = false;
            List<string> liste = new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                int i=1;
                wb = app.Workbooks.Open(openFileDialog.FileName);
                ws = wb.Sheets[1];

                while (ws.Cells[i][1].Value != null) 
                {
                    string tmp = "";
                    for (int x = 1; x <= 3; x++)
                        tmp = String.Concat(tmp, ws.Cells[i, x].Value.ToString());
                    liste.Add(tmp);
                    tmp = "";
                    i++;
                }

                foreach (string element in liste)
                    MessageBox.Show(element);

                app.Workbooks.Close();

                releaseObject(ws);
                releaseObject(wb);
                releaseObject(app);
             }
                */
            TextBox tmp = null;
            foreach(POI element in MyPersonalMap.CollectionObjets)
            {
                tmp = new TextBox();
                tmp.Text = element.Description;
                stackDesc.Children.Add(tmp);

                tmp = new TextBox();
                tmp.Text = "POI";
                stackType.Children.Add(tmp);
            }
        }
        

        private void BouttonFileSave_Click(object sender, RoutedEventArgs e)
        {
            //MyPersonalMap.export("C:\\Users\\sami\\Documents\\école");
        }
        #endregion

        #region utilitaire
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occuredwhile releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void initObjet()
        {
            TextBox tmp = null;
            switch (ObjetSelect)
            {
                case "POI":
                    //création nouveau pin
                    pin = new Pushpin();
                    poiPerso = new POI();
                    poiPerso.ObjetLie = pin;
                    break;
                    

                case "Polyline":
                    //création nouveau polyline
                    polyline = new MapPolyline();
                    polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                    polyline.StrokeThickness = 5;
                    polyline.Opacity = 0.7;
                    polyline.Locations = new LocationCollection();
                    polylinePerso = new Polyline();
                    polylinePerso.ObjetLie = polyline;

                    //ajout dans la liste et sur la map
                    Map.Children.Add(polyline);
                    MyPersonalMap.CollectionObjets.Add(polylinePerso);

                    //ajout dans la liste visuelle
                    tmp = new TextBox();
                    tmp.Text = "...";
                    stackDesc.Children.Add(tmp);
                    ListTextBox.Add(tmp);

                    tmp = new TextBox();
                    tmp.Text = "polyline";
                    stackType.Children.Add(tmp);
                    ListTextBox.Add(tmp);
                    break;

                case "Polygon":
                    //création nouvel objet MapPolygon
                    polygon = new MapPolygon();
                    polygon.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                    polygon.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                    polygon.StrokeThickness = 5;
                    polygon.Opacity = 0.7;
                    polygon.Locations = new LocationCollection();
                    polygonPerso = new Polygon();
                    polygonPerso.ObjetLie = polygon;

                    //ajout dans la liste et sur la map
                    Map.Children.Add(polygon);
                    MyPersonalMap.CollectionObjets.Add(polygonPerso);

                    //ajout dans la liste visuelle
                    tmp = new TextBox();
                    tmp.Text = "...";
                    stackDesc.Children.Add(tmp);
                    ListTextBox.Add(tmp);

                    tmp = new TextBox();
                    tmp.Text = "polygon";
                    stackType.Children.Add(tmp);
                    ListTextBox.Add(tmp);
                    break;

                default: break;
            }
        }

        private void creerObjet(Point Pos)
        {
            Location location = Map.ViewportPointToLocation(Pos);
            switch (ObjetSelect)
            {
                case "POI":
                    pin.Location = location;
                    poiPerso.Longitude = location.Longitude;
                    poiPerso.Latitude = location.Latitude;

                    //ajout dans la liste et sur la map
                    Map.Children.Add(pin);
                    MyPersonalMap.CollectionObjets.Add(poiPerso);

                    //ajout dans la liste visuelle
                    TextBox tmp = new TextBox();
                    tmp.Text = "...";
                    stackDesc.Children.Add(tmp);
                    ListTextBox.Add(tmp);

                    tmp = new TextBox();
                    tmp.Text = "POI";
                    stackType.Children.Add(tmp);
                    ListTextBox.Add(tmp);

                    //on initialise un nouveau pushpin pour enchainer la création
                    initObjet();
                    break;

                case "Polyline":
                    polyline.Locations.Add(location);
                    polylinePerso.add(new Coordonnees(location.Latitude, location.Longitude));
                    break;

                case "Polygon":
                    polygon.Locations.Add(location);
                    polygonPerso.add(new Coordonnees(location.Latitude, location.Longitude));
                    break;

                default:
                    MessageBox.Show("selectionnez un type d'objet");
                    break;
            }
        }

        private POI recherchePOI(Point Pos)
        {
            Location location = Map.ViewportPointToLocation(Pos);
            POI poitmp = null;
            int i = 0;
            int lenght = MyPersonalMap.CollectionObjets.Count();
            while(i < lenght)
            {
                if (MyPersonalMap.CollectionObjets[i] is POI)
                {
                    poitmp = (POI)MyPersonalMap.CollectionObjets[i];
                    if (poitmp.IsPointClose(new Coordonnees(location.Latitude, location.Longitude), 0.00004))
                        return poitmp;
                }
                i++;
            }
            return null;
        }

        private Polygon recherchePolygon(Point Pos)
        {
            Location location = Map.ViewportPointToLocation(Pos);
            Polygon polytmp;
            int i = 0;
            int lenght = MyPersonalMap.CollectionObjets.Count();
            while(i < lenght)
            {
                if(MyPersonalMap.CollectionObjets[i] is Polygon)
                {
                    polytmp = (Polygon)MyPersonalMap.CollectionObjets[i];
                    foreach (Coordonnees coordonnees in polytmp.Liste)
                    {
                        if (coordonnees.IsPointClose(new Coordonnees(location.Latitude, location.Longitude), 0.00004))
                            return polytmp;
                    }
                }
                i++;
            }
            return null;
        }

        private Polyline recherchePolyline(Point Pos)
        {
            Location location = Map.ViewportPointToLocation(Pos);
            Polyline polytmp;
            int i = 0;
            int lenght = MyPersonalMap.CollectionObjets.Count();
            while (i < lenght)
            {
                if (MyPersonalMap.CollectionObjets[i] is Polyline)
                {
                    polytmp = (Polyline)MyPersonalMap.CollectionObjets[i];
                    foreach (Coordonnees coordonnees in polytmp.Liste)
                    {
                        if (coordonnees.IsPointClose(new Coordonnees(location.Latitude, location.Longitude), 0.00004))
                            return polytmp;
                    }
                }
                i++;
            }
            return null;
        }

        private void supprimerObjet(Point Pos)
        {
            switch (ObjetSelect)
            {
                case "POI":
                    poiPerso = null;
                    poiPerso = recherchePOI(Pos);

                    if (poiPerso != null)
                    {
                        Map.Children.Remove(poiPerso.ObjetLie);
                        MyPersonalMap.CollectionObjets.Remove(poiPerso);
                    }
                    break;

                case "Polygon":
                    polygonPerso = recherchePolygon(Pos);

                    if(polygonPerso != null)
                    {
                        Map.Children.Remove(polygonPerso.ObjetLie);
                        MyPersonalMap.CollectionObjets.Remove(polygonPerso);
                    }
                    break;

                case "Polyline":
                    polylinePerso = recherchePolyline(Pos);

                    if (polylinePerso != null)
                    {
                        Map.Children.Remove(polylinePerso.ObjetLie);
                        MyPersonalMap.CollectionObjets.Remove(polylinePerso);
                    }
                    break;

                default:
                    MessageBox.Show("selectionnez un type d'objet");
                    break;
            }
        }

        #endregion

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //si une action est selctionnée, on override le handle par defaut
            if (Action != "")
            {
                //override
                e.Handled = true;

                //récupération des coordonnées du click
                Point Pos = e.GetPosition(this);
                Pos.Y = Pos.Y - MenuOptions.Height - toolBar.Height;
                Pos.X = Pos.X - gridListeData.Width;

                switch (Action)
                {
                    case "creer":
                        creerObjet(Pos);
                        break;

                    case "supprimer":
                        supprimerObjet(Pos);
                        break;
                }
            }
        }
    }
}

