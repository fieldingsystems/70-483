using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialMethod
{
    // code produced i some source code file
    sealed partial class Base
    {
        private String m_name;

        // this defines the partial method. and is called vefore changing the m_name field
        partial void OnNameChanging(String value);

        public String Name 
        {
            get { return m_name; }
            set 
            {
                OnNameChanging(value.ToUpper());// inform class of potential change
                m_name = value; // change the field
            }
        }
    }

    // code produced in some other source code file
    sealed partial class Base
    {
        // this implementation of partial method is called vefore the m_name is changed
        partial void OnNameChanging(String value)
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
