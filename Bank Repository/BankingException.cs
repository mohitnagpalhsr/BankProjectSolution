using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Repository
{
    public class BankingException : Exception
    {
        public BankingException(string message) : base(message)
        {
            //Console.WriteLine(message);
        }
    }
}
