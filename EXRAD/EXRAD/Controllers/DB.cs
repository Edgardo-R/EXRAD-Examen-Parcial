using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using EXRAD.Model;
using EXRAD.Controllers;
using System.Threading.Tasks;

namespace EXRAD.Controllers
{
    internal static class DB
    {
        public static SQLiteAsyncConnection dbconexion;
        public static void conexion(string dbpath)
        {
            dbconexion = new SQLiteAsyncConnection(dbpath);
            dbconexion.CreateTableAsync<Contactos>();
        }
        public static Task<List<Contactos>>obtenerListaContactos()
        {
            return DB.dbconexion.Table<Contactos>().ToListAsync();
        }
        public static Task<int> AddContacto(Contactos contacto)
        {
            if(contacto.ID!=0)
            {
                return DB.dbconexion.UpdateAsync(contacto);
            }
            else
            {
                return DB.dbconexion.InsertAsync(contacto);
            }
        }
        public static Task<Contactos> ObtenerContacto(int pid)
        {
            return DB.dbconexion.Table<Contactos>()
                .Where(i=>i.ID==pid)
                .FirstOrDefaultAsync();
        }
        public static Task<int> DelContactoAsync(Contactos contacto)
        {
            return dbconexion.DeleteAsync(contacto); 
        }
    }
}
