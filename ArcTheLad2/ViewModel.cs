using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArcTheLad2
{
	internal class ViewModel
	{
		public Info Info { get; } = Info.Instance();

		public ICommand OpenFileCommand { get; }
		public ICommand SaveFileCommand { get; }

		public ObservableCollection<Character> Party { get; } = new ObservableCollection<Character>();

		public ViewModel()
		{
			OpenFileCommand = new ActionCommand(OpenFile);
			SaveFileCommand = new ActionCommand(SaveFile);
		}

		private void Initialize()
		{
			Party.Clear();

			for (uint index = 0; index < 32; index++)
			{
				Party.Add(new Character(0x2624 + index * 260));
			}
		}

		private void OpenFile(Object? param)
		{
			var dlg = new OpenFileDialog();
			dlg.DefaultExt = "mcd";
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Open(dlg.FileName))
			{
				Initialize();
			}
		}

		private void SaveFile(Object? param)
		{
			SaveData.Instance().Save();
		}
	}
}
