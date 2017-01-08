// Include Project files
#include "Menu.h"
#include "ui_Menu.h"

namespace cams_gui
{

Menu
::Menu(QWidget *parent) :
    QWidget(parent),
    _ui(new Ui::Menu)
{
    this->_ui->setupUi(this);
}

Menu
::~Menu()
{
    delete this->_ui;
}

} // namespace cams_gui
