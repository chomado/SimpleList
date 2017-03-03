using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace SimpleList
{
    public partial class SimpleListPage : ContentPage
    {
        public SimpleListPage()
        {
            InitializeComponent();
        }

        // "データを読み込む"ボタンが押された時の処理（イベント）
        private async void OnClick(object sender, EventArgs e)
        { 
            using (var client = new HttpClient())
            {
                //サーバーから json を取得します
                var json = await client.GetStringAsync("http://demo4404797.mockable.io/speakers");

                //json をデシリアライズします
                var items = JsonConvert.DeserializeObject<List<Speaker>>(json);

                this.speakerListView.ItemsSource = items;
            }
        }
    }
}
