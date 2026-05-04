using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    // =========================
    // FLYWEIGHT (Intrinsic State)
    // =========================
    public class Icon
    {
        // 🔹 INTRINSIC (shared, heavy, immutable)
        private readonly string _imageData;   // e.g., bitmap/SVG data
        private readonly string _iconName;

        public Icon(string iconName, string imageData)
        {
            _iconName = iconName;
            _imageData = imageData;
        }

        // Note: extrinsic data is passed as parameters
        public void Draw(int x, int y, int size, string color)
        {
            Console.WriteLine(
                $"Drawing {_iconName} at ({x},{y}), size={size}, color={color} " +
                $"using shared imageData={_imageData}");
        }
    }

    // =========================
    // FLYWEIGHT FACTORY (ensures sharing)
    // =========================
    public class IconFactory
    {
        private readonly Dictionary<string, Icon> _icons = new();

        public Icon GetIcon(string name)
        {
            if (!_icons.ContainsKey(name))
            {
                Console.WriteLine($"Creating shared Icon for: {name}");

                // 🔹 INTRINSIC created only once
                _icons[name] = new Icon(name, $"{name}-bitmap-data");
            }

            return _icons[name];
        }
    }

    // =========================
    // CONTEXT (Extrinsic State)
    // =========================
    public class IconUsage
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _size;
        private readonly string _color;

        private readonly Icon _icon; // reference to shared flyweight

        public IconUsage(int x, int y, int size, string color, Icon icon)
        {
            // 🔹 EXTRINSIC (varies per usage)
            _x = x;
            _y = y;
            _size = size;
            _color = color;

            _icon = icon;
        }

        public void Draw()
        {
            // pass extrinsic data to intrinsic object
            _icon.Draw(_x, _y, _size, _color);
        }
    }

    // =========================
    // CLIENT
    // =========================
    class FlyWeightTest
    {
        public static void Test()
        {
            var factory = new IconFactory();

            var usages = new List<IconUsage>();

            // Same icon reused multiple times
            var saveIcon = factory.GetIcon("Save");
            usages.Add(new IconUsage(10, 10, 16, "Red", saveIcon));
            usages.Add(new IconUsage(50, 20, 32, "Blue", saveIcon));
            usages.Add(new IconUsage(100, 40, 24, "Green", saveIcon));

            // Another icon
            var openIcon = factory.GetIcon("Open");
            usages.Add(new IconUsage(200, 50, 16, "Black", openIcon));

            foreach (var usage in usages)
            {
                usage.Draw();
            }
        }
    }
}
