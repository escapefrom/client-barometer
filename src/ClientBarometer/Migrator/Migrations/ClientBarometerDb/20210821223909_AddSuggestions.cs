﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientBarometer.Migrator.Migrations.ClientBarometerDb
{
    public partial class AddSuggestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "users",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "messages",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "chats",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "barometer_values",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.CreateTable(
                name: "objection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ObjectionClass = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Example = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objection", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "objection",
                columns: new[] { "Id", "Example", "ObjectionClass" },
                values: new object[,]
                {
                    { new Guid("a94ef784-975e-4e85-9f91-2e85564b0f4b"), "не вижу интереса в этом продукте", "Нам это просто не интересно" },
                    { new Guid("21d3ae8d-339d-4ed6-97b8-268e557a3f9e"), "мы не видим в этом ничего интересного", "Нам это просто не интересно" },
                    { new Guid("254480a6-d4df-4e5c-9ebb-f656b4fb372f"), "ничего интересного в этом не видим", "Нам это просто не интересно" },
                    { new Guid("13d9e22c-37d0-42dc-806b-08b5c44ccea4"), "не видим в этом ничего интересного", "Нам это просто не интересно" },
                    { new Guid("7e82c5f6-2b52-4698-b746-77245644b978"), "ваше предложение просто не интересно", "Нам это просто не интересно" },
                    { new Guid("3cd956d6-6503-4b37-9062-ac872c938805"), "просто не интересно не нужно ", "Нам это просто не интересно" },
                    { new Guid("440ffda2-1323-4e3f-8cea-0b88e0b40593"), "нам ничего не надо у нас все есть", "Нам ничего не надо" },
                    { new Guid("02a1eb65-01ba-43a4-b66f-de68e38bc23c"), "нам это не надо ", "Нам ничего не надо" },
                    { new Guid("fbc22cab-f216-4d58-92f5-4af8293fdf49"), "нам ничего не надо", "Нам ничего не надо" },
                    { new Guid("87db950c-b587-47bc-96a0-a14a6ce4a1fc"), "нам ничего не нужно у нас все нормально", "Нам ничего не надо" },
                    { new Guid("920e9318-2020-4ec4-a711-112bd0ff362b"), "нам ничего не нужно у нас все есть", "Нам ничего не надо" },
                    { new Guid("894a288d-f37d-4059-b3e6-30db3cf6076d"), "не надо спасибо", "Нам ничего не надо" },
                    { new Guid("838f8037-a04e-40cf-a983-c117e858cd78"), "ничего не надо", "Нам ничего не надо" },
                    { new Guid("d9ebbe38-fa7f-4c5c-952e-0448b1132201"), "ничего не надо все и так хорошо", "Нам ничего не надо" },
                    { new Guid("8aa55f93-475d-4f6b-9924-d2a57db00019"), "все и так хорошо ничего не надо", "Нам ничего не надо" },
                    { new Guid("3e13806b-ec0a-47f4-926e-c4a829277fd5"), "мы ничего не хотим", "Нам ничего не надо" },
                    { new Guid("4e2ef30c-abf1-45c0-b3fe-d0f9b61a5add"), "не хотим ничего вообще все есть", "Нам ничего не надо" },
                    { new Guid("320b73fa-1a69-4155-b5f7-a537db238865"), "у нас все есть ничего не надо", "Нам ничего не надо" },
                    { new Guid("22cfe005-5a63-4c25-afc6-c02481d5c9ae"), "ничего нам не нужно", "Нам ничего не надо" },
                    { new Guid("e0e544dc-441b-4d71-b30c-8dd2e5bb7290"), "нет спасибо ничего не нужно", "Нам ничего не надо" },
                    { new Guid("593b41d9-0ce5-4c42-b2c1-5b5ecbaa0786"), "не заинтересован", "Нам это просто не интересно" },
                    { new Guid("3ed60516-5fd8-4b6d-9c9d-70890b67a8ba"), "спасибо у нас все уже есть не надо ничего", "Нам ничего не надо" },
                    { new Guid("ceaf1f5a-79bf-47fa-9a83-b3ecde21a688"), "простите, не заинтересовало", "Нам это просто не интересно" },
                    { new Guid("7c5a8990-cb51-4e14-b0c8-1cdcaf602fb3"), "нам не интересно это изучать", "Нам это просто не интересно" },
                    { new Guid("307404bb-6711-4fab-8113-9829d7c5e3f2"), "некому заниматься", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("549836ff-0cfd-4d56-ad10-e9164cb0f346"), "никто не будет это делать нет человека", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("ba6941eb-6612-4574-ae6d-6efdee828269"), "не хватает специалиста по этим делам", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("c9957b40-fa33-44d3-bf0d-1c400c0123e3"), "нет специалиста никакого", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("cd12072a-bcca-4162-8bf4-fece7d28d4f0"), "некому этим заняться", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("80c84c4c-3296-4c23-81fb-3d45924405cb"), "заняться некому этим всем", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("31b2b8cc-370b-4fc0-9497-ae8d5f447f48"), "не могу соединить вас с руководством", "Не могу соединить / Запрещено соединять" },
                    { new Guid("363e220e-01fd-4cf7-a0f4-cf656ba03de8"), "у нас нельзя соединять", "Не могу соединить / Запрещено соединять" },
                    { new Guid("ea03ef37-c0c8-49ac-8779-abe3aa67df18"), "не могу вас с ним соединить прямо сейчас никак не могу вас соединить", "Не могу соединить / Запрещено соединять" },
                    { new Guid("4320835a-7273-4719-a2f8-999f6aa7e89a"), "никак не могу просто никак нельзя вот так вот", "Не могу соединить / Запрещено соединять" },
                    { new Guid("26774709-769a-45b7-8055-413c96877ecb"), "нельзя соединять с руководством с начальством", "Не могу соединить / Запрещено соединять" },
                    { new Guid("13c7b5ff-b6a1-44e3-9d7f-5bb4797451b5"), "мы не можем соединить вас с руководствам", "Не могу соединить / Запрещено соединять" },
                    { new Guid("9e1006dd-63b2-41ed-bd75-d643d05f7b2e"), "не вижу интереса в этом продукте", "Нам это просто не интересно" },
                    { new Guid("cedc8a65-48b1-403c-bda3-51a623295b03"), "не интересно", "Нам это просто не интересно" },
                    { new Guid("0ff03430-1f5b-460b-a093-bfa59c039bd6"), "не вижу ничего интересного ", "Нам это просто не интересно" },
                    { new Guid("3b35eda5-ae72-4dba-8540-487e44adb88d"), "ваш продукт нам не интересен", "Нам это просто не интересно" },
                    { new Guid("12c6bf50-b2e0-4a90-adf0-0260e2ef07a7"), "не интересно предложение в принципе", "Нам это просто не интересно" },
                    { new Guid("53d02873-ed99-4b73-8124-f16124b86233"), "не понимаю, как это может быть интересно", "Нам это просто не интересно" },
                    { new Guid("5d433b5b-e366-4ca0-a418-6990bae44e3f"), "мне не интересно", "Нам это просто не интересно" },
                    { new Guid("cf971ecf-4ff9-4e69-ad09-9b0652d22e59"), "мы не заинтересованы в этом", "Нам это просто не интересно" },
                    { new Guid("4472b9e3-6ce7-4150-aaa8-44f4425275c0"), "нет не надо ничего все есть", "Нам ничего не надо" },
                    { new Guid("5cc219b0-4b4a-4c5a-9468-95dfce3dafaa"), "у нас как-то все есть ничего не надо", "Нам ничего не надо" },
                    { new Guid("6046d6db-9ccf-410e-993c-53f9addbc9d8"), "у нас все есть", "У нас все есть" },
                    { new Guid("a5a092a9-7b67-467b-8d11-cfb77d613297"), "мне нужно подумать я подумаю ", "Я подумаю/мне нужно подумать" },
                    { new Guid("3c9047cd-de67-4289-8f30-471ff483c0bb"), "отвечу позднее потом отвечу не могу сейчас ответить", "Я подумаю/мне нужно подумать" },
                    { new Guid("b5b242e9-4fbc-4ab0-b697-e27fd0f9313d"), "отвечу потом ", "Я подумаю/мне нужно подумать" },
                    { new Guid("6d46f7ed-8777-4821-b431-349a997426db"), "подумаю и отвечу нужно подумать нужно обмозговать", "Я подумаю/мне нужно подумать" },
                    { new Guid("9543bb22-aa98-47c6-90d2-467bb8cb3ef9"), "я подумаю нужно покумекать посообразить", "Я подумаю/мне нужно подумать" },
                    { new Guid("cc6dbddf-0064-4e86-b79f-6d0e1b4382df"), "подумаю и отвечу потом", "Я подумаю/мне нужно подумать" },
                    { new Guid("c3410d18-adc6-4a1a-a969-fa35e544c29e"), "обдумаю и отвечу обдумать думать подумать надо", "Я подумаю/мне нужно подумать" },
                    { new Guid("2834b29f-48a9-4b12-842d-e319ec9b004a"), "пришлите подробную информацию", "Пришлите КП/подробные материалы" },
                    { new Guid("6a0a4372-a480-45cf-8cf2-409e3d400c4d"), "подробные материалы вышлите инфо на почту", "Пришлите КП/подробные материалы" },
                    { new Guid("7f28ce87-9317-4d2a-ae95-005ee310790d"), "вышлите кп на почту в письме информацию ", "Пришлите КП/подробные материалы" },
                    { new Guid("23cf4c1f-993e-41d8-b0aa-c9c8417883f4"), "нужны подробные материалы дополнительные ", "Пришлите КП/подробные материалы" },
                    { new Guid("e4962975-cbdc-421b-be84-3008fd1d2450"), "прошу вас выслать подробные материалы пришлите кп", "Пришлите КП/подробные материалы" },
                    { new Guid("6ef68959-1a0e-4891-a3fd-d9fa4c7cd4f0"), "у нас нет столько денег на проект нет денег", "Нет денег" },
                    { new Guid("b7019c0a-a035-47e4-ba66-16deba9d4a5d"), "высокая стоимость не потянем нет денег", "Нет денег" },
                    { new Guid("ece3eb68-78e9-4708-8b96-a641e737f56b"), "нет денег слишком дорого", "Нет денег" },
                    { new Guid("2d9b08be-50fd-4b02-84a7-c38a9bd8aa91"), "оплачу позднее не готов оплатить сейчас думаю подождет", "Отказ оплачивать счет" },
                    { new Guid("ff414620-badf-4dce-a1b3-4a5cd32150e9"), "отказ оплачивать счет отказываюсь оплачивать счет пока", "Отказ оплачивать счет" },
                    { new Guid("a64dd1d0-6570-4695-b5ba-efcabc3a801c"), "я отказываюсь оплачивать потому что", "Отказ оплачивать счет" },
                    { new Guid("e5c212fc-9f40-4794-8a56-0e259778b344"), "оплачу потом позднее не готов", "Отказ оплачивать счет" },
                    { new Guid("1e3919eb-d205-4ccc-b7c1-937ebb007a5a"), "не нужно сейчас никак не купим в данный момент", "Сейчас не актуально" },
                    { new Guid("cce678d5-d4bb-4e0a-9cb4-8bd568804ad2"), "не актуально в данный момент", "Сейчас не актуально" },
                    { new Guid("60fff39b-84a5-415e-aa8a-595dbd833667"), "сейчас не актуально", "Сейчас не актуально" },
                    { new Guid("3189399b-15a6-4bb0-9105-a5300ec1297a"), "в данный момент не актуально", "Сейчас не актуально" },
                    { new Guid("6cfa5490-9683-4e9c-9db2-6a378aff28e7"), "у нас и так все есть", "У нас все есть" },
                    { new Guid("1db1f1e5-3907-4cb3-b57d-82bda3008bfb"), "у нас и так все нормально", "У нас все есть" },
                    { new Guid("7479e3cf-380f-456e-b3ab-dd41fd6670da"), "у нас все ок", "У нас все есть" },
                    { new Guid("b0778d0e-529f-4d10-985a-698742d8cfe7"), "все и так хорошо", "У нас все есть" },
                    { new Guid("ecca9dab-a202-4954-aac3-ae414503ff9c"), "и так все есть все хорошо спасибо", "У нас все есть" },
                    { new Guid("de7a019a-1196-45dd-95df-0e65e36ab048"), "все хорошо ничего не надо", "У нас все есть" },
                    { new Guid("0ef1dc84-9fb8-45b0-956e-e1054058db93"), "все уже установлено все на месте", "У нас все есть" },
                    { new Guid("88caea33-2346-4af2-a1eb-c831d5806073"), "все есть спасибо все ок не надо ничего", "У нас все есть" },
                    { new Guid("3531a036-9181-48d9-8c74-7be3d964313c"), "слишком дорого для нас", "Дорого" },
                    { new Guid("1070115c-ccfb-456c-9d51-eda3af550cdb"), "нет специалиста никакого никого знающих людей нет", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("f7a31882-5c01-44fa-9b5a-0132afc6b2ed"), "накладно для нас дорого", "Дорого" },
                    { new Guid("798ac972-7117-4c92-9b20-d23cebb91ff7"), "цена не устраивает дорого слишком", "Дорого" },
                    { new Guid("09a2a2dc-3bf1-422d-b6b6-4b259533fd2e"), "слишком большие расходы", "Дорого" },
                    { new Guid("7932a9e1-6b5f-43a4-bf67-ec2e0ba6a4b6"), "не устраивает цена", "Дорого" },
                    { new Guid("f13a5785-30b7-4372-b3a4-8fd270811780"), "у нас нет таких денег не можем позволить себе", "Дорого" },
                    { new Guid("9cf1c6b9-e24b-4162-a67f-a1ed21f41d6f"), "слишком накладно ", "Дорого" },
                    { new Guid("75352109-67d7-4719-84f6-c30d63028656"), "для нас это сейчас не нужно сейчас не актуально", "Сейчас не актуально" },
                    { new Guid("263a6ea1-b1e0-44d2-affc-7735c2f6f3d3"), "сейчас не подходит ", "Сейчас не актуально" },
                    { new Guid("a6198065-c708-4383-8a70-6219536f1e4b"), "сейчас другие проблемы у нас", "Сейчас не актуально" },
                    { new Guid("5fc94f37-3177-4292-bd03-048006200ec9"), "сейчас другие задачи сейчас не в рассмотрении", "Сейчас не актуально" },
                    { new Guid("4d08dc0a-b340-4d40-a9df-b8cdcfe0222f"), "не потянем по цене", "Дорого" },
                    { new Guid("0833c549-ac54-48b0-a30e-aa6a43694d51"), "работали с вами, не понравилось", "Работали с вами, не понравилось" },
                    { new Guid("b46b8c13-d5fe-41bc-a561-b7787e992900"), "некому этим заниматься никто не сможет", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("84f96cd1-b080-4e30-8faa-ec38d92f8a53"), "не знаю кто будет этим заниматься", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("e5e978f2-6e3b-4dc5-b0fa-5f6de7025798"), "мы уже приняли о работе с другими", "Мы работаем с другими" },
                    { new Guid("f7849754-7797-4f3c-a9b1-2c369ab915e0"), "другие участники рынка нам более интересны", "Мы работаем с другими" },
                    { new Guid("6624b674-4808-49d4-86ea-93d496f5f16d"), "уже пользуемся чужими продуктами", "Мы работаем с другими" },
                    { new Guid("ea9dd76b-4f47-45eb-8aa0-6b1621f346f9"), "уже пользуемся иными продуктами", "Мы работаем с другими" },
                    { new Guid("3c8d1788-23dc-444a-b204-42c07402013e"), "уже пользуемся продуктами других подрядчиков", "Мы работаем с другими" },
                    { new Guid("15024061-7e3f-408a-93c6-bd3b2c7a00db"), "другие поставщики уже работают с нами", "Мы работаем с другими" },
                    { new Guid("c065c561-2141-4e2c-9b13-bc3e798626e5"), "у нас этим занимаются другие люди", "Мы работаем с другими" },
                    { new Guid("f69e003c-c684-467d-bece-d0514e34e414"), "другие люди уже покрыли это ", "Мы работаем с другими" },
                    { new Guid("51b78a1e-0e71-42d1-9ff3-3ac52b8d0267"), "у нас это организовано с другим подрядчиком", "Мы работаем с другими" },
                    { new Guid("b22679f1-618e-45b2-b53d-85d1ff8dc267"), "у нас и так все есть", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("6bc8e464-3655-4b12-84eb-a1fbd01e60bd"), "у нас и так все нормально", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("d64d9338-a3f2-4e0f-9f72-f933b20b5bea"), "у нас все ок", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("d793b7ce-de1a-4dd1-8046-9ef97d63cc4b"), "нам ничего не нужно у нас все нормально", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("22105d06-03d2-4d47-bb64-5238811fcc26"), "нам ничего не нужно у нас все есть", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("c8d2b75a-c38e-41ec-a81d-bac1107d64ed"), "все и так хорошо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("cf3498dc-9851-4800-8616-2e010bd59c92"), "ничего не надо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("fa541b8f-6312-472e-b07a-1b846e867394"), "ничего не надо все и так хорошо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("668fccd7-80af-4cbb-9b5e-f83f0bff6b77"), "все и так хорошо ничего не надо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("a815e784-1318-4808-afef-20a0ea79f016"), "мы ничего не хотим", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("d461bbe6-4841-4082-b48b-17b9b763180f"), "у нас есть решение от другого вендора", "Мы работаем с другими" },
                    { new Guid("caa56efb-c1f4-4be5-8d6f-b8655cf20e75"), "не хотим ничего вообще все есть", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("194ac67a-289a-41e2-a2ed-cae713d3d97a"), "мы пользуемся продуктами другой компании", "Мы работаем с другими" },
                    { new Guid("cc5b3fbc-562d-4089-9b27-bd22ac84659e"), "мы уже пользуемся продуктами ваших конкурентов", "Мы работаем с другими" },
                    { new Guid("d36b45dd-f0bd-4ab5-80ac-a27e682d7cda"), "не интересно", "Нам это просто не интересно" },
                    { new Guid("6337e2fa-6b65-4a2f-a531-a9d7b5bf4674"), "не вижу ничего интересного ", "Нам это просто не интересно" },
                    { new Guid("c05be846-4108-4743-b166-60d75b231789"), "ваш продукт нам не интересен", "Нам это просто не интересно" },
                    { new Guid("3d1c4a75-28f5-4819-b312-c0d468adf47f"), "не интересно предложение в принципе", "Нам это просто не интересно" },
                    { new Guid("d1312b77-edfe-4427-aec5-2339ff6f5f25"), "не понимаю, как это может быть интересно", "Нам это просто не интересно" },
                    { new Guid("d390742e-6d7e-478f-8607-1adb6e6b2df8"), "мне не интересно", "Нам это просто не интересно" },
                    { new Guid("fe98431c-8988-46fc-967a-fb167dddf1aa"), "нам не интересно это изучать", "Нам это просто не интересно" },
                    { new Guid("b2f2fd51-ae11-4e6c-96ae-d8de063f712f"), "мы не заинтересованы в этом", "Нам это просто не интересно" },
                    { new Guid("1a24f9a1-03d9-4b3f-8e45-9ac89463076b"), "простите, не заинтересовало", "Нам это просто не интересно" },
                    { new Guid("d0163ea8-4967-4c6b-b1fb-dd17712a0f50"), "не заинтересован", "Нам это просто не интересно" },
                    { new Guid("3044c2b5-9842-4699-89f2-d42db3f12f3a"), "мы не видим в этом ничего интересного", "Нам это просто не интересно" },
                    { new Guid("cb1d919f-68c4-4964-b6cc-217a9c65d264"), "ничего интересного в этом не видим", "Нам это просто не интересно" },
                    { new Guid("05ea21d4-aedf-4e20-9a6c-1b79ceacf52e"), "не видим в этом ничего интересного", "Нам это просто не интересно" },
                    { new Guid("3eeee876-6c20-4edf-b340-a6ed035388fa"), "ваше предложение просто не интересно", "Нам это просто не интересно" },
                    { new Guid("0de6fb13-0ba0-4105-8e77-c19f8efd6ea1"), "просто не интересно", "Нам это просто не интересно" },
                    { new Guid("248e20b5-63f9-44e9-b16c-183bf46af040"), "у нас другой поставщик услуг", "Мы работаем с другими" },
                    { new Guid("865b5a4f-591a-47d6-b9aa-f7de0e05f37d"), "у нас другой подрядчик", "Мы работаем с другими" },
                    { new Guid("8c858d4b-5d21-4699-8c58-b6e562da6b3f"), "мы пользуемся другим продуктов", "Мы работаем с другими" },
                    { new Guid("bcb11196-37c8-4091-bc91-30049681bce1"), "нам больше нравится другой товар", "Мы работаем с другими" },
                    { new Guid("2736b274-c053-4c71-8dbf-ac2e3d0189f3"), "мы уже пользуемся конкурирующими продуктами", "Мы работаем с другими" },
                    { new Guid("c1ff923c-a3b3-41e1-ba89-04e7589c30a0"), "у нас все есть ничего не надо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("26b53578-3afb-4ca8-9baa-47f3a4ffda28"), "ничего нам не нужно", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("0eb78aa1-c293-4dc0-9261-e703c34c9301"), "нет спасибо ничего не нужно", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("0e54150c-6d9c-4a18-8ad2-b9df3b123ce8"), "я вам сам наберу", "Сам перезвонит" },
                    { new Guid("f0cb62ab-96a4-456a-b43a-ba27f827666b"), "сам наберу", "Сам перезвонит" },
                    { new Guid("efe950b3-2346-43b1-a675-8372fe51a7eb"), "давайте я перезвоню позднее", "Сам перезвонит" },
                    { new Guid("418f0482-8bf8-46f2-ad27-0fdc2de66dd3"), "он вам перезвонит", "Сам перезвонит" },
                    { new Guid("4dc09388-3316-4c7a-8aa9-1f18213c573f"), "он хочет перезвонить вам позднее", "Сам перезвонит" },
                    { new Guid("fac8464a-0121-4193-b519-f301bf63aa87"), "он позднее наберет вам сам", "Сам перезвонит" },
                    { new Guid("7eadf3d9-647c-4b67-bfb7-a05a13e29045"), "позднее наберу вам", "Сам перезвонит" },
                    { new Guid("97d76d20-45e3-48b6-97ac-ed612a5ace07"), "позднее наберем", "Сам перезвонит" },
                    { new Guid("6badcbc5-0508-4434-af92-592d25e87cb2"), "позднее наберет", "Сам перезвонит" },
                    { new Guid("923f85b9-4a68-40c4-9acf-271e7845d1ba"), "наберу позже наберу потом после завтра как-нибудь потом", "Сам перезвонит" },
                    { new Guid("2662de16-bd2e-4c35-9b90-29708e4297fd"), "хочу позвонить вам позднее", "Сам перезвонит" },
                    { new Guid("fa3e9bce-42be-4cc2-b88d-d151577de6e9"), "позвоню вам потом после позднее как-нибудь", "Сам перезвонит" },
                    { new Guid("7843860f-8147-4f6c-86ab-93697a602613"), "у нас нет того кто этим занимается", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("ca9688d4-7ac9-45c7-89aa-a4cb775e787f"), "у нас нет специалиста не наняли никого кто разбирается не понимаем ничего в этом этим не занимаемся не разбираемся", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("df7baf06-2c12-4737-ac15-2d88ea7a2ad4"), "мы это никогда не делали не понимаем как делать ничего не делали никак не знаем", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("436a493d-65b3-4245-9953-2c144cda6f17"), "нет человека кто этим занимается непонятно кто это будет делать", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("e0d45f62-c605-4063-acb0-bacb3c32e9ae"), "никто это делать не будет", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("2f7756d4-5c85-47fb-b973-1782dd66f27a"), "нет никого кто будет это делать непонятно нет специалистов", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("55cd57b8-7fae-42e5-b6b8-a6b3aebe5c3a"), "нет таких людей нет обученного персонала ", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("8205a980-dda2-4573-a021-ab5236ee9c52"), "хочу вам позднее перезвонить", "Сам перезвонит" },
                    { new Guid("b7df3ffd-66d8-42ff-b286-149dcbcfc642"), "я перезвоню вам сам", "Сам перезвонит" },
                    { new Guid("057f8553-80e4-4634-b998-da082788de49"), "на почтовый ящик вышлите информацию", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("f0a0e1cf-cec2-4d9a-9c87-d3828958baa1"), "мне нужна информация на моем почтовом ящике", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("5352cda9-a859-457f-bbc5-d86831d00982"), "спасибо у нас все уже есть не надо ничего", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("e6f421fe-bf38-4b51-b1de-0413e97388fc"), "нет не надо ничего все есть", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("56564325-bf05-49d2-9e09-acb65e032881"), "у нас как-то все есть ничего не надо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("5924bc51-6cab-4291-ab09-e130d53c4b27"), "как-то вышло что все есть не надо спасибо", "Нам ничего не нужно/ у нас все есть" },
                    { new Guid("235f5277-ec07-41c4-affe-6b4746959fbf"), "пришлите пожалуйста информацию", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("ed233c31-99c8-4f10-90d6-99c1058d6755"), "свяжитесь пожалуйста со мной по скайпу", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("2dc408ae-6033-41cd-9133-a3471e006027"), "свяжитесь по почте", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("d7999237-07d0-4805-aabd-63b86c33289e"), "пришлите свое кп", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("ff75340f-fe76-4251-b6a6-1b54dbd3d5a4"), "пришлите информацию на емейл", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("c0050de7-7a9d-46ae-a522-ba406426238b"), "никто не будет этим заниматься", "Я этим не занимаюсь / У нас нет человека, кто бы этим занимался" },
                    { new Guid("a77764ea-6658-4a34-8fbf-9a90f3ef17aa"), "перешлите информацию", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("1257e7f4-2eba-415a-83eb-b152215cc250"), "пришлите информацию сейчас", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("4b40019d-cd06-4b15-ba4b-c5570c21fcc4"), "хочу чтобы вы прислали информацию в письме", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("6f110aa4-64b6-4d5a-80ab-31da364a496c"), "хочу получить от вас письмо с информацией", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("791e30ae-5b20-4dbf-8d08-c582a6940e9e"), "мне нужно получить от вас информацию по почте", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("9000e898-40d7-46a4-8814-998058018662"), "хочу видеть от вас письмо", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("628e7aa1-a684-47ee-8617-c4c406e5018a"), "пришлите кп на мою почту", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("ee1902d8-c883-4b16-a402-f2fc891ffc15"), "вышлите информацию на почту в письме", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("5388506b-579d-4881-9c6d-5c03b80c7d94"), "вышлите кп на почту в письме", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("5b7f7088-6286-4bb6-bebf-9383a3a1cdbd"), "в письме на почту вышлите информацию", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("2fa120f2-fe75-489d-8f6a-e8d9d10c4cae"), "свяжитесь по скайпу", "Пришлите информацию new Objection{ ObjectionClass = скайп, КП, эл.почту}" },
                    { new Guid("0bc78ef0-e486-4568-8d78-492bd159d56c"), "с вами работали раньше ранее не понравилось в прошлом уже было не хотим возвращаться", "Работали с вами, не понравилось" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_objection_Id",
                table: "objection",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objection");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "users",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "messages",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "chats",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "barometer_values",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
        }
    }
}
