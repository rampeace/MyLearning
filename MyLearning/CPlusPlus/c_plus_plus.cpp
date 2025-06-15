// CPlusPlus.cpp : Defines the entry point for the application.
//
#include "move_demo.h"

using namespace std;

int main()
{
	move_demo a(10);
	move_demo b(a);
	b = a;

	return 0;
}
