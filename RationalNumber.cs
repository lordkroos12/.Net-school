using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4._2
{
	internal class RationalNumber :IComparable<RationalNumber>
	{
        public int Numerator { get; private set; }
		private int denominator;

		public int Denominator
		{
			get { return denominator; }
			private set {
				if (value == 0)
				{
					throw new ArgumentException("Denominator must be different from 0!");
				}	
				denominator = value; 
			}
		}


		private RationalNumber(int n, int m)
        {
            this.Numerator = n;
            this.Denominator = m;
			Rationalize();
        }
        public static RationalNumber getInstance(int n, int m)
        {
            return new RationalNumber(n,m);
        }

		private static int GCD(int a, int b)
		{
			while (a != 0 && b != 0)
			{
				if (a > b)
					a %= b;
				else
					b %= a;
			}

			return a | b;
		}

		public void Rationalize()
		{ 
			int divisor = GCD(Numerator, Denominator);
			Numerator = Numerator / divisor;
			Denominator = Denominator/ divisor;
		}

		public override string ToString()
		{
			return $"{Numerator}/{Denominator}";
		}
		public override bool Equals(object? obj)
		{
			if (obj is null || obj is not RationalNumber)
			{
				return false;
			}
			RationalNumber other = obj as RationalNumber;
			return Numerator == other.Numerator && Denominator == other.Denominator;	
		}
		public override int GetHashCode()
		{
			return Numerator.GetHashCode() ^ Denominator.GetHashCode();
		}

		public int CompareTo(RationalNumber? other)
		{
			double thisValue = (double)Numerator / Denominator;
			double otherValue = (double)other.Numerator / other.Denominator;
			return thisValue.CompareTo(otherValue);
		}

		public static RationalNumber operator +(RationalNumber a, RationalNumber b)
		{
			int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
			int denominator = a.Denominator * b.Denominator;
			return new RationalNumber(numerator, denominator);
		}
		public static RationalNumber operator -(RationalNumber a, RationalNumber b)
		{
			int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
			int denominator = a.Denominator * b.Denominator;
			return new RationalNumber(numerator, denominator);
		}

		public static RationalNumber operator *(RationalNumber a, RationalNumber b)
		{
			int numerator = a.Numerator * b.Numerator;
			int denominator = a.Denominator * b.Denominator;
			return new RationalNumber(numerator, denominator);
		}

		public static RationalNumber operator /(RationalNumber a, RationalNumber b)
		{
			if (b.Numerator == 0)
				throw new DivideByZeroException("Cannot divide by zero.");

			int numerator = a.Numerator * b.Denominator;
			int denominator = a.Denominator * b.Numerator;
			return new RationalNumber(numerator, denominator);
		}
		public static explicit operator double(RationalNumber rational)
		{
			return (double)rational.Numerator / rational.Denominator;
		}
		public static implicit operator RationalNumber(int value)
		{
			return new RationalNumber(value, 1);
		}
	}
}
