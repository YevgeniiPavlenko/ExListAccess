using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessUserAD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lib_AccessUserAD.ReadConfig.GetConfig();
            LibFunction.GetInfoADFromUsers.InfoAdCrit("", "(department=Сектор кадрової роботи)(title=Провідний фахівець з управління персоналом)", true);
            
        }
    }
}
