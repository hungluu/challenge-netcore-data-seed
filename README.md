# Data Seed Generator
-----

## Run datagen

```bash
# datagen.exe --help
datagen.exe <template-file-path> [options...]
    -c, --count           (Default: 10000) Set number of items generated.

    -o, --outdir          Output dir.

    -n, --name            Output file name.

    --help                Display this help screen.

    --version             Display version information.
```

## Composing your template file

Address
```
ZipCode - Get a zipcode.
City - Get a city name.
StreetAddress - Get a street address.
CityPrefix - Get a city prefix.
CitySuffix - Get a city suffix.
StreetName - Get a street name.
BuildingNumber - Get a building number.
StreetSuffix - Get a street suffix.
SecondaryAddress - Get a secondary address like 'Apt. 2' or 'Suite 321'.
County - Get a county.
Country - Get a country.
FullAddress - Get a full address like Street, City, Country.
CountryCode - Get a random ISO 3166-1 country code.
State - Get a random state state.
StateAbbr - Get a state abbreviation.
Latitude - Get a Latitude.
Longitude - Get a Longitude.
Direction - Generates a cardinal or ordinal direction. IE: Northwest, South, SW, E.
CardinalDirection - Generates a cardinal direction. IE: North, South, E, W.
OrdinalDirection - Generates an ordinal direction. IE: Northwest, Southeast, SW, NE.
```

Commerce
```
Department - Get a random commerce department.
Price - Get a random product price.
Categories - Get random product categories.
ProductName - Get a random product name.
Color - Get a random color.
Product - Get a random product.
ProductAdjective - Random product adjective.
ProductMaterial - Random product material.
Ean8 - Get a random EAN-8 barcode number.
Ean13 - Get a random EAN-13 barcode number.
CompanySuffix - Get a company suffix. "Inc" and "LLC" etc.
CompanyName - Get a company name.
CompanyCatchPhrase - Get a company catch phrase.
CompanyBs - Get a company BS phrase.
```

System
```
Column - Generates a column name.
DataType - Generates a column type.
Collation - Generates a collation.
DatabaseEngine - Generates a storage engine.
FileName - Get a random file name.
DirectoryPath - Get a random directory path (Unix).
FilePath - Get a random file path (Unix).
MimeType - Get a random mime type
CommonFileType - Returns a commonly used file type.
CommonFileExt - Returns a commonly used file extension.
FileType - Returns any file type available as mime-type.
FileExt - Gets a random extension for the given mime type.
Semver - Get a random semver version string.
Version - Get a random Version.
Exception - Get a random Exception with a fake stack trace.
AndroidId - Get a random GCM registration ID.
ApplePushToken - Get a random Apple Push Token
BlackBerryPin - Get a random BlackBerry Device PIN
Number - Get an random number.
Number(max) - Get an random number from 0 to max.
Number(min, max) - Get an random number from min to max.
Digits(length) - Get a random sequence of digits.
Even - Returns a random even number.
Even(min) - Returns a random even number from min.
Even(min, max) - Returns a random even number from min to max.
Odd - Returns a random odd number.
Odd(min) - Returns a random odd number from min.
Odd(min, max) - Returns a random odd number from min to max.
Double - Get a random double, between 0.0 and 1.0.
Double(min) - Get a random double, between min and 1.0.
Double(min, max) - Get a random double, between min and max.
Decimal - Get a random decimal, between 0.0 and 1.0.
Decimal(min) - Get a random decimal, between min and 1.0.
Decimal(min, max) - Get a random decimal, between min and max.
Float - Get a random float, between 0.0 and 1.0.
Float(min) - Get a random float, between min and 1.0.
Float(min, max) - Get a random float, between min and max.
Int - Generate a random int.
Int(min) - Generate a random int from MinValue.
Int(min, max) - Generate a random int between MinValue and MaxValue.
Long - Generate a random long between MinValue and MaxValue.
Char - Generate a random char.
String - Get a string.
String(length) - Get a string of characters of a specific length.
Hash - Return a random hex hash. Default 40 characters, aka SHA-1.
Hash(length) - Return a random hex hash of a specific length.
Bool - Get a random boolean.
Guid - Get a random GUID.
Uuid - Get a random GUID. Alias for Randomizer.Guid().
RandomLocale - Returns a random locale.
AlphaNumeric(length) - Returns a random set of alpha numeric characters 0-9, a-z.
Hexadecimal - Generates a random hexadecimal string.
Hexadecimal(length) - Generates a random hexadecimal string of a specific length. 
Word - Get a single word or phrase.
Words - Get some random words and phrases.
Words(count) - Get a number of some random words and phrases.
ArrayElement(value1, value2, ...) - Get a random array element.
ArrayElements(value1, value2, ...) - Get a random subset of an array.
```

