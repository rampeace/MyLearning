#include <iostream>
#include <memory>

class Exercises
{
public:

	// Write a lambda that captures a local variable by value and prints it.
	
	void fun()
	{
		int i = 10;

		auto print = [i]() { std::cout << i << std::endl; };

		print();
	}

	void print()
	{
		std::string message = "Hello";

		auto print = [message]() { std::cout << message << std::endl; };
	}

	static int Add(int a, int b)
	{
		auto add = [](int a, int b) { return a + b; };
		return add(a, b);
	}
};

class ResourceManager
{
public:
	ResourceManager(int size) : _data(new int[size]), _size(size) {}
private:
	std::unique_ptr<int[]> _data;
	int _size;
};