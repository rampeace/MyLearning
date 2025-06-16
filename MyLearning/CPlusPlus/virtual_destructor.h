#include <iostream>

class vehicle
{
public:
	virtual void Move() = 0;

	virtual ~vehicle() = default;
};

class car : public vehicle
{
public:
	void Move() override
	{
		std::cout << "The car moves faster" << std::endl;
	}
};

class bike : public vehicle
{
public:
	void Move() override
	{
		std::cout << "The bike moves little slower" << std::endl;
	}
};

class virtual_destructor_test
{
public:
	static void Test()
	{
		/*
		Runtime polymorphism (a.k.a. dynamic dispatch) only makes sense or 
		is required when the actual derived type is not known at compile time.
		*/
		//std::string input = "car";

		//std::cout << "Please enter a vehicle type: ";
		//std::cin >> input;

		//std::unique_ptr<vehicle> p = nullptr;

		//if (input == "car")
		//	p = std::make_unique<car>();
		//else if (input == "bike")
		//	p = std::make_unique<bike>();

		//if (p != nullptr)
		//	p.get()->Move();

	    std::string input = "";
		vehicle* base = nullptr;

		std::cout << "Please enter a vehicle type: ";
		std::cin >> input;

		if (input == "car")
		{
			car c;
			base = &c;
		}
		else if (input == "bike")
		{
			bike b;
			base = &b;
		}

		if (base != nullptr)
			base->Move();
		else
			std::cout << "Unknown type selected." << std::endl;
	}
};