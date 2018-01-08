using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class ClassModel
    {
        /// <summary>
        /// Private instanser til model lib klassen.
        /// </summary>

        private string navn;

        private double x1;

        private double x2;

        private double x3;

        private double x4;


        /// <summary>
        /// Get set string Variable.
        /// </summary>
        public string Navn
        {
            get => navn;
            set
            {


                try
                {
                    navn = value;
                    GetNavn();

                }
                catch (ArgumentException)
                {
                    value = null;
                    navn = value;
                    Console.WriteLine("Navn skal være længere end 4 tegn!");
                }
            }
        }

        /// <summary>
        /// Get set for double variable
        /// </summary>
        public double X1
        {
            get => x1;
            set => x1 = value;
        }

        /// <summary>
        /// Get set double variable
        /// </summary>
        public double X2
        {
            get => x2;
            set => x2 = value;
        }

        /// <summary>
        /// Get set med try catch, x3 kan ikke være null.
        /// </summary>
        public double X3
        {
            get => x3;
            set
            {
                try
                {
                    x3 = value;
                    GetX3();
                }
                catch (NullReferenceException)
                {
                    value = 0;
                    x3 = value;
                    Console.WriteLine("X3 Feltet kan ikke være nul!");
                }
            }
        }

        /// <summary>
        /// int med fejlhåndtering ved forkert antal. hvis uger ikke er mellem 1 og 52 begge tal inkluderet.
        /// </summary>
        public double X4
        {
            get => x4;

            set
            {
                //=> x4 = value;

                try
                {
                    x4 = value;
                    GetX4();
                }

                catch (ArgumentException)
                {
                    value = 0;
                    x4 = value;
                    Console.WriteLine("x4 er mellem 1 og 52!");
                }


            }
        }


        public ClassModel()
        //: this(1, "Dummy", "Dummy2", 11, "Dummy3", 77)
        {

        }

        public ClassModel(string navn, double x1, double x2, double x3, int x4)
        {

            this.navn = navn;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }


        public string GetNavn()
        {

            if (navn.Length > 4)
            {
                return navn;
            }
            else
            {
                throw new ArgumentException("Navnet skal være længere end 4 tegn.");
            }
        }

        public double GetX3()
        {
            if (X3 != 0)
            {
                return X3;
            }
            else
            {
                throw new NullReferenceException("X3 variable må ikke være null.");
            }
        }

        /// <summary>
        /// Catch try på double X4 variable som ikke må være under 1 eller større end 52. 
        /// </summary>
        /// <returns></returns>
        public double GetX4()
        {
            if (X4 >= 1 && X4 <= 52)
            {
                return X4;
            }
            //else
            {
                throw new ArgumentException("Uger er mellem 1 og 52");
            }
        }



        public override string ToString()
        {
            return "string: " + Navn + "double: " + X1 + " double: " + X2 + " double: " + X3 + "double: " +
                   X4;

        }
    }
}
