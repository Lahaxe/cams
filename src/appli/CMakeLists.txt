
find_package(Boost COMPONENTS filesystem system REQUIRED)
find_package(Qt5Core REQUIRED)

include_directories(${CMAKE_SOURCE_DIR}/src/gui
                    ${CMAKE_SOURCE_DIR}/../rompp/src/)

# Create CAMS-CLI binary
add_executable(cams-cli "cams-cli.cpp")
target_link_libraries(cams-cli log4cpp
                      ${CMAKE_SOURCE_DIR}/../rompp/build/src/librompp.a)

# Create CAMS-GUI binary
add_executable(cams-gui "cams-gui.cpp")
target_link_libraries(cams-gui libcamsgui
                      ${CMAKE_SOURCE_DIR}/../rompp/build/src/librompp.a
                      log4cpp
                      ${Boost_LIBRARIES})

QT5_USE_MODULES(cams-gui Core)
