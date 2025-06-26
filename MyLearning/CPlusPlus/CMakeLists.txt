cmake_minimum_required(VERSION 3.20)  # 3.20+ is safer for modern compiler support

project(CPlusPlus)

# Enable Hot Reload for MSVC compilers if supported
if (POLICY CMP0141)
  cmake_policy(SET CMP0141 NEW)
  set(CMAKE_MSVC_DEBUG_INFORMATION_FORMAT "$<IF:$<AND:$<C_COMPILER_ID:MSVC>,$<CXX_COMPILER_ID:MSVC>>,$<$<CONFIG:Debug,RelWithDebInfo>:EditAndContinue>,$<$<CONFIG:Debug,RelWithDebInfo>:ProgramDatabase>>")
endif()

set(CMAKE_CXX_STANDARD 23)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

add_executable(CPlusPlus "main.cpp" "move_demo.h" "simple_unique_ptr.h" "virtual_destructor.h" "diamond_problem.h" "shared_ptr_example.h" "weak_ptr_example.h" "vector_example.h" "const.h" "exercises.h" "simple_shared_ptr.h")

message(STATUS "C++ Standard is set to: ${CMAKE_CXX_STANDARD}")

target_compile_options(CPlusPlus PRIVATE /Zc:__cplusplus)
