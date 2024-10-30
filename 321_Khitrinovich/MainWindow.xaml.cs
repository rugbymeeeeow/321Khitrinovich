using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Khitrinovich.Properties;

namespace _321_Khitrinovich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateDateTime(); // Обновляем дату и время при загрузке окна

            // Устанавливаем таймер для обновления каждую секунду
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
            Background = new SolidColorBrush(Color.FromRgb(224, 169, 175));
        }

        private void UpdateDateTime()
        {
            DateTimeTextBlock.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"); // Формат даты и времени
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //NavigationService.Navigate(new Exit());
            Exit exitWindow = new Exit(); // Создаем экземпляр нового окна
            exitWindow.Show(); // Открываем новое окно
        }
        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e) 
        { 
            if(!(e.Content is Page page)) return;
            this.Title = $"ProjectByKhitrinovich - {page.Title}";

            if(page is Pages.AuthPage)
                BackButtonClick.Visibility = Visibility.Hidden;
            else
                BackButtonClick.Visibility = Visibility.Visible;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if(MainFrame.CanGoBack) MainFrame.GoBack();
        }
    }
}
