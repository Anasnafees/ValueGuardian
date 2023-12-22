# ValueGuardian NuGet Package

## Overview

ValueGuardian is a .NET library designed to provide robust value guarding functionalities for ensuring the integrity of data and preventing unexpected behaviors due to invalid or unexpected values.

## Features

- **Logical OR Operation:** Check if any of the specified values meet certain conditions.
- **Logical AND Operation:** Check if all of the specified values meet certain conditions.
- **Model Object Property Guard:** Identify and guard against invalid or unexpected values in a given model object.

## Installation

You can install the ValueGuardian NuGet package using the following Package Manager Console command:

```Nuget
Install-Package ValueGuardian
```

## How To Use

```csharp
using ValueGuardian;

class Program
{
	static void Main(string[] args)
	{
		// Test case 1: Logical OR with mixed types
		bool result1 = Checks.IsEmptyOrNullUseOr("Hello", null, "World");
		Console.WriteLine($"Test 1 Result (OR): {result1}");

		// Test case 2: Logical OR with mixed types
		bool result2 = Checks.IsEmptyOrNullUseOr("Hello", "Test", "World");
		Console.WriteLine($"Test 2 Result (OR): {result2}");

		// Test case 3: Logical OR with all null values
		bool result3 = Checks.IsEmptyOrNullUseOr(null, null, null);
		Console.WriteLine($"Test 3 Result (OR): {result3}");

		// Test case 4: Logical OR with null values in a model object
		var person1 = new Person { Name = null, Age = 0 };
		bool result4 = Checks.IsEmptyOrNullUseOr(null, null, person1);
		Console.WriteLine($"Test 4 Result (OR): {result4}");

		// Test case 5: Logical OR with model objects and a collection
		var person2 = new Person { Name = "John", Age = 25 };
		var test1 = new Test { Name = "Alice", Age = 30, Gender = "", UserId = 123 };
		bool result5 = Checks.IsEmptyOrNullUseOr(person2, person2, person2);
		Console.WriteLine($"Test 5 Result (OR): {result5}");

		// Test case 6: Logical OR with model objects
		bool result6 = Checks.IsEmptyOrNullUseOr(person2, test1, person2);
		Console.WriteLine($"Test 6 Result (OR): {result6}");

		// Test case 7: Logical OR with a collection
		var list = new List<Test> { test1 };
		bool result7 = Checks.IsEmptyOrNullUseOr(list);
		Console.WriteLine($"Test 7 Result (OR): {result7}");

		// Test case 8: Logical OR with a single model object
		var test2 = new Test { Name = "Bob", Age = 40, Gender = "Male", UserId = 456 };
		bool result8 = Checks.IsEmptyOrNullUseOr(test2);
		Console.WriteLine($"Test 8 Result (OR): {result8}");

		// Test case 9: Logical AND with mixed types
		bool result9 = Checks.IsEmptyOrNullUseAnd("Hello", null, "World");
		Console.WriteLine($"Test 9 Result (AND): {result9}");

		// Test case 10: Logical AND with mixed types
		bool result10 = Checks.IsEmptyOrNullUseAnd("Hello", "Test", "World");
		Console.WriteLine($"Test 10 Result (AND): {result10}");

		// Test case 11: Logical AND with all null values
		bool result11 = Checks.IsEmptyOrNullUseAnd(null, null, null);
		Console.WriteLine($"Test 11 Result (AND): {result11}");

		// Test case 12: Logical AND with null values in a model object
		bool result12 = Checks.IsEmptyOrNullUseAnd(null, null, person1);
		Console.WriteLine($"Test 12 Result (AND): {result12}");

		// Test case 13: Logical AND with model objects and a collection
		bool result13 = Checks.IsEmptyOrNullUseAnd(person2, person2, person2);
		Console.WriteLine($"Test 13 Result (AND): {result13}");

		// Test case 14: Logical AND with model objects
		bool result14 = Checks.IsEmptyOrNullUseAnd(person2, test1, person2);
		Console.WriteLine($"Test 14 Result (AND): {result14}");

		// Test case 15: Logical AND with a collection
		bool result15 = Checks.IsEmptyOrNullUseAnd(list);
		Console.WriteLine($"Test 15 Result (AND): {result15}");

		// Test case 16: Logical AND with a single model object
		bool result16 = Checks.IsEmptyOrNullUseAnd(test2);
		Console.WriteLine($"Test 16 Result (AND): {result16}");

		// Test case 17: Model with all properties having values
		var person3 = new Person { Name = "John", Age = 25 };
		var result17 = Checks.CheckModelProperties(person3);
		Console.WriteLine($"Test 17 Result (CheckModelProperties): {result17}");

		// Test case 18: Model with a null value in a property
		var person4 = new Person { Name = null, Age = 30 };
		var result18 = Checks.CheckModelProperties(person4);
		Console.WriteLine($"Test 18 Result (CheckModelProperties): {result18}");

		// Test case 19: Model with an empty string value in a property
		var test3 = new Test { Name = "Alice", Age = 30, Gender = "", UserId = 123 };
		var result19 = Checks.CheckModelProperties(test3);
		Console.WriteLine($"Test 19 Result (CheckModelProperties): {result19}");

		// Test case 20: Model with all properties having values
		var test4 = new Test { Name = "Bob", Age = 40, Gender = "Male", UserId = 456 };
		var result20 = Checks.CheckModelProperties(test4);
		Console.WriteLine($"Test 20 Result (CheckModelProperties): {result20}");

		Console.ReadKey();
	}
}
class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
}
class Test
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string Gender { get; set; }
	public int UserId { get; set; }
}
```

## Results


```console
Test 1 Result (OR): True
Test 2 Result (OR): False
Test 3 Result (OR): True
Test 4 Result (OR): True
Test 5 Result (OR): False
Test 6 Result (OR): False
Test 7 Result (OR): False
Test 8 Result (OR): False
Test 9 Result (AND): False
Test 10 Result (AND): False
Test 11 Result (AND): True
Test 12 Result (AND): False
Test 13 Result (AND): False
Test 14 Result (AND): False
Test 15 Result (AND): False
Test 16 Result (AND): False
Test 17 Result (CheckModelProperties): All properties have values.
Test 18 Result (CheckModelProperties): Empty or null properties: Name
Test 19 Result (CheckModelProperties): Empty or null properties: Gender
Test 20 Result (CheckModelProperties): All properties have values.
```
