using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeProgramation.Programation
{
    public class Logic
    {
        Data oData = new Data();
        Util oUtil = new Util();

        int dia;
        int mes;
        int ano = DateTime.Now.Year;
        int diasMes;


        public void ProgramationPizarronStart()
        {
            oData.DeleteCafe_Programation();
            List<string>[] empleados = oData.SelectEmpleados();
            List<string>[] festivos = oData.SelectFestivos();
            int cantidadEmpelados = empleados[0].Count;
            int cantidadFestivos = festivos[0].Count;
            int contadorEmp = 0;
            string fecha;
            for (int mesContador = 1; mesContador <= 12; mesContador++) // contador del año
            {
                mes = mesContador;
                diasMes = DateTime.DaysInMonth(ano, mes);
                for (int diaContador = 1; diaContador <= diasMes; diaContador++)
                {
                    dia = diaContador;

                    DateTime dateSaturday = new DateTime(ano, mes, dia);
                    if (dateSaturday.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dia++;
                        if (dia >= 32) break;
                        if (mes == 2 && dia >= 29) break;
                        diaContador = dia;
                        DateTime dateSunday = new DateTime(ano, mes, dia);
                        if (dateSunday.DayOfWeek == DayOfWeek.Sunday)
                        {
                            dia++;
                            if (dia >= 32) break;
                            if (mes == 2 && dia >= 29) break;
                            diaContador = dia;
                            //Dentro de este if va otro if de dias festivos
                        }
                    }

                    fecha = oUtil.acomodaFecha(ano, mes, dia);
                    //////////////////////////////////////////////Calcula festivos
                    foreach (string i in festivos[0])
                    {
                        if (fecha == i)
                        {
                            dia++;
                            diaContador = dia;
                        }
                    }
                    ////////////////////////////////////////////
                    fecha = oUtil.acomodaFecha(ano, mes, dia);
                    //Console.Write(dia + "/" + mes + "/" + ano + " ");
                    //Console.Write(" ---> " + fecha);
                    string empleadoS;
                    ////////////////////////////////////////////mete a los empelados
                    if (empleados[1][contadorEmp] == (contadorEmp + 1).ToString())
                    {
                        empleadoS = empleados[0][contadorEmp];
                        oData.InsertCafe_Programation(fecha, dia.ToString(), mes.ToString(), ano.ToString(), empleadoS);
                        //Console.Write("  "+empleadoS);
                    }
                    contadorEmp++;
                    contadorEmp = (contadorEmp >= cantidadEmpelados) ? contadorEmp = 0 : contadorEmp;
                    //if (contadorEmp >= cantidadEmpelados) { contadorEmp = 0; } --Es lo mismo que la linea de arriba pero con otra sintaxis
                    ////////////////////////////////////////////
                    //Console.WriteLine();
                }
            }
        }
    }
}
