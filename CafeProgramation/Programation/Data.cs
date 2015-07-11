using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace CafeProgramation.Programation
{
    public class Data
    {
        Conexion oConexion = new Conexion();

        public List<string>[] SelectEmpleados()
        {
            string query = "SELECT * FROM EMPLEADO ORDER BY NOLISTA";
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            if (oConexion.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, oConexion.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["noempleado"] + "");
                    list[1].Add(dataReader["nolista"] + "");
                    list[2].Add(dataReader["nombre"] + "");
                    list[3].Add(dataReader["apellido"] + "");
                }

                dataReader.Close();
                oConexion.CLoseConection();
                return list;
            }
            else
            {
                return list;
            }
        }
        public List<string>[] SelectFestivos()
        {
            string query = "SELECT * FROM FESTIVOS";
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            if (oConexion.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, oConexion.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idfechafestivo"] + "");
                    list[1].Add(dataReader["dia"] + "");
                    list[2].Add(dataReader["mes"] + "");
                    list[3].Add(dataReader["ano"] + "");
                    list[4].Add(dataReader["descripcion"] + "");
                }

                dataReader.Close();
                oConexion.CLoseConection();
                return list;
            }
            else
            {
                return list;
            }
        }
        public void DeleteCafe_Programation()
        {
            string query = "DELETE FROM cafe_programation ";
            if (oConexion.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, oConexion.connection);
                cmd.ExecuteNonQuery();
                oConexion.CLoseConection();
            }
        }
        public void InsertCafe_Programation(string idfecha, string dia, string mes, string ano, string noempleado)
        {
            string query = "INSERT INTO cafe_programation VALUES(" + idfecha + "," + dia + "," + mes + "," + ano + "," + noempleado + ")";
            if (oConexion.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, oConexion.connection);
                cmd.ExecuteNonQuery();
                oConexion.CLoseConection();
            }
        }
        public string SelectEmpleadoCafeHoy(string fecha)
        {
            string query = "SELECT E.NOMBRE FROM empleado E, cafe_programation P WHERE E.noempleado = P.noempleado AND P.idfecha = " + fecha;
            string result = "";

            if (oConexion.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, oConexion.connection);
                    result = cmd.ExecuteScalar().ToString();
                    oConexion.CLoseConection();
                    return result;
                }
                catch (Exception)
                {
                    return "Hoy no le toca a nadie";
                }
            }
            else
            {
                return result;
            }
        }
        public int SelectCantidadDiasMes(int mes, int ano)
        {
            string query1 = "SELECT COUNT(*) FROM cafe_programation WHERE mes = "+mes+ " AND ano = "+ano;
            string result1 = "";
            if (oConexion.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query1, oConexion.connection);
                    result1 = cmd.ExecuteScalar().ToString();
                    oConexion.CLoseConection();
                    return Int32.Parse(result1);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public ProgramationObject[] SelectDiasMes(int mes, int ano)
        {
            int cantidadRegistros = SelectCantidadDiasMes(mes, ano);
            string query = "SELECT cafe_programation.idfecha, cafe_programation.dia, cafe_programation.mes, cafe_programation.ano, empleado.nombre FROM cafe_programation, empleado WHERE cafe_programation.noempleado = empleado.noempleado AND MES = " + mes + " AND " + "ANO = " + ano + " ORDER BY IDFECHA";
            ProgramationObject[] diasMes = new ProgramationObject[cantidadRegistros];

            if (oConexion.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, oConexion.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int i = 0;
                while (dataReader.Read())
                {
                    diasMes[i] = ReadSingleRow((IDataRecord)dataReader);
                    i++;
                }

                dataReader.Close();
                oConexion.CLoseConection();
                return diasMes;
            }
            else
            {
                return diasMes;
            }
        }
        private static ProgramationObject ReadSingleRow(IDataRecord record)
        {
            ProgramationObject objecto = new ProgramationObject();
            objecto.idfecha = record[0]+"";
            objecto.dia = int.Parse(record[1]+"");
            objecto.mes = int.Parse(record[2]+"");
            objecto.ano = int.Parse(record[3]+"");
            objecto.noempleado = record[4]+"";
            return objecto;
        }
    }
}
