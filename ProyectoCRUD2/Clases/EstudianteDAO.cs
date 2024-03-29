﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico
{
    public static class EstudianteDAO
    {
        private static string cadenaConexion = @"server=A-SIS-044\SVRSQL2016; database=TI2019; user id=sa; password=Isabel00";
        public static int guardar(Estudiante estudiante)
        {
            
            //definimos un objeto conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);
            
            string sql = "insert into estudiantes(matricula,apellidos,nombres,genero," +
                "fechaNacimiento,email) values(@matricula,@apellidos,@nombres,@genero," +
                "@fechaNacimiento,@email) ";

            //definimos un comando
            SqlCommand comando = new SqlCommand(sql, conn);
            //configuramos los parámetros
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@matricula", estudiante.Matricula);
            comando.Parameters.AddWithValue("@apellidos", estudiante.Apellidos);
            comando.Parameters.AddWithValue("@nombres", estudiante.Nombres);
            comando.Parameters.AddWithValue("@genero", estudiante.Genero);
            comando.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@email", estudiante.Correo);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            conn.Close();

            return x;

        }

        public static DataTable getDatos()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula,apellidos,nombres,genero," +
                "fechaNacimiento,email from estudiantes order by apellidos";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        }

    }
}
