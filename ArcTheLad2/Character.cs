using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTheLad2
{
	internal class Character
	{
		private readonly uint mAddress;

		public Character(uint address)
		{
			mAddress = address;
		}

		public uint Lv
		{
			get => SaveData.Instance().ReadNumber(mAddress + 0, 2);
			set => Util.WriteNumber(mAddress + 0, 2, 1, 1000, value);
		}

		public uint MaxHP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 2, 2);
			set => Util.WriteNumber(mAddress + 2, 2, 1, 9999, value);
		}

		public uint HP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 4, 2);
			set => Util.WriteNumber(mAddress + 4, 2, 0, 9999, value);
		}

		public uint MaxMP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 6, 2);
			set => Util.WriteNumber(mAddress + 6, 2, 1, 9999, value);
		}

		public uint MP
		{
			get => SaveData.Instance().ReadNumber(mAddress + 8, 2);
			set => Util.WriteNumber(mAddress + 8, 2, 0, 9999, value);
		}

		public uint Attack
		{
			get => SaveData.Instance().ReadNumber(mAddress + 10, 2);
			set => Util.WriteNumber(mAddress + 10, 2, 1, 2499, value);
		}

		public uint Magic
		{
			get => SaveData.Instance().ReadNumber(mAddress + 12, 2);
			set => Util.WriteNumber(mAddress + 12, 2, 1, 2499, value);
		}

		public uint Defense
		{
			get => SaveData.Instance().ReadNumber(mAddress + 14, 2);
			set => Util.WriteNumber(mAddress + 14, 2, 1, 2499, value);
		}

		public uint Speed
		{
			get => SaveData.Instance().ReadNumber(mAddress + 16, 1);
			set => Util.WriteNumber(mAddress + 16, 1, 1, 255, value);
		}

		public uint ID
		{
			get => SaveData.Instance().ReadNumber(mAddress + 17, 1);
			set => SaveData.Instance().WriteNumber(mAddress + 17, 1, value);
		}
	}
}
