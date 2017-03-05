
find_package(Boost COMPONENTS filesystem system date_time REQUIRED)
find_package(Log4Cpp REQUIRED)
find_package(Qt5Core REQUIRED)

include_directories(${CMAKE_SOURCE_DIR}/src/gui
                    ${CMAKE_SOURCE_DIR}/../rompp/src/
                    ${Boost_INCLUDE_DIRS}
                    ${Log4Cpp_INCLUDE_DIRS})

# Create CAMS-CLI binary
add_executable(cams-cli "cams-cli.cpp")
target_link_libraries(cams-cli
                      ${CMAKE_SOURCE_DIR}/../rompp/build/src/librompp.a
                      ${Boost_LIBRARIES}
                      ${Log4Cpp_LIBRARIES})

# Create CAMS-GUI binary
add_executable(cams-gui "cams-gui.cpp")
target_link_libraries(cams-gui libcamsgui
                      ${CMAKE_SOURCE_DIR}/../rompp/build/src/librompp.a
                      ${Boost_LIBRARIES}
                      ${Log4Cpp_LIBRARIES})

QT5_USE_MODULES(cams-gui Core)
