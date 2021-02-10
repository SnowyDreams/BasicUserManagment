using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace second_attempt.Model
{
    class User : INotifyPropertyChanged
    {
        private int userID;
        private string userName;
        private string password;


        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                OnPropertyChanged("userID");
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("userName");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("password");
            }
        }
        public User(int userID,string userName, string password)
        {

            UserID = ++userID;
            UserName = userName;
            Password = password;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
