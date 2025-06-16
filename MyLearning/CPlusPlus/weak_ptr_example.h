#include <iostream>


//class A
//{
//public:
//	A(std::shared_ptr<B> ptr) : _ptr(ptr) {}
//
//private:
//	std::shared_ptr<B> _ptr;
//};
//
//class B
//{
//public:
//	B(std::shared_ptr<A> ptr) : _ptr(ptr) {}
//
//private:
//	std::shared_ptr<A> _ptr;
//};

/// <summary>
/// Fix cycle problem
/// </summary>
class A
{
public:
	A() {}

	void setPtr(std::shared_ptr<B> ptr)
	{
		_ptr = ptr;
	}

	~A() { std::cout << "A destroyed\n"; }

private:
	std::shared_ptr<B> _ptr;
};

class B
{
public:
	B() {}

	void setPtr(std::shared_ptr<A> ptr)
	{
		_ptr = ptr;
	}

	~B() { std::cout << "B destroyed\n"; }
private:
	std::weak_ptr<A> _ptr;
};

class weak_ptr_example
{
public:
	static void test()
	{
		std::shared_ptr<A> p = std::make_shared<A>();
		std::shared_ptr<B> p2 = std::make_shared<B>();

		p->setPtr(p2);
		p2->setPtr(p);

		std::cout << "End of test\n";
	}
};