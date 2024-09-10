namespace GrpcService.Converters
{
    public static class CountyConverter
    {
        /// <summary>
        /// Метод конвертации модели стран MSSQL в модель заказов protobuf
        /// </summary>
        /// <param name="country">Модель данных стран</param>
        /// <returns>Модель данных стран protobuf</returns>
        public static CountryReply ToProtobufCountryMsSql(this Dictionary.Models.MSSQL.Country country) 
        {
            return new CountryReply() 
            {
                Alpha2 = country.Alpha2,
                Alpha3 = country.Alpha3,
                ISO = country.ISO,
                FullName = country.FullName,
                InEnglish = country.InEnglish,
                Location = country.Location,
                Name = country.Name,
                PartOfWorld = country.PartOfWorld,
            };
        }

        /// <summary>
        /// Метод конвертации модели стран MongoDB в модель заказов protobuf
        /// </summary>
        /// <param name="country">Модель данных стран</param>
        /// <returns>Модель данных стран protobuf</returns>
        public static CountryReply ToProtobufCountryMongoDb(this Dictionary.Models.MongoDB.Country country)
        {
            return new CountryReply()
            {
                Alpha2 = country.Alpha2,
                Alpha3 = country.Alpha3,
                ISO = country.ISO,
                FullName = country.FullName,
                InEnglish = country.InEnglish,
                Location = country.Location,
                Name = country.Name,
                PartOfWorld = country.PartOfWorld,
            };
        }

    }
}
