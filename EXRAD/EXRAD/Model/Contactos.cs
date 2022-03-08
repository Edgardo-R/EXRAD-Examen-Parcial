using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EXRAD.Model
{
    public class Contactos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombres { get; set; }
        [MaxLength(100)]
        public string Apellidos { get; set; }
        [MaxLength(100)]
        public int Celular { get; set; }
        public int Edad { get; set; }
        public string Pais { get; set; }
        public string Nota { get; set; }
        [MaxLength(100)]
        public double Latitud { get; set; }
        public double Longitud { get; set; }

    }
}
