using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels;

public partial class PageTestViewModel : ObservableObject
{
    private List<string> _categoriesList;
    readonly CardsServices cardsServices = new();

    [ObservableProperty]
    private ObservableCollection<Card> _cardsForTest;

    public List<string> CategoriesList
    {
        get => _categoriesList;
        set
        {
            _categoriesList = value;
            ShowCards();
        }
    }

    private CardsServices cardServices = new();

    public PageTestViewModel()
    {
        CardsForTest = new ObservableCollection<Card>();
    }

    [RelayCommand]
    private async Task ShowCards()
    {
        try
        {
            var cardsForTest = new List<Card>();
            var filePathAllCards = cardServices.GetfilePathFor("allCards");
            var cards = await cardServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            foreach (var card in cards)
            {
                if (CategoriesList.Contains(card.Category))
                {
                    card.IsAnswerVisible = false;
                    cardsForTest.Add(card);
                }
            }

            CardsForTest = new ObservableCollection<Card>(cardsForTest);
        }
        catch (Exception ex)
        {
            await Toast.Make("Erro ao mostrar cards").Show();
        }
    }

    [RelayCommand]
    private async Task ToggleAnswerVisibility(Card card)
    {
        var filePathAllCards = cardServices.GetfilePathFor("allCards");
        var allCards = await cardServices.GetDeserializedFile<List<Card>>(filePathAllCards);

        foreach (var currentCard in allCards)
        {
            if (currentCard.Id == card.Id)
                currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;
        }

        cardServices.SaveSerializedFile(filePathAllCards, allCards);

        var cardsForTest = new List<Card>();
        foreach (var currentCard in allCards)
        {
            if (CategoriesList.Contains(currentCard.Category))
                cardsForTest.Add(currentCard);
        }

        CardsForTest = new ObservableCollection<Card>(cardsForTest);
    }

    [RelayCommand]
    private async Task SelectAnswer((Card card, bool isCorrect) parameters)
    {
        var (card, isCorrect) = parameters;

        if (card == null)
            return;

        try
        {
            // Atualizar a resposta com base na seleção (correto ou errado)
            if (isCorrect)
            {
                card.TestResult.Answer["correct"] = 1;
                card.TestResult.Answer["wrong"] = 0;
            }
            else
            {
                card.TestResult.Answer["correct"] = 0;
                card.TestResult.Answer["wrong"] = 1;
            }

            await cardServices.SaveTestResultsToFile(card.TestResult); 

            // Log para debug
            System.Diagnostics.Debug.WriteLine($"Resultado salvo para o card {card.Id}, Resposta correta: {isCorrect}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao selecionar resposta: {ex.Message}");
        }
    }


    [RelayCommand]
    private async Task SelectDifficulty((Card card, string difficulty) parameters)
    {
        var (card, difficulty) = parameters;

        if (card == null)
        {
            return;
        }

        try
        {
            if (difficulty == "Easy")
            {
                card.TestResult.Difficulty["easy"] = 1;
                card.TestResult.Difficulty["medium"] = 0;
                card.TestResult.Difficulty["difficult"] = 0;
            }
            else if (difficulty == "Medium")
            {
                card.TestResult.Difficulty["easy"] = 0;
                card.TestResult.Difficulty["medium"] = 1;
                card.TestResult.Difficulty["difficult"] = 0;
            }
            else if (difficulty == "Hard")
            {
                card.TestResult.Difficulty["easy"] = 0;
                card.TestResult.Difficulty["medium"] = 0;
                card.TestResult.Difficulty["difficult"] = 1;
            }

            await cardServices.SaveTestResultsToFile(card.TestResult);

            // Log para debug
            System.Diagnostics.Debug.WriteLine($"Dificuldade selecionada para o card {card.Id}: {difficulty}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao selecionar dificuldade: {ex.Message}");
        }
    }


    [RelayCommand]
    private async void SubmitTest()
    {
        try
        {
            var filePathTestResults = cardServices.GetfilePathFor("testResults");
            var filePathAllCards = cardServices.GetfilePathFor("allCards");

            var testResults = await cardServices.GetDeserializedFile<List<TestResult>>(filePathTestResults);
            var cards = await cardServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            if (testResults == null || cards == null)
            {
                System.Diagnostics.Debug.WriteLine("Erro: Arquivos vazios ou inexistentes.");
                return;
            }

            foreach (var testResult in testResults)
            {
                var cardToUpdate = cards.FirstOrDefault(c => c.Id == testResult.Id);

                if (cardToUpdate != null)
                {
                    cardToUpdate.TestResult.Answer["correct"] += testResult.Answer["correct"];
                    cardToUpdate.TestResult.Answer["wrong"] += testResult.Answer["wrong"];
                    cardToUpdate.TestResult.Difficulty["easy"] += testResult.Difficulty["easy"];
                    cardToUpdate.TestResult.Difficulty["medium"] += testResult.Difficulty["medium"];
                    cardToUpdate.TestResult.Difficulty["difficult"] += testResult.Difficulty["difficult"];
                }
            }

            await cardServices.SaveSerializedFile(filePathAllCards, cards);

            cardServices.CleanJsonFile("testResults");

            // Mostrar popup de parabens e volvar para criação do teste(buildtest);
            // 

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao submeter teste: {ex.Message}");
        }
    }
}
