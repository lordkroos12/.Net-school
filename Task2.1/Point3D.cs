
namespace Task2._1
{
	internal class Point3D
	{
		private int[] coordinates = new int[3];
		private double mass;

		public int X
		{
			get { return coordinates[0]; }
			set { coordinates[0] = value; }
		}

		public int Y
		{
			get { return coordinates[1]; }
			set { coordinates[1] = value; }
		}

		public int Z
		{
			get { return coordinates[2]; }
			set { coordinates[2] = value; }
		}

		public double Mass
		{
			get { return mass; }
			set { mass = value >= 0 ? value : 0; }
		}

		public bool IsZero()
		{
			if (X == 0 && Y == 0 && Z == 0)
			{
				return true;
			}
			else
			{
				return false;
			}	
		}

		public double Distance(Point3D point)
		{
			int deltaX = X - point.X;
			int deltaY = Y - point.Y;
			int deltaZ = Z - point.Z;
			return Math.Sqrt(Math.Pow(deltaX,2) + Math.Pow(deltaY,2)+ Math.Pow(deltaZ,2));
		}
	}
}
