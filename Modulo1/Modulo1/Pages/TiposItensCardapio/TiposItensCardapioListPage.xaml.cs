using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modulo1.Dal;
using Modulo1.Modelo;
using Xamarin.Forms;

namespace Modulo1.Pages.TiposItensCardapio
{
    public partial class TiposItensCardapioListPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = TipoItemCardapioDAL.GetInstance();
        public TiposItensCardapioListPage()
        {
            InitializeComponent();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }

        public async void OnRemoverClick(Object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            var opcao = await DisplayAlert("Confirmação de exclusão", "Confirma excluir o item" + item.Nome.ToUpper() + "?", "Sim", "Não");
            if (opcao)
            {
                dalTipoItemCardapio.Remove(item);
            }
        }
    }
}
