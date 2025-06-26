# 📘 XAML Interview Questions – WPF Developer Guide

This document covers commonly asked **XAML** interview questions, categorized by topics like layout, styling, templating, and bindings.

---

## 📀 Layout & Panels

### 1. What are the different layout panels in WPF?

- **Grid**: Arranges elements in rows and columns.
- **StackPanel**: Stacks elements vertically or horizontally.
- **DockPanel**: Docks child elements to top, bottom, left, right, or fill.
- **WrapPanel**: Wraps content to a new line when there's no space.
- **Canvas**: Positions children using explicit `Top`, `Left`, `Right`, `Bottom` properties.

### 2. What is the difference between `Grid` and `StackPanel`?

- `Grid` allows complex 2D layouts using rows and columns.
- `StackPanel` arranges elements in a single line (horizontal or vertical).

### 3. What is the purpose of `RowDefinition` and `ColumnDefinition` in a Grid?

- They define the structure of rows and columns in a `Grid`. Each `UIElement` can be positioned using `Grid.Row`, `Grid.Column` attached properties.

### 4. How does `*`, `Auto`, and absolute sizing work in `Grid`?

- `*`: Proportional sizing. `2*` gets twice the space of `1*`.
- `Auto`: Size to content.
- Absolute: Fixed pixel size (e.g., `100`).

### 5. How does a `DockPanel` layout its children?

- Children are docked in the order they appear using `DockPanel.Dock`. The last child can fill remaining space by setting `LastChildFill="True"`.

---

## 🎨 Styles & Resources

### 6. What is the difference between `Window.Resources`, `UserControl.Resources`, and `App.xaml` resources?

- `Window.Resources`: Scoped to a specific window.
- `UserControl.Resources`: Scoped to a specific user control.
- `App.xaml`: Application-wide resources available globally.

### 7. What is the purpose of `StaticResource` and `DynamicResource`?

- `StaticResource`: Resolved at load time. Faster but not updatable at runtime.
- `DynamicResource`: Resolved at runtime. Supports updates and themes.

### 8. How do you create a reusable `Style`?

```xaml
<Style x:Key="MyButtonStyle" TargetType="Button">
    <Setter Property="Background" Value="LightBlue" />
</Style>
```

Apply with `Style="{StaticResource MyButtonStyle}"`.

### 9. How do you apply a `Style` only to a specific control?

- Use a `Style` with an `x:Key` and apply it via `Style` property on the control.

### 10. What is a `BasedOn` style?

- Inherits properties from another style:

```xaml
<Style x:Key="AccentStyle" TargetType="Button" BasedOn="{StaticResource BaseStyle}">
    <Setter Property="Background" Value="Orange" />
</Style>
```

---

## 🎭 Control Templates & Visual Tree

### 11. What is a `ControlTemplate`?

- Defines the visual structure of a control. Replaces the default appearance.

### 12. How does a `ControlTemplate` differ from a `Style`?

- `Style` sets properties. `ControlTemplate` defines the control’s full visual layout.

### 13. Why and when would you use `TemplateBinding`?

- Used inside a `ControlTemplate` to bind to the control’s properties (e.g., `Background`, `FontSize`).

### 14. What happens to the default visual tree when you set a `ControlTemplate`?

- It is completely replaced by your new template. You must recreate needed visuals like borders, content presenters, etc.

### 15. How do you add interaction (hover, pressed) in a `ControlTemplate`?

- Use `ControlTemplate.Triggers` or `VisualStateManager` to define visual changes on events like `IsMouseOver`, `IsPressed`.

---

## 🤹️ Attached & Dependency Properties

### 16. What is a dependency property? Why are they used?

- Special property system in WPF that supports binding, animation, default values, styling, etc.

### 17. What is an attached property? How is it different from a regular property?

- Used to attach a property to child elements (e.g., `Grid.Row`, `Canvas.Left`) without them owning the property.

### 18. Why must attached properties be static?

- They are defined on the owner class and accessed globally, not on instances.

### 19. What is property value precedence in the WPF property system?

- Final value comes from multiple layers: animation > local value > style > default.

### 20. Can you explain `GetValue()` and `SetValue()`?

- Used to get and set dependency property values in code:

```csharp
SetValue(MyProperty, value);
var val = GetValue(MyProperty);
```

---

## 🔄 Data Binding

### 21. How does data binding work in XAML?

- Binds a property in XAML to a source (like a ViewModel or object). Uses `DataContext` to resolve the path.

### 22. What are binding modes (OneWay, TwoWay, etc.)?

- `OneWay`, `TwoWay`, `OneTime`, `OneWayToSource` define data flow direction.

### 23. How do you bind to an element’s property?

```xaml
<TextBlock Text="{Binding ElementName=slider1, Path=Value}" />
```

