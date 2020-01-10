using App1.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.ViewModels
{
  public class AppViewModel : INotifyPropertyChanged
  {
    ICommand _executeButtonCommand;
    ICommand _executeButton2Command;

    public ICommand ExecuteButtonCommand => _executeButtonCommand = _executeButtonCommand ?? Helper.CreateCommand(UpdateNewAppString);
    public ICommand ExecuteButton2Command => _executeButton2Command = _executeButton2Command ?? Helper.CreateCommand(UpdateNewAppStringButton2);

    string _appstring = "";
    string _newappstring = "";

    async void UpdateNewAppString()
    {
      taskactive = true;
      await Task.Delay(4000);
      newappstring = appstring;
      appstring = "";
      taskactive = false;
    }

    void UpdateNewAppStringButton2()
    {
      newappstring = "waiting for task to complete";
    }

    public string appstring
    {
      get => _appstring;
      set
      {
        _appstring = value;
        buttonactive = _appstring.Length > 0 ? true : false;

        OnPropertyChanged();
        OnPropertyChanged(nameof(buttonactive));
      }
    }

    public string newappstring
    {
      get => _newappstring;
      set
      {
        _newappstring = value;
        buttonactive = false;

        OnPropertyChanged();
        OnPropertyChanged(nameof(buttonactive));
      }
    }

    bool _buttonactive = false;

    bool _taskactive = false;

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string name = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    public bool buttonactive
    {
      get => _buttonactive;
      set
      {
        _buttonactive = value;

        OnPropertyChanged();

      }
    }

    public bool taskactive
    {
      get => _taskactive;
      set
      {
        _taskactive = value;
        OnPropertyChanged();
      }
    }
  }
}
