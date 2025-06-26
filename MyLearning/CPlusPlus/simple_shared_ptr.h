#include <iostream>

template <typename T>
class SharedPtr {
private:
    T* ptr;
    int* refCount;

public:
    // Constructor
    explicit SharedPtr(T* p = nullptr) : ptr(p), refCount(new int(1)) 
    {
        std::cout << "Created. RefCount = " << *refCount << "\n";
    }

    // Copy Constructor
    SharedPtr(const SharedPtr<T>& other) : ptr(other.ptr), refCount(other.refCount)
    {
        ++(*refCount);
        std::cout << "Copied. RefCount = " << *refCount << "\n";
    }

    // Copy Assignment
    SharedPtr<T>& operator=(const SharedPtr<T>& other) 
    {
        if (this != &other) {
            // Decrement current
            release();

            // Copy from other
            ptr = other.ptr;
            refCount = other.refCount;
            ++(*refCount);
            std::cout << "Assigned. RefCount = " << *refCount << "\n";
        }
        return *this;
    }

    // Move Constructor
    SharedPtr(SharedPtr&& other) noexcept
        : ptr(other.ptr), refCount(other.refCount) 
    {
        other.ptr = nullptr;
        other.refCount = nullptr;
        std::cout << "Move constructed\n";
    }

    // Move Assignment
    SharedPtr& operator=(SharedPtr&& other) noexcept 
    {
        if (this != &other) {
            release(); // release current ownership

            ptr = other.ptr;
            refCount = other.refCount;

            other.ptr = nullptr;
            other.refCount = nullptr;
            std::cout << "Move assigned\n";
        }
        return *this;
    }

    // Destructor
    ~SharedPtr() {
        release();
    }

    // Access operators
    T& operator*() const 
    {
        return *ptr; 
    }

    T* operator->() const 
    {
        return ptr;
    }

    int use_count() const
    { 
        return *refCount;
    }

private:
    void release() 
    {
        if (--(*refCount) == 0) {
            std::cout << "Deleting managed object\n";
            delete ptr;
            delete refCount;
        }
        else {
            std::cout << "Released one. RefCount = " << *refCount << "\n";
        }
    }
};
