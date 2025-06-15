# 💼 C++ Interview Questions (Modern C++11–23)

## 🔹 Core C++ (Syntax, Basics, OOP)

- What’s the difference between a class and a struct in C++?
- What is the Rule of 3 / Rule of 5 / Rule of 0 in C++?
- What is a virtual destructor and when do you need it?
- What is the "diamond problem" in inheritance? How does C++ solve it?
- Explain shallow copy vs deep copy. When does it matter?

## 🔹 Memory Management

- How does manual memory management work in C++?
- What’s the difference between `new/delete` and `malloc/free`?
- What are smart pointers (`unique_ptr`, `shared_ptr`, `weak_ptr`)? When would you use each?
- How do circular references happen with `shared_ptr`?
- What’s a memory leak and how can you detect it?

## 🔹 Copy/Move Semantics

- What is move semantics in C++?
- Explain copy constructor vs move constructor.
- When is the move constructor called?
- What happens when you do `S2 = std::move(S1);`?
- How can you prevent a class from being copied or moved?

## 🔹 STL & Containers

- What’s the difference between `std::vector` and `std::list`?
- How does `std::map` differ from `std::unordered_map`?
- What are iterators in STL? How do they work?
- How is memory managed in `std::vector`?
- What’s the time complexity of inserting/deleting in various STL containers?

## 🔹 Templates & Metaprogramming

- What is template specialization? Partial specialization?
- What are variadic templates?
- Explain SFINAE (Substitution Failure Is Not An Error).
- What is `constexpr` and when is it used?
- What are C++20 Concepts? How do they improve template code?

## 🔹 Multithreading & Concurrency

- How do you create threads in C++?
- What’s the difference between `std::mutex`, `std::unique_lock`, and `std::lock_guard`?
- What is a data race? How can you prevent it?
- What is `std::atomic` and when would you use it?
- How does C++20 improve concurrency?

## 🔹 C++ and Qt (If Relevant)

- What is the signal-slot mechanism in Qt?
- How does Qt’s memory management (parent-child) work?
- What’s the difference between `QWidget` and `QML`?
- How do you create a cross-platform GUI with Qt?
- How is Qt’s event loop different from traditional C++ applications?

## 🔹 Advanced Topics

- What are C++20 Ranges and why are they useful?
- Explain the use of `co_await`, `co_yield`, and coroutines in C++20.
- How do modules in C++20 work and what problem do they solve?
- What is placement new and when do you use it?
- What tools do you use to debug memory leaks and performance in C++?

## 🔹 Code-Based Questions

- Implement a simple `unique_ptr` from scratch.
- Write a templated function that adds two numbers or concatenates strings.
- Parse a CSV file using STL.
- Create a thread-safe queue.
- Implement a basic observer pattern using modern C++.
