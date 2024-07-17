using System.Text.Json;
using theflashcards.Model;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    NewCardPageViewModel viewModel = new NewCardPageViewModel();
    public NewCard()
    {
        InitializeComponent();
    }
    public void SaveCard(object sender, EventArgs e)
    {
        Cards card = new Cards();
        card.Quest = Quest.Text;
        card.Resp = Resp.Text;
        card.Category = Category.Text;

        viewModel.SaveCard(card.Category, card);
    }

}

/*
 [ ] Lista de objs json
 [ ] Add novo card em um json ja existente
 [ ] Deletar um card de um json 
 [ ] Criar a pagina e mostrar todos os cards na dela
    [ ] Anima��o para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 */