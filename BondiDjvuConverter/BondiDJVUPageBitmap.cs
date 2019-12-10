using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RollingStoneConverter
{
    public class BondiDJVUPageBitmap : IDisposable
    {
        private int width;
        private int height;
        private byte[] bitmapData;
        private int rotation;
        private GCHandle bitmapDataHandle;
        private Bitmap bitmap;

        public BondiDJVUPageBitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.bitmapData = new byte[4 * width * height];
            this.bitmapDataHandle = GCHandle.Alloc((object)this.bitmapData, GCHandleType.Pinned);
        }

        public int Width
        {
            get
            { 
                    return (this.rotation != 0)? this.height: this.width;
            }
        }

        public int Height
        {
            get
            {
                return (this.rotation != 0) ? this.width : this.height;
            }
        }

        public int DPI { get; set; }

        public double Gamma { get; set; }

        public int Rotation
        {
            get
            {
                return this.rotation;
            }
            set
            {
                if (this.rotation == value)
                    return;
                this.rotation = value;
            }
        }

        public IntPtr BitmapData
        {
            get
            {
                return this.bitmapDataHandle.AddrOfPinnedObject();
            }
        }

        public Bitmap Bitmap
        {
            get
            {
                if (this.bitmap == null)
                    this.bitmap = new Bitmap(this.width, this.height, this.width * 4, PixelFormat.Format32bppRgb, this.bitmapDataHandle.AddrOfPinnedObject());
                return this.bitmap;
            }
        }

        public void Close()
        {
            this.bitmap.Dispose();
            this.bitmap = (Bitmap)null;
            this.bitmapDataHandle.Free();
            
            this.bitmapData = new byte[1];
            this.bitmapData = (byte[])null;
        }

        public void Dispose()
        {
            this.Close();
            
        }
    }
}