### 24. What is `INotifyPropertyChanged` and why is it needed?

- Interface to notify the UI when a bound property value changes.

### 25. How do you bind to nested properties in XAML?

```xaml
<TextBlock Text="{Binding Address.City}" />
```

---

## 🔄 Triggers & Behaviors

### 26. What is the difference between `EventTrigger` and `DataTrigger`?

- `EventTrigger`: Responds to events (e.g., `Loaded`) and often starts animations.
- `DataTrigger`: Reacts to data value changes and sets properties.

### 27. How are triggers used in `ControlTemplates`?

- Define visual responses based on control state (e.g., `IsMouseOver`) using `ControlTemplate.Triggers`.

### 28. What are `VisualStateManager` and `Storyboard` used for?

- `VisualStateManager`: Manages UI states (like `Pressed`, `Disabled`).
- `Storyboard`: Defines animations used in transitions or independently.

---

## 🧠 Advanced

### 29. What is the logical tree vs visual tree in WPF?

- Logical tree: Represents control hierarchy.
- Visual tree: Includes all visual elements (e.g., borders, templates).

### 30. Can you override the default `ControlTemplate` of a control?

- Yes. Define a new `ControlTemplate` in a `Style` and apply it.

### 31. How do you create a custom control with custom dependency properties?

- Inherit from `Control`, define static `DependencyProperty`, override `OnApplyTemplate()` if needed.

### 32. How do `Themes/Generic.xaml` and custom skins work?

- `Generic.xaml` contains default templates. WPF loads it automatically for custom controls.

---

## ✅ Practical Examples

### 33. How do you create a button with rounded corners using XAML?

```xaml
<Button Content="Click Me">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Border CornerRadius="10" Background="LightBlue">
                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
            </Border>
        </ControlTemplate>
    </Button.Template>
</Button>
```

### 34. How do you create a responsive layout in WPF using `Grid`?

- Use `*`, `Auto`, and percentage-based `ColumnDefinitions`/`RowDefinitions`. Combine with `ViewBox` or `DockPanel` for flexible layouts.

### 35. How do you create a resource dictionary and reference it in multiple windows?

```xaml
<!-- MyStyles.xaml -->
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
    <Style x:Key="MyButton" TargetType="Button">
        <Setter Property="Background" Value="LightGreen"/>
    </Style>
</ResourceDictionary>

<!-- App.xaml -->
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="MyStyles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

# WPF Interview Questions: Inheritance, Class Hierarchy, and Property Inheritance

## 🔹 Class-Based Inheritance in WPF

1. **What is the base class of all WPF controls?**
2. **How does `FrameworkElement` differ from `UIElement`?**
3. **What are the key responsibilities of `UIElement` and `FrameworkElement`?**
4. **What is the difference between `Control` and `ContentControl`?**
5. **Can you describe the class inheritance hierarchy of a `Button` in WPF?**
6. **How do `UserControl` and `CustomControl` differ in terms of class structure and purpose?**
7. **What are the benefits of deriving from `FrameworkElement` versus `Control` or `Decorator`?**
8. **What is the purpose of `Decorator` in the WPF class hierarchy?**
9. **Can a control derive directly from `UIElement`? Why or why not?**
10. **What is the role of `Visual` and `DependencyObject` in the WPF inheritance chain?**

## 🔹 Property Inheritance

1. **What is property value inheritance in WPF?**
2. **Which types of properties can participate in property value inheritance?**
3. **How do attached properties participate in value inheritance?**
4. **What is the difference between logical tree inheritance and visual tree inheritance?**
5. **How does the `Inherits` flag in `FrameworkPropertyMetadata` affect dependency property behavior?**
6. **How would you make a custom dependency property participate in property inheritance?**
7. **Can you provide a code example where a child element inherits a property value from a parent?**
8. **Why doesn't `Background` property get inherited by default by child elements?**
9. **What’s the difference between property inheritance and resource lookup in WPF?**
10. **What are the performance implications of using property inheritance heavily?**

## 🔹 Practical & Advanced Scenarios

1. **When creating a custom control, why should you override metadata for inherited dependency properties?**
2. **What is `AddOwner()` used for in the context of dependency properties and inheritance?**
3. **What’s the difference between re-registering a dependency property in a derived class vs. using `AddOwner()`?**
4. **Can you override the default value of an inherited dependency property in a derived class? How?**
5. **What are the best practices when designing a base class that defines shared dependency properties in WPF?**

## 🔹 Bonus: Inheritance in Templates & Styles

1. **Do ControlTemplates or DataTemplates support inheritance? Explain.**
2. **What does the `BasedOn` property do in a Style? Is that inheritance?**
3. **Can styles or templates defined in base classes be reused in derived controls?**



