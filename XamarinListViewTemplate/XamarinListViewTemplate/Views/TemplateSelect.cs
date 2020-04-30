using Xamarin.Forms;
using XamarinListViewTemplate.Models;

namespace XamarinListViewTemplate.Views
{
    public class TemplateSelect : DataTemplateSelector
    {
        private readonly DataTemplate Template1;
        private readonly DataTemplate Template2;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            CadastroModel cadastro = item as CadastroModel;
            if (cadastro.Tipo == null)
                return null;
            switch (cadastro.Tipo)
            {
                case "user":
                    return Template1;
                case "created":
                    return Template2;
                default:
                    return null;
            }
        }


        public TemplateSelect()
        {
            Template1 = new DataTemplate(typeof(ListCell1));
            Template2 = new DataTemplate(typeof(ListCell2));
        }
    }
}
