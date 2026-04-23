using Android.Content;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
// Kui kasutad vanemat Xamarin.Forms'i, kasuta seda nimeruumi:
// using Xamarin.Forms;

namespace naidis_TARpe24SavvaSmirnyagin
{
    // 1. ANDMEMUDEL
    public class Riik
    {
        public string Nimetus { get; set; }
        public string Pealinn { get; set; }
        public int Rahvaarv { get; set; }
        public string Pilt { get; set; } // Hoiab pildi nime või seadme failiteed
    }

    // 2. PÕHILEHT
    public partial class Euroopa_Page : ContentPage
    {
        // Globaalsed muutujad
        ObservableCollection<Riik> riigid;
        ListView list;
        Entry entryNimetus, entryTootja, entryHind;

        // Muutujad pildi valimise jaoks
        string valitudPildiTee = "";
        Label lblValitudPilt;

        public Euroopa_Page()
        {
            this.Title = "Euroopa riikide rakendus";

            // Algandmete laadimine
            riigid = new ObservableCollection<Riik>
            {
                new Riik { Nimetus="Eesti", Pealinn="Tallinn", Rahvaarv=1400000, Pilt="default_riik.png" },
                new Riik { Nimetus="Läti", Pealinn="Riia", Rahvaarv=1400000, Pilt="default_riik.png" },
                new Riik { Nimetus="Leedu", Pealinn="Vilnius", Rahvaarv=1400000, Pilt="default_riik.png" }
            };

            // 1. SISESTUSVÄLJAD
            entryNimetus = new Entry { Placeholder = "Riigi nimetus (nt Eesti)" };
            entryTootja = new Entry { Placeholder = "Pealinn (nt Tallinn)" };
            entryHind = new Entry { Placeholder = "rahvaarv (täisarv)", Keyboard = Keyboard.Numeric };

            // 2. PILDI VALIMISE KONTROLLID
            Button btnValiPilt = new Button { Text = "Vali pilt galeriist", BackgroundColor = Colors.LightBlue };
            btnValiPilt.Clicked += BtnValiPilt_Clicked;

            lblValitudPilt = new Label { Text = "Pilti pole valitud (kasutatakse vaikimisi pilti)", FontSize = 12, TextColor = Colors.Gray };

            // 3. LISAMISE JA KUSTUTAMISE NUPUD
            Button btnLisa = new Button { Text = "Lisa riik", BackgroundColor = Colors.LightGreen };
            btnLisa.Clicked += Lisa_Clicked;

            Button btnKustuta = new Button { Text = "Kustuta valitud riik", BackgroundColor = Colors.LightPink };
            btnKustuta.Clicked += Kustuta_Clicked;

            Button btnMuuda = new Button { Text = "Muuda valitud riik", BackgroundColor = Colors.Orange };
            btnMuuda.Clicked += Muuda_Clicked;

            // 4. LISTVIEW JA SELLE KUJUNDUS
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = riigid,
                SelectionMode = ListViewSelectionMode.Single
            };

            list.ItemTapped += List_ItemTapped;

            list.ItemTemplate = new DataTemplate(() =>
            {
                // Pildi element
                Image imgPilt = new Image
                {
                    HeightRequest = 50,
                    WidthRequest = 50,
                    Aspect = Aspect.AspectFit,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 0, 10, 0) // Veeris paremal
                };
                imgPilt.SetBinding(Image.SourceProperty, "Pilt");

                // Tekstide elemendid
                Label lblNimetus = new Label { FontSize = 18, FontAttributes = FontAttributes.Bold };
                lblNimetus.SetBinding(Label.TextProperty, "Nimetus");

                Label lblTootja = new Label { TextColor = Colors.Gray };
                lblTootja.SetBinding(Label.TextProperty, "Pealinn");

                Label lblHind = new Label { TextColor = Colors.DarkBlue, FontAttributes = FontAttributes.Bold };
                lblHind.SetBinding(Label.TextProperty, new Binding("Rahvaarv", stringFormat: "{0} inimest"));

                var textLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.Center,
                    Children = { lblNimetus, lblTootja, lblHind }
                };

                // Kogu rea paigutus (Pilt vasakul, tekst paremal)
                var rowLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(10),
                    Children = { imgPilt, textLayout }
                };

