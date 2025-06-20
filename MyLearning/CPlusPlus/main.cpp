// CPlusPlus.cpp : Defines the entry point for the application.
//
#include "move_demo.h"
#include "simple_unique_ptr.h"
#include "virtual_destructor.h"
#include "vector_example.h"
#include "const.h"
#include <iostream>

using namespace std;

int main()
{
	EmployeeRepository obj;
	const std::string& name = obj.GetEmployee().getName();
	obj.modifyAge(5);

	cout << name << " " << obj.GetEmployee().getAge() << endl;
	return 0;
}
