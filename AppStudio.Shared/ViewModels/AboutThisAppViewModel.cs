using System;

using Windows.ApplicationModel;

namespace AppStudio.ViewModels
{
    public class AboutThisAppViewModel
    {
        public string Publisher
        {
            get
            {
                return "PTQPPTM";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Esta Aplicacion nos brinda informacion acerca de peliculas, series, cortometrajes" +
    ", asi tambien como son los estrenos de peliculas, las mejores peliculas, las pel" +
    "iculas que saldran proximamente en cines, etc.  Va orientado para todo tipo de u" +
    "suario.";
            }
        }
    }
}

