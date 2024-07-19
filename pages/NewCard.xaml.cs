using theflashcards.Model;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    readonly NewCardPageViewModel viewModel = new NewCardPageViewModel();
    public NewCard()
    {
        InitializeComponent();
    }
    public void SaveCard(object sender, EventArgs e)
    {
        // Esse obj deveria ser instanciado e montado ja na viewModel?
        Cards card = new Cards
        {
            Quest = Quest.Text,
            Resp = Resp.Text,
            Category = Category.Text
        };

        viewModel.SaveCard(card.Category, card);
    }

}

/*
 [x] Lista de objs json
 [x] Add novo card em um json ja existente
 [ ] Deletar um card de um json 
 [ ] Fazer a funcionalidade de mostrar resposta no AllCard pages ao clicar no botao
 [ ] Criar uma animação para mostrar na tela que o card foi criado com sucesso
 [ ] Criar a pagina e mostrar todos os cards na dela
    [ ] Animação para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 */