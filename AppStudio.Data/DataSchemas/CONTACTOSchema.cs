using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the CONTACTOSchema class.
    /// </summary>
    public class CONTACTOSchema : BindableSchemaBase, IEquatable<CONTACTOSchema>, ISyncItem<CONTACTOSchema>
    {
        private string _nOMBRE;
        private string _aPLICACION;
        private string _aUTOR;
        private string _sITIOWEB;
        private string _eMAIL;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string NOMBRE
        {
            get { return _nOMBRE; }
            set { SetProperty(ref _nOMBRE, value); }
        }
 
        public string APLICACION
        {
            get { return _aPLICACION; }
            set { SetProperty(ref _aPLICACION, value); }
        }
 
        public string AUTOR
        {
            get { return _aUTOR; }
            set { SetProperty(ref _aUTOR, value); }
        }
 
        public string SITIOWEB
        {
            get { return _sITIOWEB; }
            set { SetProperty(ref _sITIOWEB, value); }
        }
 
        public string EMAIL
        {
            get { return _eMAIL; }
            set { SetProperty(ref _eMAIL, value); }
        }

        public override string DefaultTitle
        {
            get { return NOMBRE; }
        }

        public override string DefaultSummary
        {
            get { return AUTOR; }
        }

        public override string DefaultImageUrl
        {
            get { return APLICACION; }
        }

        public override string DefaultContent
        {
            get { return AUTOR; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "nombre":
                        return String.Format("{0}", NOMBRE); 
                    case "aplicacion":
                        return String.Format("{0}", APLICACION); 
                    case "autor":
                        return String.Format("{0}", AUTOR); 
                    case "sitioweb":
                        return String.Format("{0}", SITIOWEB); 
                    case "email":
                        return String.Format("{0}", EMAIL); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(CONTACTOSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(CONTACTOSchema other)
        {

            return this.Id == other.Id && (this.NOMBRE != other.NOMBRE || this.APLICACION != other.APLICACION || this.AUTOR != other.AUTOR || this.SITIOWEB != other.SITIOWEB || this.EMAIL != other.EMAIL);
        }

        public void Sync(CONTACTOSchema other)
        {
            this.NOMBRE = other.NOMBRE;
            this.APLICACION = other.APLICACION;
            this.AUTOR = other.AUTOR;
            this.SITIOWEB = other.SITIOWEB;
            this.EMAIL = other.EMAIL;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CONTACTOSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
