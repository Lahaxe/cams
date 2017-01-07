// Include Standard library
#include <cstdlib>
#include <iostream>
#include <sstream>

// Include Rompp files
#include <rompp/logger/Logger.h>

int main(int argc, char *argv[])
{
    try
    {
        initialize_log();

        LOGGER_INFO << "Begin " << std::string(argv[0]);
    }
    catch (std::exception & exc)
    {
        LOGGER_FATAL << exc.what();
    }

    LOGGER_INFO << "End " << std::string(argv[0]);

    return EXIT_SUCCESS;
}

