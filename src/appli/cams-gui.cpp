// Include Standard library
#include <cstdlib>

// Include Qt files
#include <QApplication>

// Include Rompp files
#include <rompp/logger/Logger.h>

// Include Project files
#include "cams-gui/MainWindow.h"

int main(int argc, char *argv[])
{
    int status = EXIT_FAILURE;
    try
    {
        initialize_log();

        LOGGER_INFO << "Begin " << std::string(argv[0]);

        QApplication a(argc, argv);

        // Configure application
        QCoreApplication::setOrganizationName("RLahaxe");
        QCoreApplication::setApplicationName("cams-gui");

        // Create main frame
        cams_gui::MainWindow frame;
        //frame.Initialize();
        frame.show();

        status = a.exec();
    }
    catch (std::exception & exc)
    {
        LOGGER_FATAL << exc.what();
    }

    LOGGER_INFO << "End " << std::string(argv[0]);

    return status;
}

