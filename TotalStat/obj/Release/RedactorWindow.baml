   M S B A M L   `   `   `  ���� D  @TotalStat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TotalStat	TotalStat      TotalStat.RedactorWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:TotalStat       � Title$  RedactorWindow��$	��520��$	��400��
 � Top ��  �� Path$/ )(local:AppSizeGeometry.RedactorWindowTop)� �� Mode$ TwoWay=� � Left �� $0 *(local:AppSizeGeometry.RedactorWindowLeft)�$ TwoWay=�.���� .@��� ����  �� Orientation$ 
Horizontal=�.+�A� $��10��$��10��
���   ��� $��3q�Data��� $��3,5,3,3q� � RowDefinitions �� $��* ��� $��0.55* ��� $��0.07* � � ColumnDefinitions �� $
��0.8* ��� �� .+��� $��3��$��0��$��3��$��Center=�.@��� .���� $ 
Horizontal=�.+��� $��Статус: ��$��4,0,8,0q�$��10(�$��Italic$��� -    ��Name$ CurrentStatusBar��$��10(�$��Italic$�$	��250������ *	StatusBar+� $��0��$��0��	 � ShowGridLines	 .  �� �� $
��0.3* �.+��� $��0��
���   �$��2,3,3,3q����� $��
Файлы��$
��Bold"�.���� -   
 ��Name$
 SelectedItems_ListBox������ $ ChoosenFiles� �� SelectedItem �� *SelectedFile+$ TwoWay=����� .R��� ���� *Name+� $��1��	 . $��48��$��2q�$	��Top=� �� ��  �� $��* �.+��� -    ��Name$ DataAddFileButton��$��0������ *DataFileDialogCommand+{��� *DataButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�Добавить � ToolTip$! Добавить файлы���� -   $ DataRemoveFileButton��$��1������ *DataRemoveCommand+{��� *DataButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\delete.png��$��17���� $
��Bold"�Удалить$ Удалить файлы��� $��1��$��2�� �� $	��25* ��� $	��27* ��� $	��99* ��� $	��91* � �� �� �� $
��0.5* ��� .+��� $��0��$��0��$��4��$��2��.+��� $��0��$��0��$��4��$��Center=�$��15(�$��1q�$
��Bold"�-+Обновление DATA из файлов�� $��10(�$��Oblique$�$��5,0,0,0q�$��Center=�(Раздел в FAQ 2.1)�� -   $ DataRefreshButton��$��1��$��0��$��2��$��65��$��65��$
��Left=�$��Center=�$
��Bold"�$��12(�$��	4,10,5,10q����� *DataRefreshCommand+{��� *DataButtonsIsEnable+$ TwoWay=�.���� $ Vertical=�.+��� $
��Bold"�Обновить�� $��Image\refresh.png��$��35��$( "Обновить из списка���� $��1��$��1��$��2��$��3��$��Center=�$
��Left=�$ Vertical=�$��5q�$��60��.+��� $��18��$��Center=�$��Right=�$.��(Последнее обновление:��$��Oblique$�$��2,5,0,2q��� $ 
Horizontal=�$��Right=�$��2,0,3,1q�$��25��.+��� -   $ DataLastRefreshTextBlock��$��1��$��2��$��2��$��2��$��Center=� �� TextAlignment$ Right=�$��18��$��90��$��2,2,4,2q�$
��Bold"����� *
LastUpdate+�� $��1��$��3��$��2��$��20��$��20������ *DataLastDateRefresh+{��� *DataButtonsIsEnable+$ TwoWay=�.���� .+��� $��Image\refresh.png��$��35���� $��3��$��0��$��4��$��Center=�$��
6,20,10,15q�$��43��$��Center=�.+��� $��12(�$
��Bold"�$ Center=�Удалить день:�� $ 
Horizontal=�.+��� 
День�� -    ��Name$ DataDeleteDateDay��$��20��$��23��$��2q����� *DataDeleteDateDay+$ OneWayToSource=��� 
Месяц�� -   $ DataDeleteDateMonth��$��20��$��23��$��2q����� *DataDeleteDateMonth+$ OneWayToSource=��� Год�� -	   $ DataDeleteDateYear��$��20��$��40��$��2q����� *DataDeleteDateYear+$ OneWayToSource=��� -
   $ DataDeleteDateButton��$��20��$��3,0,0,0q����� *DataDeleteDateCommand+{��� *DataButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\delete.png���� $
��Bold"�Удалить$> 8Удалить указанный день из базы��� $��1��$��3�� �� $
��0.2* ��� .+��� $��0��$��Center=�$��15(�$��0,0,0,5q�$
��Bold"�/-Обновление DATA из вставки�� $��1��$ 
Horizontal=�.+��� -   $ DataAddDataTextBox��$	��100��$	��250��$��15,5,5,5q� �� AcceptsReturn . $��Disabled=�$
��Auto=����� *DataAddDataTextBox+$ OneWayToSource=�.�� �� .+��� 86Ticker Open Close Nite NitePercent ImbNY ImbEX PremVol�� ПРИМЕР:�� ,*BLL 41.88 41.65 -0.23 -0.55 700 -6500 1339�� BTZ 12.39 12.39 0 0 1200 0 0.���� -   $ DataAddDataButton��$��55��$��70��$��
8,20,20,20q����� *DataAddDataCommand+{��� *DataButtonsIsEnable+$ TwoWay=�.���� $ Vertical=�.+��� $
��Bold"�Добавить�� $��Image\add.png��$��35��$3 -Добавить дату за сегодня���� ���� $ 
Horizontal=�.+�A� $��10��$��10��
���   ��� $��3q�
Stock Info���� $��3��$��0��$��3��$��3,20,3,3q�.+��� $��Center=�$��15(�$
��Bold"� Информация с Finviz�� �� $
��Left=�$��Bottom=�$
��Bold"�$��Normal$�$��11(�$��40,5,5,0q�$ ��Выберите файл:���� $ 
Horizontal=�$��5q�.+��� -   $ FinvizFilePath��$	��230��$��Right=� �� TextAlignment$ Justify=�$��	10, 0,0,0q����� *FinvizFilePath+$ TwoWay=��� -   $ FinvizAddFile��$	��...��$��20��$
��Left=����� *FinvizFileDialogCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�$! Добавить файлы���� -   $ FinvizRefreshButton��$��60��$��20��$��20,0,0,0q����� *FinvizRefreshCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\refresh.png���� $
��Bold"�Обновить$; 5Обновить из выбранного файла���� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.2.1�� $��	5,15,5,15q��� $��Center=�$��15(�$
��Bold"�!Род деятельности�� $
��Left=�$��Bottom=�$
��Bold"�$��Normal$�$��11(�$��40,5,5,0q�$ ��Выберите файл:���� $ 
Horizontal=�$��5q�.+��� -   $ AboutFilePath��$	��230��$��Right=�$ Justify=�$��10,0,0,0q����� *AboutFilePath+$ TwoWay=��� -   $ AboutAddFile��$	��...��$��20��$
��Left=����� *AboutFileDialogCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�$! Добавить файлы���� -   $ AboutRefreshButton��$��60��$��20��$��20,0,0,0q����� *AboutRefreshCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\refresh.png���� $
��Bold"�Обновить$; 5Обновить из выбранного файла���� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.2.2�� $��	5,15,5,10q��� $��Center=�$��15(�$��0,0,0,5q�$
��Bold"�Сектора�� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.2.3�� $ 
Horizontal=�$��0,0,0,5q�.+��� -   $ SectorAddSectorTextBox��$	��140��$	��230��$��	20,5,5,10q� . $��Disabled=�$
��Auto=����� *SectorAddSectorTextBox+$ OneWayToSource=�.�� �� .+��� Ticker MarketCap Sector�� ПРИМЕР:�� BAC 314.83 Divirsified Banks�� (&MSFT 1280.7 Business Software Services.���� $ Vertical=�$	��110��$��5,5,3,3q�.+��� -   $ SectorAddFirstLevelButton��$!��Первый уровень��$��30��$��5��$��0,3,0,3q�$
��Bold"����� *SectorAddFirstSectorCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�$4 .Обновляет сектор 1 уровня���� -   $  SectorAddSecondLevelButton��$!��Второй уровень��$��30��$��40��$��0,3,0,3q�$
��Bold"����� *SectorAddSecondSectorCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�$4 .Обновляет сектор 2 уровня���� -   $ SectorAddThirdLevelButton��$!��Третий уровень��$��30��$��40��$��0,3,0,3q�$
��Bold"����� *SectorAddThirdSectorCommand+{��� *InfoButtonsIsEnable+$ TwoWay=�$4 .Обновляет сектор 3 уровня���� ���� $ 
Horizontal=�.+�A� $��10��$��10��
���   ��� $��3q�	Reports���� $��3��$��0��$��3��$��3,10,3,3q�.+��� $��Center=�$��15(�$
��Bold"�75Обновление репортов из файла�� $
��Left=�$��Bottom=�$
��Bold"�$��Normal$�$��11(�$��40,5,5,0q�$ ��Выберите файл:���� $ 
Horizontal=�$��5q�.+��� -   $ ReportFilePath��$	��220��$��Right=�$ Justify=�$��15,0,0,0q����� *ReportFilePath+$ TwoWay=��� -   $ ReportAddFile��$	��...��$��20��$
��Left=����� *ReportFileDialogCommand+{��� *ReportButtonsIsEnable+$ TwoWay=�$! Добавить файлы���� -   $ ReportRefreshButton��$��60��$��20��$��20,0,0,0q����� *ReportRefreshCommand+{��� *ReportButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\refresh.png���� $
��Bold"�Обновить$J DОбновить репорты из выбранного файла���� $��10(�$��Oblique$�$��5,0,0,0q�_]Формат файла должен быть YYYY.MM.DD.txt(например 2018.12.26.txt)�� $��10(�$��Oblique$�$��5,0,0,0q�CAРазделителем BMO и AMC служит слово After�� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.3.1�� $��	5,10,5,10q��� $��Center=�$��15(�$��0,0,0,10q�$
��Bold"�;9Обновление репортов из вставки�� $ 
Horizontal=�.+��� -   $ ReportAddReportTextBox��$��95��$	��200��$��15,5,5,5q� . $��Disabled=�$
��Auto=����� *ReportAddReportTextBox+$ OneWayToSource=�.�� �� .+��� Ticker�� ПРИМЕР:�� BAC�� LEN�� After�� MSFT.���� $ Vertical=�.+��� -   $$ ReportAddYesterdayReportButton��$��25��$	��120��$��8,5,5,5q�$
��Bold"����� *!ReportAddYesterdayReportCommand+{��� *ReportButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�
Вчера$5 /Добавить репорты за вчера���� -   $  ReportAddTodayReportButton��$��25��$��40��$��8,5,5,5q�$
��Bold"����� *ReportAddTodayReportCommand+{��� *ReportButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�Сегодня$9 3Добавить репорты за сегодня���� -   $# ReportAddTomorrowReportButton��$��25��$��40��$��8,5,5,5q�$
��Bold"����� * ReportAddTomorrowReportCommand+{��� *ReportButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�Завтра$7 1Добавить репорты за завтра���� $��10(�$��Oblique$�$��5,0,0,0q�CAРазделителем BMO и AMC служит слово After�� $��10(�$��Oblique$�$��5,0,0,0q�zxДля пятницы завтра = понедельник, для понедельника вчера = пятница�� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.3.2�� $��	5,10,5,10q��� $��Center=�$��15(�$��0,0,0,10q�$
��Bold"�Удаление даты�� $ 
Horizontal=�$��Center=�.+��� 
День�� -   $ ReportDeleteDateDay��$��20��$��23��$��3q����� *ReportDeleteDateDay+$ OneWayToSource=��� 
Месяц�� -   $ ReportDeleteDateMonth��$��20��$��23��$��3q����� *ReportDeleteDateMonth+$ OneWayToSource=��� Год�� -    $ ReportDeleteDateYear��$��20��$��40��$��3q����� *ReportDeleteDateYear+$ OneWayToSource=��� -!   $ ReportDeleteDateButton��$��20��$��8,0,0,0q�$
��Bold"����� *ReportDeleteDateCommand+{��� *ReportButtonsIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\delete.png���� $
��Bold"�Удалить$> 8Удалить указанный день из базы���� ���� $ 
Horizontal=�.+�A� $��10��$��10��
���   ��� $��3q�	Dividends���� $��5��$��0��$��3��$��3,10,3,3q�.+��� $��Center=�$��15(�$
��Bold"�;9Обновление дивидендов из файла�� $
��Left=�$��Bottom=�$
��Bold"�$��Oblique$�$��11(�$��40,5,5,0q�$ ��Выберите файл:���� $ 
Horizontal=�$��5q�.+��� -"   $ DividendFilePath��$	��220��$��Right=�$ Justify=�$��	15, 0,0,0q����� *DividendFilePath+$ TwoWay=��� -#   $ DividendAddFile��$	��...��$��20��$
��Left=����� *DividendFileDialogCommand+{��� *DividendButtonIsEnable+$ TwoWay=�$! Добавить файлы���� -$   $ DividendRefreshButton��$��60��$��20��$��20,0,0,0q����� *DividendRefreshCommand+{��� *DividendButtonIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\refresh.png���� $
��Bold"�Обновить$N HОбновить дивиденды из выбранного файла���� $��10(�$��Oblique$�$��5,0,0,0q�_]Формат файла должен быть YYYY.MM.DD.txt(например 2018.12.26.txt)�� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.4.1�� $��	5,10,5,10q��� $��Center=�$��15(�$��0,0,0,10q�$
��Bold"�?=Обновление дивидендов из вставки�� $ 
Horizontal=�.+��� -%   $ DividendAddDivTextBox��$��95��$	��200��$��15,5,5,5q� . $��Disabled=�$
��Auto=����� *DividendAddDivTextBox+$ OneWayToSource=�.�� �� .+��� 
Ticker Sum�� ПРИМЕР:�� 
BAC 0.35�� 	MSFT 1.24.���� $ Vertical=�.+��� -&   $# DividendAddYesterdayDivButton��$��25��$	��120��$��8,5,5,5q����� * DividendAddYesterdayDivCommand+{��� *DividendButtonIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�
Вчера$9 3Добавить дивиденды за вчера���� -'   $ DividendAddTodayDivButton��$��25��$	��120��$��8,5,5,5q����� *DividendAddTodayDivCommand+{��� *DividendButtonIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�Сегодня$= 7Добавить дивиденды за сегодня���� -(   $" DividendAddTomorrowDivButton��$��25��$	��120��$��8,5,5,5q����� *DividendAddTomorrowDivCommand+{��� *DividendButtonIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\add.png���� $
��Bold"�Завтра$; 5Добавить дивиденды за завтра���� $��10(�$��Oblique$�$��5,0,0,0q�zxДля пятницы завтра = понедельник, для понедельника вчера = пятница�� $��10(�$��Oblique$�$��5,0,0,0q�Раздел в FAQ 2.4.2�� $��	5,10,5,10q��� $��Center=�$��15(�$��0,0,0,10q�$
��Bold"�Удаление даты�� $ 
Horizontal=�$��Center=�.+��� 
День�� -)   $ DividendDeleteDateDay��$��20��$��23��$��3q����� *DividendDeleteDateDay+$ OneWayToSource=��� 
Месяц�� -*   $ DividendDeleteDateMonth��$��20��$��23��$��3q����� *DividendDeleteDateMonth+$ OneWayToSource=��� Год�� -+   $ DividendDeleteDateYear��$��20��$��40��$��3q����� *DividendDeleteDateYear+$ OneWayToSource=��� -,   $ DividendDeleteDateButton��$��20��$��8,0,0,0q����� *DividendDeleteDateCommand+{��� *DividendButtonIsEnable+$ TwoWay=�.���� $ 
Horizontal=�.+��� $��Image\delete.png���� $
��Bold"�Удалить$> 8Удалить указанный день из базы��