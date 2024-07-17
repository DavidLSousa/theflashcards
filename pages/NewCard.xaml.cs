using System.Text.Json;
using theflashcards.Model;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    List<Cards> newCards = new List<Cards>();
    NewCardPageViewModel viewModel = new NewCardPageViewModel();
    public NewCard()
    {
        InitializeComponent();
    }
    public async void SaveCard(object sender, EventArgs e)
    {
        Cards card = new Cards();
        card.Quest = Quest.Text;
        card.Resp = Resp.Text;
        card.Category = Category.Text;

        newCards.Add(card);

        // Rever essa List para criação do json, a ideia é criar caso n exista um json no diretorio e caso exista, editar ou add algo nele
        //List<string> newCardJsonSerialized = new List<string>
        //{
        //    JsonSerializer.Serialize(newCard)
        //};

        var options = new JsonSerializerOptions { WriteIndented = true };

        viewModel.SaveCard(card.Category, JsonSerializer.Serialize(newCards, options));
    }

}

/*
 [ ] Lista de objs json
 [ ] Add novo card em um json ja existente
 [ ] Deletar um card de um json 
 [ ] Criar a pagina e mostrar todos os cards na dela
    [ ] Animação para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 */