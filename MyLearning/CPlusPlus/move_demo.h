#include <algorithm>

class move_demo
{
public:

	// constructor
	move_demo(size_t s) : size(s), array(new int[s]) {}

	// copy constructor move_demo(other)
	move_demo(const move_demo& other) : size(other.size), array(new int[size])
	{
		
		// 1		2		3
		// ^		^		^
		// 0x1      _      0x3
		// copy(0, 0x3, array)

		std::copy(other.array, other.array + size, array);   
	}

	// assignment operator runs after the object is created
	move_demo& operator= (const move_demo& other)
	{
		if (this == &other)
			return *this;

		delete[] array;

		size = other.size;
		array = new int[size];

		std::copy(other.array, other.array + size, array);
		return *this;
	}

	// move assignment
	// In regular code (outside templates), T&& means an rvalue reference:
	/*
	* 
	* The move constructor exists to efficiently transfer ownership of temporary objects (rvalues)
	instead of performing a costly deep copy. It does this by stealing the resources of the temporary
	object, leaving it in a safe but invalid state.

		takeValue(MyClass()); // OK
		MyClass a;
		takeValue(a);         // Error — a is an lvalue

		template<typename T>
			T&& move(T& arg) {
				return static_cast<T&&>(arg);

	  move_demo a;
	  move_demo b = a; // copy constructor

	  move_demo c, d;
	  c = d // assignment operator

	  move_demo e = move_demo();  // move constructor 

	  move_demo f;
	  f = move_demo();  // move assignment operator

	  mode_demo g;
	  move_demo h = std::move(g);  // move constructor

	  move_demo i;
	  move_demo j;
	  j = std::move(i)   // move assignment operator

	  d = move_demo();

	*/
	// move assignment operator
	move_demo& operator= (move_demo&& other) noexcept
	{ 
		if (this == &other)
			return *this;

		delete[] array;
		size = other.size;
		array = other.array;

		other.array = nullptr;
		other.size = 0;

		return *this;
	}

	// move copy constructor
	move_demo(move_demo&& other) noexcept : size(other.size), array(other.array) 
	{
		other.array = nullptr;
		other.size = 0;
	}

	~move_demo()
	{
		delete[] array;
	}

private:
	int* array;
	size_t size;
};

