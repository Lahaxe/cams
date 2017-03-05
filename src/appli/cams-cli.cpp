// Include Standard library
#include <cstdlib>
#include <iostream>
#include <sstream>

// Include Rompp files
#include <rompp/logger/Logger.h>

int main(int argc, char *argv[])
{
    auto logger = Logger::instance();
    try
    {
        logger.initialize_default("DEBUG");

        std::stringstream message;
        message << "Begin " << std::string(argv[0]);
        logger.info(message.str());
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

    return EXIT_SUCCESS;
}

