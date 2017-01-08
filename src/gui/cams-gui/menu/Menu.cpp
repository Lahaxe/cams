// Include Qt files
#include <QMainWindow>

// Include Project files
#include "Menu.h"
#include "ui_Menu.h"

#include "cams-gui/menu/User.h"

namespace cams_gui
{

namespace menu
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

void
Menu
::on_user_btn_clicked()
{
    QWidget * mainwindow = nullptr;
    foreach(QWidget *widget, qApp->topLevelWidgets())
    {
        if(widget->inherits("QMainWindow"))
        {
            mainwindow = widget;
            break;
        }
    }

    User* user = new User(mainwindow);
    //user->setWindowModality(Qt::WindowModal);
    user->setWindowFlags(Qt::FramelessWindowHint | Qt::Popup);

    QRect const & geometry_user_btn = this->_ui->user_btn->geometry();

    int user_x = geometry_user_btn.x() + geometry_user_btn.width() -
                 user->geometry().width();
    int user_y = geometry_user_btn.y() + geometry_user_btn.height();
    int user_width = user->geometry().width();
    int user_height = user->geometry().height();

    user->setGeometry(user_x, user_y, user_width, user_height);

    user->show();
}

} // namespace menu

} // namespace cams_gui
