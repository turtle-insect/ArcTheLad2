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
		private Item? mCopyItem = null;

		public Info Info { get; } = Info.Instance();

		public ICommand OpenFileCommand { get; }
		public ICommand SaveFileCommand { get; }
		public ICommand CopyItemCommand { get; }
		public ICommand PasteItemCommand { get; }
		public ICommand ImportItemCommand { get; }
		public ICommand ExportItemCommand { get; }

		public ObservableCollection<Character> Party { get; } = new ObservableCollection<Character>();
		public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

		public ViewModel()
		{
			OpenFileCommand = new ActionCommand(OpenFile);
			SaveFileCommand = new ActionCommand(SaveFile);
			CopyItemCommand = new ActionCommand(CopyItem);
			PasteItemCommand = new ActionCommand(PasteItem);
			ImportItemCommand = new ActionCommand(ImportItem);
			ExportItemCommand = new ActionCommand(ExportItem);
		}

		private void Initialize()
		{
			Party.Clear();
			for (uint index = 0; index < 32; index++)
			{
				Party.Add(new Character(0x2624 + index * 260));
			}

			Items.Clear();
			for (uint index = 0; index < 96; index++)
			{
				Items.Add(new Item(0x46A4 + index * 30));
			}
		}

		private void OpenFile(Object? param)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "mcd|*.mcd";
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

		private void CopyItem(Object? param)
		{
			mCopyItem = param as Item;
		}

		private void PasteItem(Object? param)
		{
			if (mCopyItem == null) return;

			var item = param as Item;
			if (item == null) return;

			item.Copy(mCopyItem);
		}

		private void ImportItem(Object? param)
		{
			var item = param as Item;
			if (item == null) return;

			var dlg = new OpenFileDialog();
			dlg.Filter = "arc2 item|*.arc2item";
			if (dlg.ShowDialog() == false) return;

			item.Import(System.IO.File.ReadAllBytes(dlg.FileName));
		}

		private void ExportItem(Object? param)
		{
			var item = param as Item;
			if (item == null) return;

			var dlg = new SaveFileDialog();
			dlg.Filter = "arc2 item|*.arc2item";
			if (dlg.ShowDialog() == false) return;

			System.IO.File.WriteAllBytes(dlg.FileName, item.Export());
		}
	}
}
