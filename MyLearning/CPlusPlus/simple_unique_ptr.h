template<typename T>
class simple_unique_ptr
{
public:
	explicit simple_unique_ptr(T* ptr) : ptr_(ptr) {}

	// disable copy constructor and assignment operators

	simple_unique_ptr(const simple_unique_ptr& other) = delete;
	simple_unique_ptr& operator=(const simple_unique_ptr& other) = delete;

	// enable move constructor
	simple_unique_ptr(simple_unique_ptr&& other) : ptr_(other.ptr_)
	{
		other.ptr_ = nullptr;
	}

	// enable move assignment
	simple_unique_ptr& operator=(simple_unique_ptr&& other)
	{
		if (this == &other)
			return *this;

		delete ptr_;

		ptr_ = other.ptr_;
		other.ptr_ = nullptr;

		return *this;
	}

	T* get() const
	{
		return ptr_;
	}

	T& operator*() const // T& no copy or move
	{
		return *ptr_;
	}

	T* operator ->()
	{
		return ptr_;
	}

	T* operator ->() const
	{
		return ptr_;
	}

	T* release()
	{
		T* temp = ptr_;
		ptr_ = nullptr;
		return temp;
	}

	void reset(T* newPtr = nullptr)
	{
		delete ptr_;
		ptr_ = newPtr;
	}

	~simple_unique_ptr()
	{
		delete ptr_;
	}
private:
	T* ptr_;
};