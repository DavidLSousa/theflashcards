using CommunityToolkit.Maui.Alerts;
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
        // Isso precisa passar pra view movel e usar o Binding
        bool savedSuccessfully = viewModel.SaveCard(Quest.Text, Resp.Text, Category.Text);

        if (!savedSuccessfully)
        {
            var errorToast = Toast.Make("Erro ao salvar Cards :(");
            errorToast.Show();

            return;
        }

        var successToast = Toast.Make("Salvo com sucesso :)");
        successToast.Show();
    }

}

/*
 [x] Lista de objs json
 [x] Add novo card em um json ja existente
 [x] Fazer a funcionalidade de mostrar resposta no AllCard pages ao clicar no botao
    [x] Verificar erro comentado na linha 60 da AllCardsViewModel.cs
 [x] Criar a pagina e mostrar todos os cards na dela
    [x] Anima��o para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 [x] Criar uma anima��o para mostrar na tela que o card foi criado com sucesso
    // ToastNotification ou displayAlert ?
 [ ] Limpar os campos(quest e resp) para uma novo Card quando for salvo com sucesso;
 [ ] Criar pagina de edi��o para cada categoria, assim como o mostrar todos os cards, mas para mostrar todos cards de uma categoria ou subcategoria e poder apagar e editar
    [ ] Deletar card
    [ ] Editar card
    [ ] Permitir mudar de categoria - Mostrar as categorias possiveis para escolher
 [ ] Criar a pagina simulado, onde vai mostrar uma pergunta por vez e de forma aleatoria
 [ ] Implementar a funcionalidade de caterogia, para salvar na pasta de acordo com a categoria passada
    [ ] A propriedade categora precisa virr uma lista: List<string>
 [x] Add Imagem ao icone do app
 [x] Add Splash Screen
 [ ]

 OBS:
    [ ] AllCardsViewModel - LoadAllCards e UpdateDataCards - "filePath"
        // Salvar de maneira duplicada todos arquivos quando criados, na categoria e em um arquivo "allCards"
            // Vai ser necess�rio atualizar sempre em 2 lugares quando for editado ou deletado um json, como a informa��o estara duplicada em sua categoria e no arquivos com todas as categorias
        
 */