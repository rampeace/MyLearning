#include <iostream>

class Functor
{
public:
	void operator()(int x)
	{
		std::cout << x << std::endl;
	}
};