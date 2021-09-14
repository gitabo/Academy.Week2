using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AcademyG.Week2.ClassLibrary
{
    public class ComplexNumber
    {
        public double A { get; set; }
        public double B { get; set; }

        public double Module
        {
            get
            {
                return Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
            }
            set
            
        }

        public string Conjugate
        {
            get
            {
                return $"{A} + i{-B}"; 
            }
            set
            {
               
            }
        }


        public ComplexNumber(double NumA, double NumB)
        {
            A = NumA;
            B = NumB;
        }

        public void Sum(double A1, double B1, double A2, double B2)
        {
            A = A1 + A2;
            B = B1 + B2;
        }

        public void Difference(double A1, double B1, double A2, double B2)
        {
            A = A1 - A2;
            B = B1 - B2;
        }

        public void Product(double A1, double B1, double A2, double B2)
        {
            A = A1 * A2 - B1 * B2;
            B = A1 * B2 + A2 * B1;
        }

        public void Division(double A1, double B1, double A2, double B2)
        {
            A = (A1 * A2 + B1 * B2)/(Math.Pow(A2,2)+Math.Pow(B2));
            B = (B1*A2 - A1*B2)/(Math.Pow(A2, 2) + Math.Pow(B2));
        }

    }

    
}