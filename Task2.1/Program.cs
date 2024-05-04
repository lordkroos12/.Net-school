namespace Task2._1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Point3D point1 = new Point3D();
			point1.X = 4;
			point1.Y = 3;
			point1.Z = 2;
			point1.Mass = 9;

			Point3D point2 = new Point3D();
			point2.X = 1;
			point2.Y = 3;
			point2.Z = 2;
			point2.Mass = -7;

			Console.WriteLine($"Is Point 1 zero: {point1.IsZero()}");
			Console.WriteLine($"Is Point 2 zero: {point2.IsZero()}");

			Console.WriteLine($"Distance between Point 1 and Point 2: {point1.Distance(point2)}");
		}
	}
}
