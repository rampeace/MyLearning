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
#include <memory>

using namespace std;

int main()
{
	vector<int> v = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

	auto it = v.begin();

	while (it < v.end())
	{
		cout << *it << endl;

		++it;
	}

	return 0;
}
