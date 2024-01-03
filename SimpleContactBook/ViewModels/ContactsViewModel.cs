using SimpleContactBook.Utility;
using SimpleContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SimpleContactBook.Services;

namespace SimpleContactBook.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { OnPropertyChanged(ref _selectedContact, value); }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            { 
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }

        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }

        private List<Contact> _contacts;
        public ObservableCollection<Contact> Contacts { get; private set; }

        public ICommand EditCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }


        private IContactDataService _dataService;
        public ContactsViewModel(IContactDataService dataService)
        {
            _dataService = dataService;
            _contacts = dataService.GetContacts().ToList();


            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        private bool CanDelete()
        {
            return SelectedContact == null ? false : true;
        }

        private void Delete()
        {
            _contacts.Remove(SelectedContact);
            Contacts.Remove(SelectedContact);
            Save();
        }

        private void Add()
        {
            var newContact = new Contact
            {
                Name = "Name Surname",
                PhoneNumber = "Phone number",
                Email = "E-mail adress"
            };

            Contacts.Add(newContact);
            _contacts.Add(newContact);
            SelectedContact = newContact;
        }

        private bool IsEdit()
        {
            return IsEditMode;
        }

        private void Save()
        {
            _dataService.Save(_contacts);
            IsEditMode = false;
            OnPropertyChanged("SelectedContact");
        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;
            return !IsEditMode;
        }

        private void Edit()
        {
            IsEditMode = true;
        }

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
        }
    }
}
