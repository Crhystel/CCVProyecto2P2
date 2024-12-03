

using CCVProyecto2P2.ViewsModels;

namespace CCVProyecto2P2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new DataAccess.DBContext());
        }


    }

}
