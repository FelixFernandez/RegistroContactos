using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DAL;

namespace BLL
{
    public class Contacto
    {
        public int contactoId { get; set; }
        public string correo { get; set; }
        public string asunto { get; set; }
        public string mensaje { get; set; }


        public Contacto()
        {

            this.contactoId = 0;
            this.correo = "";
            this.asunto = "";
            this.mensaje = "";
        }

        public bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Insert Into Contacto (ContactoId,Correo,Asunto,Mensaje) Values('" + this.contactoId + "','" + this.correo + "','" + this.asunto + "','" + this.mensaje + "') Select @@Identity");
            return retorno;
        }

        public bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Update Contacto set Correo = '" + this.correo + "' Where ContactoId = " + this.contactoId);
            return retorno;
        }

        public bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Delete from Contacto where ContactoId=" + this.contactoId);
            return retorno;
        }

        public bool Buscar(int ContactoId)
        {
            bool retorno = false;
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();
            dt = conexion.ObtenerDatos("select * from Contacto where ContactoId = " + this.contactoId);
            if (dt.Rows.Count > 0)
            {
                contactoId = (int)dt.Rows[0]["ContactoId"];
                correo = dt.Rows[0]["Correo"].ToString();
                asunto = dt.Rows[0]["Asunto"].ToString();
                mensaje = dt.Rows[0]["Mensaje"].ToString();

                retorno = true;
            }

            return retorno;
        }

        public  DataTable Listar(string Campos, string filtro, string orden)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.ObtenerDatos("select " + Campos + " from Contacto where " + filtro + " order by ContactoId " + orden);

        }


    }
}