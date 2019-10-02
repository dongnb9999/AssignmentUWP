using AssignmentUWP.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AssignmentUWP.ASM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class listsong : Page
    {
        private const string ApiGetListSong = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";
        public ObservableCollection<List> ListSongs = new ObservableCollection<List>();
        public listsong()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(ApiGetListSong).Result.Content.ReadAsStringAsync().Result;
            ObservableCollection<List> listSong = JsonConvert.DeserializeObject<ObservableCollection<List>>(response);

            foreach (List item in listSong)
            {
                ListSongs.Add(item);
            }
        }

        private void Choosed_Song(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
