using BrpApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrpApi.Models
{
    public class Persoon
    {
        //Het burgerservicenummer(BSN) wordt in 2007 ingevoerd.Het BSN is een uniek identificerend persoonsnummer dat iedereen krijgt, die ingeschreven staat in de Gemeentelijke basisadministratie en persoonsgegevens(GBA) of de nog te vormen registratie niet-ingezetenen.Getalsmatig is het burgerservicenummer gelijk aan het sociaal-fiscaalnummer(Sofi-nummer), dat wil zeggen dat het ook uit negen cijfers bestaat en dat het voldoet aan de elfproef.Het BSN onderscheidt zich van het Sofi-nummer voor wat het bereik ervan betreft en de wijze waarop wettelijk is vastgelegd wat met behulp van het BSN mag gebeuren.Het BSN zal door(overheid)organisaties gebruikt worden voor de communicatie met de burger en, daar waar dat wettelijk is toegestaan, voor de uitwisseling van persoonsgegevens tussen(overheid)organisaties onderling.
        //BSN                     NUMBER(9,0)         Yes		26	
        public int? Burgerservicenummer { get; set; }

        //Een door DSZW uitgegeven nummer ter identificatie van een subject.
        //SUBJECTNR NUMBER(8,0)         No		1	

        //Een door de Belastingdienst aan een Persoon toegekend identificerend nummer.Het sociaal-fiscaal nummer, bedoeld in artikel 51 van de Wet GBA. Een unieke persoonsaanduiding t.b.v.uitvoering sociale- en belastingwetten.
        //SOFINR NUMBER(9,0)         Yes		2	

        //Het aan een persoon vanwege de minister van Binnenlandse Zaken uniek, aselect en niet-persoonsbeschrijvend nummer dat mede ten behoeve van externe instanties als zoeksleutel gebruikt wordt in de gemeentelijke bevolkingsadministratie.Het administratienummer, bedoeld in artikel 50 van de Wet GBA.
        //ANR                     NUMBER(10,0)        Yes		3	

        //Naam van een Persoon. Meisjesnaam. 
        //De (geslachts)naam waarvan de eventueel aanwezige voorvoegsels en adellijke titel/predikaat zijn afgesplitst.
        //De naam zoals deze op de geboorteakte vermeld staat, zonder voorvoegsel.
        //De naam wordt bepaald aan de hand van de afstamming van een natuurlijk persoon en het geldend nationaal recht. 
        //Bij wijziging van de afstamming of van de eigen nationaliteit kan de geslachtsnaam wijzigen. 
        //Heeft de natuurlijke persoon geen geslachtsnaam, dan gelden de namen als geslachtsnaam. 
        //Is de geslachtsnaam onbekend dan staat op de eerste positie een punt.
        public string Naam { get; set; }

        //Voorvoegsels van een geslachtsnaam. De onlosmakelijk tot de geslachtsnaam behorende gegevens waarmee deze begint.
        public string? Voorvoegsels { get; set; }

        //De verzameling letters, die wordt gevormd door de eerste letter van alle in volgorde voorkomende voornamen.
        //Geen onderdeel Persoonslijst Kernregistratie.Lengte 6 conform IB. 
        // "VOORLETTERS				NVARCHAR2(6 CHAR)	Yes		6
        public string? Voorletters { get; set; }

        //De verzameling van een of meer namen die bij de geboorteaangifte aan een persoon is gegeven, die gescheiden door spatie, voorafgaat aan de geslachtsnaam.
        //VOORNAMEN NVARCHAR2(200 CHAR) Yes		7
        public string? Voornamen { get; set; }

        //Een aanduiding die aangeeft dat of een persoon een man of een vrouw is. 
        //Onbekend geslacht wordt omgezet.Dit gegeven wordt door CBS gebruikt (Kenmerk 2).
        //GESLACHT NUMBER(5,0)         Yes		8	
        public enmGeslacht? Geslacht { get; set; }

        //De datum van de geboorte zoals deze is opgegeven aan de ambtenaar van de Burgerlijke Stand, 
        //of bij vestigen vanuit het buitenland aan de GBA.
        //DTGEBOORTEGBA           VARCHAR2(8 BYTE)    Yes		9	
        public DateTime? DatumGeboorteBevolking { get; set; }

        //Datum waarop een Persoon geboren is. 
        //Dit gegeven wordt door CBS gebruikt(Kenmerk 1). 
        //Als de dag en/of maand van geboorte onbekend is dan wordt resp. 15 en 07 gebruikt.
        //DTGEBOORTE DATE                Yes		10	
        public DateTime? DatumGeboorte { get; set; }

        //De(vermoedelijke) datum van overlijden of de datum van lijkvinding zoals dit is opgegeven aan de ambtenaar van de 
        //Burgerlijke Stand.
        //Indien de dag en/of maand van geboorte onbekend is dan wordt resp. 15 en 07 gebruikt.
        //DTOVERLIJDEN DATE                Yes     11	
        public DateTime? DatumOverlijden { get; set; }


        //Het land waar de geboorte heeft plaatsgevonden.
        //Weergave in codering conform
        //GEBOORTELAND NUMBER(5,0)         Yes		12	
        public int? Geboorteland { get; set; }

        //Het feit dat een persoon het lidmaatschap van een bepaalde staat heeft.
        //Dit gegeven wordt door CBS gebruikt (Kenmerk 6).
        //NATIONALITEIT1 NUMBER(5,0)         Yes		13	
        public int? Nationaliteit1 { get; set; }

        //Het feit dat een persoon nog een lidmaatschap van een bepaalde staat heeft.
        //Tweede nationaliteit.Mag alleen voorkomen als Nationaliteit aanwezig is. 
        //Bij Personen met twee nationaliteiten wordt bij CBS gekeken of 1 van de twee Nederlandse is. 
        //Als dat zo is dan is Nationaliteit CBS Nederlandse.Zoniet dan geldt de eerste Nationaliteit.
        //NATIONALITEIT2 NUMBER(5,0)         Yes		14	
        public int? Nationaliteit2 { get; set; }

        //Aanduiding ter vaststelling van de wijze van naamgebruik zoals deze door de betrokken persoon gewenst is. 
        //Als een persoon de naam van een(ex) partner gebruikt dan is dat hiermee aangegeven.
        //Een aanduiding voor de wijze van aanschrijving van een persoon.
        //NAAMGEBRUIK             NUMBER(5,0)         Yes		15	
        //public string? Naamgebruik { get; set; }

        //De naam van de partner van een persoon inclusief spatie en voorvoegsels.
        //Het gebruik van deze naam wordt bepaald door waarde van Naamgebruik.
        //NAAMPARTNER NVARCHAR2(51 CHAR)  Yes		16	
        //public string? NaamPartner { get; set; }

        //Indicatie die aangeeft of de persoonsgegevens(extra) vertrouwelijk behandeld moeten worden.
        //GEHEIM                  NUMBER(1,0)         No		17	
        public bool Geheim { get; set; }

        //Nummer waarmee een werkgever geidentificeerd kan worden.
        //WERKGEVERSNR VARCHAR2(15 BYTE)   Yes		18	

        //Hiermee wordt aangegeven of een Subject een Klant, Derde of Organisatie.
        //SOORT                   NUMBER(5,0)         No		19	

        //Tijdstip waarop een gegeven wordt vastgelegd.Dit wordt bij het opvoeren, wijzigen en vrijgeven van een gegeven bepaald.
        //DTOPVOER DATE                No      20	
        //
        //Deze datum wordt gevuld als het gegeven wordt overschreven (status wordt -1 of -2) door een ander gegeven.
        //DTAFVOER                DATE Yes		21	
        //
        //Hiermee wordt aangegeven dat een eerder vrijgegeven gegeven niet (meer) bestaat. Technische kolom.
        //GELDIG NUMBER(1,0)         No		22	
        //
        //Geeft de status van het invoerproces van een gegeven weer.
        //STATUS                  NUMBER(1,0)         No		23	
        //
        //UserID van de medewerker die een gegeven opvoert.
        //LOGIN                   VARCHAR2(64 BYTE)   No		24	
        //
        //Technisch nummer dat gebruikt wordt om de perioden binnen een tijdslijn te onderscheiden.
        //Dit nummer komt in unique constraints voor.Als(dtbegin en) dtopvoer onderdeel uitmaken van een primairy key, 
        //dan zijn de overige kolommen van die PK samen met periodenr uniek.
        //PERIODENR NUMBER(9,0)         No		25	

        public string? Aanhef { get; set; }

        public string? Aanschrijfwijze { get; set; }

    }
}
