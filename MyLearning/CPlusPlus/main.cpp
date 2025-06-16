// CPlusPlus.cpp : Defines the entry point for the application.
//
#include "move_demo.h"
#include "simple_unique_ptr.h"
#include "virtual_destructor.h"
#include "vector_example.h"

#include <iostream>

using namespace std;

int main()
{
	vector_example::to_dictionary();

	std::cin.get();

	return 0;
}
