using System.Text.Json;
using theflashcards.Model;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    public NewCard()
    {
        InitializeComponent();
    }
    public async void SaveCard(object sender, EventArgs e)
    {

        Cards newCard = new Cards();

        newCard.Quest = Quest.Text;
        newCard.Resp = Resp.Text;
        newCard.Category = Category.Text;

        // Rever essa List para criação do json, a ideia é criar caso n exista um json no diretorio e caso exista, editar ou add algo nele
        //List<string> newCardJsonSerialized = new List<string>
        //{
        //    JsonSerializer.Serialize(newCard)
        //};

        string rootDir = GetRootDirSpecificPlataform();

        if (!Directory.Exists(rootDir))
        {
            Directory.CreateDirectory(rootDir);
        }

        string filePath = Path.Combine(rootDir, "dataCards.json");

        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(newCard));

    }

    private string GetRootDirSpecificPlataform()
    {
        string folderPath;
#if ANDROID
        folderPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
#elif WINDOWS
        folderPath = @"C:\";
#else
        throw new PlatformNotSupportedException("Plataforma não suportada.");
#endif
        string appSpecificPath = Path.Combine(folderPath, "theflashcards");

        System.Diagnostics.Debug.WriteLine($"Root directory path: {appSpecificPath}");

        return appSpecificPath;
    }

}

/*
 [ ] Lista de objs json
 [ ] Add novo card em um json ja existente
 [ ] Deletar um card de um json 
 [ ] Criar a pagina e mostrar todos os cards na dela
    [ ] Animação para mostrar a pergunta e ao clicar em cima aparecer a resp como um popup 
 */