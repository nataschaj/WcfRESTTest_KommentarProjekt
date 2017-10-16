using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRESTTest
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int NoOfRooms { get; set; }
        public int Story { get; set; }
        public int ZipCode { get; set; }
        public string Adress { get; set; }

        public Apartment()
        {

        }
    }
}