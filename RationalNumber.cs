namespace Task4._2
{
	internal class RationalNumber : IComparable<RationalNumber>
	{
		public int Numerator { get; private set; }
		private int denominator;
		public int Denominator
		{
			get { return denominator; }
			private set
			{
				denominator = value;
			}
		}

		public RationalNumber(int n, int m)
		{
			this.Numerator = n;
			this.Denominator = m;

			if (Denominator < 0)
			{
				Numerator = -Numerator;
				Denominator = -Denominator;
			}

			Rationalize();
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
			Denominator = Denominator / divisor;
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
			int left = Numerator * other.Denominator;
			int right = other.Numerator * Denominator;

			return left.CompareTo(right);
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
