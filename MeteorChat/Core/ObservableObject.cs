using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeteorChat.Core
{
    public class ObservableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
