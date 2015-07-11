using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeProgramation.Programation
{
    public class Util
    {
        public string acomodaFecha(int ano, int mes, int dia)
        {
            string fecha;
            string anoS = ano.ToString();
            string mesS;
            string diaS;
            mesS = (mes < 10) ? mesS = "0" + mes : mesS = mes.ToString();
            diaS = (dia < 10) ? diaS = "0" + dia : diaS = dia.ToString();
            fecha = anoS + mesS + diaS;
            return fecha;
        }
    }
}
