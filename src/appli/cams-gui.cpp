// Include Standard library
#include <cstdlib>
#include <iostream>
#include <sstream>

// Include Qt files
#include <QApplication>

// Include Rompp files
#include <rompp/logger/Logger.h>

// Include Project files
#include "cams-gui/MainWindow.h"

int main(int argc, char *argv[])
{
    auto logger = Logger::instance();
    int status = EXIT_FAILURE;
    try
    {
        logger.initialize_default("DEBUG");

        std::stringstream message;
        message << "Begin " << std::string(argv[0]);
        logger.info(message.str());

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
        std::stringstream message;
        message << exc.what();
        logger.fatal(message.str());
    }

    std::stringstream message;
    message << "End " << std::string(argv[0]);
    logger.info(message.str());

    return status;
}

