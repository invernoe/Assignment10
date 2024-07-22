namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 2
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());
            #endregion

            #region Part 3
            Point3D[] points = new Point3D[2];
            for (int i = 1; i < 3; i++)
            {
                bool isAllParsed = true;

                Console.WriteLine($"enter X for point {i}: ");
                isAllParsed &= int.TryParse(Console.ReadLine(), out int x);
                Console.WriteLine($"enter Y for point {i}: ");
                isAllParsed &= int.TryParse(Console.ReadLine(), out int y);
                Console.WriteLine($"enter Z for point {i}: ");
                isAllParsed &= int.TryParse(Console.ReadLine(), out int z);

                if (isAllParsed)
                    points[i - 1] = new Point3D(x, y, z);
                else
                    i--;
            }

            //does not work because == base implementation compares references
            Console.WriteLine($"point 1 == point 2?\n{points[0] == points[1]}");

            //array of points
            Point3D[] points2 =
            {
                new Point3D (10, 20, 10),
                new Point3D (10, 10, 10),
                new Point3D (30, 30, 30),
            };

            Array.Sort(points2);
            foreach (Point3D point in points2)
            {
                Console.WriteLine(point);
            }

            Point3D p1 = new Point3D(10, 20, 30);
            Point3D p2 = (Point3D) p1.Clone();
            #endregion
        }
    }
}
