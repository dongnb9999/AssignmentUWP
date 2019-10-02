using AssignmentUWP.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    public sealed partial class upsong : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
        public upsong()
        {
            this.InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var member = new Member
            {
                name = this.name.Text,
                description = this.decription.Text,
                singer = this.singer.Text,
                author = this.author.Text,
                thumbnail = this.thumnail.Text,
                link = this.link.Text,



            };
            
            // validate phía client.
            Debug.WriteLine(JsonConvert.SerializeObject(member));
                
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8,
                "application/json");

            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl, content);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);

        }
    }
}
