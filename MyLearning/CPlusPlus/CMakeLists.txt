cmake_minimum_required(VERSION 3.20)  # 3.20+ is safer for modern compiler support

if (WIN32 AND NOT DEFINED CMAKE_TOOLCHAIN_FILE)
  if (DEFINED ENV{VCPKG_ROOT} AND EXISTS "$ENV{VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake")
    set(CMAKE_TOOLCHAIN_FILE "$ENV{VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake" CACHE STRING "vcpkg toolchain file")
  elseif (EXISTS "C:/Program Files/Microsoft Visual Studio/18/Community/VC/vcpkg/scripts/buildsystems/vcpkg.cmake")
    set(CMAKE_TOOLCHAIN_FILE "C:/Program Files/Microsoft Visual Studio/18/Community/VC/vcpkg/scripts/buildsystems/vcpkg.cmake" CACHE STRING "vcpkg toolchain file")
  endif()
endif()

project(CPlusPlus)

option(ENABLE_CLANG_TIDY "Run clang-tidy during C++ builds" OFF)
option(ENABLE_ADDRESS_SANITIZER "Build with AddressSanitizer instrumentation" OFF)

# Enable Hot Reload for MSVC compilers if supported
if (POLICY CMP0141)
  cmake_policy(SET CMP0141 NEW)
  if (ENABLE_ADDRESS_SANITIZER)
    set(CMAKE_MSVC_DEBUG_INFORMATION_FORMAT "ProgramDatabase")
  else()
    set(CMAKE_MSVC_DEBUG_INFORMATION_FORMAT "$<IF:$<AND:$<C_COMPILER_ID:MSVC>,$<CXX_COMPILER_ID:MSVC>>,$<$<CONFIG:Debug,RelWithDebInfo>:EditAndContinue>,$<$<CONFIG:Debug,RelWithDebInfo>:ProgramDatabase>>")
  endif()
endif()

set(CMAKE_CXX_STANDARD 23)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

find_package(Microsoft.GSL CONFIG REQUIRED)

add_executable(CPlusPlus "main.cpp" "move_demo.h" "simple_unique_ptr.h" "virtual_destructor.h" "diamond_problem.h" "shared_ptr_example.h" "weak_ptr_example.h" "vector_example.h" "const.h" "exercises.h" "simple_shared_ptr.h" "variadic_templates.h" "functor.h" "Pointers/pointers.h" "stl/stl.h")

message(STATUS "C++ Standard is set to: ${CMAKE_CXX_STANDARD}")

target_compile_options(CPlusPlus PRIVATE /Zc:__cplusplus)
target_link_libraries(CPlusPlus PRIVATE Microsoft.GSL::GSL)

if (ENABLE_CLANG_TIDY)
  find_program(CLANG_TIDY_EXE NAMES clang-tidy PATHS "C:/Program Files/LLVM/bin" REQUIRED)
  set_target_properties(CPlusPlus PROPERTIES CXX_CLANG_TIDY "${CLANG_TIDY_EXE}")
endif()

if (ENABLE_ADDRESS_SANITIZER)
  if (MSVC)
    target_compile_options(CPlusPlus PRIVATE /fsanitize=address /Zi)
    target_link_options(CPlusPlus PRIVATE /fsanitize=address)
  else()
    target_compile_options(CPlusPlus PRIVATE -fsanitize=address -fno-omit-frame-pointer)
    target_link_options(CPlusPlus PRIVATE -fsanitize=address)
  endif()
endif()
