
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RollingStoneConverter
{
    public class BondiDJVUActions
    {
        private string openFileName;
        private int pageCount;
        private Size[] pageSizeArray;


        [DllImport("BondiReader.DJVU.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool OpenDocument(string fileName, string username, string password);

        [DllImport("BondiReader.DJVU.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void CloseDocument();

        [DllImport("BondiReader.DJVU.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int GetPageCount();

        [DllImport("BondiReader.DJVU.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool GetPageSize(int pageIndex, ref BondiDJVUActions.SIZE size);

        [DllImport("BondiReader.DJVU.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool GetPageBitmapData(int pageIndex, int width, int height, int rotation, IntPtr d);

        public BondiDJVUActions()
        {
        }

        public int PageCount
        {
            get
            {
                return this.pageCount;
            }
        }

        public int LastPageIndex
        {
            get
            {
                return (this.pageCount != 0) ? this.pageCount - 1 : -1;
            }
        }

        public bool Open(string fileName, string username, string password)
        {
            if (this.openFileName != null)
            {
                BondiDJVUActions.CloseDocument();
                this.openFileName = (string)null;
            }
            BondiDJVUActions.OpenDocument(fileName, username, password);

            this.openFileName = fileName;
            this.pageCount = BondiDJVUActions.GetPageCount();
            this.pageSizeArray = new Size[this.pageCount];
            return true;
        }

        public void Close()
        {
            if (this.openFileName == null)
                return;
            
            BondiDJVUActions.CloseDocument();
            this.openFileName = (string)null;
            this.pageCount = 0;
            this.pageSizeArray = (Size[])null;
        }

        public void SavePageBitmap(string outputFilePath, int pageIndex, int width, int height)
        {
            BondiDJVUPageBitmap djvuPageBitmap = new BondiDJVUPageBitmap(width, height);
            if (BondiDJVUActions.GetPageBitmapData(pageIndex, width, height, 0, djvuPageBitmap.BitmapData))
            {
                djvuPageBitmap.Bitmap.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                djvuPageBitmap.Close();
            }


            GC.Collect();

        }

        public Size GetPageSize(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex > this.LastPageIndex)
            {
                return Size.Empty;
            }
            
            if (!this.pageSizeArray[pageIndex].IsEmpty)
            {
                return this.pageSizeArray[pageIndex];
            }

            BondiDJVUActions.SIZE size = new BondiDJVUActions.SIZE();

            if (!BondiDJVUActions.GetPageSize(pageIndex, ref size))
                return Size.Empty;

            this.pageSizeArray[pageIndex] = size.Size;
            return this.pageSizeArray[pageIndex];
        }

        public struct SIZE
        {
            public int cx;
            public int cy;

            public SIZE(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
            }

            public Size Size
            {
                get
                {
                    return new Size(this.cx, this.cy);
                }
            }
        }
    }
}
