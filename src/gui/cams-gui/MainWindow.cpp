
// Include Rompp files
#include <rompp/logger/Logger.h>

// Include Qt files
#include <qdesktopwidget.h>

// Include Project files
#include "MainWindow.h"
#include "ui_MainWindow.h"

namespace cams_gui
{

MainWindow
::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    _ui(new Ui::MainWindow)
{
    this->_ui->setupUi(this);

    this->setWindowFlags(Qt::Window | Qt::FramelessWindowHint);

    // Resize to fullscreen
    this->resize(QDesktopWidget().availableGeometry(this).size());
}

MainWindow
::~MainWindow()
{
    delete this->_ui;
}

} // namespace cams_gui
