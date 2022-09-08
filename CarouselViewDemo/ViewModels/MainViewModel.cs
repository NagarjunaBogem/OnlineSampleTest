using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using CarouselViewDemo.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CarouselViewDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        readonly IList<ItemDetails> source;
        HttpClient client;

        public ObservableCollection<ItemDetails> Items { get; private set; }
        public IList<ItemDetails> EmptyItems { get; private set; }
        string url = "https://www.colourlovers.com/api/patterns/random";
        public ItemDetails PreviousItems { get; set; }
        public ItemDetails CurrentItem { get; set; }
        public ItemDetails CurrentItems { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);

        public MainViewModel()
        {
            source = new List<ItemDetails>();
            CreateItemCollection();
            client = new HttpClient();

            //var task = Task.Run(() => GetItemDetails());
            //task.Wait();

            CurrentItems = Items.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        /// <summary>
        /// Sample data 
        /// </summary>
        void CreateItemCollection()
        {
            source.Add(new ItemDetails
            {
                Name = "Baboon",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/3250/3250257.png"
            });

            source.Add(new ItemDetails
            {
                Name = "UPtimist",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/1599/1599853.png"
            });

            source.Add(new ItemDetails
            {
                Name = "Sukiro",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/4547/4547146.png"
            });

            source.Add(new ItemDetails
            {
                Name = "Tzadkiel",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/475/475336.png"
            });

            source.Add(new ItemDetails
            {
                Name = "Geighteyed",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/5357/5357862.png"
            });

            source.Add(new ItemDetails
            {
                Name = "fbail",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/5556/5556047.png"
            });

            source.Add(new ItemDetails
            {
                Name = "kumori",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/2121/2121528.png"
            });

            source.Add(new ItemDetails
            {
                Name = "Baboon",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/3250/3250257.png"
            });

            source.Add(new ItemDetails
            {
                Name = "UPtimist",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/1599/1599853.png"
            });

            source.Add(new ItemDetails
            {
                Name = "Sukiro",
                FileType = "Video",
                ImageUrl = "http://static.colourlovers.com/images/patterns/4547/4547146.png"
            });

            Items = new ObservableCollection<ItemDetails>(source);
        }

        /// <summary>
        /// Get dta from Web API
        /// </summary>
        /// <returns></returns>
        private async Task GetItemDetails()
        {
            try
            {
                Uri uri = new Uri(string.Format(url, string.Empty));
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var text = await response.Content.ReadAsStringAsync();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }

           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

       

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
