using CommunityToolkit.Maui.Alerts;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    readonly NewCardPageViewModel viewModel = new();
    public NewCard()
    {
        InitializeComponent();
    }
    public void SaveCard(object sender, EventArgs e)
    {
        // Isso precisa passar pra view movel e usar o Binding
        var categoryList = new List<string>();
        var currentPathCategory = string.Empty;

        foreach (var currentCategory in Category.Text.Split('/').ToList())
        {
            currentPathCategory = string.IsNullOrEmpty(currentPathCategory) 
                ? currentCategory 
                : $"{currentPathCategory}/{currentCategory}";

            categoryList.Add(currentPathCategory);
        }

        bool savedSuccessfully = viewModel
            .SaveCard(Quest.Text, Resp.Text, categoryList);

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
    [x] Animação para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 [x] Criar uma animação para mostrar na tela que o card foi criado com sucesso
    // ToastNotification ou displayAlert ?
 [x] Implementar a funcionalidade de caterogia, para salvar na pasta de acordo com a categoria passada
    [x] A propriedade categora precisa virr uma lista: List<string>
 [x] Add Imagem ao icone do app
 [x] Add Splash Screen
 [ ] Limpar os campos(quest e resp) para uma novo Card quando for salvo com sucesso;
    [ ] Pode ser um botao ao lado no entry que limpe isso ?
 [ ] Criar pagina de edição para cada categoria, assim como o mostrar todos os cards, mas para mostrar todos cards de uma categoria ou subcategoria e poder apagar e editar
    [ ] Deletar card
    [ ] Editar card
        [ ] Permitir mudar de categoria - Mostrar as categorias possiveis para escolher
 [ ] Criar a pagina simulado, onde vai mostrar uma pergunta por vez e de forma aleatoria
    [x] Mostrar as categorias ja criadas
    [x] As categorias precisam ser salva com todo o seu path
    [ ] Implementar interação com a pagina de botoes
    [ ] Ajustar problema de navegação depagina, não tem botao de voltar
        // Add botão no finla da pagina "Sair do simulado?"
 [ ] Implementar pag de simulado automatico, gerado por uma IA;
 [ ] Satinização dos dados
 [x] Transformar metodo para usar uma generic -> GetDeserializedFile
 [ ] 

 OBS:
    [x] AllCardsViewModel - LoadAllCards e UpdateDataCards - "filePath"
        // Salvar de maneira duplicada todos arquivos quando criados, na categoria e em um arquivo "allCards"
    [ ] Ajustar o cardServices.BuildFilePath, para retornar um obj e não um array
        // Rever o noe da variavel, n é sem categoria e sim sem arquivo json no path
    [ ] Esta sendo mostrando a caterogia teste como categoria valida pra montar o teste, porem da erro pq n foi criado nada dentro de tste, so das suas subcategorias
        // Fazer checagem na hora de mostrar as categorias disponiveis, se existe ou não json naquela pasta
 */