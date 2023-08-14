using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Helper
{
    public class HelperClass
    {
        //public Dictionary<int, Dictionary<string, string>> colors = new Dictionary<int, Dictionary<string, string>>()
        //{
        //    { 0, 
        //      new Dictionary<string, string>() {
        //           { "color", "none"  },
        //           { "value", "0" }
        //      } 
        //    },
        //    { 1,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" },
        //           { "value", "1" }
        //      }
        //    },
        //    { 2,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" },
        //           { "value", "2" }
        //      }
        //    },
        //    { 3,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "3" }
        //      }
        //    },
        //    { 4,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "4" }
        //      }
        //    },
        //    { 5,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "5" }
        //      }
        //    },
        //    { 6,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "6" }
        //      }
        //    },
        //    { 7,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "7" }
        //      }
        //    },
        //    { 8,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "8" }
        //      }
        //    },
        //    { 9,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "9" }
        //      }
        //    },
        //    { 10,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "10" }
        //      }
        //    },
        //    { 11,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "11" }
        //      }
        //    },
        //    { 12,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "12" }
        //      }
        //    },
        //    { 13,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "13" }
        //      }
        //    },
        //    { 14,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "14" }
        //      }
        //    },
        //    { 15,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "15" }
        //      }
        //    },
        //    { 16,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "16" }
        //      }
        //    },
        //    { 17,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "17" }
        //      }
        //    },
        //    { 18,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "18" }
        //      }
        //    },
        //    { 19,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "19" }
        //      }
        //    },
        //    { 20,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "20" }
        //      }
        //    },
        //    { 21,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "21" }
        //      }
        //    },
        //    { 22,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "22" }
        //      }
        //    },
        //    { 23,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "23" }
        //      }
        //    },
        //    { 24,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "24" }
        //      }
        //    },
        //    { 25,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "25" }
        //      }
        //    },
        //    { 26,
        //      new Dictionary<string, string>() {
        //           { "color", "bla" } , { "value", "26" }
        //      }
        //    },
        //    { 27,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "27" }
        //      }
        //    },
        //    { 28,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "28" }
        //      }
        //    },
        //    { 29,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "29" }
        //      }
        //    },
        //    { 30,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "30" }
        //      }
        //    },
        //    { 31,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "31" }
        //      }
        //    },
        //    { 32,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "32" }
        //      }
        //    },
        //    { 33,
        //      new Dictionary<string, string>() {
        //           { "color", "negro" } , { "value", "33" }
        //      }
        //    },
        //    { 34,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "34" }
        //      }
        //    },
        //    { 35,
        //      new Dictionary<string, string >() {
        //           { "color", "negro" },{ "value", "35" }
        //      }
        //    },
        //    { 36,
        //      new Dictionary<string, string>() {
        //           { "color", "rojo" } , { "value", "36" }
        //      }
        //    },
        ////};

         

        public int RandomNumber()
        {
            Random random = new Random();

            // Obtiene un número aleatorio entre 0 y 36
            int number = random.Next(0, 37);
            return number;
        }
    }

    public class RouletteData
    {
        public string Color { get; set; }
        public string Value { get; set; }

        public static Dictionary<int, RouletteData> InitializeRouletteData()
        {
            return new Dictionary<int, RouletteData>
        {
            { 0, new RouletteData { Color = "none", Value = "0" } },
            { 1, new RouletteData { Color = "rojo", Value = "1" } },
            { 2, new RouletteData { Color = "negro", Value = "2" } },
            { 3, new RouletteData { Color = "rojo", Value = "3" } },
            { 4, new RouletteData { Color = "negro", Value = "4" } },
            { 5, new RouletteData { Color = "rojo", Value = "5" } },
            { 6, new RouletteData { Color = "negro", Value = "6" } },
            { 7, new RouletteData { Color = "rojo", Value = "7" } },
            { 8, new RouletteData { Color = "negro", Value = "8" } },
            { 9, new RouletteData { Color = "rojo", Value = "9" } },
            { 10, new RouletteData { Color = "negro", Value = "10" } },
            { 11, new RouletteData { Color = "negro", Value = "11" } },
            { 12, new RouletteData { Color = "rojo", Value = "12" } },
            { 13, new RouletteData { Color = "negro", Value = "13" } },
            { 14, new RouletteData { Color = "rojo", Value = "14" } },
            { 15, new RouletteData { Color = "negro", Value = "15" } },
            { 16, new RouletteData { Color = "rojo", Value = "16" } },
            { 17, new RouletteData { Color = "negro", Value = "17" } },
            { 18, new RouletteData { Color = "rojo", Value = "18" } },
            { 19, new RouletteData { Color = "rojo", Value = "19" } },
            { 20, new RouletteData { Color = "negro", Value = "20" } },
            { 21, new RouletteData { Color = "rojo", Value = "21" } },
            { 22, new RouletteData { Color = "negro", Value = "22" } },
            { 23, new RouletteData { Color = "rojo", Value = "23" } },
            { 24, new RouletteData { Color = "negro", Value = "24" } },
            { 25, new RouletteData { Color = "rojo", Value = "25" } },
            { 26, new RouletteData { Color = "negro", Value = "26" } },
            { 27, new RouletteData { Color = "rojo", Value = "27" } },
            { 28, new RouletteData { Color = "negro", Value = "28" } },
            { 29, new RouletteData { Color = "negro", Value = "29" } },
            { 30, new RouletteData { Color = "rojo", Value = "30" } },
            { 31, new RouletteData { Color = "negro", Value = "31" } },
            { 32, new RouletteData { Color = "rojo", Value = "32" } },
            { 33, new RouletteData { Color = "negro", Value = "33" } },
            { 34, new RouletteData { Color = "rojo", Value = "34" } },
            { 35, new RouletteData { Color = "negro", Value = "35" } },
            { 36, new RouletteData { Color = "rojo", Value = "36" } },

            // Add more entries as needed
        };
        }
    }





}