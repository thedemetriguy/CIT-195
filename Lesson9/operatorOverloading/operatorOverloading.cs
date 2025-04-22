using System;

namespace InventoryManagement
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalValue => Quantity * UnitPrice;

        public InventoryItem(string name, int quantity, double unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // Unary ++ overload: increment quantity by 1
        public static InventoryItem operator ++(InventoryItem item)
        {
            item.Quantity++;
            return item;
        }

        // Comparison overloads based on TotalValue
        public static bool operator >(InventoryItem a, InventoryItem b) =>
            a.TotalValue > b.TotalValue;

        public static bool operator <(InventoryItem a, InventoryItem b) =>
            a.TotalValue < b.TotalValue;

        public static bool operator ==(InventoryItem a, InventoryItem b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.TotalValue == b.TotalValue;
        }

        public static bool operator !=(InventoryItem a, InventoryItem b) =>
            !(a == b);

        public override bool Equals(object obj)
        {
            // Try to cast; 'other' will be null if obj isn't an InventoryItem
            var other = obj as InventoryItem;
            if (other == null)
            {
                // Either obj was null or not the right type
                return false;
            }

            // Now compare the meaningful value
            return this.TotalValue == other.TotalValue;
        }

        public override int GetHashCode() =>
            TotalValue.GetHashCode();

        // Binary + overload: combine quantities, average unit price, and join names
        public static InventoryItem operator +(InventoryItem a, InventoryItem b)
        {
            string combinedName = $"{a.Name} & {b.Name}";
            int combinedQty = a.Quantity + b.Quantity;
            double averagePrice = (a.UnitPrice + b.UnitPrice) / 2.0;
            return new InventoryItem(combinedName, combinedQty, averagePrice);
        }

        public override string ToString() =>
            $"{Name}: {Quantity} in stock @ {UnitPrice:C2} each (Total: {TotalValue:C2})";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create two InventoryItem objects
            var apples  = new InventoryItem("Apples",  10, 0.50);
            var oranges = new InventoryItem("Oranges", 15, 0.75);

            Console.WriteLine("Initial Items:");
            Console.WriteLine(apples);
            Console.WriteLine(oranges);
            Console.WriteLine();

            // 2. Use unary ++ to restock one apple
            apples++;
            Console.WriteLine("After apples++:");
            Console.WriteLine(apples);
            Console.WriteLine();

            // 3. Compare them using >, <, ==, !=
            Console.WriteLine($"Apples > Oranges?  {apples > oranges}");
            Console.WriteLine($"Apples < Oranges?  {apples < oranges}");
            Console.WriteLine($"Apples == Oranges? {apples == oranges}");
            Console.WriteLine($"Apples != Oranges? {apples != oranges}");
            Console.WriteLine();

            // 4. Combine them with binary +
            var fruitMix = apples + oranges;
            Console.WriteLine("Result of apples + oranges:");
            Console.WriteLine(fruitMix);
        }
    }
}
