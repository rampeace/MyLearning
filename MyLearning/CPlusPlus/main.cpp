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

using namespace std;

int main()
{
	Functor zip;
	
	zip(30);

	return 0;
}
