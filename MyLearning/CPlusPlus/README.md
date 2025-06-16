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

# C++ STL Interview Questions

This document covers a **comprehensive list of C++ STL (Standard Template Library) interview questions**, organized by topic. It includes both conceptual and practical questions, ranging from basic to advanced.

---

## 📦 General STL Questions

- What is the STL in C++?
- What are the main components of STL?
  - Containers
  - Algorithms
  - Iterators
  - Function Objects
- What are the advantages of using STL?
- How is STL different from Boost libraries?

---

## 📚 Containers

### ✅ Sequence Containers
- Difference between `vector`, `list`, and `deque`
- When would you use `vector` over `list`?
- Why is `vector` preferred in most cases?
- Time complexity of insert/delete in `vector` vs `list`
- How is memory managed in `vector`?
- Difference between `std::array` and C-style arrays

### ✅ Associative Containers
- Difference between `set` and `unordered_set`
- How does `map` maintain order?
- Internal data structures of `map` and `unordered_map`
- How does hashing work in `unordered_map`?
- When to use `unordered_map` vs `map`
- Can you store custom objects in `unordered_map` or `set`?

### ✅ Container Adapters
- What are `stack`, `queue`, and `priority_queue`?
- Are `stack` and `queue` STL containers?
- Can you iterate over a `stack` or `queue`?
- How does `priority_queue` maintain order?

---

## 🔁 Iterators

- What is an iterator in STL?
- Types of iterators:
  - Input
  - Output
  - Forward
  - Bidirectional
  - Random-access
- Which containers support random-access iterators?
- How do you reverse iterate a container?
- Difference between `begin()` and `cbegin()`

---

## 🧮 Algorithms

- Commonly used STL algorithms
- Difference between `std::find` and `std::binary_search`
- Difference between `std::sort()` and `std::stable_sort()`
- How does `std::transform()` work?
- Difference between `remove()` and `erase()` idiom
- Explain the erase-remove idiom
- Use of `std::accumulate()`
- How are lambdas used with STL algorithms?

---

## 🧱 Function Objects & Lambdas

- What is a function object (functor)?
- Purpose of custom comparator in STL containers
- How do lambdas compare with functors?
- Using lambdas for custom sort

---

## 🧠 Memory Management & Performance

- How does STL manage memory?
- Purpose of `reserve()` in `vector`
- Cost of inserting in the middle of a `vector`
- When to prefer `emplace_back()` over `push_back()`
- How is `shrink_to_fit()` used?

---

## 🔗 Smart Pointers with STL

- Can `shared_ptr` be stored in STL containers?
- Why is `weak_ptr` useful in STL?
- Issues with storing raw pointers in containers

---

## 🧪 Advanced STL Topics

- Implementing LRU cache using STL
- What is allocator-aware STL?
- Modifying containers while iterating — is it safe?
- Iterator invalidation rules for `vector`, `list`, and `map`
- What happens when you insert a duplicate key in `map`?

---

## ⚙️ Multithreading & STL

- Is STL thread-safe?
- Which containers are safe to use across threads?
- How to handle concurrent access to `unordered_map`

---

## 🧩 Custom Types in STL

- How to store custom classes in a `set` or `map`
- Defining custom comparator or hash function
- Why must custom keys be comparable or hashable?

---

## 🛠️ Practical Coding Questions

- Implement a frequency counter using `unordered_map`
- Sort a list of pairs by second element
- Remove duplicates from a `vector`
- Group anagrams using `unordered_map`
- Find the first non-repeating character using STL

---

> Feel free to fork this list or contribute additional questions or answers!
