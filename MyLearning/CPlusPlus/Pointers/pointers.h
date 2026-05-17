#include <iostream>
#include <gsl/pointers>

using namespace std;

void PrintNums()
{
	int arr[] = { 10, 20, 30, 40, 50 };

	int* p = arr;

	for (int i = 0; i < 5; i++)
	{
		cout << *p << endl;
		++p;
	}
}

void PrintArrayBackwards()
{
	// Print the array backward using pointers.

	int len = 5;
	int arr[5] = { 10, 20, 30, 40, 50 };

	int* p = arr;

	p += (len - 1);

	for (int i = len - 1; i >= 0; i--)
	{
		cout << *p << endl;
		--p;
	}
}

int Sum(int* arr, int size)
{
	// Using pointer traversal
	int* p = arr;
	int sum = 0;

	for (int i = 0; i < size; ++i)
	{
		sum += (*p);
		++p;
	}

	return sum;
}

int Max(int* arr, int size)
{
	// Without using indexing
	int max = INT_MIN;

	int* p = arr;

	for (int i = 0; i < size; ++i)
	{
		if (*p > max)
			max = *p;

		++p;
	}

	return max;
}

void Copy(int* src, int* dest, int size)
{
	for (int i = 0; i < size; ++i)
	{
		dest[i] = src[i];
	}
}

void SwapUsingPointers(int* left, int* right)
{
	// Exercise: swap the two integer values by dereferencing left and right.

	string s = "hello";


}

int MyStrLen(const char* str)
{
	const char* p = str;

	int length = 0;

	while (*p != '\0')
	{
		++length;
		++p;
	}

	return length;
}

void CreateNumber(gsl::owner<int*>* p)
{
	*p = new int;
}

void CreateArray(gsl::owner<int*>* arr, int size)
{
	*arr = new int[size];
}

void CreateNames(gsl::owner<string*>* names, int* size)
{
	*size = 3;

	*names = new string[*size]
	{
		"Shiva",
		"Kavin",
		"Raj"
	};
}

void ResizeArray(gsl::owner<int*>* arr, int oldSize, int newSize)
{
	gsl::owner<int*> newArr = new int[newSize];

	int copySize = oldSize < newSize ? oldSize : newSize;

	for (int i = 0; i < copySize; i++)
	{
		newArr[i] = (*arr)[i];
	}

	gsl::owner<int*> oldArr = *arr;
	delete[] oldArr;

	*arr = newArr;
}

void ReverseUsingPointers(char* s)
{
	int len = strlen(s);

	char* start = s;
	char* end = start + (len - 1);

	while (start < end)
	{
		char temp = *start;
		*start = *end;
		*end = temp;

		++start;
		--end;
	}
}

void* MyMemcpy(void* dest, const void* src, size_t size)
{
    const unsigned char* s = (const unsigned char*)src;
    unsigned char* d = (unsigned char*)dest;

    const unsigned char* start = s;
    const unsigned char* end = s + size;

    while (start < end)
    {
        *d = *start;

        ++start;
        ++d;
    }

    return dest;
}

void* memset(void* dest, int value, size_t size)
{
	unsigned char* d = (unsigned char*)dest;

	unsigned char* start = d;
	unsigned char* end = d + size;

	unsigned char byte = (unsigned char)value;

	while (start < end)
	{
		*start = byte;

		++start;
	}

	return d;
}

char* strcpy(char* dest, const char* src)
{
	const char* from = src;
	char* to = dest;

	while (*from != '\0')
	{
		*to = *from;

		++to;
		++from;
	}

	*to = '\0';

	return to;
}

char* MyStrcat(char* dest, const char* src)
{
	char* to = dest;

	while (*to != '\0')
	{
		++to;
	}

	const char* from = src;

	while (*from != '\0')
	{
		*to = *from;

		++to;
		++from;
	}

	*to = '\0';

	return dest;
}

/*
*   memset
	strcpy
	strcmp
	strcat
	memcmp
	strchr
	atoi
	strstr
	memmove
*/