                return new ViewCell { View = rowLayout };
            });

            // 5. PANEME KÕIK LEHELE KOKKU
            this.Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    entryNimetus,
                    entryTootja,
                    entryHind,
                    btnValiPilt,   // Uus nupp galerii jaoks
                    lblValitudPilt, // Tagasiside silt
                    btnLisa,
                    btnKustuta,
                    btnMuuda,
                    list
                }
            };
        }

        // --- SÜNDMUSTE TÖÖTLEJAD (Event Handlers) ---

        // Pildi valimine galeriist
        private async void BtnValiPilt_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    valitudPildiTee = photo.FullPath; // Jätame asukoha meelde
                    lblValitudPilt.Text = $"Valitud: {photo.FileName}";
                    lblValitudPilt.TextColor = Colors.Green;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Viga", "Pildi valimine ebaõnnestus: " + ex.Message, "OK");
            }
        }

        // Uue telefoni lisamine
        private void Lisa_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryNimetus.Text) && !string.IsNullOrWhiteSpace(entryTootja.Text))
            {
                int hind = 0;
                int.TryParse(entryHind.Text, out hind);

                // Kui pilti ei valitud, kasutame vaikimisi faili
                string pildiNimi = string.IsNullOrWhiteSpace(valitudPildiTee) ? "default_riik.png" : valitudPildiTee;
                string uusNimi = entryNimetus.Text;

                // LINQ abil on väga lihtne kontrollida, kas nimekirjas leidub juba selline nimi
                // StringComparison.OrdinalIgnoreCase tagab, et "Eesti" ja "eesti" loetakse samaks
                bool riikOnOlemas = riigid.Any(r => r.Nimetus.Equals(uusNimi, StringComparison.OrdinalIgnoreCase));

                if (riikOnOlemas)
                {
                    DisplayAlert("Viga", "See riik on juba nimekirjas!", "OK");
                }
                else
                {
                    riigid.Add(new Riik
                    {
                        Nimetus = entryNimetus.Text,
                        Pealinn = entryTootja.Text,
                        Rahvaarv = hind,
                        Pilt = pildiNimi
                    });
                }
                

                // Puhastame väljad uue sisestuse jaoks
                entryNimetus.Text = "";
                entryTootja.Text = "";
                entryHind.Text = "";

                // Lähtestame pildi valiku oleku
                valitudPildiTee = "";
                lblValitudPilt.Text = "Pilti pole valitud (kasutatakse vaikimisi pilti)";
                lblValitudPilt.TextColor = Colors.Gray;
            }
            else
            {
                DisplayAlert("Viga", "Palun täida vähemalt pealinna ja nimetuse väljad!", "OK");
            }
        }

        // Telefoni kustutamine
        private async void Kustuta_Clicked(object sender, EventArgs e)
        {
            Riik valitudTelefon = list.SelectedItem as Riik;

            if (valitudTelefon != null)
            {
                bool vastus = await DisplayAlert("Kinnitus", $"Kas oled kindel, et soovid riigi {valitudTelefon.Nimetus} kustutada?", "Jah", "Ei");

                if (vastus == true)
                {
                    riigid.Remove(valitudTelefon);
                    list.SelectedItem = null;
                }
            }
            else
            {
                await DisplayAlert("Viga", "Palun vali nimekirjast riik, mida soovid kustutada.", "OK");
            }
        }

        private async void Muuda_Clicked(object sender, EventArgs e)
        {
            Riik valitudTelefon = list.SelectedItem as Riik;

            if (valitudTelefon != null)
            {

                int hind = 0;
                int.TryParse(entryHind.Text, out hind);

                // Kui pilti ei valitud, kasutame vaikimisi faili
                string pildiNimi = string.IsNullOrWhiteSpace(valitudPildiTee) ? "default_riik.png" : valitudPildiTee;

                bool vastus = await DisplayAlert("Kinnitus", $"Kas oled kindel, et soovid riigi {valitudTelefon.Nimetus} muuta?", "Jah", "Ei");

                if (vastus == true)
                {
                    valitudTelefon.Nimetus = entryNimetus.Text;
                    valitudTelefon.Pealinn = entryTootja.Text;
                    valitudTelefon.Rahvaarv = hind;
                    valitudTelefon.Pilt = pildiNimi;

                    list.ItemsSource = null;
                    list.ItemsSource = riigid;

                    list.SelectedItem = null;
                    list.SelectedItem = null;
                }

                list.ItemsSource = null;
                list.ItemsSource = riigid;
            }
            else
            {
                await DisplayAlert("Viga", "Palun vali nimekirjast riik, mida soovid muuta.", "OK");
            }
        }

        // Loendis reale vajutamine
        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Riik valitudTelefon = e.Item as Riik;

            if (valitudTelefon != null)
            {
                entryNimetus.Text = valitudTelefon.Nimetus;
                entryTootja.Text = valitudTelefon.Pealinn;
                entryHind.Text = valitudTelefon.Rahvaarv.ToString();
                await DisplayAlert("Riigi info", $"Pealinn: {valitudTelefon.Pealinn}\nNimetus: {valitudTelefon.Nimetus}\nRahvaarv: {valitudTelefon.Rahvaarv} inimest", "Sulge");
            }
        }


    }
}