// CPlusPlus.cpp : Defines the entry point for the application.
//
#include "move_demo.h"
#include "simple_unique_ptr.h"
#include "virtual_destructor.h"
#include "vector_example.h"
#include "const.h"
#include <iostream>
#include "simple_shared_ptr.h"

using namespace std;

int main()
{
	std::unique_ptr<int> ptr(new int);

	*ptr = 10;

	std::cout << *ptr << std::endl;

	return 0;
}
