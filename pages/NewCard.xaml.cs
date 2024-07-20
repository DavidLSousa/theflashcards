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
        Card card = new Card
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
 [x] Fazer a funcionalidade de mostrar resposta no AllCard pages ao clicar no botao
    [x] Verificar erro comentado na linha 60 da AllCardsViewModel.cs
 [x] Criar a pagina e mostrar todos os cards na dela
    [x] Animação para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 [ ] Criar uma animação para mostrar na tela que o card foi criado com sucesso
 [ ] Deletar um card de um json 
 [ ] Criar a pagina simulado, onde vai mostrar uma pergunta por vez e de forma aleatoria
 [ ] Implementar a funcionalidade de caterogia, para salvar na pasta de acordo com a categoria passada
 */