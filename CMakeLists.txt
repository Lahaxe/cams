cmake_minimum_required(VERSION 3.5)

project("cams")
set(cams_MAJOR_VERSION 0)
set(cams_MINOR_VERSION 1)
set(cams_PATCH_VERSION 0)
set(cams_VERSION
    ${cams_MAJOR_VERSION}.${cams_MINOR_VERSION}.${cams_PATCH_VERSION})

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++17")
set(_GLIBCXX_USE_CXX11_ABI 0)

option(BUILD_EXAMPLES "Build the examples directory." OFF)
option(BUILD_TESTING "Build the tests directory." OFF)

set(CMAKE_MODULE_PATH "${CMAKE_SOURCE_DIR}/cmake" ${CMAKE_MODULE_PATH})
include(CTest)
include(cmake/functions.cmake)

set_property(GLOBAL PROPERTY USE_FOLDERS ON)

if(WIN32)
    # Trying the automatic creation of .def files by CMake
    if(${BUILD_SHARED_LIBS})
        set(WINDOWS_EXPORT_ALL_SYMBOLS TRUE)
    endif()

    # We have to set _WIN32_WINNT for Asio
    if(${CMAKE_SYSTEM_VERSION} EQUAL 10) # Windows 10
        add_definitions(-D _WIN32_WINNT=0x0A00)
    elseif(${CMAKE_SYSTEM_VERSION} EQUAL 6.3) # Windows 8.1
        add_definitions(-D _WIN32_WINNT=0x0603)
    elseif(${CMAKE_SYSTEM_VERSION} EQUAL 6.2) # Windows 8
        add_definitions(-D _WIN32_WINNT=0x0602)
    elseif(${CMAKE_SYSTEM_VERSION} EQUAL 6.1) # Windows 7
        add_definitions(-D _WIN32_WINNT=0x0601)
    elseif(${CMAKE_SYSTEM_VERSION} EQUAL 6.0) # Windows Vista
        add_definitions(-D _WIN32_WINNT=0x0600)
    else() # Windows XP (5.1)
        add_definitions(-D _WIN32_WINNT=0x0501)
    endif()
endif()

add_subdirectory("src")

if(BUILD_EXAMPLES)
    add_subdirectory("examples")
endif()

if(BUILD_TESTING)
    add_subdirectory("tests")
endif()
