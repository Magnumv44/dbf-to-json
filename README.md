![.NET Framework 4.7.1](https://img.shields.io/badge/.NET%20Framework-4.7-green)

# Конвертер даних з DBF в JSON
Приклад конвертера даних з формату DBF в формат JSON на прикладі [внесення відомостей про лікарняні до ПФУ](https://www.pfu.gov.ua/2155675-yak-zavantazhyty-informatsiyu-pro-likarnyani-sformovani-v-programnomu-zabezpechenni-vedennya-buhgalterskogo-obliku-strahuvalnyka-u-zayavu-rozrahunok-na-vebportali-pensijnogo-fondu-ukrayiny "Натисніть щоб відкрити посилання")

## Використання
За необхідності змінити опис структури майбутьнього JSON файлу в класі [DbfJsonStructure](DbfToJson/DbfToJson/DbfToJson/DbfJsonStructure.cs "Натисніть щоб переглянути код"). Для подальшої обробки та запису даних необхідо знати структуру відного файлу DBF.

## Використані бібліотеки
* [dBASE.NET](https://github.com/henck/dBASE.NET "Натисніть щоб відкрити репозиторій бібліотеки")