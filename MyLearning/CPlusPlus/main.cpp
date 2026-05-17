// CPlusPlus.cpp : Defines the entry point for the application.
//
#include "move_demo.h"
#include "simple_unique_ptr.h"
#include "virtual_destructor.h"
#include "vector_example.h"
#include "const.h"
#include <iostream>
#include "simple_shared_ptr.h"
#include "variadic_templates.h"
#include "functor.h"
#include "Pointers/pointers.h"

using namespace std;

void ChangeName(string* name)
{
	*name = "Changed";
}

class Test
{
public:
	Test()
	{
		p = new string();
	}

	~Test()
	{
		delete p;
	}
private:
	string* p;
};

int main()
{
	string s = "original";

	ChangeName(&s);

	cout << s << endl;

	return 0;
}
