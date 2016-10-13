using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robert.Models
{
    public class Bal
    {
        public string Save(Class1 c)
        {
            Dal d = new Dal();
            return d.Save(c);
        }

        public string Update(Class1 c)
        {
            Dal d = new Dal();
            return d.Update(c);
        }
        public string Delete(Class1 c)
        {
            Dal d = new Dal();
            return d.Delete(c);
        }
        public string login(string USERNAME, string PASSWORD)
        {
            Dal d = new Dal();
            return d.login( USERNAME,  PASSWORD);
        }
    }
}