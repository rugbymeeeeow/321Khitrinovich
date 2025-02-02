﻿using Khitrinovich;
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

namespace _321_Khitrinovich.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Window
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void TextBoxLogin_Changed(object sender, RoutedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (TextBoxLogin.Text.Length > 0)
            {
                txtHintLogin.Visibility = Visibility.Hidden;
            }
        }

        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
            }

            using (var db = new Entities()) 
            { 
                var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);

                if (user != null)
                {
                    MessageBox.Show("Такой пользователь не найден!");
                    return;
                }

                switch (user.Role)

                {
                    case "администратор":
                        NavigationService?.Navigate(new AdminMenu()));
                        break;
                    case "пользователь":
                        NavigationService?.Navigate(new UserMenu());
                        break;
                }
            }
        }
    }
}
