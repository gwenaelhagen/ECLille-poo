using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace csharpfiddle
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new ViewModel();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var person = (DataContext as ViewModel).AddRandomly();

            if (person == null)
            {
                CmdBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                return;
            }

            var name = person.ToString();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool OO { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName.ToUpper();
        }
    }

    public class ViewModel
    {
        private readonly List<Person> _data;
        
        public ViewModel()
        {
            _data = new List<Person>
                {
                    new Person { FirstName = "Gwenaël", LastName = "HAGENMULLER", OO = false },
                    new Person { FirstName = "Victor", LastName = "CHANAT", OO = false },
                    new Person { FirstName = "Alexis", LastName = "CHARVERIAT", OO = false },
                    new Person { FirstName = "Juri", LastName = "FEDJAEV", OO = false },
                    new Person { FirstName = "Samuel", LastName = "LE GOFF", OO = false },
                    new Person { FirstName = "Maxence", LastName = "LEDUC", OO = false },
                    new Person { FirstName = "Victor", LastName = "MANENTI", OO = false },
                    new Person { FirstName = "Nicolas", LastName = "MERCIER", OO = false },
                    new Person { FirstName = "Vincent", LastName = "RAES", OO = false },
                    new Person { FirstName = "Ming Ye", LastName = "WANG", OO = false },
                    new Person { FirstName = "Buyun", LastName = "ZHANG", OO = false },
                    new Person { FirstName = "Firas", LastName = "MAHMOUD", OO = false }
                };
            Data = new ObservableCollection<Person>(new List<Person>(_data.Count));
        }

        public Person AddRandomly()
        {
            if (_data.Count <= 0)
                return null;

            var i = (new Random()).Next(0, _data.Count);

            var person = _data[i];

            Data.Add(person);
            _data.RemoveAt(i);

            return person;
        }

        public ObservableCollection<Person> Data { get; private set; }
    }
}
