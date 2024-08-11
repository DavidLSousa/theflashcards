#if ANDROID
using Android.Content;
using Uri = Android.Net.Uri;
using Android.App;

namespace theflashcards.Platforms.Android
{
    public class AndroidPermissions
    {
        const string TreeUriPreferenceKey = "TreeUri";

        public bool CheckDirectoryAccess()
        {
            // Recupera o URI salvo
            string treeUriString = Preferences.Get(TreeUriPreferenceKey, null);

            if (!string.IsNullOrEmpty(treeUriString))
            {
                Uri treeUri = Uri.Parse(treeUriString);

                var persistedUriPermissions = Platform.CurrentActivity.ContentResolver.PersistedUriPermissions;
                bool hasAccess = persistedUriPermissions.Any(uriPermission =>
                    uriPermission.Uri.Equals(treeUri) &&
                    uriPermission.IsWritePermission);

                if (hasAccess)
                {
                    return true; 
                }
                else
                {
                    RequestDirectoryAccess();
                    return false; 
                }
            }
            else
            {
                RequestDirectoryAccess();
                return false;
            }
        }

        void RequestDirectoryAccess()
        {
            Intent intent = new Intent(Intent.ActionOpenDocumentTree);
            intent.AddFlags(ActivityFlags.GrantPersistableUriPermission);
            Platform.CurrentActivity.StartActivityForResult(intent, 1);
        }

        //Método para armazenar o URI persistente quando o acesso é concedido
        public void HandleActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 1 && resultCode == Result.Ok)
            {
                Uri treeUri = data.Data;

                var takeFlags = data.Flags & (ActivityFlags.GrantReadUriPermission | ActivityFlags.GrantWriteUriPermission);
                Platform.CurrentActivity.ContentResolver.TakePersistableUriPermission(treeUri, takeFlags);

                // Salva o URI de forma persistente
                Preferences.Set(TreeUriPreferenceKey, treeUri.ToString());
            }
        }
    }
}
#endif
