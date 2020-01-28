using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vector2D vec2D = new Vector2D(2, 1, 2);
            Vector3D vec3D = new Vector3D(3, 2, 3, 4);
            Console.WriteLine("Scalar");
            Console.WriteLine(vec2D.Scalar());
            Console.WriteLine(vec3D.Scalar());
            _ = Console.ReadLine();
        }

    }

    public abstract class Vector
    {
        protected int dimension;

        public Vector(int dim)
        {
            Console.WriteLine("Dimension dans vector : " + dimension);
            dimension = dim;
        }

        public abstract int Scalar();
    }

    public class Vector2D : Vector
    {
        private int x, y;
        public Vector2D(int dimension, int xx, int yy) : base(dimension)
        {
            Console.WriteLine("In constructor 2D");
            x = xx;
            y = yy;
        }

        public override int Scalar()
        {
            return x * y * dimension;
        }
    }
    public class Vector3D : Vector
    {
        private int x, y, z;
        public Vector3D(int dimension, int xx, int yy, int zz) : base(dimension)
        {
            Console.WriteLine("In constructor 3D");
            x = xx;
            y = yy;
            z = zz;
        }
        public override int Scalar()
        {
            return x * y * z * dimension;
        }
    }
}
