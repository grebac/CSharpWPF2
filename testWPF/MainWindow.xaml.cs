﻿using System;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Maps.MapControl.WPF;


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
        //Excel.Application app = null;
        //Excel.Workbook wb = null;
        //Excel.Worksheet ws = null;
        MapPolygon polygon = null;
        MapPolyline polyline = null;
        Pushpin pin = null;

        private List<MapPolygon> _listePolygon = new List<MapPolygon>();
        private List<MapPolyline> _listePolyline = new List<MapPolyline>();
        private List<Pushpin> _listePushPin = new List<Pushpin>();
        #endregion

        #region propriété
        public List<Pushpin> ListePushpin
        {
            get { return _listePushPin; }
            set { _listePushPin = value; }
        }


        public List<MapPolyline> ListePolyline
        {
            get { return _listePolyline; }
            set { _listePolyline = value; }
        }


        public List<MapPolygon> ListePolygon
        {
            get { return _listePolygon; }
            set { _listePolygon = value; }
        }

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

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            connexion co = new connexion();
            co.Show();
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
        }
        

        private void BouttonFileSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("en construction");
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

        private bool IsCloseTo(double x1, double y1, double x2, double y2, double precision)
        {
            double Xtmp = Math.Pow(x2 - x1,2);
            double Ytmp = Math.Pow(y2 - y1, 2);
            double distanceFinale = Math.Pow(Xtmp + Ytmp,0.5);

            return (precision >= distanceFinale);
        }

        private void initObjet()
        {
            switch (ObjetSelect)
            {
                case "POI":
                    //création nouveau pin
                    pin = new Pushpin();
                    break;

                case "Polyline":
                    //création nouveau polyline
                    polyline = new MapPolyline();
                    polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                    polyline.StrokeThickness = 5;
                    polyline.Opacity = 0.7;
                    polyline.Locations = new LocationCollection();

                    //ajout dans la liste et sur la map
                    Map.Children.Add(polyline);
                    ListePolyline.Add(polyline);
                    break;

                case "Polygon":
                    //création nouvel objet MapPolygon
                    polygon = new MapPolygon();
                    polygon.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                    polygon.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                    polygon.StrokeThickness = 5;
                    polygon.Opacity = 0.7;
                    polygon.Locations = new LocationCollection();

                    //ajout dans la liste et sur la map
                    Map.Children.Add(polygon);
                    ListePolygon.Add(polygon);
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

                    //ajout dans la liste et sur la map
                    Map.Children.Add(pin);
                    ListePushpin.Add(pin);

                    initObjet();
                    break;

                case "Polyline":
                    polyline.Locations.Add(location);
                    break;

                case "Polygon":
                    polygon.Locations.Add(location);
                    break;

                default:
                    MessageBox.Show("selectionnez un type d'objet");
                    break;
            }
        }

        private Pushpin recherchePushpin(Point Pos)
        {
            Point tmp = new Point();

            foreach (Pushpin element in ListePushpin)
            {
                tmp = Map.LocationToViewportPoint(element.Location);

                if (IsCloseTo(tmp.X, tmp.Y, Pos.X, Pos.Y, 20))
                {
                    Map.Children.Remove(element);
                    ListePushpin.Remove(element);
                    return element;
                }
            }
            return null;
        }

        private MapPolygon recherchePolygon(Point Pos)
        {

            foreach (MapPolygon element in ListePolygon)
            {
                Point tmp = new Point();

                foreach (Location locElement in element.Locations)
                {
                    tmp = Map.LocationToViewportPoint(locElement);

                    if (IsCloseTo(tmp.X, tmp.Y, Pos.X, Pos.Y, 20))
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        private MapPolyline recherchePolyline(Point Pos)
        {
            Point tmp = new Point();
            foreach (MapPolyline element in ListePolyline)
            {
                foreach (Location locElement in element.Locations)
                {
                    tmp = Map.LocationToViewportPoint(locElement);

                    if (IsCloseTo(tmp.X, tmp.Y, Pos.X, Pos.Y, 20))
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        private void supprimerObjet(Point Pos)
        {
            switch (ObjetSelect)
            {
                case "POI":
                    pin = recherchePushpin(Pos);

                    if (pin != null)
                    {
                        Map.Children.Remove(pin);
                        ListePushpin.Remove(pin);
                    }
                    break;

                case "Polygon":
                    polygon = recherchePolygon(Pos);

                    if(polygon != null)
                    {
                        Map.Children.Remove(polygon);
                        ListePolygon.Remove(polygon);
                    }
                    break;

                case "Polyline":
                    polyline = recherchePolyline(Pos);

                    if (polyline != null)
                    {
                        Map.Children.Remove(polyline);
                        ListePolyline.Remove(polyline);
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

                switch(Action)
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

