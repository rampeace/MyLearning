
#include <iostream>

// const references can access only const functions.
struct Employee
{
public:
	Employee(std::string name, int age) : _name(name), _age(age) {}

	const std::string& getName() const 
	{ 
		return _name;
	}

	int getAge() const
	{
		return _age;
	}

	void modifyAge(int age)
	{
		_age = age;
	}

private:
	std::string _name;
	int _age;
};

class EmployeeRepository
{
public:
	EmployeeRepository() : _employee("Ram", 34) {}

	const Employee& GetEmployee() 
	{	
		return _employee;
	}

	void modifyAge(int age)
	{
		_employee.modifyAge(age);
	}

private:
	Employee _employee;
};

class Engine
{

};

class Car
{
	Engine _engine;
};