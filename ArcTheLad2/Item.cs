using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTheLad2
{
    class Item
    {
        private readonly uint mAddress;

        public Item(uint address)
        {
            mAddress = address;
        }

		public uint Type
        {
            get => SaveData.Instance().ReadNumber(mAddress, 1);
            set => SaveData.Instance().WriteNumber(mAddress, 1, value);
        }

		public uint Special
		{
			get => SaveData.Instance().ReadNumber(mAddress + 1, 1);
			set => SaveData.Instance().WriteNumber(mAddress + 1, 1, value);
		}

		public uint Base
		{
			get => SaveData.Instance().ReadNumber(mAddress + 4, 1);
			set => SaveData.Instance().WriteNumber(mAddress + 4, 1, value);
		}

		public uint Addtitional
		{
			get => SaveData.Instance().ReadNumber(mAddress + 4, 1);
			set => SaveData.Instance().WriteNumber(mAddress + 4, 1, value);
		}

		public uint Exp
		{
			get => SaveData.Instance().ReadNumber(mAddress + 8, 2);
			set => SaveData.Instance().WriteNumber(mAddress + 8, 2, value);
		}

		public void Copy(Item src)
		{
			SaveData.Instance().WriteValue(mAddress, SaveData.Instance().ReadValue(src.mAddress, 30));
		}

		public void Import(Byte[] buf)
		{
			if (buf.Length != 30) return;
			SaveData.Instance().WriteValue(mAddress, buf);
		}

		public Byte[] Export()
		{
			return SaveData.Instance().ReadValue(mAddress, 30);
		}
	}
}
