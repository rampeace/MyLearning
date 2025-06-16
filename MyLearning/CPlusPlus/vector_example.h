#include <iostream>
#include <vector>
#include <algorithm>
#include <ranges>
#include <string>
#include <unordered_set>
#include <unordered_map>

using namespace std;

struct person
{
	string name;
	int age;
};

class vector_example
{
public:
	static void create()
	{
		vector<int> v = { 1, 2, 3, 4, 5 };

		vector<int> v2;
		v2.push_back(1);
		v2.push_back(2);

		for (int num : v)
		{
			cout << num << " ";
		}
	}

	static void remove()
	{
		vector<int> v = { 1, 2, 3, 4, 5 };

		// remove by index
		int index = 4;
		v.erase(v.begin() + index);

		// remove by it
		auto it = find(v.begin(), v.end(), 3);
		v.erase(it);
	}

	static void where()
	{
		vector<int> nums = { 1, 2, 3, 4, 5 };

		auto result = nums | std::views::filter([](int num) { return num % 2 == 0; });

		for (int num : result)
		{
			cout << num << " ";
		}
	}

	static void select()
	{
		vector<int> nums = { 1, 2, 3, 4, 5 };

		auto result = nums
			| std::views::filter([](int num) { return num % 2 == 0; })
			| std::views::transform([](int num) { return std::to_string(num); });			

		for (std::string num : result)
		{
			cout << num << " ";
		}
	}

	static void select_many()
	{
		vector<vector<int>> nums = { {1, 2}, {4, 5} };

		auto result = nums | std::views::join;	

		for (int i : result)
			std::cout << i << " ";

        vector<vector<vector<int>>> sample_data = {
            { {1, 2}, {3, 4} },
            { {5, 6}, {7, 8} }
        };

		auto result2 = sample_data | std::views::join | std::views::join;

		std::cout << endl;

		for (int i : result2)
			std::cout << i << " ";
	}

	static void aggregate()
	{
		vector<int> nums = { 1, 2, 3, 4 };

		auto factorial = std::ranges::fold_left(nums, 1, [](int acc, int curr) { return acc * curr; });

		vector<string> s = { "ram", " kumar" };

		auto concat = std::ranges::fold_left(s, "", [](string acc, string curr) {return acc + curr; });

		std::cout << "Factorial: " << factorial << endl;
		std::cout << "Concat: " << concat << endl;
	}

	static void sort()
	{
		vector<person> people = { {"Ram", 32}, {"Kavin", 24}};

		std::ranges::sort(people, [](const person& p1, const person p2) { return p1.age > p2.age; });

		for (auto& person : people)
		{
			std::cout << person.name << " " << person.age << endl;
		}
	}

	static void distinct()
	{
		vector<int> nums = { 1, 2, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		unordered_set<int> seen;

		for (int num : nums)
			seen.insert(num);

		for (int num : seen)
			std::cout << num << " ";
	}

	static void reverse()
	{
		vector<int> nums = { 1, 2, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		// one way
		//std::reverse(nums.begin(), nums.end());

		// using ranges
		auto reversed = std::views::reverse(nums);

		for (int i : reversed)
			cout << i << " ";
	}

	static void take()
	{
		vector<int> nums = { 1, 2, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		// using ranges
		auto taken = nums | std::views::take(3);

		for (auto i : taken)
			cout << i << " ";
	}

	static void take_while()
	{
		vector<int> nums = { 1, 2, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		// std::views::take and take_while are lazy, like LINQ — no copy is made unless you materialize them.
		auto taken = nums | std::views::take_while([](int num) { return num < 20; });

		for (auto i : taken)
			cout << i << " ";
	}

	static void skip()
	{
		vector<int> nums = { 1, 2, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		// std::views::take and take_while are lazy, like LINQ — no copy is made unless you materialize them.
		auto skipped = nums | std::views::drop(4);

		for (auto i : skipped)
			cout << i << " ";
	}

	static void skip_while()
	{
		vector<int> nums = { 1, 2, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		// std::views::take and take_while are lazy, like LINQ — no copy is made unless you materialize them.
		auto skipped = nums | std::views::drop_while([](int num) { return num < 10; });

		for (auto i : skipped)
			cout << i << " ";
	}

	static void first()
	{
		vector<int> nums = { 177, 22, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };

		auto it = std::ranges::find_if(nums, [](int num) { return num % 2 == 0; });

		cout << *it << endl;
	}

	static void count()
	{
		vector<int> nums = { 177, 22, 3, 3, 34, 5, 6, 7, 6, 7, 8, 2, 3, 5 };
				
		//int count = std::ranges::distance(nums)

		int count = std::ranges::distance(nums | std::views::filter([](int num) { return num > 20; }));

		cout << count << endl;
	}

	static void range() 
	{
		auto numbers = std::views::iota(5, 10);

		for (int num : numbers)
			cout << num << " ";
	}

	static void repeat()
	{
		auto repeated = std::views::repeat(-1, 10);

		vector<int> v(repeated.begin(), repeated.end());

		for (int num : repeated)
			cout << num << " ";
	}

	static void zip()
	{
		vector<string> names = { "Ram", "Peter", "Kavin" };
		vector<int> marks = { 56, 87, 90 };

		auto result = std::views::zip(names, marks);

		for (auto [name, mark] : result) // tuple deconstruction
			cout << name << ": " << mark << endl;
	}

	static void max_by()
	{
		std::vector<person> people = {
		  {"Alice", 30},
		  {"Bob", 42},
		  {"Charlie", 25}
		};

		// {} is the default comparator, equivalent to comparing p.Age < q.Age or std::less{}
		auto max = std::ranges::max_element(people, {}, [](const person& p) { return p.age; });

		cout << max->name << ": " << max->age << endl;
	}

	static void min_by()
	{
		std::vector<person> people = {
		{"Alice", 30},
		{"Bob", 42},
		{"Charlie", 25}
		};

		// Default comparator + projection
		auto it = std::ranges::min_element(people, {}, &person::age);

		if (it != people.end()) {
			std::cout << "Youngest: " << it->name << " (" << it->age << ")\n";
		}
	}

	static void last()
	{
		vector<int> marks = { 56, 87, 90 };

		auto it = std::ranges::rbegin(marks);

		std::cout << *it << endl;
	}

	static void to_dictionary()
	{
		std::vector<std::pair<int, std::string>> vec = {
		   {1, "apple"},
		   {2, "banana"},
		   {3, "cherry"}
		};

		std::unordered_map dict(vec.begin(), vec.end());

		for (auto& [key, value] : dict)
			std::cout << key << " " << value << endl;
	}

	static void all()
	{
		vector<int> marks = { 56, 87, 90 };

		bool result = std::ranges::all_of(marks, [](int mark) { return mark > 50; });

		std::cout << result << endl;
	}
};