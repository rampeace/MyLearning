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

int main()
{
	int arr[5] = { 10, 20, 30, 40, 50 };

	cout << Max(arr, 5);

	return 0;
}
