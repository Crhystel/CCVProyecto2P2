using CCVProyecto2P2.ViewsModels;

namespace CCVProyecto2P2.ViewsProfesor;

public partial class PMainPage : ContentPage
{
    public PMainPage()
    {
        InitializeComponent();
        BindingContext = new PMainViewModel(new DataAccess.DbbContext());
    }
}