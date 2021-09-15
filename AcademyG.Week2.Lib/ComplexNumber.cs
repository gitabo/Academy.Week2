using System;

namespace AcademyG.Week2.Lib
{
    public class ComplexNumber : IEquatable<ComplexNumber>
    {
        public double ParteReale { get; set; }
        public double ParteImmaginaria { get; set; }

        public ComplexNumber(double a, double b)
        {
            ParteReale = a;
            ParteImmaginaria = b;
        }

        public ComplexNumber(string compl)
        {
            string c1 = compl.Remove(0, 1);
            string c2 = c1.Remove(c1.Length - 1, 1);
            string[] numString = c2.Split(",");
            try 
            { 
                ParteReale = double.Parse(numString[0]);
                ParteImmaginaria = double.Parse(numString[1]);
            }
            catch(Exception ex)
            {
                ParteReale = 0;
                ParteImmaginaria = 0;
            }
            

        }

        public double Modulo
        {
            get
            {
                return (Math.Sqrt(Math.Pow(ParteReale, 2) + Math.Pow(ParteImmaginaria, 2)));
            }
        } 

        public ComplexNumber Coniugato
        {
            get
            {
                return new ComplexNumber(ParteReale, -ParteImmaginaria);
            }
        }

        public static ComplexNumber NeutralElementSum
        {
            get
            {
                return new ComplexNumber(0, 0);
            }
        }

        public static ComplexNumber NeutralElementProduct
        {
            get
            {
                return new ComplexNumber(1, 0);
            }
        }

        public ComplexNumber Sum(ComplexNumber num)
        {
            return new ComplexNumber(ParteReale + num.ParteReale, ParteImmaginaria+num.ParteImmaginaria);
        }

        public ComplexNumber Difference(ComplexNumber num)
        {
            return new ComplexNumber(ParteReale - num.ParteReale, ParteImmaginaria - num.ParteImmaginaria);
        }

        public ComplexNumber Product(ComplexNumber num)
        {
            double real = ParteReale * num.ParteReale - ParteImmaginaria * num.ParteImmaginaria;
            double img = ParteReale * num.ParteImmaginaria + ParteImmaginaria * num.ParteReale;
            return new ComplexNumber(real, img);
        }

        public ComplexNumber Division(ComplexNumber num)
        {
            double den = Math.Pow(num.ParteReale, 2) + Math.Pow(num.ParteImmaginaria, 2);
            double real = ((ParteReale * num.ParteReale) + (ParteImmaginaria * num.ParteImmaginaria))/den;
            double img = ((ParteImmaginaria * num.ParteReale) - (ParteReale * num.ParteImmaginaria)) / den;
            return new ComplexNumber(real, img);
        }

        public ComplexNumber Sum(double num)
        {
            return new ComplexNumber(ParteReale + num, ParteImmaginaria);
        }

        public ComplexNumber Difference(double num)
        {
            return new ComplexNumber(ParteReale - num, ParteImmaginaria);
        }

        public ComplexNumber Product(double num)
        {
            double real = ParteReale * num;
            double img = ParteImmaginaria * num;
            return new ComplexNumber(real, img);
        }

        public ComplexNumber Division(double num)
        {
            ComplexNumber value = new ComplexNumber(num, 0);

            return this.Division(value);
        }

        public static ComplexNumber CreateComplex(double real, double img)
        {
            return new ComplexNumber(real, img);
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.Sum(c2);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.Difference(c2);
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.Product(c2);
        }

        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.Division(c2);
        }

        public static ComplexNumber operator -(ComplexNumber compl)
        {
            return compl.Coniugato;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ComplexNumber);
        }

        public bool Equals(ComplexNumber other)
        {
            if (other == null)
                return false;

            return this.ParteReale == other.ParteReale && this.ParteImmaginaria == other.ParteImmaginaria;
        }

        public override int GetHashCode()
        {
            return ParteReale.GetHashCode() ^ ParteImmaginaria.GetHashCode();
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            if (object.ReferenceEquals(a, null))
            {
                if (object.ReferenceEquals(b, null))
                    return true;

                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
        {
            return !(c1 == c2);
        }

        public static explicit operator double(ComplexNumber value)
        {
            return value.Modulo;
        }

        public static implicit operator ComplexNumber(double value)
        {
            return new ComplexNumber(value, 0);
        }
    }
}
