#include <iostream>

class myclass
{
public:
	myclass(int i) : _i(i) {}
private:
	int _i;
};


class shared_ptr_example
{
public:
	void Test()
	{
		std::shared_ptr<myclass> p = std::make_shared<myclass>();

		{
			std::shared_ptr<myclass> p2 = p;
			std::cout << "Usage Count: " << p.use_count() << std::endl;
		}
		std::cout << "Usage Count: " << p.use_count() << std::endl;
	}
};

