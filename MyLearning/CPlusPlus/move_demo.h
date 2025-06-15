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

	// assignment operator move_demo obj2 = obj
	move_demo& operator= (move_demo other)
	{
		delete[] array;
		size = other.size;
		array = new int[size];

		std::copy(other.array, other.array + size, array);
		return *this;
	}

	~move_demo()
	{
		delete[] array;
	}
private:
	int* array;
	size_t size;
};

