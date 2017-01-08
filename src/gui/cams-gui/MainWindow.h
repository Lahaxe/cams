#ifndef _9162810b_73fd_4f92_9c12_53cff547cbcc
#define _9162810b_73fd_4f92_9c12_53cff547cbcc

// Include Qt Files
#include <QMainWindow>

namespace cams_gui
{

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);

    virtual ~MainWindow();

private:
    Ui::MainWindow * _ui;

};

} // namespace cams_gui

#endif // _9162810b_73fd_4f92_9c12_53cff547cbcc
