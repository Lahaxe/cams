#ifndef USER_H
#define USER_H

#include <QWidget>

namespace Ui {
class User;
}

class User : public QWidget
{
    Q_OBJECT

public:
    explicit User(QWidget *parent = 0);
    ~User();

signals:
    void quit();

private slots:
    void on_quit_btn_clicked();

private:
    Ui::User *ui;
};

#endif // USER_H
