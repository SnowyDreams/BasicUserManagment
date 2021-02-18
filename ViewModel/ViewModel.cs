using second_attempt.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace second_attempt.View_Model
{
    class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model.User> usersList = new ObservableCollection<Model.User>();
        public ViewModel()
        {
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        private Model.User currentUser;
        private bool isUpdate = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddOrEditUser(Button button)
        {
            if (isUpdate)
            {
                EditUser(button);
            }
            else
            {
                AddUser();
            }
        }

        public void AddUser()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("First and Last names MUST be filled");
            }
            else
            {
                usersList.Insert(NewUserID(), new Model.User(NewUserID(), UserName, Password));
                ResetNames();
                OnPropertyChanged("UserName");
                OnPropertyChanged("Password");
            }
        }

        public void EditUser(Button button)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("First and Last names MUST be filled");
            }
            else
            {
                currentUser.UserName = UserName;
                currentUser.Password = Password;
                button.Content = "Add User";
                ResetNames();
                SetUpdate();
            }
            
        }

        public void SetEditedUser(List<Model.User> selectedUsers, Button button)
        {
            if (selectedUsers.Count > 1)
            {
                MessageBox.Show("Cannot edit multiple users at once");
            }
            else
            {
                UserName = selectedUsers[0].UserName;
                Password = selectedUsers[0].Password;
                currentUser = selectedUsers[0];
                button.Content = "Save Change";
                OnPropertyChanged("UserName");
                OnPropertyChanged("Password");
                SetUpdate();
            }

        }

        public void DeleteUsers(List<Model.User> selectedUsers)
        {
            foreach (Model.User user in selectedUsers)
            {
                usersList.Remove(user);
            }


        }
        public void CloseGaps()
        {
            foreach (User user in usersList)
            {
                user.UserID = usersList.IndexOf(user) + 1;
            }
        }

        private int NewUserID()
        {
            if (usersList.Count == 0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < usersList.Count; i++)
                {
                    if (usersList[i].UserID != i + 1)
                    {
                        return i;
                    }
                }

                return usersList.Count;
            }
        }

        private void ResetNames()
        {
            UserName = string.Empty;
            Password = string.Empty;
            OnPropertyChanged("UserName");
            OnPropertyChanged("Password");
        }

        private void SetUpdate()
        {
            isUpdate = !isUpdate;
        }
    }

}
