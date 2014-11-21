using CollectionItemUploader.Models.DataTransferObjects;
using GongSolutions.Wpf.DragDrop;
using MVVMBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CollectionItemUploader.Common
{
    public class ImageDragAndDropCollection : ObservableCollection<ImageData>, IDropTarget
    {
        #region IDropTarget

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataObject)
            {
                var fileList = ToArray((dropInfo.Data as DataObject).GetFileDropList());
                var allowedExtensions = new string[] { ".jpg", ".png", ".gif" };
                if (fileList.Length > 0 && fileList.All(o => allowedExtensions.Contains(Path.GetExtension(o).ToLower())))
                {
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = DragDropEffects.Move;
                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            var files = ToArray((dropInfo.Data as DataObject).GetFileDropList());

            var decoders = ImageCodecInfo.GetImageDecoders();

            foreach (var file in files)
            {
                using (var img = Image.FromFile(file))
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var resized = ImageHelper.ResizeImage(img, new System.Drawing.Size(800, 800)))
                        {
                            resized.Save(stream, img.RawFormat);
                            var format = img.RawFormat;
                            var codec = decoders.FirstOrDefault(c => c.FormatID == format.Guid);
                            var mimeType = codec.MimeType;
                            this.Add(new ImageData()
                            {
                                Content = stream.ToArray(),
                                FileName = file,
                                MimeType = mimeType
                            });
                        }
                    }
                }
            }
        }

        private string[] ToArray(StringCollection collection)
        {
            List<string> lst = new List<string>();
            foreach (var str in collection)
            {
                lst.Add(str);
            }
            return lst.ToArray();
        }

        #endregion IDropTarget
    }
}