## Will be supported in the future

Date
Past - Get a DateTime in the past between refDate and yearsToGoBack.
Soon - Get a DateTime that will happen soon.
Future - Get a DateTime in the future between refDate and yearsToGoForward.
Between - Get a random DateTime between start and end.
Recent - Get a random DateTime within the last few days.
Timespan - Get a random TimeSpan.
Month - Get a random month
Weekday - Get a random weekday

Finance
Account - Get an account number. Default length is 8 digits.
AccountName - Get an account name. Like "savings", "checking", "Home Loan" etc..
Amount - Get a random amount. Default 0 - 1000.
TransactionType - Get a transaction type: "deposit", "withdrawal", "payment", or "invoice".
Currency - Get a random currency.
CreditCardNumber - Generate a random credit card number with valid Luhn checksum.
CreditCardCvv - Generate a credit card CVV
BitcoinAddress - Generates a random Bitcoin address.
EthereumAddress - Generate a random Ethereum address.
RoutingNumber - Generates an ABA routing number with valid check digit.
Bic - Generates Bank Identifier Code (BIC) code.
Iban - Generates an International Bank Account Number (IBAN).

Hacker
Abbreviation - Returns an abbreviation.
Adjective - Returns a adjective.
Noun - Returns a noun.
Verb - Returns a verb.
IngVerb - Returns a verb ending with -ing.
Phrase - Returns a phrase.

Images
DataUri - Get a SVG data URI image with a specific width and height.
PicsumUrl - Get an image from the https://picsum.photos service.
LoremFlickrUrl - Get an image from https://loremflickr.com service.
LoremPixelUrl - Creates an image URL with http://lorempixel.com. Note: This service is slow. Consider using PicsumUrl() as a faster alternative.
Abstract - Gets an abstract looking image.
Animals - Gets an image of an animal.
Business - Gets a business looking image.
Cats - Gets a picture of a cat.
City - Gets a city looking image.
Food - Gets an image of food.
Nightlife - Gets an image with city looking nightlife.
Fashion - Gets an image in the fashion category.
People - Gets an image of humans.
Nature - Gets an image of nature.
Sports - Gets an image related to sports.
Technics - Get a technology related image.
Transport - Get a transportation related image.

Internet
Avatar - Generates a legit Internet URL avatar from twitter accounts.
Email - Generates an email address.
ExampleEmail - Generates an example email with @example.com.
UserName - Generates user names.
DomainName - Generates a random domain name.
DomainWord - Generates a domain word used for domain names.
DomainSuffix - Generates a domain name suffix like .com, .net, .org
Ip - Gets a random IP address.
Ipv6 - Generates a random IPv6 address.
UserAgent - Generates a random user agent.
Mac - Gets a random mac address.
Password - Generates a random password.
Color - Gets a random aesthetically pleasing color near the base RGB. See here.
Protocol - Returns a random protocol. HTTP or HTTPS.
Url - Generates a random URL.
UrlWithPath - Get a random URL with random path.

Lorem
Word - Get a random lorem word.
Words - Get some lorem words
Letter - Get a character letter.
Sentence - Get a random sentence of specific number of words.
Sentences - Get some sentences.
Paragraph - Get a paragraph.
Paragraphs - Get a specified number of paragraphs.
Text - Get random text on a random lorem methods.
Lines - Get lines of lorem.
Slug - Slugify lorem words.

Name
FirstName - Get a first name. Getting a gender specific name is only supported on locales that support it.
LastName - Get a last name. Getting a gender specific name is only supported on locales that support it.
FullName - Get a full name, concatenation of calling FirstName and LastName.
Prefix - Gets a random prefix for a name.
Suffix - Gets a random suffix for a name.
FindName - Gets a full name.
JobTitle - Gets a random job title.
JobDescriptor - Get a job description.
JobArea - Get a job area expertise.
JobType - Get a type of job.

Phone
PhoneNumber - Get a phone number.
PhoneNumberFormat - Gets a phone number based on the locale's phone_number.formats[] array index.

Rant
Review - Generates a random user review.
Reviews - Generate an array of random reviews.


Vehicle
Vin - Generate a vehicle identification number (VIN).
Manufacturer - Get a vehicle manufacture name. IE: Toyota, Ford, Porsche.
Model - Get a vehicle model. IE: Camry, Civic, Accord.
Type - Get a vehicle type. IE: Minivan, SUV, Sedan.
Fuel - Get a vehicle fuel type. IE: Electric, Gasoline, Diesel.