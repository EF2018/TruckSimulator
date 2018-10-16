using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TruckSimulator
{
    class City
    {
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Coordinate Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }

        #region CTOR
        public City(string name)
        {
            _name = name;
        }

        public City(Coordinate coordinate)
        {
            _coordinate.Lat = coordinate.Lat;
            _coordinate.Lng = coordinate.Lng;
        }
        #endregion

        private string GetHtml()
        {
            string adressstring = "http://openstreetmap.ru/api/search?q=" + Name;

            HttpWebRequest request = WebRequest.Create(adressstring) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            StreamReader str = new StreamReader(response.GetResponseStream());
            string doc = str.ReadToEnd();
            return doc;
        }

        public string FindGeoCoordinate()
        {
            dynamic json = JObject.Parse(this.GetHtml());

            Coordinate.Lng = json.matches[0].lon;
            Coordinate.Lat = json.matches[0].lat;

            return Coordinate.Lng + "," + Coordinate.Lat;
        }


        #region Attributes
        string _name;
        Coordinate _coordinate;
        #endregion
    }
}