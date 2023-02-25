namespace OpenBootcamp.Models.DataModels
{
    public class JwtSettings
    {
        /*

        La clase JwtSettings representa un conjunto de configuraciones utilizadas para validar tokens de autenticación JSON Web Token (JWT). Un JWT es un estándar de autenticación de la web que permite la transferencia segura de información entre dos partes en forma de objeto JSON.

        La clase JwtSettings tiene las siguientes propiedades:

        ValidateIssuerSigningKey: Un valor booleano que indica si se debe validar la clave del emisor (issuer) del token.

        IssuerSigningKey: Una cadena que contiene la clave secreta utilizada para firmar y verificar el token.

        ValidateIssuer: Un valor booleano que indica si se debe validar el emisor (issuer) del token.

        ValidIssuer: Una cadena que contiene el nombre del emisor (issuer) válido del token.

        ValidateAudience: Un valor booleano que indica si se debe validar la audiencia del token.

        ValidAudience: Una cadena que contiene el nombre de la audiencia válida del token.

        RequireExpirationTime: Un valor booleano que indica si se debe requerir un tiempo de expiración en el token.

        ValidateLifetime: Un valor booleano que indica si se debe validar el tiempo de vida del token.

        Las propiedades tienen valores predeterminados y pueden ser configuradas mediante un archivo de configuración o directamente en el código. Estas configuraciones son importantes para garantizar que los tokens de autenticación sean válidos y seguros.*/

        public bool ValidateIssuerSigningKey { get; set; }
        public string? IssuerSigningKey { get; set; } = string.Empty;

        public bool ValidateIssuer { get; set; }
        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }

        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifetime { get; set; } = true;

    }
}
