using Xamarin.Forms;
using XamarinListViewTemplate.Models;
using XamarinListViewTemplate.Views.CustomCell;

namespace XamarinListViewTemplate.Views
{
    public class TemplateSelect : DataTemplateSelector
    {
        private readonly DataTemplate Template1;
        private readonly DataTemplate Template2;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Personagem personagem = item as Personagem;
            if (personagem == null)
                return null;
            if(personagem.Nome.Length > 12)
            {
                return Template1;
            }
            else
            {
                return Template2;
            }
        }


        public TemplateSelect()
        {
            Template1 = new DataTemplate(typeof(ImageLeftCell));
            Template2 = new DataTemplate(typeof(ImageRightCell));
        }
    }
}
