#ifndef _bc09e680_1ffe_4e01_bc22_9fde1b3070b2
#define _bc09e680_1ffe_4e01_bc22_9fde1b3070b2

// include Qt files
#include <QWidget>

namespace cams_gui
{

namespace Ui {
class Menu;
}

class Menu : public QWidget
{
    Q_OBJECT

public:
    explicit Menu(QWidget *parent = 0);

    virtual ~Menu();

private:
    Ui::Menu * _ui;
};

} // namespace cams_gui

#endif // _bc09e680_1ffe_4e01_bc22_9fde1b3070b2
