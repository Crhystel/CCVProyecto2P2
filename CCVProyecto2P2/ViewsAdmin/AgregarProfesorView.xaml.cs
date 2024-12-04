using CCVProyecto2P2.DataAccess;
using CCVProyecto2P2.ViewsModels;

namespace CCVProyecto2P2.ViewsAdmin;

public partial class AgregarProfesorView : ContentPage
{
    public AgregarProfesorView()
    {
        InitializeComponent();
        BindingContext = new ProfesorViewModel(new DbbContext());
    }
}