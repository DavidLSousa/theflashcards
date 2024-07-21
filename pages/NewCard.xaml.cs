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
        // Add um try/cacth e caso a viewmodel retorne um erro, deve ser informado que não foi salvo
        viewModel.SaveCard(Quest.Text, Resp.Text, Category.Text);
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
    // ToastNotification ou displayAlert ?
 [ ] Criar pagina de edição para cada categoria, assim como o mostrar todos os cards, mas para mostrar todos cards de uma categoria ou subcategoria e poder apagar e editar
    [ ] Deletar card
    [ ] Editar card
    [ ] Permitir mudar de categoria - Mostrar as categorias possiveis para escolher
 [ ] Criar a pagina simulado, onde vai mostrar uma pergunta por vez e de forma aleatoria
 [ ] Implementar a funcionalidade de caterogia, para salvar na pasta de acordo com a categoria passada
    [ ] A propriedade categora precisa virr uma lista: List<string>
 
 OBS:
    [ ] AllCardsViewModel - LoadAllCards e UpdateDataCards - "filePath"
        // Salvar de maneira duplicada todos arquivos quando criados, na categoria e em um arquivo "allCards"
            // Vai ser necessário atualizar sempre em 2 lugares quando for editado ou deletado um json, como a informação estara duplicada em sua categoria e no arquivos com todas as categorias
        
 */