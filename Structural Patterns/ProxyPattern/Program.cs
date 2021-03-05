using System;

namespace ProxyPattern
{
    interface Image
    {
        void Display();
    }

    class RealImage : Image
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromDisk(fileName);
        }
        public void Display()
        {
            Console.WriteLine("Displaying " + fileName);
        }

        public void LoadFromDisk(string fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
    }

    class ProxyImage : Image
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }
        public void Display()
        {
            if (realImage == null)
                realImage = new RealImage(fileName);
            realImage.Display();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Image image = new ProxyImage("Test.jpg");
            Console.WriteLine("Image will be loaded from disk...");
            image.Display();
            Console.WriteLine("Image is already loaded from the disk...");
            image.Display();
        }
    }
}

/*
Output:
Image will be loaded from disk...
Loading Test.jpg
Displaying Test.jpg
Image is already loaded from the disk...
Displaying Test.jpg
*/