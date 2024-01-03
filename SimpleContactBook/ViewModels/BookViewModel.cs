using SimpleContactBook.Services;
using SimpleContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleContactBook.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        private IContactDataService _service;

        private ContactsViewModel _contactsVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactsVM; }
            set { OnPropertyChanged(ref _contactsVM, value); }
        }

        public ICommand LoadContactsCommand { get; private set; }

        public BookViewModel(IContactDataService service)
        {
            ContactsVM = new ContactsViewModel(service);

            _service = service;

            LoadContactsCommand = new RelayCommand(LoadContacts);
        }

        private void LoadContacts()
        {
            ContactsVM.LoadContacts(_service.GetContacts());
        }
    }
}
