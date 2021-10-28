using System;

namespace ClassBoxData
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double length;
        private double width;
        private double height;

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * length * height + 2 * width * height;
        }

        public double Volume()
        {
            return length * width * height;
        }
    }
}
