using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Club = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Spiker" },
                    { 2, "Setter" },
                    { 3, "Libero" },
                    { 4, "Opposite" },
                    { 5, "Center" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Birthday", "Club", "Description", "Height", "ImageLink", "Name", "PositionId", "Weight" },
                values: new object[,]
                {
                    { 1, "1992.05.03", "FATUM Nyíregyháza", "Nikola Radosová (born 3 May 1992) is a Slovak female volleyball player. She is part of the Slovakia women's national volleyball team. She competed at the 2019 Women's European Volleyball Championship.", 1.8600000000000001, "https://t.aimg.sk/magaziny/jQg6qSKSS-6QkmTfMGAKDg~Volejbalistka-Nikola-Radosov.jpg?t=LzB4ODU6MTA2N3g2ODUvZml0LWluLzE2MDB4OTAw&h=Wga6PqMq3hI4_zELe2x9rA&e=2145916800&v=3", "Nikola Radosová", 4, 66 },
                    { 2, "1983.03.21", "1. MCM-Diamant", "Tanja Matic több száz szerb élvonalbeli mérkőzéssel a háta mögött, a patinás Szpartak Szabadka korábbi csapatkapitányaként 2015 nyarán érkezett hazánkba, és előbb két éven át játszott Békéscsabán, majd két szezont húzott le Nyíregyházán. A csabaiakkal mindent megnyert, amit csak itthon lehetett: a bajnokságban és a Magyar Kupában is két-két elsőséggel gazdagodott, emellett egy Közép-európai Liga elsőséget is begyűjtött. A nyíregyháziakkal két alkalommal hódította el a Magyar Kupa-trófeát, és 2018-ban, illetve 2019-ben is bejutott a bajnokság döntőjébe, ahol végül ezüstéremmel zárt. A tapasztalt röplabdázó ezek után, pályafutásának újabb állomásaként Kaposvárt választotta, így újra együtt dolgozhatott korábbi edzőjével, Sasa Nedeljkoviccsal. A 2019/2020-as évadban elért eredményekre mindenki büszke lehet, de mivel az ismert okok miatt váratlanul félbeszakadt, majd véget is ért a pontvadászat, mindenki kettőzött erővel szeretne majd újra munkába állni", 179.0, "https://1mcmvolley.hu/wp-content/uploads/2020/09//2019.10.24-2.jpg", "Tanja Matic", 4, 57 },
                    { 3, "1983.06.30", "Barueri", "Katarzyna Ewa Skowrońska-Dolata egykori lengyel röplabdázó, a lengyel női röplabda-válogatott és az olasz Foppapedretti Bergamo klub tagja, kettős Európa-bajnok, olasz, török, kínai és azeri nemzeti bajnokság aranyérmese.", 188.0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBrypz5TGmd6zLI19niR_UwuO_uYOKmBbRxg&usqp=CAU", "Katarzyna Skowrońska-Dolata", 4, 75 },
                    { 4, "1984.05.14", "KPS Chemik Police", "Anna Werblińska lengyel röplabdázó, a lengyel női röplabda-válogatott tagja 2006–2016-ban, a Pekingi Olimpiai Játékok résztvevője, a 2009-es Európa-bajnokság bronzérmese és négyszeres lengyel bajnok.", 1.78, "https://upload.wikimedia.org/wikipedia/commons/6/68/Anna_Werbli%C5%84ska_%2812194794495%29.jpg", "Anna Werblińska", 4, 69 },
                    { 5, "1986.02.20", "KPS Chemik Police", "Agnieszka Bednarek-Kasza lengyel röplabdázó, a lengyel női röplabda-válogatott és a lengyel KPS Chemik Police klub tagja, a Peking 2008 olimpiai játékok résztvevője, a 2009-es Európa-bajnokság bronzérmese, Lengyel bajnok.", 1.8500000000000001, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Bednarek-Pekin_2008.jpg/800px-Bednarek-Pekin_2008.jpg", "Agnieszka Bednarek-Kasza", 2, 69 },
                    { 6, "1978.10.25", "MKS Dąbrowa Górnicza", "Eleonora Dziękiewicz lengyel röplabdázó, a lengyel női röplabda-válogatott és a lengyel Tauron MKS Dąbrowa Górnicza klub tagja, a 2009-es Európa-bajnokság bronzérmese, háromszoros lengyel bajnok", 1.8500000000000001, "https://dl.siatkarskaliga.pl/68831/inline/scalecrop=400x800/9c119d/Eleonora-Dziekiewicz.jpg", "Eleonora Dziękiewicz", 2, 78 },
                    { 7, "1979.01.10", "Futura Volley Busto Arsizio", "Francesca Piccinini olasz röplabdázó, aki négyszer képviselte Olaszországot a nyári olimpián. Tagja volt a női válogatottnak, amely aranyérmet nyert a 2002-es németországi világbajnokságon. 1995. június 10-én debütált Olaszországban az Egyesült Államok ellen.", 1.8400000000000001, "https://i.ytimg.com/vi/LjRmWzwz-nk/hqdefault.jpg", "Francesca Piccinini", 4, 62 },
                    { 8, "1983.12.31", "Osasco Audax", "Jaqueline Maria Pereira de Carvalho Endres brazil röplabdázó, a brazil csapat tagja, amely megnyerte az olimpiai játékokat Pekingben 2008 és London 2012-ben", 1.8600000000000001, "https://alchetron.com/cdn/jaqueline-carvalho-12811a8c-5f68-4099-8345-7d8a58f65dd-resize-750.jpeg", "Jaqueline Carvalho", 4, 70 },
                    { 9, "1995.03.03", "Leningradka Saint-Petersburg", "Yelyzaveta Samadova-Ruban ukrán születésű azerbajdzsáni röplabdázó, aki jelenleg az olasz Pallavolo Scandicci és az azerbajdzsáni női röplabda-válogatottban játszik külső spikerként.", 1.8500000000000001, "https://s21466.pcdn.co/wp-content/uploads/2018/10/YelyzavetaSamadovaofAzerbaijanspikesthebal-e1539604875126.jpg", "Yelyzaveta Samadova", 4, 71 },
                    { 10, "1987.06.22", "Beshiktas", "Eda Erdem Dündar török ​​röplabdázó. 190 cm magas, és középső blokkolóként játszik. Erdem tömbmagassága 302 cm, tüske magassága 308 cm. Jelenleg a Fenerbahçe SK csapatában játszik, és mind a klub, mind a török ​​röplabda -válogatott kapitánya", 1.8799999999999999, "https://i.ytimg.com/vi/EU3075haQeA/maxresdefault.jpg", "Eda Erdem Dündar", 5, 73 },
                    { 11, "1998.02.19.", "UCLA", "Jamie Robbins is one of the most beautiful volleyball players. She plays on the UCLA volleyball team. Her position is an outside hitter. Although we can’t consider her as a professional volleyball player, she is pretty popular with over 120k Instagram followers. ", 1.8500000000000001, "https://i1.wp.com/tstreetvolleyball.com/wp-content/uploads/2019/05/web-18-Shawn-Robbins-Jaime-8-HL5A8412-118-250x350.jpg?fit=250%2C350&ssl=1", "Jamie Robbins", 4, 61 },
                    { 12, "1999.07.07", "Vakıfbank Istanbul", "Zehra Güneş török ​​röplabdázó. 1,97 m magas, 88 kg, középső blokkoló pozícióban játszik. Jelenleg a Vakıfbank Istanbul csapatában játszik, és a török ​​női röplabda-válogatott tagja.", 1.97, "https://s.yimg.com/ny/api/res/1.2/rzzeYSjj.dK9f9Sj_JHBnQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTIwMDA7aD0xMzMz/https://s.yimg.com/os/creatr-uploaded-images/2021-08/beb34af0-f434-11eb-bd5d-8a19df83047c", "Zehra Güneş", 2, 88 },
                    { 13, "1998.03.30", "HAOK Mladost Zagreb", "Klara Perić horvát röplabdázó. Szetterként játszik a horvát HAOK Mladost klubban.", 1.8500000000000001, "https://cdn.nwmgroups.hu/s/img/i/2201//20220105klara-peric-roplabda.jpg", "Klara Perić", 4, 71 },
                    { 14, "1998.11.25", "Grot Budowlani Łódź", "Maria Stenzel lengyel röplabdázó. A lengyel női röplabda -válogatott tagja. Részt vett a 2015 -ös FIVB röplabda lányok U18 -as világbajnokságán, a 2017 -es FIVB röplabda női U20 -as világbajnokságon és a 2018 -as FIVB röplabda Női Nemzetek Ligájában. Klubszinten a Grot Budowlani Łódź csapatában játszott.", 167.0, "https://ocdn.eu/pulscms-transforms/1/yqXk9kqTURBXy8yYWQxYWVjMzQ2MWQ5OTkxZjE3YmNmMjFhMjFlYjhkMC5qcGVnk5UDAcyBzQu3zQaWkwmmZTk5N2EyBpMFzQSwzQJ2gaEwAQ/maria-stenzel.jpg", "Maria Stenzel", 4, 63 },
                    { 15, "1987.07.30", "Olympiakos CFP", "Mariana Andrade Costa, más néven Mari Paraíba brazil női röplabdázó. A brazíliai női röplabda-válogatott tagja. Klubszinten az Osasco Voleibol Clube, az EC Pinheiros és a Minas Tênis Clube csapatában játszott. Jelenleg az Olympiakos CFP-nél játszik", 1.8100000000000001, "https://i.redd.it/smql3twwyxf61.jpg", "Mariana Costa", 3, 75 },
                    { 16, "1994.11.22", "Fenerbahçe", "Mariana Andrade Costa, más néven Mari Paraíba brazil női röplabdázó. A brazíliai női röplabda-válogatott tagja. Klubszinten az Osasco Voleibol Clube, az EC Pinheiros és a Minas Tênis Clube csapatában játszott. Jelenleg az Olympiakos CFP-nél játszik", 1.8799999999999999, "https://www.ilawjournals.com/wp-content/uploads/2021/07/Samantha-Bricio.jpg", "Samantha Bricio", 5, 58 },
                    { 17, "1995.01.06", "Telekom Baku", "Winifer María Fernández Pérez (born 6 January 1995) is a Dominican female volleyball player. With her club Mirador she competed at the 2015 FIVB Club World Championship. She became well known after a video and later some photos of her playing and training, and personal photos of her--some of them fake--went viral in July 2016. ", 1.6899999999999999, "https://www.ilawjournals.com/wp-content/uploads/2021/07/Samantha-Bricio.jpg", "Winifer Fernández", 2, 62 },
                    { 18, "1989.06.01", "ROC", "Nataliya Olegovna Goncharova, 2012 és 2016 között Obmochaeva, orosz női röplabdázó. 2010 -ig az ukrán női röplabda -válogatottban játszott, amikor az orosz női röplabda -válogatott tagja lett.", 1.8899999999999999, "https://worldofvolley.com/wp-content/uploads/2021/05/unnamed-file-12921.jpg", "Nataliya Goncharova", 4, 75 },
                    { 19, "1994.09.23", "Lokomotiv Kaliningrad", "Louisa-Christin Lippmann német női röplabdázó. Külső ütőként vagy ellentétesen játszik, és több mint 100 alkalommal szerepel a német női röplabda-válogatottban. Klubszinten jelenleg a Kalinyingrádi Lokomotiv csapatában játszik.", 1.9099999999999999, "https://i.pinimg.com/736x/5c/2a/29/5c2a2996ce6e78d5d97245411c15caef.jpg", "Louisa Lippmann", 4, 74 },
                    { 20, "1995.08.13", "Bayamón", "Vilmarie Mojica Puerto Rico-i röplabdázó, aki a női válogatott csapatkapitánya volt a 2008-as japán olimpiai kvalifikációs tornán. Ott a csapat a nyolcadik és az utolsó helyen végzett, miután vadkártyát kapott az eseményre, miután Peru és Kenya visszalépett.", 1.8, "https://volleybox.net/media/upload/players/1430051555SFXh6.jpg", "Vilmarie Mojica", 1, 63 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
