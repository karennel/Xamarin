using System.ComponentModel;

namespace RandomApp.ViewModel
{
	public interface IViewModel : INotifyPropertyChanged
	{
		bool IsBusy { get; set; }

		string Title { get; set; }

		string Icon { get; set; }
	}
}
