using CCVProyecto2P2.ViewsModels;
using CCVProyecto2P2.DataAccess;
namespace CCVProyecto2P2.ViewsAdmin;

public partial class AgregarEstudianteView : ContentPage
{

    public AgregarEstudianteView()
    {
        InitializeComponent();
        BindingContext = new EstudianteViewModel(new DbbContext());
    }
}