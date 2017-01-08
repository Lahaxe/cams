
# Appeler automatique le moc quand nécessaire
set(CMAKE_AUTOMOC ON)
# Appeler automatique le uic quand nécessaire
set(CMAKE_AUTOUIC ON)
# Les fichiers générés par le moc sont générés dans le dossier bin,
# dire à CMake de toujours inclure les entêtes de ce dossier
set(CMAKE_INCLUDE_CURRENT_DIR ON)

find_package(Boost COMPONENTS filesystem system REQUIRED)
find_package(Qt5Widgets REQUIRED)

file(GLOB_RECURSE Source_Files "*.cpp")
file(GLOB_RECURSE Header_Files "*.h")
file(GLOB_RECURSE Forms_Files "*.ui")
file(GLOB_RECURSE Resources_Files "*.qrc")

# Regroup files by folder
GroupFiles(Header_Files)
GroupFiles(Source_Files)
GroupFiles(Forms_Files)

include_directories(${CMAKE_CURRENT_SOURCE_DIR}
                    ${CMAKE_CURRENT_SOURCE_DIR}/../lib
                    ${CMAKE_SOURCE_DIR}/../rompp/src/
                    ${Boost_INCLUDE_DIRS}
                    ${CMAKE_CURRENT_BINARY_DIR})

add_library(libcamsgui SHARED ${Source_Files} ${Header_Files} ${Forms_Files})
set_target_properties(libcamsgui PROPERTIES OUTPUT_NAME dicomifiergui)

target_link_libraries(libcamsgui ${Boost_LIBRARIES})

QT5_USE_MODULES(libcamsgui Widgets)
