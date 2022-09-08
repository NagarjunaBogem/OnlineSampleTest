using System;
using CarouselViewDemo.Models;
using Xamarin.Forms;

namespace CarouselViewDemo.Controls
{
    public class ItemsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AudioFile { get; set; }
        public DataTemplate VideoFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ItemDetails)item).FileType.Contains("Audio") ? AudioFile : VideoFile;
        }
    }
}
