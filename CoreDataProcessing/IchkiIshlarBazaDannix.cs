using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreDataProcessing
{
    public class IchkiIshlarBazaDannix
    {
        public string pinpp           { get; set;}  
        public string surname_latin   { get; set;}
        public string name_latin      { get; set;}
        public string patronym_latin  { get; set;}
        public string bdate           { get; set;}
        public string psp             { get; set;}
        public string doc_give_date   { get; set;}
        public string doc_end_date    { get; set;}
        public string division        { get; set;}
        public string viloyati        { get; set;}
        public string tumani          { get; set;}
        public string address         { get; set;}
        public string date_out        { get; set;}
        public string country_out     { get; set;}
        public string trans_number    { get; set;}
        public string trip_purpose    { get; set; }

    }
}
