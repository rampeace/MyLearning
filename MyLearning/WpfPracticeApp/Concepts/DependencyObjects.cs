/*
  The core of WPF's property engine.

class DependencyProperty
{
	public string Name;
	public object DefaultValue;
	public bool Inherits;

	public DependencyProperty(string name, object defaultValue, bool inherits)
	{
		Name = name;
		DefaultValue = defaultValue;
		Inherits = inherits;
	}
}

class DependencyObject
{
    public Dictionary<DependencyProperty, object> localValues = new(); // dependency property bag
    public DependencyObject? Parent;

    public void SetValue(DependencyProperty dp, object value)
    {
        localValues[dp] = value;
    }

    public object GetValue(DependencyProperty dp)
    {
        // 1. Check for local value
        if (localValues.TryGetValue(dp, out var value))
            return value;

        // 2. Check if it's inheritable
        if (dp.Inherits && Parent != null)
            return Parent.GetValue(dp); // Recursive: walk up logical tree

        // 3. Use default
        return dp.DefaultValue;
    }
}

Class Button : DependencyObject
{
	    // Register the attached property
    public static readonly DependencyProperty AssignedSalaryProperty =
        DependencyProperty.RegisterAttached(
            "AssignedSalary",             // Name of the property
            typeof(double),               // Type
            typeof(Employee),             // Owner class
            new PropertyMetadata(0.0));   // Default value
			
	public static void SetColor(DependencyObject obj, DependencyProperty dp, object value)
	{
		obj.SetValue(dp, value);
	}
}

Button fistButton = new Button();
Button.SetColor(firstButton, "Color", "Red"); 
Button.SetWidth(firstButton, "Width", 15);

Button secocndButton = new Button();
Button.SetColor(secondButton, "Color", "Blue");

This way firstButton will have two properties, Color and Width 
The secondButton will have only one Property, Color

public class DependencyObject
{
    public class PropertyValueEntry
    {
        public PriorityQueue<object, int> ValueQueue = new();
    }

    private Dictionary<DependencyProperty, PropertyValueEntry> propertyEntries = new();

    public void SetValue(DependencyProperty dp, object value, int priority)
    {
        if (!propertyEntries.ContainsKey(dp))
        {
            propertyEntries[dp] = new PropertyValueEntry();
        }

        propertyEntries[dp].ValueQueue.Enqueue(value, priority);
    }

    public object GetValue(DependencyProperty dp)
    {
        if (propertyEntries.TryGetValue(dp, out var entry))
        {
            if (entry.ValueQueue.TryPeek(out var value, out _))
                return value;
        }

        // Default if nothing is set
        return dp.DefaultValue;
    }
}

The actual WPF doesn't use a priority queue, but it uses-

struct EffectiveValueEntry
{
    object LocalValue;
    object ExpressionValue;
    object AnimatedValue;
    object InheritedValue;
    // ...etc
}

Then uses fixed priority rules in a switch statement instead of a heap-based queue, since the number of layers is known and small. 
But your PriorityQueue is a great way to simulate it dynamically.

*/ 