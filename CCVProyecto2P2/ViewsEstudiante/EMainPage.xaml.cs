

using CCVProyecto2P2.ViewsModels;

namespace CCVProyecto2P2
{
    public partial class EMainPage : ContentPage
    {

        public EMainPage()
        {
            InitializeComponent();
            BindingContext = new EMainViewModel(new DataAccess.DbbContext());
        }


    }

}
